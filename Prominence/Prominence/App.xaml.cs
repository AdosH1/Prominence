﻿using Prominence.Contexts;
using Prominence.Controllers;
using Prominence.Model.Constants;
using Prominence.View;
using System;
using System.Drawing;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prominence
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            AssemblyContext.Initialise();
            MainPage = new DialogueView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
