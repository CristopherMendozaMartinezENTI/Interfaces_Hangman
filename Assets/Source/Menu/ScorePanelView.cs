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

    private ScorePanelViewModel _viewModel;

    public override void SetViewModel(ViewModel viewModel)
    {
        _viewModel = viewModel as ScorePanelViewModel;

        _viewModel
            .IsFromTheLeft
            .Subscribe((isFromTheLeft) => {
                _startingSide = isFromTheLeft ? DoTweenPanelSwipeController.StartingSide.LEFT : DoTweenPanelSwipeController.StartingSide.RIGHT;
            })
            .AddTo(_disposables);

        _viewModel
            .IsVisible
            .Subscribe((isVisible) => {
                //gameObject.SetActive(isVisible);

                if (isVisible)
                {
                    _panel.SetAsLastSibling();
                    _swipeController.Animate(_startingSide);
                }
                //gameObject.transform.DOShakePosition(1.5f, 10.0f);
            })
            .AddTo(_disposables);
    }
}
