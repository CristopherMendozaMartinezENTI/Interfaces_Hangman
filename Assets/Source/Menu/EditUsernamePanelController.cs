using UniRx;

public class EditUsernamePanelController
{
    private readonly EditUsernamePanelViewModel _editUsernamePanelViewModel;

    public EditUsernamePanelController(EditUsernamePanelViewModel viewModel)
    {
        _editUsernamePanelViewModel = viewModel;

        _editUsernamePanelViewModel
            .SaveButtonPressed
            .Subscribe((_) => {
                //TODO: save username in firestore, dispatch new username, hide edit username menu
                _editUsernamePanelViewModel.IsVisible.Value = false;
            });

        _editUsernamePanelViewModel
            .BackgroundButtonPressed
            .Subscribe((_) => {
                _editUsernamePanelViewModel.IsVisible.Value = false;
            });
    }
}
