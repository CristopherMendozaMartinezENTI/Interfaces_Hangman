using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class AddPanelController : Controller
{
    private readonly AddPanelViewModel _addPanelviewModel;
   
    public AddPanelController(AddPanelViewModel viewModel)
    {
        _addPanelviewModel = viewModel;

        _addPanelviewModel
            .WatchAdddPressed
            .Subscribe((_) => {
                //
            })
            .AddTo(_disposables);

        _addPanelviewModel
            .TryAgainPressed
            .Subscribe((_) => {
                //
            })
            .AddTo(_disposables);

        _addPanelviewModel
            .ToMenuPressed
            .Subscribe((_) => {
                //
            })
            .AddTo(_disposables);
    }
}
