using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Installer : MonoBehaviour
{
    [SerializeField] private RectTransform _CanvasParent;

    [SerializeField] private RectTransform _menuPanelsParent;
    [SerializeField] private MenuPanelView _menuPanelPrefab;
    [SerializeField] private HomePanelView _homePanelPrefab;
    [SerializeField] private ScorePanelView _scorePanelPrefab;
    [SerializeField] private SettingsPanelView _settingsPanelPrefab;
    [SerializeField] private EditUsernamePanelView _editUsernamePanelPrefab;

    [SerializeField] private FirebaseLoginService _firebaseService;
    [SerializeField] private FirestoreService _firestoreService;

    private MenuPanelController _menuPanelController;
    private HomePanelController _homePanelController;
    private EditUsernamePanelController _editUsernamePanelController;

    private void Awake()
    {
        var loginUseCase = new FirebaseLogin(_firebaseService);
        var authPersistanceUseCase = new FirebaseAuthPersistance(_firebaseService);
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
        var homePanelViewModel = new HomePanelViewModel();
        var scorePanelViewModel = new ScorePanelViewModel();
        var settingsPanelViewModel = new SettingsPanelViewModel();
        var editUsernamePanelViewModel = new EditUsernamePanelViewModel();

        menuPanel.SetViewModel(menuPanelViewModel);
        homePanelView.SetViewModel(homePanelViewModel);
        scorePanelView.SetViewModel(scorePanelViewModel);
        settingPanelView.SetViewModel(settingsPanelViewModel);
        editUsernamePanelView.SetViewModel(editUsernamePanelViewModel);

        var homePanelPresenter = new HomePanelPresenter(homePanelViewModel);

        _menuPanelController = new MenuPanelController(menuPanelViewModel, homePanelViewModel, scorePanelViewModel, settingsPanelViewModel);
        _homePanelController = new HomePanelController(homePanelViewModel, editUsernamePanelViewModel, loginUseCase, databaseUseCase);
        _editUsernamePanelController = new EditUsernamePanelController(editUsernamePanelViewModel, databaseUseCase);

        //TODO: Set Home as default starting menu
    }

    private void Start() 
    {
        _homePanelController.Initialize();
    }
}
