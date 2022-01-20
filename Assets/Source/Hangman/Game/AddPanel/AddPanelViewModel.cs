using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class AddPanelViewModel : ViewModel
{
    public readonly ReactiveCommand WatchAdddPressed;
    public readonly ReactiveCommand TryAgainPressed;
    public readonly ReactiveCommand ToMenuPressed;
    public readonly ReactiveProperty<bool> IsVisible;

    public AddPanelViewModel()
    {
        WatchAdddPressed = new ReactiveCommand().AddTo(_disposables);
        TryAgainPressed = new ReactiveCommand().AddTo(_disposables);
        ToMenuPressed = new ReactiveCommand().AddTo(_disposables);
        IsVisible = new ReactiveProperty<bool>(false).AddTo(_disposables);
    }
}
