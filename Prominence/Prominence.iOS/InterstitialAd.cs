﻿using Foundation;
using Google.MobileAds;
using Prominence.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;

namespace Prominence.iOS
{
    class InterstitialAd : IInterstitialAd
    {
        public Task Display(string adId)
        {
            TaskCompletionSource<bool> displayAdTask = new TaskCompletionSource<bool>();
            Interstitial interstitial = new Interstitial(adId);

            interstitial.AdReceived += (sender, args) =>
            {
                if (interstitial.IsReady)
                {
                    var keyWindow = UIApplication.SharedApplication.KeyWindow;
                    var rootViewController = keyWindow.RootViewController;
                    while (rootViewController.PresentedViewController != null)
                    {
                        rootViewController = rootViewController.PresentedViewController;
                    }
                    interstitial.PresentFromRootViewController(rootViewController);
                }
            };

            interstitial.ScreenDismissed += (sender, e) =>
            {
                if (displayAdTask != null)
                {
                    displayAdTask.TrySetResult(interstitial.IsReady);
                    displayAdTask = null;
                }
            };

            interstitial.ReceiveAdFailed += (sender, e) =>
            {
                displayAdTask.TrySetResult(false);
                displayAdTask.TrySetCanceled();
                displayAdTask = null;
            };

            var request = Request.GetDefaultRequest();
            interstitial.LoadRequest(request);
            return Task.WhenAll(displayAdTask.Task);
        }
    }
}