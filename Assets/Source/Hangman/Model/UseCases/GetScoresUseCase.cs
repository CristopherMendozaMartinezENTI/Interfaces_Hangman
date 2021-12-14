using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Firebase.Extensions;

using System.Threading.Tasks;

public class GetScoresUseCase : ScoreGetter
{
    RealtimeDatabaseService _realtimeDatabaseService;
    IEventDispatcherService _eventDispatcherService;

    public GetScoresUseCase(RealtimeDatabaseService realtimeDatabaseService, IEventDispatcherService eventDispatcherService)
    {
        _realtimeDatabaseService = realtimeDatabaseService;
        _eventDispatcherService = eventDispatcherService;
    }

    public async Task GetScores()
    {
        await _realtimeDatabaseService.GetData().ContinueWithOnMainThread(task => 
        {
            int counter = 1;
            var sortedRanking = task.Result;
            Debug.Log("GetScoresUseCase - List Length: " + sortedRanking.Count);
            foreach(var rankingEntry in sortedRanking)
            {
                Debug.Log("GetScoresUseCase - Username: " + rankingEntry.Key + ", Score: " + rankingEntry.Value.score + ", Playtime: " + rankingEntry.Value.playtime);
                _eventDispatcherService.Dispatch(new NewSortedScoreEntry(counter, rankingEntry.Key, rankingEntry.Value.score, rankingEntry.Value.playtime));
                Debug.Log("GetScoresUseCase - Continuing foreach");
                counter++;
            }
        });
    }
}
