using UnityEngine;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;

public class HomePanelView : MonoBehaviour
{
    [SerializeField] private RectTransform _panel;
    public RectTransform Panel { get => _panel; }
    [SerializeField] private DoTweenPanelSwipeController _swipeController;
    private HomePanelViewModel _viewModel;

    [SerializeField] private Button _editUsernameButton;
    [SerializeField] private Button _playButton;

    public void SetViewModel(HomePanelViewModel viewModel)
    {
        _viewModel = viewModel;

        _viewModel
            .IsVisible
            .Subscribe((isVisible) => {
                //gameObject.SetActive(isVisible);

                if (isVisible)
                {
                    _panel.SetAsLastSibling();
                    _swipeController.Animate(DoTweenPanelSwipeController.StartingSide.LEFT);
                }
                
                //gameObject.transform.DOShakePosition(1.5f, 10.0f);
            });
        
        _editUsernameButton.onClick.AddListener(() => {
            _viewModel.EditUsernameButtonPressed.Execute();
        }
        );
    }
}
