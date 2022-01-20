using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class KeyButtonController : Controller
{
    private readonly KeyButtonViewModel _keyButtonViewModel;

    public KeyButtonController(KeyButtonViewModel viewModel, string key)
    {
        _keyButtonViewModel = viewModel;

        _keyButtonViewModel
            .KeyButtonPressed
            .Subscribe((_) => {
                CheckKey(key);
            })
            .AddTo(_disposables);
    }

    public void CheckKey(string key)
    {

    }
}
