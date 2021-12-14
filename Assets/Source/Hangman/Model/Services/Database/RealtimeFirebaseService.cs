using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading.Tasks;
using System.Linq;

using Firebase.Database;
using Firebase.Extensions;

public class RealtimeFirebaseService : RealtimeDatabaseService
{
    public async Task<List<KeyValuePair<string, ScoreEntry>>> GetData()
    {
        Debug.Log("Getting Data from Ranking");
        var ranking = new List<KeyValuePair<string, ScoreEntry>>();
        await FirebaseDatabase.DefaultInstance
               .GetReference(Constants.STRING_DB_COLLECTION_SCORES)
               .GetValueAsync()
               .ContinueWithOnMainThread(task =>
               {
                   if (task.IsCompleted)
                   {
                       DataSnapshot queryResult = task.Result;
                       Debug.Log("Realtime Database Service - Children count: " + queryResult.ChildrenCount);

                       Debug.Log("Read Ok");
                       foreach (var dataSnapshot in task.Result.Children)
                       {
                            var userName = dataSnapshot.Key.ToString();
                            var score = int.Parse(dataSnapshot.Child(Constants.STRING_DB_FIELD_SCORES_SCORE).Value.ToString());
                            var playTime = int.Parse(dataSnapshot.Child(Constants.STRING_DB_FIELD_SCORES_PLAYTIME).Value.ToString());
                            ScoreEntry userScore = new ScoreEntry(score, playTime);
                            ranking.Add(new KeyValuePair<string, ScoreEntry>(userName, userScore));

                           Debug.Log("Realtime Database Service - Username: " + userName + ", Score: " + score + ", Playtime: " + playTime);
                       }
                   }
               });
        //Debug.Log("Realtime Database Service - Result Length: " + ranking.Count);

        ranking.Sort((p1, p2) => p2.Value.score.CompareTo(p1.Value.score));
        return ranking;
    }
}
