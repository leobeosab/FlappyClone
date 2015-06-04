package com.some_company.plugin;

import com.qwapi.adclient.android.data.Ad;
import com.qwapi.adclient.android.data.Status;
import com.qwapi.adclient.android.requestparams.*;
import com.qwapi.adclient.android.view.QWAdView;

import com.admob.android.ads.AdView;
import com.admob.android.ads.SimpleAdListener;
import com.admob.android.ads.AdManager;

import com.unity3d.player.UnityPlayerActivity;

import android.content.Context;
import android.os.Bundle;
import android.util.Log;
import android.view.Gravity;
import android.view.ViewGroup.LayoutParams;
import android.widget.RelativeLayout;

// Both AdMob and Quattro Wireless (and this activity) dumps information to the 'logcat'.
// Please inspect it using 'adb logcat' from the command line/terminal, to track down faulty behavior.

public class AdPluginActivity extends UnityPlayerActivity
{
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setupAds();
    }
    
    final private boolean useQWads = true;
    final private boolean gravityBottom = true;

    private void setupAds()
    {
    	RelativeLayout layout = new RelativeLayout(this);
        addContentView(layout, new LayoutParams(LayoutParams.FILL_PARENT,LayoutParams.FILL_PARENT));

		if (gravityBottom)
			layout.setGravity(Gravity.BOTTOM);
    	
    	if (useQWads)
        {
			// This code uses test/demo ids as shown in the Quattro Wireless samples.
			// Please read http://wiki.quattrowireless.com/index.php/Android for further info
			// on how to substitute the site/publisher ids.
	        QWAdView adView = new QWAdView(
				this,
				"Quattro_Wireless_Demo",
				"c3d598cf86144bd4b6e957011336a46e",
				MediaType.banner,
				Placement.bottom,
				DisplayMode.autoRotate, 
				15, 
				AnimationType.slide, 
				new com.qwapi.adclient.android.view.AdEventsListener()
				{
					public void onAdClick(Context ctx, Ad ad) {
						Log.d("AdEventsListener","onAdClick for Ad: " + ad.getAdType() + " : " + ad.getId());
					}

					public void onAdRequest(Context ctx, AdRequestParams params) {
						Log.d("AdEventsListener","onAdRequest for RequestParams: " + params.toString());
					}

					public void onAdRequestFailed(Context ctx, AdRequestParams params, Status status) {
						Log.d("AdEventsListener","onAdRequestFailed for RequestParams: " + params.toString() + " : " + status);	
					}

					public void onAdRequestSuccessful(Context ctx, AdRequestParams params, Ad ad) {
						Log.d("AdEventsListener","onAdRequestSuccessful for RequestParams: " + params.toString() + " : Ad: " + ad.getAdType() + " : " + ad.getId());
					}

					public void onDisplayAd(Context ctx, Ad ad) {
						Log.d("AdEventsListener", "onDisplayAd for Ad: " + ad.getAdType() + " : " + ad.getId());
					}
				}, 
				true );
	        layout.addView(adView);
        }
    	else
        {
			// Please read http://developer.admob.com/wiki/Android before trying this code,
			// especially the part about how to use test mode, and add test devices (below).
			// Also, a valid publisher id is needed, even in test mode it seems.
	        AdView adView = new AdView(this);
	        adView.setAdListener( new SimpleAdListener()
	        {
	    		public void onFailedToReceiveAd(com.admob.android.ads.AdView adView)
	    		{
	    			Log.d("AdListener", "onFailedToReceiveAd: " + adView.toString());
	    			super.onFailedToReceiveAd(adView);
	    		}

	    		public void onFailedToReceiveRefreshedAd(com.admob.android.ads.AdView adView)
	    		{
	    			Log.d("AdListener", "onFailedToReceiveRefreshedAd: " + adView.toString());
	    			super.onFailedToReceiveRefreshedAd(adView);
	    		}

	    		public void onReceiveAd(com.admob.android.ads.AdView adView)
	    		{
	    			Log.d("AdListener", "onReceiveAd: " + adView.toString());
	    			super.onReceiveAd(adView);
	    		}

	    		public void onReceiveRefreshedAd(com.admob.android.ads.AdView adView)
	    		{
	    			Log.d("AdListener", "onReceiveRefreshedAd: " + adView.toString());
	    			super.onReceiveRefreshedAd(adView);
	    		}
	        } );
	        adView.setBackgroundColor(0xff000000);
	        adView.setPrimaryTextColor(0xffffffff); 
	        adView.setSecondaryTextColor(0xffcccccc);
	        adView.setKeywords("Android game");
	        adView.setRequestInterval(15);
	        adView.setVisibility(android.view.View.VISIBLE);
	        adView.requestFreshAd();

//	        AdManager.setTestDevices( new String[] { "<add test device ids here>" } );
//	        AdManager.setPublisherId( "<add publisher id here>" );

			layout.addView(adView);
        }
    }
}
