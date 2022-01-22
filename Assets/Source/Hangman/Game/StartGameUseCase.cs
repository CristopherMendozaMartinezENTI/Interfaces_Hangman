using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Code.Web;
using Code.Web.HangmanApi.Response;
using Code.Web.HangmanApi;

public class StartGameUseCase : StartGame
{
    HangmanClient _hangmanClient;
    public StartGameUseCase(HangmanClient hangmanClient)
    {
        _hangmanClient = hangmanClient;
    }

    public async Task Start()
    {
        Debug.Log("Starting new game");
        var response = await _hangmanClient
            .StartGame<NewGameResponse>(EndPoints.NewGame);
        PlayerPrefs.SetString(Constants.STRING_GAMETOKEN, response.token);

        Debug.Log("New game started");
        ServiceLocator.Instance.GetService<IEventDispatcherService>().Dispatch<NewGameResponse>(response);
        Debug.Log("New Game Dispatched");
    }
}
