using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GamePanelController : Controller
{
    private readonly GamePanelViewModel _gamePanelViewModel;
    private readonly GameOverPanelViewModel _gameOverPanelViewModel;
    private readonly PausePanelViewModel _pausePanelViewModel;
    private readonly AddPanelViewModel _addPanelViewModel;

    public GamePanelController(GamePanelViewModel viewModel, GameOverPanelViewModel gameOverPanelViewModel, PausePanelViewModel pausePanelViewModel, AddPanelViewModel addPanelViewModel)
    {
        _gamePanelViewModel = viewModel;
        _addPanelViewModel = addPanelViewModel;
        _gameOverPanelViewModel = gameOverPanelViewModel;
        _pausePanelViewModel = pausePanelViewModel;

        _gamePanelViewModel
            .PausePressed
            .Subscribe((_) => {
                OnEnterPauseMenu();
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
        //
    }
}


