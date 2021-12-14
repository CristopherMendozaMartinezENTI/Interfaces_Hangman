using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Firebase.Firestore;

[FirestoreData]
public class UserDto : Dto
{
    [FirestoreDocumentId]
    public string userId {get; set;}

    [FirestoreProperty]
    public string username {get; set;}

    [FirestoreProperty]
    public string email { get; set; }

    public UserDto()
    {
    }

    public UserDto(string _userId, string _username)
    {
        userId = _userId;
        username = _username;
        email = "";
    }

    public UserDto(string _userId, string _username, string _email)
    {
        userId = _userId;
        username = _username;
        email = _email;
    }
}
