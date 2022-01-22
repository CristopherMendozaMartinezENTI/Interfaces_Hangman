using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Code.Web;
using Code.Web.HangmanApi.Response;
using Code.Web.HangmanApi;

public class GuessLetterUseCase : GuessLetter
{
    HangmanClient _hangmanClient;
    public GuessLetterUseCase(HangmanClient hangmanClient)
    {
        _hangmanClient = hangmanClient;
    }

    public async Task Guess(string letter)
    {
        if (string.IsNullOrEmpty(letter))
        {
            Debug.LogError("Input text is null");
            return;
        }

        if (letter.Length > 1)
        {
            Debug.LogError("Only 1 letter");
            return;
        }

        Debug.Log("Guessing letter: " + letter);
        var response = await _hangmanClient.GuessLetter<GuessLetterResponse>(EndPoints.GuessLetter, PlayerPrefs.GetString(Constants.STRING_GAMETOKEN), letter);
        PlayerPrefs.SetString(Constants.STRING_GAMETOKEN, response.token);

        GuessLetterResult result = new GuessLetterResult();
        result.response = response;
        result.letter = letter;

        Debug.Log("Letter: " + letter + ", " + (response.correct ? "correct" : "incorrect"));
        ServiceLocator.Instance.GetService<IEventDispatcherService>().Dispatch<GuessLetterResult>(result);       
    }
}
