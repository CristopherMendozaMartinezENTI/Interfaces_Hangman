using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading.Tasks;

public class SetUserDataUseCase : UserDataSetter
{
    DatabaseService _databaseService;

    public SetUserDataUseCase(DatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    public async Task SetUserdata(UserData userdata)
    {
        UserDto dataToSave = new UserDto(userdata.Id, userdata.Username, PlayerPrefs.GetString(Constants.STRING_PLAYERPREFS_EMAIL, ""));
        await _databaseService.Save<UserDto>(dataToSave, Constants.STRING_DB_COLLECTION_USERS, userdata.Id);

        PlayerPrefs.SetString(Constants.STRING_PLAYERPREFS_USERNAME, userdata.Username);
    }
}
