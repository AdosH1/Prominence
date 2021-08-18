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

        private void Back(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}