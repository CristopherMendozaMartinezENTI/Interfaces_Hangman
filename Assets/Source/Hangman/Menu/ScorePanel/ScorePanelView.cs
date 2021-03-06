using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;

public class ScorePanelView : View
{
    [SerializeField] private RectTransform _panel;
    public RectTransform Panel { get => _panel; }

    [SerializeField] private DoTweenPanelSwipeController _swipeController;
    private DoTweenPanelSwipeController.StartingSide _startingSide;

    [SerializeField] private RectTransform scrollListParent;
    [SerializeField] private ScoreCardPanelView _scoreCardPrefab;

    private List<ScoreCardPanelView> scoreCardInstances;
    public RectTransform ScrollList { get => scrollListParent; }

    private ScorePanelViewModel _viewModel;

    public override void SetViewModel(ViewModel viewModel)
    {
        _viewModel = viewModel as ScorePanelViewModel;
        scoreCardInstances = new List<ScoreCardPanelView>();

        _viewModel
            .IsFromTheLeft
            .Subscribe((isFromTheLeft) =>
            {
                _startingSide = isFromTheLeft ? DoTweenPanelSwipeController.StartingSide.LEFT : DoTweenPanelSwipeController.StartingSide.RIGHT;
            })
            .AddTo(_disposables);

        _viewModel
            .IsVisible
            .Subscribe((isVisible) =>
            {
                if (isVisible)
                {
                    _panel.SetAsLastSibling();
                    _swipeController.Animate(_startingSide);
                }
            })
            .AddTo(_disposables);

        _viewModel
            .ScoreCards
            .ObserveAdd()
            .Subscribe(InstantiateScoreCard)
            .AddTo(_disposables);
    }

    private void InstantiateScoreCard(CollectionAddEvent<ScoreCardPanelViewModel> scoreCardPanelEntity)
    {
        Debug.Log("Score Panel V - Instantiating New Score Card");
        var scoreCard = Instantiate(_scoreCardPrefab, scrollListParent);
        scoreCard.SetViewModel(scoreCardPanelEntity.Value);
        scoreCardInstances.Add(scoreCard);
        Debug.Log("Score Panel V - New Score Card Instantiated");
    }
}
