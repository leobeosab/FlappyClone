using UnityEngine;
using System.Collections;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using GoogleMobileAds.Android;

public class AdController : MonoBehaviour {

	private BannerView bannerView;
	private InterstitialAd interstitial;

	void Start()
	{
		RequestBanner ();
		RequestInterstitial ();
		bannerView.Show ();
	}


	
	private void RequestBanner()
	{
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-1991895393724672/8973896544";
		#elif UNITY_IPHONE
		string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
		#else
		string adUnitId = "unexpected_platform";
		#endif
		

		bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

		bannerView.AdFailedToLoad += HandleAdFailedToLoad;

		bannerView.LoadAd(createAdRequest());
	}
	private void RequestInterstitial()
	{
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-1991895393724672/8186664146";
		#elif UNITY_IPHONE
		string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		interstitial = new InterstitialAd(adUnitId);

		interstitial.AdFailedToLoad += HandleAdFailedToLoad;

		interstitial.LoadAd(createAdRequest());
	}
	
	private AdRequest createAdRequest()
	{
		return new AdRequest.Builder ().Build ();
			/*.AddTestDevice(AdRequest.TestDeviceSimulator)
				.AddTestDevice("4b8cd5e6094699f9")
				.Build();*/
	}
	public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		bannerView.Destroy ();
		interstitial.Destroy ();
	}
	public void GameOver()
	{
		int gameOvers = PlayerPrefs.GetInt ("gameovers");
		PlayerPrefs.SetInt ("gameovers", gameOvers + 1);
		if (gameOvers > 3) 
		{
			if (interstitial.IsLoaded())
			{
				interstitial.Show();
			}

			PlayerPrefs.SetInt ("gameovers", 0);
		}
	}
}
