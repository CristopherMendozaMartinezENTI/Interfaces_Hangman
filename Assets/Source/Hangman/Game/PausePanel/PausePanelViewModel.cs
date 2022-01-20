using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PausePanelViewModel : ViewModel
{
    public readonly ReactiveCommand ResumePressed;
    public readonly ReactiveCommand ResetPressed;
    public readonly ReactiveCommand ToMenuPressed;
    public readonly ReactiveCommand BackgroundButtonPressed;
    public readonly ReactiveProperty<bool> IsVisible;

    public PausePanelViewModel()
    {
        ResumePressed = new ReactiveCommand().AddTo(_disposables);
        ResetPressed = new ReactiveCommand().AddTo(_disposables);
        ToMenuPressed = new ReactiveCommand().AddTo(_disposables);
        BackgroundButtonPressed = new ReactiveCommand().AddTo(_disposables);
        IsVisible = new ReactiveProperty<bool>(false).AddTo(_disposables);
    }
}
