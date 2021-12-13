using UniRx;

public class ScorePanelViewModel : ViewModel
{
    public readonly ReactiveProperty<bool> IsVisible;
    public readonly ReactiveProperty<bool> IsFromTheLeft;

    public readonly ReactiveCollection<ScoreCardPanelViewModel> ScoreCards;

    public ScorePanelViewModel()
    {
        IsVisible = new ReactiveProperty<bool>();
        IsFromTheLeft = new ReactiveProperty<bool>();

        ScoreCards = new ReactiveCollection<ScoreCardPanelViewModel>();
    }
}
