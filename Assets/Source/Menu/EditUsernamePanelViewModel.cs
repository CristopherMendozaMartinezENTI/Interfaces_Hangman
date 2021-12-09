using UniRx;

public class EditUsernamePanelViewModel
{
    public readonly ReactiveCommand<string> SaveButtonPressed;
    public readonly ReactiveCommand<string> InputFieldSubmitted;
    public readonly ReactiveCommand BackgroundButtonPressed;

    public readonly ReactiveProperty<bool> IsVisible;

    public EditUsernamePanelViewModel()
    {
        SaveButtonPressed = new ReactiveCommand<string>();
        InputFieldSubmitted = new ReactiveCommand<string>();
        BackgroundButtonPressed = new ReactiveCommand();

        IsVisible = new ReactiveProperty<bool>();
    }
}
