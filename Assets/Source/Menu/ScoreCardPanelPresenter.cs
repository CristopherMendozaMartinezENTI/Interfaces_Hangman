using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCardPanelPresenter : Presenter
{
    private readonly ScoreCardPanelViewModel _model;

    public ScoreCardPanelPresenter(ScoreCardPanelViewModel model, int rank, KeyValuePair<string, ScoreEntry> playerScore)
    {
        _model = model;
        EventDispatcherService.Instance.Subscribe<KeyValuePair<string, ScoreEntry>>(OnUserScoreUpdated);
    }

    private void OnUserScoreUpdated(KeyValuePair<string, ScoreEntry> pair)
    {
        _model.UserName.Value = pair.Key;
        _model.Score.Value = pair.Value.Score.ToString();
        _model.PlayTime.Value = pair.Value.PlayTime.ToString();
    }

    public new void Dispose()
    {
        EventDispatcherService.Instance.Unsubscribe<KeyValuePair<string, ScoreEntry>>(OnUserScoreUpdated);
    }
}
