using UniRx;

public class SettingsPanelViewModel : ViewModel
{
    public readonly ReactiveProperty<bool> IsVisible;

    public SettingsPanelViewModel()
    {
        IsVisible = new ReactiveProperty<bool>();
    }
}
