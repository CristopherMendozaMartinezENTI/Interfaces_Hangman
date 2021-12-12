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
    public Dictionary<string, ScoreEntry> rankingData;

    public async Task<Dictionary<string, ScoreEntry>> GetData()
    {
        Debug.Log("Getting Data from Ranking");
        var ranking = new Dictionary<string, ScoreEntry>();
        var reference = FirebaseDatabase.DefaultInstance;
        await reference.GetReference("ranking").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("Read Ok");
                foreach (var dataSnapshot in task.Result.Children)
                {
                    var userName = dataSnapshot.Key.ToString();
                    var score = int.Parse(dataSnapshot.Child("Score").Value.ToString());
                    var playTime = int.Parse(dataSnapshot.Child("PlayTime").Value.ToString());
                    ScoreEntry userScore = new ScoreEntry(score, playTime);
                    ranking.Add(userName, userScore);
                }

                var sortedRanking = from entry in ranking orderby entry.Value.Score descending select entry;

                foreach (var entry in sortedRanking)
                {
                    ranking[entry.Key] = new ScoreEntry(entry.Value.Score, entry.Value.PlayTime);
                }
            }
       });
       rankingData = ranking;
       return ranking;
    }

    public async Task AddData(string user, ScoreEntry _scoreEntry)
    {
        var reference = FirebaseDatabase.DefaultInstance.RootReference;
        var jsonValue = JsonUtility.ToJson(new ScoreEntry(_scoreEntry.Score, _scoreEntry.PlayTime));
        var scoreEntry = new ScoreEntry(_scoreEntry.Score, _scoreEntry.PlayTime);
        await reference.Child("ranking").Child(user).SetRawJsonValueAsync(jsonValue).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("ScoreAdded");
            }
        });
    }
}
