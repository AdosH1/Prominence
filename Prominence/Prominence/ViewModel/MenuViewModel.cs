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
using Core.Models;

namespace Prominence.ViewModel
{
    public class MenuViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Achievement> Achievements { get; set; }
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

        private Command _teleporterCmd { get; set; }
        public Command TeleporterCmd
        {
            get => _teleporterCmd;
            set
            {
                _teleporterCmd = value;
                NotifyPropertyChanged("TeleporterCmd");
            }
        }

        private Command _closeMenuCmd { get; set; }
        public Command CloseMenuCmd
        {
            get => _closeMenuCmd;
            set
            {
                _closeMenuCmd = value;
                NotifyPropertyChanged("CloseMenuCmd");
            }
        }

        public MenuViewModel()
        {
            GameController.MenuViewModel = this;
            MenuButtonImage = AssemblyContext.GetImageByName(Constants.Gear);
            GameController.ChangeMenuBackground(Constants.MenuScreen);
            TeleporterCmd = new Command(async () =>
            {
                GameController.DialogueViewModel.Log.Clear();
                var tp = GameController.Traverse(GameController.TeleporterLocation);
                GameController.DialogueViewModel.LoadFrame(tp);
                await Application.Current.MainPage.Navigation.PopModalAsync();
            });
            CloseMenuCmd = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PopModalAsync();
            });

            LoadAchievements();
        }

        public void LoadAchievements()
        {
            Achievements = new ObservableCollection<Achievement>();
            foreach (var achievement in GameController.User.AchievementsModel.Achievements)
            {
                Achievements.Add(achievement.Value);
            }
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
