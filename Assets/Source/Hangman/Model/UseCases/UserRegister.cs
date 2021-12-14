using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public interface UserRegister
{
    Task RegisterNewUser(LoginData loginData);
}
