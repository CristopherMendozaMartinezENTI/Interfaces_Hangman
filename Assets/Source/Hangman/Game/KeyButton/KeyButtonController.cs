using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class KeyButtonController : Controller
{
    private readonly KeyButtonViewModel _keyButtonViewModel;
    private readonly GuessLetter guessLetterUseCase;

    public KeyButtonController(KeyButtonViewModel viewModel, GuessLetter _guessLeterUseCase)
    {
        _keyButtonViewModel = viewModel;
        guessLetterUseCase = _guessLeterUseCase;

        _keyButtonViewModel
            .KeyButtonPressed
            .Subscribe((key) => {
                OnKeyPressed(key);
            })
            .AddTo(_disposables);
    }

    public void OnKeyPressed(string key)
    {
        _keyButtonViewModel.IsUsed.Value = true;

        guessLetterUseCase.Guess(_keyButtonViewModel.letter);
    }
}
