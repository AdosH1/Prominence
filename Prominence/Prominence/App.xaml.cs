using Prominence.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prominence
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new DialogueView(); //= new NavigationPage(new MainPage());
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
