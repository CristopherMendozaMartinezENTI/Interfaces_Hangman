using UniRx;

public class MenuPanelController 
{
    private readonly MenuPanelViewModel _menuPanelViewModel;
    private readonly HomePanelViewModel _homePanelViewModel;
    private readonly ScorePanelViewModel _scorePanelViewModel;
    private readonly SettingsPanelViewModel _settingsPanelViewModel;

    public MenuPanelController(MenuPanelViewModel viewModel, HomePanelViewModel homePanelViewModel, 
        ScorePanelViewModel scorePanelViewModel , SettingsPanelViewModel settingsPanelViewModel)
    {
        _menuPanelViewModel = viewModel;
        _homePanelViewModel = homePanelViewModel;
        _scorePanelViewModel = scorePanelViewModel;
        _settingsPanelViewModel = settingsPanelViewModel;

        _menuPanelViewModel
        .HomeButtonPressed
        .Subscribe((_) =>
        {
            _homePanelViewModel.IsVisible.Value = true;
            _scorePanelViewModel.IsVisible.Value = false;
            _settingsPanelViewModel.IsVisible.Value = false;
        });

        _menuPanelViewModel
         .ScoreButtonPressed
         .Subscribe((_) =>
         {
             _homePanelViewModel.IsVisible.Value = false;
             _scorePanelViewModel.IsVisible.Value = true;
             _settingsPanelViewModel.IsVisible.Value = false;
         });

        _menuPanelViewModel
        .SettingsButtonPressed
        .Subscribe((_) =>
        {
            _homePanelViewModel.IsVisible.Value = false;
            _scorePanelViewModel.IsVisible.Value = false;
            _settingsPanelViewModel.IsVisible.Value = true;
        });
    }
}
