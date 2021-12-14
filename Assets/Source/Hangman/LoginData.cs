using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginData
{   
    public readonly string email;
    public readonly string password;
    
    public LoginData(string _email, string _password)
    {
        email = _email;
        password = _password;
    }
}
