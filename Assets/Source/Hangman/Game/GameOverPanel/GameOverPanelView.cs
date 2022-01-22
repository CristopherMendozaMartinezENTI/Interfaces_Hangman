using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using TMPro;

public class GameOverPanelView : View
{
    private GameOverPanelViewModel _viewModel;

    [SerializeField] private Button _tryAgainButton;
    [SerializeField] private Button _toMenuButton;
    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private TMP_Text ResultText;
    [SerializeField] private TMP_Text TimeText;

    public override void SetViewModel(ViewModel viewModel)
    {
        _viewModel = viewModel as GameOverPanelViewModel;

        _viewModel
            .IsVisible
            .Subscribe((isVisible) => {
                gameObject.SetActive(isVisible);
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

        _viewModel
         .Score
         .Subscribe((score) => {
             ScoreText.text = score;
         })
         .AddTo(_disposables);

        _viewModel
          .Result
          .Subscribe((result) => {
              ResultText.text = result;
          })
          .AddTo(_disposables);

        _viewModel
       .Time
       .Subscribe((time) => {
           TimeText.text = time;
       })
       .AddTo(_disposables);
    }
}