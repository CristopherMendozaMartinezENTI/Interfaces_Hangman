using UniRx;
using System;
using System.Collections.Generic;

public class MainMenuController : Controller
{
    private readonly MainMenuViewModel _model;
    private readonly LoginRequest _loginRequester;

    public MainMenuController(MainMenuViewModel model, LoginRequest loginRequester)
    {
        _model = model;
        _loginRequester = loginRequester;

        _model.LoginButtonPressed.Subscribe(OnLoginButtonPressed)
        .AddTo(_disposables);
    }

    private void OnLoginButtonPressed(Unit _)
    {
        _loginRequester.Login();
    }
}
