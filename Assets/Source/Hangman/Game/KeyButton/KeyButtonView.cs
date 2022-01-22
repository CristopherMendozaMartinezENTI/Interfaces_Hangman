using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using TMPro;

public class KeyButtonView : View
{
    [SerializeField] private Button _keyButton;
    [SerializeField] private Text _keyText;
    public string letter { get { return _keyText.text; } }

    [SerializeField] private RectTransform correctPanel;
    [SerializeField] private RectTransform incorrectPanel;

    private KeyButtonViewModel _viewModel;
    private bool isUsed = false;

    public override void SetViewModel(ViewModel viewModel)
    {
        _viewModel = viewModel as KeyButtonViewModel;

        _viewModel
            .IsUsed
            .Subscribe((_) => { 
                isUsed = _viewModel.IsUsed.Value;
                if (isUsed)
                {
                    _keyButton.interactable = false;
                }
                else
                {
                    correctPanel.gameObject.SetActive(false);
                    incorrectPanel.gameObject.SetActive(false);
                }
            });
        
        _viewModel
            .IsCorrect
            .Subscribe((_) => {
                if (isUsed)
                {
                    if (_viewModel.IsCorrect.Value == 1)
                    {
                        correctPanel.gameObject.SetActive(true);
                    }
                    else if (_viewModel.IsCorrect.Value == -1)
                    {
                        incorrectPanel.gameObject.SetActive(true);
                    }
                }
            });

        _keyButton
          .OnClickAsObservable()
          .Subscribe((_) => {
              _viewModel.KeyButtonPressed.Execute(_keyText.text);
          })
          .AddTo(_disposables);
    }
}
