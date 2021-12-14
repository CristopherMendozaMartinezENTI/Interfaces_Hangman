using UniRx;

public class HomePanelViewModel : ViewModel
{
    public readonly ReactiveCommand EditUsernameButtonPressed;
    public readonly ReactiveCommand PlayButtonPressed;

    public readonly ReactiveProperty<bool> IsVisible;
    public readonly ReactiveProperty<string> Username;

    public HomePanelViewModel()
    {
        EditUsernameButtonPressed = new ReactiveCommand().AddTo(_disposables);
        PlayButtonPressed = new ReactiveCommand().AddTo(_disposables);

        IsVisible = new ReactiveProperty<bool>().AddTo(_disposables);
        Username = new ReactiveProperty<string>().AddTo(_disposables);
    }
}
