using UniRx;
using UnityEngine;

public class EditUsernamePanelController : Controller
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

        _databaseUseCase.SetUserdata(userdata);
        EventDispatcherService.Instance.Dispatch<UserData>(userdata);
    }

    private void OnUsernameEditAborted() 
    {
        _editUsernamePanelViewModel.IsVisible.Value = false;
    }
}
