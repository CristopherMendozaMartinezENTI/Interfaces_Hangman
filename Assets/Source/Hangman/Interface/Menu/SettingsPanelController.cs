using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Extensions;

using UniRx;

public class SettingsPanelController : Controller
{
    private readonly SettingsPanelViewModel _settingsPanelViewModel;
    private readonly RegisterMenuViewModel _registerMenuViewModel;
    private readonly LoginMenuViewModel _loginMenuViewModel;
    private UserDataGetter _userDataGetterUseCase;
    private Authenticator _authenticatorUseCase;
    private ToggleNotifications _toggleNotificationsUseCase;

    public SettingsPanelController(
        SettingsPanelViewModel settingsPanelViewModel, 
        RegisterMenuViewModel registerMenuViewModel, 
        LoginMenuViewModel loginMenuViewModel, 
        Authenticator authenticatorUseCase, 
        ToggleNotifications toggleNotificationsUseCase)
    {
        _settingsPanelViewModel = settingsPanelViewModel;
        _registerMenuViewModel = registerMenuViewModel;
        _loginMenuViewModel = loginMenuViewModel;
        _toggleNotificationsUseCase = toggleNotificationsUseCase;

        _authenticatorUseCase = authenticatorUseCase;

        _settingsPanelViewModel
            .RegisterButtonPressed
            .Subscribe((_) => 
            {
                _registerMenuViewModel.IsVisible.Value = true;
            }).AddTo(_disposables);
        
        _settingsPanelViewModel
            .LoginButtonPressed
            .Subscribe((_) => 
            {
                _loginMenuViewModel.IsVisible.Value = true;
            }).AddTo(_disposables);

        _settingsPanelViewModel
            .NotificationsButtonPressed
            .Subscribe((_) =>
            {
                _settingsPanelViewModel.NotificationsActive.Value = !_settingsPanelViewModel.NotificationsActive.Value;
                _toggleNotificationsUseCase.ToggleNotifications(_settingsPanelViewModel.NotificationsActive.Value);
            }).AddTo(_disposables);
    }
}
