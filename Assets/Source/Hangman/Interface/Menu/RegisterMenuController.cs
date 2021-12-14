using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class RegisterMenuController : Controller
{
    private readonly RegisterMenuViewModel _registerMenuViewModel;
    UserRegister _registerUseCase;

    public RegisterMenuController(RegisterMenuViewModel viewModel, UserRegister registerUseCase)
    {
        _registerMenuViewModel = viewModel;
        _registerUseCase = registerUseCase;

        _registerMenuViewModel
            .RegisterButtonPressed
            .Subscribe((loginData) => {
                OnRegisterInputDone(loginData);
            })
            .AddTo(_disposables);

        _registerMenuViewModel
            .BackgroundButtonPressed
            .Subscribe((_) => {
                OnLoginInputAborted();
            })
            .AddTo(_disposables);

        _registerMenuViewModel
            .InputFieldSubmitted
            .Subscribe((loginData) => {
                OnRegisterInputDone(loginData);
            })
            .AddTo(_disposables);
    }

    private void OnRegisterInputDone(LoginData loginData)
    {
        _registerUseCase.RegisterNewUser(loginData);
        _registerMenuViewModel.IsVisible.Value = false;
    }

    private void OnLoginInputAborted()
    {
        _registerMenuViewModel.IsVisible.Value = false;
    }
}
