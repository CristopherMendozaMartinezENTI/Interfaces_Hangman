using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;

using Firebase.Extensions;

public class FirestoreDatabase : IDatabase
{
    const string USERS_COLLECTION_NAME = "users";
    const string USERS_USERNAME_FIELD_NAME = "username";
    FirestoreService _firestoreService;
    public FirestoreDatabase(FirestoreService firestoreService) 
    {
        _firestoreService = firestoreService;
    }
    public async Task SetUserdata(UserData userdata)
    {
        Debug.Log("Called set user data.\nUsername was: " + userdata.Username + "\nUser ID was: " + userdata.Id);
        Dictionary<string, object> data = new Dictionary<string, object>();
        data.Add(USERS_USERNAME_FIELD_NAME, userdata.Username);
        await _firestoreService.AddData(USERS_COLLECTION_NAME, userdata.Id, data);
    }

    public async Task<UserData> GetUserdata(string userID)
    {
        Dictionary<string, object> data = new Dictionary<string, object>();
        UserData userdata = new UserData(userID, Constants.STRING_DEFAULT_USERNAME);
        await _firestoreService.GetDocument(USERS_COLLECTION_NAME, userID).ContinueWithOnMainThread( Task => 
        {
            data = Task.Result;
            object username;
            if (data.TryGetValue(USERS_USERNAME_FIELD_NAME, out username))
            {
                userdata = new UserData(userID, (string)username);
            }            
        });
        return userdata;
    }

    public void Dispose() 
    {

    }
}
