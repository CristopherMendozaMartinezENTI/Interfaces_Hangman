using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePanelPresenter : Presenter
{
    ScorePanelViewModel _scorePanelViewModel;

    public ScorePanelPresenter(ScorePanelViewModel scorePanelViewModel)
    {
        _scorePanelViewModel = scorePanelViewModel;
        ServiceLocator.Instance.GetService<IEventDispatcherService>().Subscribe<NewSortedScoreEntry>(OnScoreEntryAdded);
    }

    private void OnScoreEntryAdded(NewSortedScoreEntry newSortedScoreEntry)
    {
        Debug.Log("Score Panel VM - New Score Entry");
        _scorePanelViewModel.ScoreCards.Add(new ScoreCardPanelViewModel(newSortedScoreEntry.orderNumber.ToString(), newSortedScoreEntry.username, newSortedScoreEntry.score.ToString(), newSortedScoreEntry.playtime.ToString()));
    }

    public new void Dispose() 
    {
        ServiceLocator.Instance.GetService<IEventDispatcherService>().Unsubscribe<NewSortedScoreEntry>(OnScoreEntryAdded);
    }
}