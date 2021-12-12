using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using System;

public class Installer : MonoBehaviour
{
    [SerializeField] private RectTransform _CanvasParent;

    [SerializeField] private RectTransform _menuPanelsParent;
    [SerializeField] private MenuPanelView _menuPanelPrefab;
    [SerializeField] private HomePanelView _homePanelPrefab;
    [SerializeField] private ScorePanelView _scorePanelPrefab;
    [SerializeField] private SettingsPanelView _settingsPanelPrefab;
    [SerializeField] private EditUsernamePanelView _editUsernamePanelPrefab;

    [SerializeField] private ScoreCardPanelView _scoreCardPanelView;

    [SerializeField] private FirebaseLoginService _firebaseService;
    [SerializeField] private FirestoreService _firestoreService;
    [SerializeField] private FirebaseRankingDatabase _firebaseDatabase;

    private MenuPanelController _menuPanelController;
    private HomePanelController _homePanelController;
    private EditUsernamePanelController _editUsernamePanelController;

    private List<IDisposable> _disposables = new List<IDisposable>();

    private void Awake()
    {
        var loginUseCase = new FirebaseLogin(_firebaseService);
        var authPersistanceUseCase = new FirebaseAuthPersistance(_firebaseService);
        _disposables.Add(authPersistanceUseCase);
        var databaseUseCase = new FirestoreDatabase(_firestoreService);
        
        authPersistanceUseCase.SetAuthenticationPersistance();

        var homePanelView = Instantiate(_homePanelPrefab, _menuPanelsParent);
        var scorePanelView = Instantiate(_scorePanelPrefab, _menuPanelsParent);
        var settingPanelView = Instantiate(_settingsPanelPrefab, _menuPanelsParent);
        var menuPanel = Instantiate(_menuPanelPrefab, _CanvasParent);

        var editUsernamePanelView = Instantiate(_editUsernamePanelPrefab, homePanelView.Panel);

        menuPanel.Panel.SetAsFirstSibling();
        homePanelView.Panel.SetAsLastSibling();

        var menuPanelViewModel = new MenuPanelViewModel();
        _disposables.Add(menuPanelViewModel);
        var homePanelViewModel = new HomePanelViewModel();
        _disposables.Add(homePanelViewModel);
        var scorePanelViewModel = new ScorePanelViewModel();
        _disposables.Add(scorePanelViewModel);
        var settingsPanelViewModel = new SettingsPanelViewModel();
        _disposables.Add(settingsPanelViewModel);
        var editUsernamePanelViewModel = new EditUsernamePanelViewModel();
        _disposables.Add(editUsernamePanelViewModel);

        menuPanel.SetViewModel(menuPanelViewModel);
        homePanelView.SetViewModel(homePanelViewModel);
        scorePanelView.SetViewModel(scorePanelViewModel);
        settingPanelView.SetViewModel(settingsPanelViewModel);
        editUsernamePanelView.SetViewModel(editUsernamePanelViewModel);

        var homePanelPresenter = new HomePanelPresenter(homePanelViewModel);
        _disposables.Add(homePanelPresenter);

        for (int i = 0; i < 10; i++)
        {
            //Ranking 
            var scoreCardPanelViewInit = Instantiate(_scoreCardPanelView, scorePanelView.ScrollList);

            var scoreCardPanelViewModel = new ScoreCardPanelViewModel();
            _disposables.Add(scoreCardPanelViewModel);

            scoreCardPanelViewInit.SetViewModel(scoreCardPanelViewModel);

            KeyValuePair<string, ScoreEntry> playerScore = new KeyValuePair<string, ScoreEntry>("Kroozu", new ScoreEntry(i+2, i+1));

            var scoreCardPanelPresenter = new ScoreCardPanelPresenter(scoreCardPanelViewModel, playerScore);
            _disposables.Add(scoreCardPanelPresenter);

            EventDispatcherService.Instance.Dispatch(playerScore);
        }

        _menuPanelController = new MenuPanelController(menuPanelViewModel, homePanelViewModel, scorePanelViewModel, settingsPanelViewModel);
        _disposables.Add(_menuPanelController);
        _homePanelController = new HomePanelController(homePanelViewModel, editUsernamePanelViewModel, loginUseCase, databaseUseCase);
        _disposables.Add(_homePanelController);
        _editUsernamePanelController = new EditUsernamePanelController(editUsernamePanelViewModel, databaseUseCase);
        _disposables.Add(_editUsernamePanelController);

        //TODO: Set Home as default starting menu
    }

    private void Start() 
    {
        _homePanelController.Initialize();
    }

    private void OnDestroy() {
        foreach (var disposable in _disposables)
        {
            if (disposable != null)
                disposable.Dispose();
        }        
    }
}
