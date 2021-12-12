using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCardPanelPresenter : Presenter
{
    private readonly ScoreCardPanelViewModel _model;

    public ScoreCardPanelPresenter(ScoreCardPanelViewModel model, KeyValuePair<string, ScoreEntry> pair)
    {
        _model = model;
    }

    public new void Dispose()
    {
    }
}
