using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UniRx;

public class ScoreCardPanelView : View
{
    [SerializeField] private TMP_Text userNameText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text playTimeText;
    [SerializeField] private TMP_Text orderNumberText;

    private ScoreCardPanelViewModel _viewModel;

    public override void SetViewModel(ViewModel viewModel)
    {
        _viewModel = viewModel as ScoreCardPanelViewModel;

        _viewModel
          .UserName
          .Subscribe((username) => {
              userNameText.text = username;
          })
          .AddTo(_disposables);

        _viewModel
          .Score
          .Subscribe((score) => {
              scoreText.text = score;
          })
          .AddTo(_disposables);

        _viewModel
          .OrderNumber
          .Subscribe((orderNumber) => {
              orderNumberText.text = orderNumber;
          })
          .AddTo(_disposables);

        _viewModel
          .PlayTime
          .Subscribe((playtime) => {
              playTimeText.text = playtime;
          })
          .AddTo(_disposables);
    }
}
