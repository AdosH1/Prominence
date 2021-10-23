using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace Prominence.iOS
{
    /// TODO: Implement splash screen
    /// Follow this (I think it needs a Macbook (xcode)): https://www.c-sharpcorner.com/article/creating-a-splash-screen-in-xamarin-forms/
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}
