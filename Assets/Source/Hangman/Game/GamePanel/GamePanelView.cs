using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanelView : View
{
    private GamePanelViewModel _viewModel;

    public override void SetViewModel(ViewModel viewModel)
    {
        _viewModel = viewModel as GamePanelViewModel;
    }
}
