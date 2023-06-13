using GoogleMobileAds.Api;
using UnityEngine;

public class Banner : MonoBehaviour
{
#if UNITY_ANDROID
    private const string AdUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
    private const string AdUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
    private const string AdUnitId = "unexpected_platform";
#endif

    private BannerView _bannerView;

    public void Start()
    {
        // アプリを起動した後に一度だけ実行する
        MobileAds.Initialize(initStatus => { });

        RequestBanner();
    }

    private void RequestBanner()
    {
        // 前のBannerViewのインスタンスが残っていたら破棄する
        if (_bannerView != null)
        {
            _bannerView.Destroy();
            _bannerView = null;
        }

        // 新しいバナー広告を作成・表示する
        _bannerView = new BannerView(AdUnitId, AdSize.Banner, AdPosition.Bottom);
        var request = new AdRequest.Builder().Build();
        _bannerView.LoadAd(request);
    }

    private void OnDestroy()
    {
        // バナー広告を破棄するときは必ずDestoryしないと、メモリリークするようです
        _bannerView?.Destroy();
    }
}