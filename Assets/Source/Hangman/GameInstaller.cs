using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using System;

public class GameInstaller : MonoBehaviour
{
    [SerializeField] private RectTransform _CanvasParent;
    [SerializeField] private RectTransform _gamePanelsParent;

    [SerializeField] private GamePanelView _gamePanelPrefab;
    [SerializeField] private GameOverPanelView _gameOverPanelPrefab;
    [SerializeField] private PausePanelView _pausePanelPrefab;
    [SerializeField] private AddPanelView _addPanelPrefab;

    private GamePanelController _gamePanelController;
    private GameOverPanelController _gameOverPanelController;
    private PausePanelController _pausePanelController;
    private AddPanelController _addPanelController;

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

        var getUserDataUseCase = new GetUserDataUseCase(firestoreDatabaseService);
        var setUserDataUseCase = new SetUserDataUseCase(firestoreDatabaseService);
        var registerUseCase = new RegisterUseCase(firebaseAuthenticationService, firestoreDatabaseService);
        var toggleNotificationsUseCase = new ToggleNotificationsUseCase();
        var loginUseCase = new LoginUseCase(firebaseAuthenticationService);

        var gameOverPanelView = Instantiate(_gameOverPanelPrefab, _gamePanelsParent);
        var pausePanelView = Instantiate(_pausePanelPrefab, _gamePanelsParent);
        var addPanelView = Instantiate(_addPanelPrefab, _gamePanelsParent);
        var gamePanel = Instantiate(_gamePanelPrefab, _CanvasParent);

        gamePanel.Panel.SetAsFirstSibling();

        var gameViewModel = new GamePanelViewModel();
        _disposables.Add(gameViewModel);

        var gameOverViewModel = new GameOverPanelViewModel();
        _disposables.Add(gameViewModel);

        var pauseViewModel = new PausePanelViewModel();
        _disposables.Add(gameViewModel);

        var addViewModel = new AddPanelViewModel();
        _disposables.Add(gameViewModel);

        gamePanel.SetViewModel(gameViewModel);
        gameOverPanelView.SetViewModel(gameOverViewModel);
        pausePanelView.SetViewModel(pauseViewModel);
        addPanelView.SetViewModel(addViewModel);

        _gamePanelController = new GamePanelController(gameViewModel, gameOverViewModel, pauseViewModel, addViewModel);
        _disposables.Add(_gamePanelController);

        _gameOverPanelController = new GameOverPanelController(gameOverViewModel);
        _disposables.Add(_gameOverPanelController);

        _pausePanelController = new PausePanelController(pauseViewModel);
        _disposables.Add(_pausePanelController);

        _addPanelController = new AddPanelController(addViewModel);
        _disposables.Add(_addPanelController);
    }

    private void Start()
    {
        _gamePanelController.StartGame();
    }

    private void OnDestroy()
    {
        foreach (var disposable in _disposables)
        {
            if (disposable != null)
                disposable.Dispose();
        }
    }
}
