using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;

//Implementacion para Firebase
public class LoginUseCase : LoginRequest
{
    FirebaseLoginService firebaseLoginService;

    public LoginUseCase(FirebaseLoginService _firebaseLoginService)
    {
        firebaseLoginService = _firebaseLoginService;
    }

    public async Task Login()
    {
        firebaseLoginService.AnonimSignUp();
        //Espero 2 segundos. Utilizo Task porque al no ser Monobehaviour no puedo utilizar una coroutine.
        await Task.Delay(TimeSpan.FromSeconds(1));
        var userData = new UserData(PlayerPrefs.GetString("UserId"));
        EventDispatcherService.Instance.Dispatch(userData);
    }
}