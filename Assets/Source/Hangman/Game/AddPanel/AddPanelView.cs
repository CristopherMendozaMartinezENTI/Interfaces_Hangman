using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using TMPro;

public class AddPanelView : View
{
    private AddPanelViewModel _viewModel;
    public override void SetViewModel(ViewModel viewModel)
    {
        _viewModel = viewModel as AddPanelViewModel;
    }
}
