using UniRx;

public class ProfileViewModel : ViewModel
{
    public readonly ReactiveProperty<string> UserId;

    public ProfileViewModel()
    {
        UserId = new StringReactiveProperty();
    }
}