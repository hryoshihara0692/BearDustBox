using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class Interstitial : MonoBehaviour
{
    private InterstitialAd interstitial;

    private void Start()
    {
        RequestInterstitial();
        if (ES3.KeyExists("Play_Sum"))
        {
            if (ES3.Load<int>("Play_Sum") % 3 == 0)
            {
                ShowInterstitialAd();
            }
        }
    }

    public void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-1637197251115749/1313690556";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif
        this.interstitial = new InterstitialAd(adUnitId);
        DestroyInterstitialAd();

        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        this.interstitial.OnAdClosed += HandleOnAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
        RequestInterstitial();
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

    public void ShowInterstitialAd()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
        else
        {
            Debug.Log("まだ読み込みができていない");
        }
    }

    public void DestroyInterstitialAd()
    {
        interstitial.Destroy();
    }
}