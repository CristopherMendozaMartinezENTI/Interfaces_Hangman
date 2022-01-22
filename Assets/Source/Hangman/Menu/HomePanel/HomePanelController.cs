using UniRx;
using UnityEngine;
using Firebase.Extensions;
using System;

public class HomePanelController : Controller
{
    private readonly HomePanelViewModel _homePanelViewModel;
    private readonly EditUsernamePanelViewModel _editUsernamePanelViewModel;
    private UserDataGetter _userDataGetterUseCase;
    private Authenticator _authenticatorUseCase;

    public HomePanelController(HomePanelViewModel homePanelViewModel, EditUsernamePanelViewModel editUsernamePanelViewModel, Authenticator authenticatorUseCase, UserDataGetter getUserDataUseCase)
    {
        _homePanelViewModel = homePanelViewModel;
        _editUsernamePanelViewModel = editUsernamePanelViewModel;

        _authenticatorUseCase = authenticatorUseCase;
        _userDataGetterUseCase = getUserDataUseCase;

        _homePanelViewModel
            .EditUsernameButtonPressed
            .Subscribe((_) => {
                _editUsernamePanelViewModel.IsVisible.Value = true;
            });

        _homePanelViewModel
            .PlayButtonPressed
            .Subscribe((_) => {
                OnPlayButtonPressed();
            });
    }

    public void Initialize() 
    {
        InitializeUser();
    }

    private async void InitializeUser()
    {
        await _authenticatorUseCase.Authenticate();
        UserData userdata = new UserData(PlayerPrefs.GetString(Constants.STRING_PLAYERPREFS_USERID), Constants.STRING_DEFAULT_USERNAME);
        await _userDataGetterUseCase.GetUserdata(PlayerPrefs.GetString(Constants.STRING_PLAYERPREFS_USERID)).ContinueWithOnMainThread( Task => 
        {
            userdata = Task.Result;
        });

        ServiceLocator.Instance.GetService<IEventDispatcherService>().Dispatch<UserData>(userdata);
    }

    private void OnPlayButtonPressed()
    {
        ServiceLocator.Instance.GetService<SceneHandlerService>().LoadScene("Game");
    }
}
