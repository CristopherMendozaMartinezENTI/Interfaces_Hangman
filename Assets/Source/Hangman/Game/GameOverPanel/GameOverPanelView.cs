using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using TMPro;

public class GameOverPanelView : View
{
    private GameOverPanelViewModel _viewModel;

    [SerializeField] private Button _playAgainButton;
    [SerializeField] private Button _toMenuButton;
    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private TMP_Text ResultText;

    public override void SetViewModel(ViewModel viewModel)
    {
        _viewModel = viewModel as GameOverPanelViewModel;

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

        _playAgainButton
           .OnClickAsObservable()
           .Subscribe((_) => {
               //
           })
           .AddTo(_disposables);

        _playAgainButton
            .OnClickAsObservable()
            .Subscribe((_) => {
                //
            })
            .AddTo(_disposables);
    }
}