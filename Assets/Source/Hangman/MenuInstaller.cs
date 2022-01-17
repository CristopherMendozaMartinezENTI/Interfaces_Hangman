using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using System;

public class MenuInstaller : MonoBehaviour
{
    [SerializeField] private RectTransform _CanvasParent;

    [SerializeField] private RectTransform _menuPanelsParent;
    [SerializeField] private MenuPanelView _menuPanelPrefab;
    [SerializeField] private HomePanelView _homePanelPrefab;
    [SerializeField] private ScorePanelView _scorePanelPrefab;
    [SerializeField] private SettingsPanelView _settingsPanelPrefab;
    [SerializeField] private EditUsernamePanelView _editUsernamePanelPrefab;
    [SerializeField] private LoginMenuView _loginMenuPrefab;
    [SerializeField] private RegisterMenuView _registerMenuPrefab;

    [SerializeField] private ScoreCardPanelView _scoreCardPanelView;

    private MenuPanelController _menuPanelController;
    private HomePanelController _homePanelController;
    private SettingsPanelController _settingsPanelController;
    private EditUsernamePanelController _editUsernamePanelController;
    private LoginMenuController _loginMenuController;
    private RegisterMenuController _registerMenuController;

    private List<IDisposable> _disposables = new List<IDisposable>();

    private void Awake()
    {
        var firebaseAuthenticationService = new FirebaseAuthenticationService();
        var firestoreDatabaseService = new FirestoreService();
        var eventDispatcherService = new EventDispatcherService();
        var realtimeFirebaseService = new RealtimeFirebaseService();

        ServiceLocator.Instance.RegisterService<AuthenticationService>(firebaseAuthenticationService);
        ServiceLocator.Instance.RegisterService<DatabaseService>(firestoreDatabaseService);
        ServiceLocator.Instance.RegisterService<IEventDispatcherService>(eventDispatcherService);

        var authenticatorUseCase = new AuthenticateUseCase(firebaseAuthenticationService, eventDispatcherService);

       // _firestoreService.InitializeDatabase();
        var getUserDataUseCase = new GetUserDataUseCase(firestoreDatabaseService);
        var setUserDataUseCase = new SetUserDataUseCase(firestoreDatabaseService);
        var registerUseCase = new RegisterUseCase(firebaseAuthenticationService, firestoreDatabaseService);
        var toggleNotificationsUseCase = new ToggleNotificationsUseCase();
        var loginUseCase = new LoginUseCase(firebaseAuthenticationService);

        var homePanelView = Instantiate(_homePanelPrefab, _menuPanelsParent);
        var scorePanelView = Instantiate(_scorePanelPrefab, _menuPanelsParent);
        var settingsPanelView = Instantiate(_settingsPanelPrefab, _menuPanelsParent);
        var menuPanel = Instantiate(_menuPanelPrefab, _CanvasParent);

        var editUsernamePanelView = Instantiate(_editUsernamePanelPrefab, homePanelView.Panel);
        var loginMenuView = Instantiate(_loginMenuPrefab, settingsPanelView.Panel);
        var registerMenuView = Instantiate(_registerMenuPrefab, settingsPanelView.Panel);

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
        var loginMenuViewModel = new LoginMenuViewModel();
        _disposables.Add(loginMenuViewModel);
        var registerMenuViewModel = new RegisterMenuViewModel();
        _disposables.Add(registerMenuViewModel);

        menuPanel.SetViewModel(menuPanelViewModel);
        homePanelView.SetViewModel(homePanelViewModel);
        scorePanelView.SetViewModel(scorePanelViewModel);
        settingsPanelView.SetViewModel(settingsPanelViewModel);
        editUsernamePanelView.SetViewModel(editUsernamePanelViewModel);
        loginMenuView.SetViewModel(loginMenuViewModel);
        registerMenuView.SetViewModel(registerMenuViewModel);

        var homePanelPresenter = new HomePanelPresenter(homePanelViewModel);
        _disposables.Add(homePanelPresenter);
        var scorePanelPresenter = new ScorePanelPresenter(scorePanelViewModel);
        _disposables.Add(scorePanelPresenter);


        var getScoresUseCase = new GetScoresUseCase(realtimeFirebaseService, eventDispatcherService);
        getScoresUseCase.GetScores();

        _menuPanelController = new MenuPanelController(menuPanelViewModel, homePanelViewModel, scorePanelViewModel, settingsPanelViewModel);
        _disposables.Add(_menuPanelController);
        _homePanelController = new HomePanelController(homePanelViewModel, editUsernamePanelViewModel, authenticatorUseCase, getUserDataUseCase);
        _disposables.Add(_homePanelController);
        _settingsPanelController = new SettingsPanelController(settingsPanelViewModel, registerMenuViewModel, loginMenuViewModel, authenticatorUseCase, toggleNotificationsUseCase);
        _disposables.Add(_settingsPanelController);
        _editUsernamePanelController = new EditUsernamePanelController(editUsernamePanelViewModel, setUserDataUseCase);
        _disposables.Add(_editUsernamePanelController);
        _loginMenuController = new LoginMenuController(loginMenuViewModel, loginUseCase, getUserDataUseCase);
        _disposables.Add(_loginMenuController);
        _registerMenuController = new RegisterMenuController(registerMenuViewModel, registerUseCase);
        _disposables.Add(_registerMenuController);

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
