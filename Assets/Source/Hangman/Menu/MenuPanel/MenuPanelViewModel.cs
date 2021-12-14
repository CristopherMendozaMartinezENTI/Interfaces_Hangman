using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;
using System.Collections.Generic;
using System.Linq;

public class MenuPanelViewModel : ViewModel
{
    public readonly ReactiveCommand HomeButtonPressed;
    public readonly ReactiveCommand ScoreButtonPressed;
    public readonly ReactiveCommand SettingsButtonPressed;

    public MenuPanelViewModel()
    {
        HomeButtonPressed = new ReactiveCommand().AddTo(_disposables);
        ScoreButtonPressed = new ReactiveCommand().AddTo(_disposables);
        SettingsButtonPressed = new ReactiveCommand().AddTo(_disposables);
    }
}
