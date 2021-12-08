using UnityEngine;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;

public class SettingsPanelView : MonoBehaviour
{
    private SettingsPanelViewModel _viewModel;

    public void SetViewModel(SettingsPanelViewModel viewModel)
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
