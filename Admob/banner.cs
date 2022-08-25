using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
public class banner : MonoBehaviour
{
    BannerView bannerview;
    string adid;
    void Start()
    {
        request();
    }

    // Update is called once per frame
    void request()
    {
        adid = "ca-app-pub-3940256099942544/6300978111";

        AdSize adsize = new AdSize(250, 250);
        bannerview = new BannerView(adid, AdSize.Banner, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().Build();
        bannerview.LoadAd(request);
    }
}
