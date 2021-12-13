using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePanelPresenter : Presenter
{
    ScorePanelViewModel _scorePanelViewModel;

    public ScorePanelPresenter(ScorePanelViewModel scorePanelViewModel)
    {
        _scorePanelViewModel = scorePanelViewModel;
        EventDispatcherService.Instance.Subscribe<NewSortedScoreEntry>(OnScoreEntryAdded);
    }

    private void OnScoreEntryAdded(NewSortedScoreEntry newSortedScoreEntry)
    {
        _scorePanelViewModel.ScoreCards.Add(new ScoreCardPanelViewModel(newSortedScoreEntry.orderNumber.ToString(), newSortedScoreEntry.username, newSortedScoreEntry.score.ToString()));
    }

    public new void Dispose() 
    {
        EventDispatcherService.Instance.Unsubscribe<NewSortedScoreEntry>(OnScoreEntryAdded);
    }
}