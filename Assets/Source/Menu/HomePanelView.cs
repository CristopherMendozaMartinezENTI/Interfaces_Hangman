using UnityEngine;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;

public class HomePanelView : MonoBehaviour
{
    private HomePanelViewModel _viewModel;

    public void SetViewModel(HomePanelViewModel viewModel)
    {
        _viewModel = viewModel;

        _viewModel
            .IsVisible
            .Subscribe((isVisible) => {
                gameObject.SetActive(isVisible);
                gameObject.transform.DOShakePosition(1.5f, 10.0f);
            });
    }
}
