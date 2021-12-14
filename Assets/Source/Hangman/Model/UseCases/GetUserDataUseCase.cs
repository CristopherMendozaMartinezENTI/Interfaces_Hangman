using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading.Tasks;
using Firebase.Extensions;

public class GetUserDataUseCase : UserDataGetter
{
    DatabaseService _databaseService;

    public GetUserDataUseCase(DatabaseService databaseService)
    {
        _databaseService = databaseService;
    }
    public async Task<UserData> GetUserdata(string userID)
    {
        Dictionary<string, object> data = new Dictionary<string, object>();
        UserData userdata = new UserData(userID, Constants.STRING_DEFAULT_USERNAME);
        bool exists = false;
        await _databaseService.ExistKey(Constants.STRING_DB_COLLECTION_USERS, userID).ContinueWithOnMainThread( task =>
        {
            exists = task.Result;
        });

        if (exists)
        {
            await _databaseService.Load<UserDto>(Constants.STRING_DB_COLLECTION_USERS, userID).ContinueWithOnMainThread( task => 
            {
                UserDto userDto = task.Result;
                userdata = new UserData(userDto.userId, userDto.username);
                PlayerPrefs.SetString(Constants.STRING_PLAYERPREFS_USERNAME, userdata.Username);
            });
        }
        
        return userdata;
    }
}
