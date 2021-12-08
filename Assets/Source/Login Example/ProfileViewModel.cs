using UniRx;

public class ProfileViewModel
{
    public readonly ReactiveProperty<string> UserId;

    public ProfileViewModel()
    {
        UserId = new StringReactiveProperty();
    }
}