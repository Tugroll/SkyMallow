using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class Advertisement : MonoBehaviour
{

    private static Advertisement advs;

    public static Advertisement _advs
    {
        get { return advs; }
    }

    string interad = "ca-app-pub-3940256099942544/8691691433";
    InterstitialAd �nterstitial;
    bool shown;
    //BannerView bannerview;
    //string adid;

    
    private void Start()
    {
        advs = this;
        //request();
        requestInter();
       

    }

   

    //void request()
    //{
    //    adid = "ca-app-pub-3940256099942544/6300978111";

    //    AdSize adsize = new AdSize(250, 250);
    //    bannerview = new BannerView(adid, AdSize.Banner, AdPosition.Bottom);

    //    AdRequest request = new AdRequest.Builder().Build();
    //    bannerview.LoadAd(request);
    //}
    void requestInter()
    {

        �nterstitial = new InterstitialAd(interad);
        AdRequest request = new AdRequest.Builder().Build();
        �nterstitial.LoadAd(request);
    }

    public void showInters()
    {
        if (�nterstitial.IsLoaded())
        {
            �nterstitial.Show();
            
        }
        else
        {
            requestInter();
           
        }
    }


}
