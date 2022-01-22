using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GamePanelViewModel : ViewModel
{
    public readonly ReactiveCommand PausePressed;
    public readonly ReactiveCommand OutOfTries;
    public readonly ReactiveCommand WinAchieved;
    public readonly ReactiveProperty<string> Score;
    public readonly ReactiveProperty<string> Word;
    public readonly ReactiveProperty<int> Tries;
    public readonly ReactiveProperty<bool> WinConditionAchieved;

    public GamePanelViewModel()
    {
        PausePressed = new ReactiveCommand().AddTo(_disposables);
        OutOfTries = new ReactiveCommand().AddTo(_disposables);
        WinAchieved = new ReactiveCommand().AddTo(_disposables);
        Score = new ReactiveProperty<string>().AddTo(_disposables);
        Word = new ReactiveProperty<string>().AddTo(_disposables);
        Tries = new ReactiveProperty<int>().AddTo(_disposables);
        WinConditionAchieved = new ReactiveProperty<bool>(false).AddTo(_disposables);
    }
}
