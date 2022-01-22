using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using TMPro;

public class AddPanelView : View
{
    [SerializeField] private Button _watchAgainButton;
    [SerializeField] private Button _tryAgainButton;
    [SerializeField] private Button _toMenuButton;

    private AddPanelViewModel _viewModel;
    public override void SetViewModel(ViewModel viewModel)
    {
        _viewModel = viewModel as AddPanelViewModel;

        _viewModel
            .IsVisible
            .Subscribe((isVisible) => {
                gameObject.SetActive(isVisible);
            })
            .AddTo(_disposables);

        _watchAgainButton
          .OnClickAsObservable()
          .Subscribe((_) => {
              _viewModel.WatchAdddPressed.Execute();
          })
          .AddTo(_disposables);

        _tryAgainButton
        .OnClickAsObservable()
        .Subscribe((_) => {
            _viewModel.TryAgainPressed.Execute();
        })
        .AddTo(_disposables);

        _toMenuButton
            .OnClickAsObservable()
            .Subscribe((_) => {
                _viewModel.ToMenuPressed.Execute();
            })
            .AddTo(_disposables);

    }
}
