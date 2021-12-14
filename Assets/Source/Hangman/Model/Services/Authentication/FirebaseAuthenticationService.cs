using System;
using System.Threading.Tasks;
using UnityEngine;

using Firebase.Extensions;

public class FirebaseAuthenticationService : AuthenticationService
{
    public string UserId { get; private set; }

    public async Task<string> AnonymousLogin()
    {
        string userId = "UserId";
        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;

        if (auth.CurrentUser != null)
        {
            userId = auth.CurrentUser.UserId;
            UserId = userId;
            PlayerPrefs.SetString(Constants.STRING_PLAYERPREFS_USERID, auth.CurrentUser.UserId);
            return userId;
        }

        await auth.SignInAnonymouslyAsync().ContinueWith(task => {
        if (task.IsCanceled) {
            throw new Exception("FirebaseAuthError - Anonymous Sign In was canceled.");
        }
        if (task.IsFaulted) {
            throw new Exception("FirebaseAuthError - SignInAnonymouslyAsync encountered an error: " + task.Exception);
        }

        Firebase.Auth.FirebaseUser newUser = task.Result;

        userId = newUser.UserId;
        });

        if (userId == "UserId")
            throw new Exception("FirebaseAuthError - User id couldn't be assigned propperly.");
        UserId = userId;

        var loginResult = new LoginResult(true);
        var userData = new UserData(PlayerPrefs.GetString(Constants.STRING_PLAYERPREFS_USERID), Constants.STRING_DEFAULT_USERNAME);
        ServiceLocator.Instance.GetService<IEventDispatcherService>().Dispatch(loginResult);
        ServiceLocator.Instance.GetService<IEventDispatcherService>().Dispatch(userData);

        return userId;
    }

    public async Task<string> RegisterWithEmailAndPassword(LoginData loginData)
    {
        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        string userId = "UserId";

        await auth.CreateUserWithEmailAndPasswordAsync(loginData.email, loginData.password).ContinueWithOnMainThread(task => {
            if (task.IsCanceled)
            {
                return;
            }
            if (task.IsFaulted)
            {
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            userId = newUser.UserId;
        });
        PlayerPrefs.SetString(Constants.STRING_PLAYERPREFS_USERID, auth.CurrentUser.UserId);
        UserId = userId;
        return userId;
    }

    public async Task<string> LoginWithEmailAndPassword(LoginData loginData)
    {
        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        string userId = "UserId";

        await auth.SignInWithEmailAndPasswordAsync(loginData.email, loginData.password).ContinueWithOnMainThread(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            userId = newUser.UserId;
        });
        PlayerPrefs.SetString(Constants.STRING_PLAYERPREFS_USERID, auth.CurrentUser.UserId);
        UserId = userId;
        return userId;
    }
}
