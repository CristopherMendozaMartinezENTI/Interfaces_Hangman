using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UniRx;

public class GamePanelView : View
{
    [SerializeField] private RectTransform _panel;
    public RectTransform Panel { get => _panel; }
    [SerializeField] private Button _pauseButton;
    [SerializeField] private TMP_Text ScoreText;

    private GamePanelViewModel _viewModel;

    public override void SetViewModel(ViewModel viewModel)
    {
        _viewModel = viewModel as GamePanelViewModel;

        _pauseButton
         .OnClickAsObservable()
         .Subscribe((_) => {
             _viewModel.PausePressed.Execute();
         })
         .AddTo(_disposables);

        _viewModel
         .Score
         .Subscribe((score) => {
             ScoreText.text = score;
         })
         .AddTo(_disposables);
    }
}
