using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GamePanelViewModel : ViewModel
{
    public readonly ReactiveCommand PausePressed;
    public readonly ReactiveProperty<string> Score;

    public GamePanelViewModel()
    {
        PausePressed = new ReactiveCommand().AddTo(_disposables);
        Score = new ReactiveProperty<string>().AddTo(_disposables);
    }
}
