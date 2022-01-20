using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class PausePanelView : View
{
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _resetButton;
    [SerializeField] private Button _toMenuButton;
    [SerializeField] private Button _backgroundButton;

    private PausePanelViewModel _viewModel;

    public override void SetViewModel(ViewModel viewModel)
    {
        _viewModel = viewModel as PausePanelViewModel;

        _resumeButton
          .OnClickAsObservable()
          .Subscribe((_) => {
              _viewModel.ResumePressed.Execute();
          })
          .AddTo(_disposables);

        _resetButton
        .OnClickAsObservable()
        .Subscribe((_) => {
            _viewModel.ToMenuPressed.Execute();
        })
        .AddTo(_disposables);

        _toMenuButton
        .OnClickAsObservable()
        .Subscribe((_) => {
            _viewModel.ToMenuPressed.Execute();
        })
        .AddTo(_disposables);

        _backgroundButton
        .OnClickAsObservable()
        .Subscribe((_) => {
            _viewModel.BackgroundButtonPressed.Execute();
        })
        .AddTo(_disposables);
    }
}
