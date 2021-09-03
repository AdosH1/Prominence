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

            //MainPage = new NavigationPage(new MainPage());
            MainPage = new DialogueView();
            var test = GetImageByName("Sequoia.ComputerRoom");
            MainPage.BackgroundImageSource = test;

        }

        public static ImageSource GetImageByName(string imageName)
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            string resourceName = asm.GetName().Name + ".Properties.Resources";
            var rm = new System.Resources.ResourceManager(resourceName, asm);
            var tt = (byte[])rm.GetObject(imageName);

            var imSrc = ImageSource.FromStream(() => new MemoryStream(tt));

            return imSrc;
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
