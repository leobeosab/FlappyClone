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
		
		// Create a 320x50 banner at the top of the screen.
		bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);
		// Register for ad events.

		// Load a banner ad.
		bannerView.LoadAd(createAdRequest());
	}

	// Returns an ad request with custom ad targeting.
	private AdRequest createAdRequest()
	{
		return new AdRequest.Builder()
			.AddTestDevice(AdRequest.TestDeviceSimulator)
				.AddTestDevice("4b8cd5e6094699f9")
				.Build();
		
	}
}
