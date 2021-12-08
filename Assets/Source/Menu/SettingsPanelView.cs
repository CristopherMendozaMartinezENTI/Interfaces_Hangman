using UnityEngine;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;

public class SettingsPanelView : MonoBehaviour
{
    [SerializeField] private RectTransform _panel;
    public RectTransform Panel { get => _panel; }
    [SerializeField] private DoTweenPanelSwipeController _swipeController;
    private SettingsPanelViewModel _viewModel;

    [SerializeField] private Button _loginButton;
    [SerializeField] private Button _registerButton;
    [SerializeField] private Button _notificationsButton;
    [SerializeField] private RectTransform _notificationsGreenIndicator;
    [SerializeField] private RectTransform _notificationsRedIndicator;
    [SerializeField] private Button _audioButton;
    [SerializeField] private RectTransform _audioGreenIndicator;
    [SerializeField] private RectTransform _audioRedIndicator;

    public void SetViewModel(SettingsPanelViewModel viewModel)
    {
        _viewModel = viewModel;

        _viewModel
            .IsVisible
            .Subscribe((isVisible) => {
                //gameObject.SetActive(isVisible);
                
                if (isVisible)
                {
                    _panel.SetAsLastSibling();
                    _swipeController.Animate(DoTweenPanelSwipeController.StartingSide.RIGHT);
                }
                //gameObject.transform.DOShakePosition(1.5f, 10.0f);
            });
    }
}
