using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Code.Web.HangmanApi.Response;

public class GamePanelController : Controller
{
    private readonly GamePanelViewModel _gamePanelViewModel;
    private readonly GameOverPanelViewModel _gameOverPanelViewModel;
    private readonly PausePanelViewModel _pausePanelViewModel;
    private readonly AddPanelViewModel _addPanelViewModel;
    private readonly StartGame _startGameUseCase;

    bool addShown = false;

    public GamePanelController(GamePanelViewModel viewModel, GameOverPanelViewModel gameOverPanelViewModel, PausePanelViewModel pausePanelViewModel, AddPanelViewModel addPanelViewModel, StartGame startGameUseCase)
    {
        _gamePanelViewModel = viewModel;
        _addPanelViewModel = addPanelViewModel;
        _gameOverPanelViewModel = gameOverPanelViewModel;
        _pausePanelViewModel = pausePanelViewModel;
        _startGameUseCase = startGameUseCase;

        _gamePanelViewModel
            .PausePressed
            .Subscribe((_) => {
                OnEnterPauseMenu();
            })
            .AddTo(_disposables);

        _gamePanelViewModel
            .OutOfTries
            .Subscribe((_) => {
                OnOutOfTries();
            })
            .AddTo(_disposables);

        _gamePanelViewModel
            .WinAchieved
            .Subscribe((_) => {
                OnWinAchieved();
            })
            .AddTo(_disposables);
    }

    private void OnEnterPauseMenu()
    {
        Time.timeScale = 0;
        _pausePanelViewModel.IsVisible.Value = true;
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt(Constants.STRING_TRIES, Constants.INT_MAXTRIES);
        _gamePanelViewModel.Tries.Value = Constants.INT_MAXTRIES;
        _startGameUseCase.Start();
    }

    private void OnOutOfTries()
    {
        if (!addShown)
        {
            _addPanelViewModel.IsVisible.Value = true;
        }
        else
        {
            _gameOverPanelViewModel.Result.Value = "You Lose";
            _gameOverPanelViewModel.IsVisible.Value = true;
        }
    }

    private void OnWinAchieved()
    {
        _gameOverPanelViewModel.Result.Value = "You Win!";
        _gameOverPanelViewModel.IsVisible.Value = true;
    }
}


