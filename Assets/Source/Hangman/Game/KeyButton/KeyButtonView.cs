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

    private KeyButtonViewModel _viewModel;
    public override void SetViewModel(ViewModel viewModel)
    {
        _viewModel = viewModel as KeyButtonViewModel;

        _keyButton
          .OnClickAsObservable()
          .Subscribe((_) => {
              _viewModel.KeyButtonPressed.Execute();
          })
          .AddTo(_disposables);
    }
}
