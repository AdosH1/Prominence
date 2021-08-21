using Prominence.Model;
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

        private void LaunchStatView(object sender, EventArgs e)
        {
            var player = new PlayerModel();
            player.Name = "Ados";

            player.Experience = 20000;
            player.MaxHealth = 120;
            player.Health = 85;

            player.MaxEnergy = 100;
            player.Energy = 68;

            player.Strength = 1337;
            player.Magic = 7331;
            player.Speed = 1373;

            var statsModel = new StatisticsViewModel(player);
            var statsView = new StatisticsView();
            statsView.BindingContext = statsModel;

            Application.Current.MainPage.Navigation.PushModalAsync(statsView);
        }

        private void LaunchCombatView(object sender, EventArgs e)
        {
            var player = new PlayerModel();
            player.Name = "Ados";

            player.Experience = 20000;
            player.MaxHealth = 120;
            player.Health = 85;

            player.MaxEnergy = 100;
            player.Energy = 68;

            player.Strength = 1337;
            player.Magic = 7331;
            player.Speed = 1373;

            var combatModel = new CombatViewModel(player);
            var combatView = new CombatView();
            combatView.BindingContext = combatModel;

            Application.Current.MainPage.Navigation.PushModalAsync(combatView);
        }

        private void LaunchInterstitialAd(object sender, EventArgs e)
        {
            DialogueGrid.IsVisible = false;
            InterstitialAd.IsVisible = true;
        }

        private void LaunchResetSave(object sender, EventArgs e)
        {
            if(Application.Current.Properties.ContainsKey("visited"))
            {
                Application.Current.Properties.Remove("visited");
                Application.Current.SavePropertiesAsync();
            }
        }
    }
}