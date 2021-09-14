using Prominence.Contexts;
using Prominence.Controllers;
using Prominence.Model;
using Prominence.Model.Constants;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using Sequoia;

namespace Prominence.ViewModel
{
    public class MenuViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Label> Achievements { get; set; }
        private ImageSource _background { get; set; }
        public ImageSource Background
        {
            get
            {
                return _background;
            }
            set
            {
                _background = value;
                NotifyPropertyChanged("Background");
            }
        }
        private ImageSource _menuButtonImage { get; set; }
        public ImageSource MenuButtonImage
        {
            get => _menuButtonImage;
            set
            {
                _menuButtonImage = value;
                NotifyPropertyChanged("MenuButtonImage");
            }
        }

        public MenuViewModel()
        {
            GameController.MenuViewModel = this;
            MenuButtonImage = AssemblyContext.GetImageByName(Constants.Gear);
            GameController.ChangeMenuBackground(Constants.MenuScreen);
        }

        public void LoadAchievements()
        {
            Achievements = new ObservableCollection<Label>();


        }

        public void ChangeBackground(ImageSource source)
        {
            Background = source;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
