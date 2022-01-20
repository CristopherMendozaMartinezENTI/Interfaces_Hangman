using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GameOverPanelController : Controller
{
    private readonly GameOverPanelViewModel _gameOverPanelViewModel;

    public GameOverPanelController(GameOverPanelViewModel viewModel)
    {
        _gameOverPanelViewModel = viewModel;

        _gameOverPanelViewModel
            .TryAgainPressed
            .Subscribe((_) => {
                //
            })
            .AddTo(_disposables);

        _gameOverPanelViewModel
            .ToMenuPressed
            .Subscribe((_) => {
                //
            })
            .AddTo(_disposables);
    }
}
