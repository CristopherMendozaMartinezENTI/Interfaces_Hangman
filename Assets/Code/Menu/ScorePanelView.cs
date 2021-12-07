using UnityEngine;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;

public class ScorePanelView : MonoBehaviour
{
    private ScorePanelViewModel _viewModel;

    public void SetViewModel(ScorePanelViewModel viewModel)
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
