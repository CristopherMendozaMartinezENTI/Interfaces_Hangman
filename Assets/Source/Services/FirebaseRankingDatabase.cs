using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Extensions;
using Firebase.Database;
using UnityEngine;
using System.Linq;
using TMPro;

public class FirebaseRankingDatabase : MonoBehaviour
{
    public async Task<Dictionary<string, ScoreEntry>> GetData()
    {
        Debug.Log("Getting Data from Ranking");
        var unsortedRanking = new Dictionary<string, ScoreEntry>();
        await FirebaseDatabase.DefaultInstance
               .GetReference("ranking")
               .GetValueAsync()
               .ContinueWithOnMainThread(task =>
               {
                   if (task.IsCompleted)
                   {
                       Debug.Log("Read Ok");
                       foreach (var dataSnapshot in task.Result.Children)
                       {
                           var userName = dataSnapshot.Key.ToString();
                           Debug.Log($"{dataSnapshot.Key}");
                           foreach (var child in dataSnapshot.Children)
                           {
                               Debug.Log($"{child.Key}: {child.Value}");
                               ScoreEntry userScore = new ScoreEntry((int)child.Child("PlayTime").Value, (int)child.Child("Score").Value);
                               unsortedRanking.Add(userName, userScore);
                           }
                       }
                   }
               });

        var sortedRanking = (Dictionary<string, ScoreEntry>) from entry in unsortedRanking orderby entry.Value.Score descending select entry;
        return sortedRanking;
    }

    public async Task AddData(string user, ScoreEntry _scoreEntry)
    {
        var reference = FirebaseDatabase.DefaultInstance.RootReference;
        var jsonValue = JsonUtility.ToJson(new ScoreEntry(_scoreEntry.Score, _scoreEntry.PlayTime));
        var scoreEntry = new ScoreEntry(_scoreEntry.Score, _scoreEntry.PlayTime);
        await reference
            .Child("ranking")
            .Child(user)
            .SetRawJsonValueAsync(jsonValue)
            .ContinueWithOnMainThread(task =>
            {
                if (task.IsCompleted)
                {
                    Debug.Log("ScoreAdded");
                }
            });
    }
}
