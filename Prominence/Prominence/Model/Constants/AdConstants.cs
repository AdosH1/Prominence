using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Prominence.Model.Constants
{
    public static class AdConstants
    {
        // Ad Unit Ids (Google AdMobs) - used to identify which user/application is requesting ads
        public static readonly string InterstitialAppId = "ca-app-pub-3397582154167604/3356753204";

        // Debug Ad Unit Ids for testing (called in display function)
        public static readonly string DebugAppOpenId = "ca-app-pub-3940256099942544/3419835294";
        public static readonly string DebugBannerId = "ca-app-pub-3940256099942544/6300978111";
        public static readonly string DebugRewardedId = "ca-app-pub-3940256099942544/5224354917";
        public static readonly string DebugInterstitialId = "ca-app-pub-3940256099942544/1033173712";
        public static readonly string DebugInterstitialVideoId = "ca-app-pub-3940256099942544/8691691433";
        public static readonly string DebugInterstitialRewardedId = "ca-app-pub-3940256099942544/5354046379";
        

        public static string InterstitialAdId
        {
            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.Android:
                        return DebugInterstitialId;
                    case Device.iOS:
                        return DebugInterstitialId;
                    default:
                        return DebugInterstitialId;
                }
            }
        }


    }
}
