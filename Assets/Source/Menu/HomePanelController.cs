using UniRx;

public class HomePanelController
{
    private readonly HomePanelViewModel _homePanelViewModel;
    private readonly EditUsernamePanelViewModel _editUsernamePanelViewModel;

    public HomePanelController(HomePanelViewModel homePanelViewModel, EditUsernamePanelViewModel editUsernamePanelViewModel)
    {
        _homePanelViewModel = homePanelViewModel;
        _editUsernamePanelViewModel = editUsernamePanelViewModel;

        _homePanelViewModel
            .EditUsernameButtonPressed
            .Subscribe((_) => {
                //TODO: Hacer visible el menu de edit username
                _editUsernamePanelViewModel.IsVisible.Value = true;
            });
    }
}
