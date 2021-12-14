using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading.Tasks;
using Firebase.Extensions;

public class RegisterUseCase : UserRegister
{
    AuthenticationService _authenticationService;
    DatabaseService _databaseService;

    public RegisterUseCase(AuthenticationService authenticationService, DatabaseService databaseService)
    {
        _authenticationService = authenticationService;
        _databaseService = databaseService;
    }
    public async Task RegisterNewUser(LoginData loginData)
    {
        await _authenticationService.RegisterWithEmailAndPassword(loginData);

        string userId = _authenticationService.UserId;
        string username = PlayerPrefs.GetString(Constants.STRING_PLAYERPREFS_USERNAME, Constants.STRING_DEFAULT_USERNAME);

        Debug.Log("Register - UserId: " + userId + ", Username: " + username + ", Email: " + loginData.email);

        await _databaseService.Save(new UserDto(userId, username, loginData.email), Constants.STRING_DB_COLLECTION_USERS, _authenticationService.UserId);

        PlayerPrefs.SetString(Constants.STRING_PLAYERPREFS_EMAIL, loginData.email);
        //TODO: Save password into playerprefs encrypted
    }
}
