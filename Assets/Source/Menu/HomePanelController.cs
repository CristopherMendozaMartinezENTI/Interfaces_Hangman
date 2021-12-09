using UniRx;
using UnityEngine;
using Firebase.Extensions;
using System;

public class HomePanelController : IDisposable
{
    private readonly HomePanelViewModel _homePanelViewModel;
    private readonly EditUsernamePanelViewModel _editUsernamePanelViewModel;

    private ILoginRequest _loginUseCase;
    private IDatabase _databaseUseCase;

    public HomePanelController(HomePanelViewModel homePanelViewModel, EditUsernamePanelViewModel editUsernamePanelViewModel, ILoginRequest loginUseCase, IDatabase databaseUseCase)
    {
        _homePanelViewModel = homePanelViewModel;
        _editUsernamePanelViewModel = editUsernamePanelViewModel;

        _loginUseCase = loginUseCase;
        _databaseUseCase = databaseUseCase;

        _homePanelViewModel
            .EditUsernameButtonPressed
            .Subscribe((_) => {
                //TODO: Hacer visible el menu de edit username
                _editUsernamePanelViewModel.IsVisible.Value = true;
            });
    }

    public void Initialize() 
    {
        InitializeUser();
    }

    private async void InitializeUser()
    {
        await _loginUseCase.AnonymousSignIn();
        UserData userdata = new UserData(PlayerPrefs.GetString(Constants.STRING_PLAYERPREFS_USERID), Constants.STRING_DEFAULT_USERNAME);
        await _databaseUseCase.GetUserdata(PlayerPrefs.GetString(Constants.STRING_PLAYERPREFS_USERID)).ContinueWithOnMainThread( Task => 
        {
            userdata = Task.Result;
        });

        EventDispatcherService.Instance.Dispatch<UserData>(userdata);
    }

    public void Dispose() 
    {
        
    }
}
