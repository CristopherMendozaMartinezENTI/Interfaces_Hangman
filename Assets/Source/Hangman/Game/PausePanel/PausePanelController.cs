using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PausePanelController : Controller
{
    private readonly PausePanelViewModel _pausePanelViewModel;

    public PausePanelController(PausePanelViewModel viewModel)
    {
        _pausePanelViewModel = viewModel;

        _pausePanelViewModel
            .ResumePressed
            .Subscribe((_) => {
                //
            })
            .AddTo(_disposables);

        _pausePanelViewModel
            .ResetPressed
            .Subscribe((_) => {
                //
            })
            .AddTo(_disposables);

         _pausePanelViewModel
            .ToMenuPressed
            .Subscribe((_) => {
                //
            })
            .AddTo(_disposables);

        _pausePanelViewModel
            .BackgroundButtonPressed
            .Subscribe((_) => {
                OnExitPauseMenu();
            })
            .AddTo(_disposables);

    }

    private void OnExitPauseMenu()
    {
        Time.timeScale = 1;
        _pausePanelViewModel.IsVisible.Value = false;
    }
}
