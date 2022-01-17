using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GameOverPanelViewModel : ViewModel
{
    public readonly ReactiveCommand PlayAgainPressed;
    public readonly ReactiveCommand ToMenuPressed;
    public readonly ReactiveProperty<string> Score;
    public readonly ReactiveProperty<string> Result;

    public GameOverPanelViewModel()
    {
        PlayAgainPressed = new ReactiveCommand().AddTo(_disposables);
        ToMenuPressed = new ReactiveCommand().AddTo(_disposables);
        Score = new ReactiveProperty<string>().AddTo(_disposables);
        Result = new ReactiveProperty<string>().AddTo(_disposables);
    }
}