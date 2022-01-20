using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class KeyButtonViewModel : ViewModel
{
    public readonly ReactiveCommand KeyButtonPressed;
    public readonly ReactiveProperty<bool> IsVisible;

    public KeyButtonViewModel()
    {
        KeyButtonPressed = new ReactiveCommand().AddTo(_disposables);
        IsVisible = new ReactiveProperty<bool>(false).AddTo(_disposables);
    }
}
