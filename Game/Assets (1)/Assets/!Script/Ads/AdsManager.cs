using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsManager : MonoBehaviour
{
    public static AdsManager _instance;
    public InterstitialAd _intads;
    public RewardedAds _rewardedAds;
    public bool isReward;
    private void OnEnable()
    {
        
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void FncLoadInitads()
    {
        _intads.LoadAd();
    }
    public void FncShowInitads()
    {
        _intads.ShowAd();
    }

    public void FncLoadRewardads()
    {
        _rewardedAds.LoadAd();
    }
    public void FnShowRewardads()
    {
        _rewardedAds.ShowAd();
    }

}
