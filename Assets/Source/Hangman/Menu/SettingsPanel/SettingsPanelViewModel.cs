using UniRx;

public class SettingsPanelViewModel : ViewModel
{
    public readonly ReactiveCommand LoginButtonPressed;
    public readonly ReactiveCommand RegisterButtonPressed;
    public readonly ReactiveCommand NotificationsButtonPressed;
    public readonly ReactiveProperty<bool> IsVisible;
    public readonly ReactiveProperty<bool> NotificationsActive;

    public SettingsPanelViewModel()
    {
        LoginButtonPressed = new ReactiveCommand().AddTo(_disposables);
        RegisterButtonPressed = new ReactiveCommand().AddTo(_disposables);
        NotificationsButtonPressed = new ReactiveCommand().AddTo(_disposables);
        IsVisible = new ReactiveProperty<bool>().AddTo(_disposables);
        NotificationsActive = new ReactiveProperty<bool>().AddTo(_disposables);
    }
}
