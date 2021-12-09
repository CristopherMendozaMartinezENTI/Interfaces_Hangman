using UniRx;
using UnityEngine;

public class EditUsernamePanelController
{
    private readonly EditUsernamePanelViewModel _editUsernamePanelViewModel;

    private readonly IDatabase _databaseUseCase;

    public EditUsernamePanelController(EditUsernamePanelViewModel viewModel, IDatabase databaseUseCase)
    {
        _editUsernamePanelViewModel = viewModel;
        _databaseUseCase = databaseUseCase;

        _editUsernamePanelViewModel
            .SaveButtonPressed
            .Subscribe((username) => {
                OnUsernameEditDone(username);
            });

        _editUsernamePanelViewModel
            .BackgroundButtonPressed
            .Subscribe((_) => {
                OnUsernameEditAborted();
            });

        _editUsernamePanelViewModel
            .InputFieldSubmitted
            .Subscribe((username) => {
                OnUsernameEditDone(username);
            });
    }

    private void OnUsernameEditDone(string username)
    {
        UserData userdata = new UserData(PlayerPrefs.GetString(Constants.STRING_PLAYERPREFS_USERID), username);
        _editUsernamePanelViewModel.IsVisible.Value = false;

        _databaseUseCase.SetUserdata(userdata);
        EventDispatcherService.Instance.Dispatch<UserData>(userdata);
    }

    private void OnUsernameEditAborted() 
    {
        _editUsernamePanelViewModel.IsVisible.Value = false;
    }
}
