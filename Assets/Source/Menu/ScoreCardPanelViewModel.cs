using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ScoreCardPanelViewModel : ViewModel
{
    public readonly ReactiveProperty<string> UserName;
    public readonly ReactiveProperty<string> Score;
    public readonly ReactiveProperty<string> PlayTime;

    public ScoreCardPanelViewModel()
    {
        UserName = new ReactiveProperty<string>();
        Score = new ReactiveProperty<string>();
        PlayTime = new ReactiveProperty<string>();
    }
}
