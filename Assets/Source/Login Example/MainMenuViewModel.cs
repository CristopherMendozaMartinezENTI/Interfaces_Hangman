using UniRx;

public class MainMenuViewModel : ViewModel
{
    public readonly ReactiveCommand LoginButtonPressed;
    public readonly ReactiveProperty<bool> IsVisible;

    public MainMenuViewModel()
    {
        LoginButtonPressed = new ReactiveCommand();
        IsVisible = new BoolReactiveProperty(true);
    }

}
