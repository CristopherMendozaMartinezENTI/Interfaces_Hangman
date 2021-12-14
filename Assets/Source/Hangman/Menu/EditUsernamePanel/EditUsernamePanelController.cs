using UniRx;
using UnityEngine;

public class EditUsernamePanelController : Controller
{
    private readonly EditUsernamePanelViewModel _editUsernamePanelViewModel;

    private readonly UserDataSetter _setUserDataUseCase;

    public EditUsernamePanelController(EditUsernamePanelViewModel viewModel, UserDataSetter setUserDataUseCase)
    {
        _editUsernamePanelViewModel = viewModel;
        _setUserDataUseCase = setUserDataUseCase;

        _editUsernamePanelViewModel
            .SaveButtonPressed
            .Subscribe((username) => {
                OnUsernameEditDone(username);
            })
            .AddTo(_disposables);

        _editUsernamePanelViewModel
            .BackgroundButtonPressed
            .Subscribe((_) => {
                OnUsernameEditAborted();
            })
            .AddTo(_disposables);

        _editUsernamePanelViewModel
            .InputFieldSubmitted
            .Subscribe((username) => {
                OnUsernameEditDone(username);
            })
            .AddTo(_disposables);
    }

    private void OnUsernameEditDone(string username)
    {
        UserData userdata = new UserData(PlayerPrefs.GetString(Constants.STRING_PLAYERPREFS_USERID), username);
        _editUsernamePanelViewModel.IsVisible.Value = false;

        _setUserDataUseCase.SetUserdata(userdata);
        ServiceLocator.Instance.GetService<IEventDispatcherService>().Dispatch<UserData>(userdata);
    }

    private void OnUsernameEditAborted() 
    {
        _editUsernamePanelViewModel.IsVisible.Value = false;
    }
}
