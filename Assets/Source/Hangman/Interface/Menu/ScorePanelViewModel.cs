using UniRx;

public class ScorePanelViewModel : ViewModel
{
    public readonly ReactiveProperty<bool> IsVisible;
    public readonly ReactiveProperty<bool> IsFromTheLeft;

    public readonly ReactiveCollection<ScoreCardPanelViewModel> ScoreCards;

    public ScorePanelViewModel()
    {
        IsVisible = new ReactiveProperty<bool>().AddTo(_disposables);
        IsFromTheLeft = new ReactiveProperty<bool>().AddTo(_disposables);

        ScoreCards = new ReactiveCollection<ScoreCardPanelViewModel>().AddTo(_disposables);
    }
}
