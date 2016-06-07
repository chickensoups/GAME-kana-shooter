using UnityEngine;
using GoogleMobileAds.Api;
using System.Collections;

public class GoogleAdsController
{

    public static void RequestBanner()
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-7850062606973101/3817276274";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Create a 320x50 banner at the top of the screen.
        BannerView bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
        AdRequest request = new AdRequest.Builder().Build();
        //// Create an empty ad request.
        //AdRequest request = new AdRequest.Builder()
        //                        .AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
        //                        .AddTestDevice("47393342C58D9E66AEFA7643876CDF69")  // My test device.
        //                        .Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);
    }

}
