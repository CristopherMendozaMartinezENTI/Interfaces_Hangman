using UnityEngine;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;

public class ScorePanelView : MonoBehaviour
{
    [SerializeField] private RectTransform _panel;
    public RectTransform Panel { get => _panel; }
    [SerializeField] private DoTweenPanelSwipeController _swipeController;
    private DoTweenPanelSwipeController.StartingSide _startingSide;

    [SerializeField] private RectTransform scrollListParent;

    private ScorePanelViewModel _viewModel;

    public void SetViewModel(ScorePanelViewModel viewModel)
    {
        _viewModel = viewModel;

        _viewModel
            .IsFromTheLeft
            .Subscribe((isFromTheLeft) => {
                _startingSide = isFromTheLeft ? DoTweenPanelSwipeController.StartingSide.LEFT : DoTweenPanelSwipeController.StartingSide.RIGHT;
            });

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
            });
    }
}
