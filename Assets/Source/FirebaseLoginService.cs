using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebaseLoginService : MonoBehaviour
{
    //Nos conectamos a Firebase.
    private Firebase.FirebaseApp app;
    private Firebase.Auth.FirebaseUser newUser;
    // Start is called before the first frame update
    public void Start()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                app = Firebase.FirebaseApp.DefaultInstance;
                Debug.Log("Firebase Ok");
                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
                Debug.Log("Firebase no Ok");
            }
        });
    }

    public void AnonimSignUp()
    {
        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.SignInAnonymouslyAsync().ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInAnonymouslyAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInAnonymouslyAsync encountered an error: " + task.Exception);
                return;
            }

            newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0}", newUser.UserId);
            PlayerPrefs.SetString("UserId", newUser.UserId);
        });
    }
}
