using UniRx;

public class EditUsernamePanelViewModel : ViewModel
{
    public readonly ReactiveCommand<string> SaveButtonPressed;
    public readonly ReactiveCommand<string> InputFieldSubmitted;
    public readonly ReactiveCommand BackgroundButtonPressed;

    public readonly ReactiveProperty<bool> IsVisible;

    public EditUsernamePanelViewModel()
    {
        SaveButtonPressed = new ReactiveCommand<string>().AddTo(_disposables);
        InputFieldSubmitted = new ReactiveCommand<string>().AddTo(_disposables);
        BackgroundButtonPressed = new ReactiveCommand().AddTo(_disposables);

        IsVisible = new ReactiveProperty<bool>(false).AddTo(_disposables);
    }
}
