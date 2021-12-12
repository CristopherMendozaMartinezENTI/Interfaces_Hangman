using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Firebase.Extensions;

public class RetrieveScoresFromDatabaseUseCase : IRetrieveScoresUseCase
{
    private IDatabaseService _databaseService;

    public RetrieveScoresFromDatabaseUseCase(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    public async void RetrieveScores()
    {
        await _databaseService.GetCollection(Constants.STRING_DB_COLLECTION_SCORES).ContinueWithOnMainThread(task => 
        {
            Dictionary<string, Dictionary<string, object>> collection = task.Result;
            List<ScoreEntry> scoreEntries = new List<ScoreEntry>();
            foreach(KeyValuePair<string, Dictionary<string, object>> document in collection)
            {
                object score;
                if (document.Value.TryGetValue(Constants.STRING_DB_FIELD_SCORES_SCORE, out score))
                {
                    ScoreEntry scoreEntry = new ScoreEntry(document.Key, (int)score);
                };
            }
            scoreEntries.Sort((s1, s2) => s1.score.CompareTo(s2.score));

            ScoreEntry[] scoreEntriesArray = scoreEntries.ToArray();
            for (int i = 0; i < scoreEntriesArray.Length; i++)
            {
                NewSortedScoreEntry newSortedScoreEntry = new NewSortedScoreEntry(i+1, scoreEntriesArray[i].username, scoreEntriesArray[i].score);
                EventDispatcherService.Instance.Dispatch<NewSortedScoreEntry>(newSortedScoreEntry);
            }
        });
    }
}
