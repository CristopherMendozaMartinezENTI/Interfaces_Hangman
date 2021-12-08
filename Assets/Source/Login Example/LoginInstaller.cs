using System;
using System.Collections.Generic;

using UnityEngine;

public class LoginInstaller : MonoBehaviour
{
    [SerializeField] private MainMenuView _mainMenuView;
    [SerializeField] private ProfileView _profileView;
    [SerializeField] private FirebaseLoginService firebaseService;
    private List<IDisposable> _disposables = new List<IDisposable>();

    private void Awake()
    {
        var mainMenuViewModel = new MainMenuViewModel();
        _mainMenuView.Configure(mainMenuViewModel);
        var profileViewModel = new ProfileViewModel();
        _profileView.Configure(profileViewModel);
        var loginUseCase = new LoginUseCase(firebaseService);
        var mainMenuPresenter = new MainMenuPresenter(mainMenuViewModel);
        _disposables.Add(mainMenuPresenter);
        var mainMenuController = new MainMenuController(mainMenuViewModel, loginUseCase);
        _disposables.Add(mainMenuController);

        new ProfilePresenter(profileViewModel);
    }

    private void OnDestroy()
    {
        foreach (var disposable in _disposables)
        {
            disposable.Dispose();
        }
    }
}
