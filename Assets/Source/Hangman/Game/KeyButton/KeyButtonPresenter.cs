using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Code.Web.HangmanApi.Response;

public class KeyButtonPresenter : Presenter
{
    private readonly KeyButtonViewModel _keyButtonViewModel;

    public KeyButtonPresenter(KeyButtonViewModel keyButtonViewModel)
    {
        _keyButtonViewModel = keyButtonViewModel;

        ServiceLocator.Instance.GetService<IEventDispatcherService>().Subscribe<GuessLetterResult>(OnGuessLetterResultReceived);
    }

    private void OnGuessLetterResultReceived(GuessLetterResult guessLetterResult)
    {
        if (_keyButtonViewModel.letter == guessLetterResult.letter)
        {
            _keyButtonViewModel.IsCorrect.Value = guessLetterResult.response.correct?1:-1;
        }
    }

    public new void Dispose()
    {
        ServiceLocator.Instance.GetService<IEventDispatcherService>().Unsubscribe<GuessLetterResult>(OnGuessLetterResultReceived);
    }
}
