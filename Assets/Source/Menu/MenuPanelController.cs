using UniRx;

public class MenuPanelController : Controller
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
            if (!_homePanelViewModel.IsVisible.Value)
            {
                _homePanelViewModel.IsVisible.Value = true;
                _scorePanelViewModel.IsVisible.Value = false;
                _settingsPanelViewModel.IsVisible.Value = false;
            }
            else
            {
                //Ya estamos en el menu Home
            }
        })
        .AddTo(_disposables);

        _menuPanelViewModel
         .ScoreButtonPressed
         .Subscribe((_) =>
         {
             
             if (!scorePanelViewModel.IsVisible.Value)
             {
                _scorePanelViewModel.IsFromTheLeft.Value = _homePanelViewModel.IsVisible.Value ? false : true;
                
                _homePanelViewModel.IsVisible.Value = false;
                _scorePanelViewModel.IsVisible.Value = true;
                _settingsPanelViewModel.IsVisible.Value = false;
             }
             else
             {
                 //Ya estamos en el menu Score
             }
             
         })
         .AddTo(_disposables);

        _menuPanelViewModel
        .SettingsButtonPressed
        .Subscribe((_) =>
        {
            if (!_settingsPanelViewModel.IsVisible.Value)
            {
                _homePanelViewModel.IsVisible.Value = false;
                _scorePanelViewModel.IsVisible.Value = false;
                _settingsPanelViewModel.IsVisible.Value = true;
            }
            else
            {
                //Ya estamos en el menu Settings
            }            
        })
        .AddTo(_disposables);
    }
}
