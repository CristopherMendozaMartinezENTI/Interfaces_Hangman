using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
using Firebase.Extensions;

public class LoginMenuController : Controller
{
    private readonly LoginMenuViewModel _loginMenuViewModel;
    UserLogin _loginUseCase;
    UserDataGetter _getUserDataUseCase;

    public LoginMenuController(LoginMenuViewModel viewModel, UserLogin loginUseCase, UserDataGetter getUserDataUseCase)
    {
        _loginMenuViewModel = viewModel;
        _loginUseCase = loginUseCase;
        _getUserDataUseCase = getUserDataUseCase;

        _loginMenuViewModel
            .LoginButtonPressed
            .Subscribe((loginData) => {
                OnLoginInputDone(loginData);
            })
            .AddTo(_disposables);

        _loginMenuViewModel
            .BackgroundButtonPressed
            .Subscribe((_) => {
                OnLoginInputAborted();
            })
            .AddTo(_disposables);

        _loginMenuViewModel
            .InputFieldSubmitted
            .Subscribe((loginData) => {
                OnLoginInputDone(loginData);
            })
            .AddTo(_disposables);
    }

    private void OnLoginInputDone(LoginData loginData)
    {
        _loginUseCase.Login(loginData);
        _getUserDataUseCase.GetUserdata(PlayerPrefs.GetString(Constants.STRING_PLAYERPREFS_USERID)).ContinueWithOnMainThread(task => {
            UserData userData = task.Result;
            ServiceLocator.Instance.GetService<IEventDispatcherService>().Dispatch(userData);
        });
        _loginMenuViewModel.IsVisible.Value = false;
    }

    private void OnLoginInputAborted()
    {
        _loginMenuViewModel.IsVisible.Value = false;
    }
}
