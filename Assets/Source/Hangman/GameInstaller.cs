using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Code.Web;

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

    private GamePanelPresenter _gamePanelPresenter;
    private GameOverPanelPresenter _gameOverPanelPresenter;

    private List<IDisposable> _disposables = new List<IDisposable>();

    private void Awake()
    {
        var hangmanClientService = ServiceLocator.Instance.GetService<HangmanClient>();

        

        var guessLetterUseCase = new GuessLetterUseCase(hangmanClientService);
        var startGameUseCase = new StartGameUseCase(hangmanClientService);

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
        foreach (KeyButtonView keyButton in gamePanel.keyButtons)
        {
            var keyButtonViewModel = new KeyButtonViewModel(keyButton.letter);
            var keyButtonController = new KeyButtonController(keyButtonViewModel, guessLetterUseCase);
            _disposables.Add(keyButtonController);
            var keyButtonPresenter = new KeyButtonPresenter(keyButtonViewModel);
            _disposables.Add(keyButtonPresenter);
            _disposables.Add(keyButtonViewModel);
            keyButton.SetViewModel(keyButtonViewModel);
        }


        gameOverPanelView.SetViewModel(gameOverViewModel);
        pausePanelView.SetViewModel(pauseViewModel);
        addPanelView.SetViewModel(addViewModel);

        _gamePanelPresenter = new GamePanelPresenter(gameViewModel);
        _disposables.Add(_gamePanelPresenter);
        _gamePanelController = new GamePanelController(gameViewModel, gameOverViewModel, pauseViewModel, addViewModel, startGameUseCase);
        _disposables.Add(_gamePanelController);        

        _gameOverPanelController = new GameOverPanelController(gameOverViewModel);
        _disposables.Add(_gameOverPanelController);
        _gameOverPanelPresenter = new GameOverPanelPresenter();
        _disposables.Add(_gameOverPanelPresenter);

        _pausePanelController = new PausePanelController(pauseViewModel);
        _disposables.Add(_pausePanelController);

        _addPanelController = new AddPanelController(addViewModel, gameViewModel);
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
