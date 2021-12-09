using UnityEngine;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;
using TMPro;

public class HomePanelView : View
{
    [SerializeField] private RectTransform _panel;
    public RectTransform Panel { get => _panel; }
    [SerializeField] private DoTweenPanelSwipeController _swipeController;
    private HomePanelViewModel _viewModel;

    [SerializeField] private Button _editUsernameButton;
    [SerializeField] private Button _playButton;

    [SerializeField] private TMP_Text usernameText;
    public override void SetViewModel(ViewModel viewModel)
    {
        _viewModel = viewModel as HomePanelViewModel;

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
            })
            .AddTo(_disposables);
        
        _viewModel
            .Username
            .Subscribe((username) => {
                usernameText.text = username;
            })
            .AddTo(_disposables);
        
        _editUsernameButton
            .OnClickAsObservable()
            .Subscribe((_) => {
                _viewModel.EditUsernameButtonPressed.Execute();
            })
            .AddTo(_disposables);
    }
}
