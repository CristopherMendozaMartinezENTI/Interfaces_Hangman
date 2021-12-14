using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ScoreCardPanelViewModel : ViewModel
{
    public readonly ReactiveProperty<string> UserName;
    public readonly ReactiveProperty<string> Score;
    public readonly ReactiveProperty<string> OrderNumber;
    public readonly ReactiveProperty<string> PlayTime;

    public ScoreCardPanelViewModel(string orderNumber, string username, string score, string playtime)
    {
        UserName = new ReactiveProperty<string>(username).AddTo(_disposables);
        Score = new ReactiveProperty<string>(score).AddTo(_disposables);
        OrderNumber = new ReactiveProperty<string>(orderNumber).AddTo(_disposables);
        PlayTime = new ReactiveProperty<string>(playtime).AddTo(_disposables);
    }
}
