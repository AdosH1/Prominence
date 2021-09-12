using Prominence.Model;
using Prominence.Model.Constants;
using Prominence.Model.Interfaces;
using Prominence.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Prominence.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DialogueView : ContentPage
    {
        public bool IsReady = false;

        public DialogueView()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            IsReady = true;
        }

        private async void LaunchInterstitialAd(object sender, EventArgs e)
        {
            await DependencyService.Get<IInterstitialAd>().Display(AdConstants.DebugInterstitialId).ConfigureAwait(true);
        }

        private async void LaunchMenuButton(object sender, EventArgs e)
        {
            var menuView = new MenuView();
            await Application.Current.MainPage.Navigation.PushModalAsync(menuView);
        }
    }
}