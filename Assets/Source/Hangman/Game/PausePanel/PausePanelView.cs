using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanelView : View
{
    private PausePanelViewModel _viewModel;

    public override void SetViewModel(ViewModel viewModel)
    {
        _viewModel = viewModel as PausePanelViewModel;
    }
}
