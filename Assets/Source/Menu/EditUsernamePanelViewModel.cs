using UniRx;

public class EditUsernamePanelViewModel
{
    public readonly ReactiveCommand SaveButtonPressed;
    public readonly ReactiveCommand BackgroundButtonPressed;

    public readonly ReactiveProperty<bool> IsVisible;

    public EditUsernamePanelViewModel()
    {
        SaveButtonPressed = new ReactiveCommand();
        BackgroundButtonPressed = new ReactiveCommand();

        IsVisible = new ReactiveProperty<bool>();
    }
}
