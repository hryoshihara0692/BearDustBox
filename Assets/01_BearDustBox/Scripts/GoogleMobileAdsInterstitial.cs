using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class GoogleMobileAdsInterstitial : MonoBehaviour
{
    private InterstitialAd interstitial;

    private int reShowCount;

    private void Start()
    {
        //指定の回数のときだけRequestを呼ぶ形はどうだろうか
        if (ES3.KeyExists("Play_Sum"))
        {
            if (ES3.Load<int>("Play_Sum") % 3 == 0)
            {
                RequestInterstitial();
                //ShowInterstitialAd();
            }
            else
            {
                Debug.Log("a");
                GameController.Instance.GameStart();
            }
        }
        else
        {
            GameController.Instance.GameStart();
        }
    }

    public void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-1637197251115749/1313690556";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-9039976303435151/6390636929";
#else
        string adUnitId = "unexpected_platform";
#endif
        this.interstitial = new InterstitialAd(adUnitId);
        DestroyInterstitialAd();

        //this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        interstitial.OnAdLoaded += (sender, e) => { ((InterstitialAd)sender).Show(); };
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        this.interstitial.OnAdClosed += HandleOnAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);

        //ShowInterstitialAd();
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

        //ここが広告終了の処理
        //GameStartの処理をする
        //RequestInterstitial();
        GameController.Instance.GameStart();
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

    public void ShowInterstitialAd()
    {
        //準備できてたら表示
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
            reShowCount = 0;
        }
        else
        {
            Debug.Log("だめ" + reShowCount);

            //準備できてなかったら0.1秒ごとに準備できてるか確認
            if (reShowCount < 10)
            {
                Invoke("InterstitialShow", 0.1f);
                reShowCount++;
            }
            else
            {
                //1秒たっても準備できなかったとき
                reShowCount = 0;
            }
        }
    }

    public void DestroyInterstitialAd()
    {
        interstitial.Destroy();
    }
}