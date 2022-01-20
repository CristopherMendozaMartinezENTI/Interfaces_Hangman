using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GameOverPanelViewModel : ViewModel
{
    public readonly ReactiveCommand TryAgainPressed;
    public readonly ReactiveCommand ToMenuPressed;
    public readonly ReactiveProperty<string> Score;
    public readonly ReactiveProperty<string> Result;
    public readonly ReactiveProperty<string> Time;
    public readonly ReactiveProperty<bool> IsVisible;

    public GameOverPanelViewModel()
    {
        TryAgainPressed = new ReactiveCommand().AddTo(_disposables);
        ToMenuPressed = new ReactiveCommand().AddTo(_disposables);
        Score = new ReactiveProperty<string>().AddTo(_disposables);
        Result = new ReactiveProperty<string>().AddTo(_disposables);
        Time = new ReactiveProperty<string>().AddTo(_disposables);
        IsVisible = new ReactiveProperty<bool>(false).AddTo(_disposables);
    }
}