using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UniRx;

public class GamePanelView : View
{
    [SerializeField] private List<KeyButtonView> _keyButtons = new List<KeyButtonView>();
    public List<KeyButtonView> keyButtons { get { return _keyButtons; }}
    [SerializeField] private RectTransform _panel;
    public RectTransform Panel { get => _panel; }
    [SerializeField] private Button _pauseButton;
    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private TMP_Text GuessedWord;
    [SerializeField] private TMP_Text Tries;

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

        _viewModel
         .Word
         .Subscribe((word) => {
             GuessedWord.text = word;
         })
         .AddTo(_disposables);

        _viewModel
         .Tries.Subscribe((tries) =>
         {
             Tries.text = tries.ToString();
             if (tries == 0)
             {
                 _viewModel.OutOfTries.Execute();
             }   
         }).AddTo(_disposables);

        _viewModel
         .WinConditionAchieved.Subscribe((win) =>
         {
             if (win) _viewModel.WinAchieved.Execute();
         }).AddTo(_disposables);
    }
}
