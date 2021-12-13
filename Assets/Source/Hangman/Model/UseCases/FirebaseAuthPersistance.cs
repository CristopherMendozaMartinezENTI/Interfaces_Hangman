using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebaseAuthPersistance : IAuthPersistance
{
    private FirebaseLoginService _firebaseLoginService;

    public FirebaseAuthPersistance(FirebaseLoginService firebaseLoginService)
    {
        _firebaseLoginService = firebaseLoginService;
    }
    public void SetAuthenticationPersistance()
    {
        var auth = _firebaseLoginService.GetFirebaseAuthDefaultInstance();

        auth.StateChanged += CheckForCurrentUserData;
    }

    private void CheckForCurrentUserData(object sender, EventArgs e)
    {
        var auth = _firebaseLoginService.GetFirebaseAuthDefaultInstance();
        var currentUser = auth.CurrentUser;

        if (currentUser != null)
        {
            EventDispatcherService.Instance.Dispatch(new LoginResult(true));
            EventDispatcherService.Instance.Dispatch(new UserData(currentUser.UserId, "Username"));
        }
    }

    public void Dispose()
    {
        var auth = _firebaseLoginService.GetFirebaseAuthDefaultInstance();

        auth.StateChanged -= CheckForCurrentUserData;
    }
}
