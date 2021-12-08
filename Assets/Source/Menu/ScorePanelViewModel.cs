using UniRx;

public class ScorePanelViewModel 
{
    public readonly ReactiveProperty<bool> IsVisible;
    public readonly ReactiveProperty<bool> IsFromTheLeft;

    public ScorePanelViewModel()
    {
        IsVisible = new ReactiveProperty<bool>();
        IsFromTheLeft = new ReactiveProperty<bool>();
    }
}
