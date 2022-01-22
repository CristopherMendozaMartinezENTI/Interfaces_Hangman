using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Code.Web;
using Code.Web.HangmanApi.Response;
using Code.Web.HangmanApi;

public class GamePanelPresenter : Presenter
{
    private readonly GamePanelViewModel _gamePanelViewModel;

    public GamePanelPresenter(GamePanelViewModel gamePanelViewModel)
    {
        _gamePanelViewModel = gamePanelViewModel;

        ServiceLocator.Instance.GetService<IEventDispatcherService>().Subscribe<GuessLetterResult>(OnGuessLetterResultReceived);
        ServiceLocator.Instance.GetService<IEventDispatcherService>().Subscribe<NewGameResponse>(OnNewGameResponseReceived);
    }

    private void OnNewGameResponseReceived(NewGameResponse newGameResponse)
    {
        Debug.Log("New Game Response Received");
        _gamePanelViewModel.Word.Value = newGameResponse.hangman;
        Debug.Log("New Game Started with word: " + newGameResponse.hangman);
    }

    private void OnGuessLetterResultReceived(GuessLetterResult guessLetterResult)
    {
        if (guessLetterResult.response.correct)
        {
            _gamePanelViewModel.Word.Value = guessLetterResult.response.hangman;

            if (IsCompleted(guessLetterResult.response.hangman))
            {
                _gamePanelViewModel.WinConditionAchieved.Value = true;
            }
        }
        else
        {
            int tries = PlayerPrefs.GetInt(Constants.STRING_TRIES);
            tries--;
            PlayerPrefs.SetInt(Constants.STRING_TRIES, tries);

            _gamePanelViewModel.Tries.Value = tries;
        }
    }

    public new void Dispose()
    {
        ServiceLocator.Instance.GetService<IEventDispatcherService>().Unsubscribe<GuessLetterResult>(OnGuessLetterResultReceived);
        ServiceLocator.Instance.GetService<IEventDispatcherService>().Unsubscribe<NewGameResponse>(OnNewGameResponseReceived);
    }

    private bool IsCompleted(string hangman)
    {
        const string secretCharacter = "_";
        return !hangman.Contains(secretCharacter);
    }
}
