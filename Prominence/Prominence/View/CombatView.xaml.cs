using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prominence.Model;
using Prominence.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prominence.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CombatView : ContentPage
    {
        public CombatView()
        {
            InitializeComponent();
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
    }
}