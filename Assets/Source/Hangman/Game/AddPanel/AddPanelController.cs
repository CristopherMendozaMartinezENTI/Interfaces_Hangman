using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine.UI;
using System;

public class AddPanelController : Controller
{
    private RewardedAd rewardedAd;
    private readonly AddPanelViewModel _addPanelviewModel;
    private readonly GamePanelViewModel _gamePanelViewModel;
   
    public AddPanelController(AddPanelViewModel viewModel, GamePanelViewModel gamePanelViewModel)
    {
        _addPanelviewModel = viewModel;
        _gamePanelViewModel = gamePanelViewModel;

        _addPanelviewModel
            .WatchAdddPressed
            .Subscribe((_) => {
                OnWatchAdd();
            })
            .AddTo(_disposables);

        _addPanelviewModel
            .TryAgainPressed
            .Subscribe((_) => {
                ServiceLocator.Instance.GetService<SceneHandlerService>().LoadScene("Game");
            })
            .AddTo(_disposables);

        _addPanelviewModel
            .ToMenuPressed
            .Subscribe((_) => {
                ServiceLocator.Instance.GetService<SceneHandlerService>().LoadScene("Menu");
            })
            .AddTo(_disposables);
    }

    

    void OnWatchAdd()
    {
        rewardedAd = new RewardedAd("ca-app-pub-8382896161792402/1619404122"); //Esta es la ip del bloque de anuncion creada. 

        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        //this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);

        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);

        PlayerPrefs.SetInt(Constants.STRING_TRIES, Constants.INT_EXTRATRIES);
        _gamePanelViewModel.Tries.Value = Constants.INT_EXTRATRIES;

        _addPanelviewModel.IsVisible.Value = false;
    }
}
