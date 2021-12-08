using UniRx;

public class HomePanelViewModel
{
    public readonly ReactiveCommand EditUsernameButtonPressed;
    public readonly ReactiveCommand PlayButtonPressed;

    public readonly ReactiveProperty<bool> IsVisible;

    public HomePanelViewModel()
    {
        EditUsernameButtonPressed = new ReactiveCommand();
        PlayButtonPressed = new ReactiveCommand();

        IsVisible = new ReactiveProperty<bool>();
    }
}
