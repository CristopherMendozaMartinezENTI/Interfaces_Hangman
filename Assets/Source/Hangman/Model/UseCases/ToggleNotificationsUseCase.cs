using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Firebase.Messaging;
using Firebase.Extensions;

using System.Threading.Tasks;

public class ToggleNotificationsUseCase : ToggleNotifications
{
    public async Task ToggleNotifications(bool value)
    {
        if (value)
        {
            await FirebaseMessaging.SubscribeAsync(Constants.STRING_MSG_TOPIC);
        } 
        else
        {
            await FirebaseMessaging.UnsubscribeAsync(Constants.STRING_MSG_TOPIC);
        }
    }
}
