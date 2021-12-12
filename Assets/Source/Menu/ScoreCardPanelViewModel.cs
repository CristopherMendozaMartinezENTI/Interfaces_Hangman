using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ScoreCardPanelViewModel : ViewModel
{
    public readonly ReactiveProperty<string> UserName;
    public readonly ReactiveProperty<string> Score;
    public readonly ReactiveProperty<string> OrderNumber;

    public ScoreCardPanelViewModel(string orderNumber, string username, string score)
    {
        UserName = new ReactiveProperty<string>(username);
        Score = new ReactiveProperty<string>(score);
        OrderNumber = new ReactiveProperty<string>(orderNumber);
    }
}
