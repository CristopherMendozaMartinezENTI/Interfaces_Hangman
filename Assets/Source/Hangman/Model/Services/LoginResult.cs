using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginResult
{
    public readonly bool LoginSuccessful;

    public LoginResult(bool loginSuccessful)
    {
        LoginSuccessful = loginSuccessful;
    }
}
