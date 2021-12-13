using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;
using System.Collections.Generic;
using System.Linq;

public class MenuPanelView : View
{
    [SerializeField] private RectTransform _panel;
    public RectTransform Panel { get => _panel; }
    [SerializeField] private RectTransform _homeContainer;
    [SerializeField] private RectTransform _scoreContainer;
    [SerializeField] private RectTransform _settingsContainer;

    [SerializeField] private Button _homeButton;
    [SerializeField] private Button _scoreButton;
    [SerializeField] private Button _settingsButton;

    private MenuPanelViewModel _viewModel;

    public override void SetViewModel(ViewModel viewModel)
    {
        _viewModel = viewModel as MenuPanelViewModel;

        _homeButton
            .OnClickAsObservable()
            .Subscribe((_) => {
                _viewModel.HomeButtonPressed.Execute();
            })
            .AddTo(_disposables);

        _scoreButton
            .OnClickAsObservable()
            .Subscribe((_) => {
                _viewModel.ScoreButtonPressed.Execute();
            })
            .AddTo(_disposables);

        _settingsButton
            .OnClickAsObservable()
            .Subscribe((_) => {
                _viewModel.SettingsButtonPressed.Execute();
            })
            .AddTo(_disposables);
    }
}
