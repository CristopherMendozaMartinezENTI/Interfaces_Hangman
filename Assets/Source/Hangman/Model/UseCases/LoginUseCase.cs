using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading.Tasks;
using Firebase.Extensions;

public class LoginUseCase : UserLogin
{
    AuthenticationService _authenticationService;

    public LoginUseCase(AuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public async Task Login(LoginData loginData)
    {
        
        await _authenticationService.LoginWithEmailAndPassword(loginData);
        PlayerPrefs.SetString(Constants.STRING_PLAYERPREFS_EMAIL, loginData.email);
        //TODO: Save encrypted password to playerprefs;
    }
}
