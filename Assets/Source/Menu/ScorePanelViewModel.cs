using UniRx;

public class ScorePanelViewModel : ViewModel
{
    public readonly ReactiveProperty<bool> IsVisible;
    public readonly ReactiveProperty<bool> IsFromTheLeft;

    public ScorePanelViewModel()
    {
        IsVisible = new ReactiveProperty<bool>();
        IsFromTheLeft = new ReactiveProperty<bool>();
    }
}
