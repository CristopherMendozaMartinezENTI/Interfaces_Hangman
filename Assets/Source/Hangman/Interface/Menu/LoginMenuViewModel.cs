using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class LoginMenuViewModel : ViewModel
{
    public readonly ReactiveCommand<LoginData> LoginButtonPressed;
    public readonly ReactiveCommand<LoginData> InputFieldSubmitted;
    public readonly ReactiveCommand BackgroundButtonPressed;

    public readonly ReactiveProperty<bool> IsVisible;

    public LoginMenuViewModel()
    {
        LoginButtonPressed = new ReactiveCommand<LoginData>().AddTo(_disposables);
        InputFieldSubmitted = new ReactiveCommand<LoginData>().AddTo(_disposables);
        BackgroundButtonPressed = new ReactiveCommand().AddTo(_disposables);

        IsVisible = new ReactiveProperty<bool>(false).AddTo(_disposables);
    }
}
