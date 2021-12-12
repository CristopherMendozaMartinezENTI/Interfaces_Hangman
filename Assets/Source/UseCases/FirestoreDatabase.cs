using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;

using Firebase.Extensions;

public class FirestoreDatabase : IDatabase
{
    FirestoreService _firestoreService;

    public FirestoreDatabase(FirestoreService firestoreService) 
    {
        _firestoreService = firestoreService;
    }
    public async Task SetUserdata(UserData userdata)
    {
        Debug.Log("Called set user data.\nUsername was: " + userdata.Username + "\nUser ID was: " + userdata.Id);
        Dictionary<string, object> data = new Dictionary<string, object>();
        data.Add(Constants.STRING_DB_FIELD_USERS_USERNAME, userdata.Username);
        await _firestoreService.AddData(Constants.STRING_DB_COLLECTION_USERS, userdata.Id, data);
    }

    public async Task<UserData> GetUserdata(string userID)
    {
        Dictionary<string, object> data = new Dictionary<string, object>();
        UserData userdata = new UserData(userID, Constants.STRING_DEFAULT_USERNAME);
        await _firestoreService.GetDocument(Constants.STRING_DB_COLLECTION_USERS, userID).ContinueWithOnMainThread( Task => 
        {
            data = Task.Result;
            object username;
            if (data.TryGetValue(Constants.STRING_DB_FIELD_USERS_USERNAME, out username))
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
