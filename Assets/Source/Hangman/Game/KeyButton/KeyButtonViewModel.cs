using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class KeyButtonViewModel : ViewModel
{
    private string _letter;
    public string letter { get { return _letter; } }
    public readonly ReactiveCommand<string> KeyButtonPressed;
    public readonly ReactiveProperty<int> IsCorrect;
    public readonly ReactiveProperty<bool> IsUsed;

    public KeyButtonViewModel(string letter)
    {
        KeyButtonPressed = new ReactiveCommand<string>().AddTo(_disposables);
        IsCorrect = new ReactiveProperty<int>(0).AddTo(_disposables);
        IsUsed = new ReactiveProperty<bool>(false).AddTo(_disposables);

        _letter = letter;
    }
}
