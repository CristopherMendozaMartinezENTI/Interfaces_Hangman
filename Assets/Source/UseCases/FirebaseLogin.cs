using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;

//Implementacion para Firebase
public class FirebaseLogin : ILoginRequest
{
    private FirebaseLoginService _firebaseLoginService;

    public FirebaseLogin(FirebaseLoginService firebaseLoginService)
    {
        _firebaseLoginService = firebaseLoginService;
    }

    public async Task AnonymousSignIn()
    {
        var currentUser = _firebaseLoginService.GetCurrentUser();

        if (currentUser == null)
        {
            Debug.Log("Current user was null.");
            await _firebaseLoginService.AnonymousSignIn();
            var loginResult = new LoginResult(true);
            var userData = new UserData(PlayerPrefs.GetString(Constants.STRING_PLAYERPREFS_USERID), Constants.STRING_DEFAULT_USERNAME);
            EventDispatcherService.Instance.Dispatch(loginResult);
            EventDispatcherService.Instance.Dispatch(userData);
        }
        else
        {
            Debug.Log("Current user was not null, user id: " + currentUser.UserId);
            PlayerPrefs.SetString(Constants.STRING_PLAYERPREFS_USERID, currentUser.UserId);
        }
    }
}