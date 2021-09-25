using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using Prominence.Model;
using Prominence.View;
using Xamarin.Forms;
using Utilities;
using Prominence.Controllers;
using System.Runtime.CompilerServices;
using Prominence.Model.Constants;
using Prominence.Contexts;
using Sequoia;
using Core.Models;
using Xamarin.Essentials;

namespace Prominence.ViewModel
{
    public class DialogueViewModel : INotifyPropertyChanged
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public ObservableCollection<DialogueLabel> Log { get; set; }
        public ObservableCollection<Button> Buttons { get; set; }
        private string CurrentBackgroundImage { get; set; }
        private ImageSource _background { get; set; }
        public ImageSource Background 
        { 
            get => _background;
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
        public static Grid AchievementTab;
        public string _achievementText { get; set; }
        public string AchievementText
        {
            get => _achievementText;
            set
            {
                _achievementText = value;
                NotifyPropertyChanged("AchievementText");
            }
        }
        

        public DialogueViewModel()
        {
            Height = DeviceDisplay.MainDisplayInfo.Height;
            Width = DeviceDisplay.MainDisplayInfo.Width;

            Log = new ObservableCollection<DialogueLabel>();
            Buttons = new ObservableCollection<Button>();

            MenuButtonImage = AssemblyContext.GetImageByName(Constants.Gear);

            GameController.DialogueViewModel = this;
            GameController.User = 
                new UserModel(
                    new UserSettingsModel(),
                    new PlayerModel("Ados"),
                    Sequoia.Controller.GetAchievements()
                    );

            GameController.CurrentFilm = Sequoia.Controller.GetFilm(GameController.Player);

            var destinationFrame = GameController.Traverse(GameController.Player.Location);
            LoadFrame(destinationFrame);
        }

        public void ClearScreen(bool clearAll = false)
        {
            if (clearAll) Log.Clear();
            Buttons.Clear();
        }

        public async Task<bool> SlowlyRevealText(DialogueLabel label, string text)
        {
            var len = text.Length;
            var currString = StringFunctions.ScrambleString(text, len);

            var strBuilder = new StringBuilder(currString);

            label.Text = strBuilder.ToString(); ;
            Log.Add(label);

            for (var i = 0; i < len; i++)
            {
                strBuilder.Insert(i+1, text[i]);
                strBuilder.Remove(i, 1);

                label.Text = strBuilder.ToString();

                //await Task.Delay(10);
            }

            return true;
        }

        // TODO: Convert this to a template
        public async void AddButtonClickedText(string text)
        {
            var label1 = new DialogueLabel("----------------------------", LabelType.Ignore);
            label1.HorizontalTextAlignment = TextAlignment.Center;
            label1.FontSize = 12;
            label1.TextColor = Color.White;
            Log.Add(label1);

            var label2 = new DialogueLabel(text, LabelType.Button);
            Log.Add(label2);

            Log.Add(label1);
        }

        public async void LoadFrame(FrameModel frame)
        {
            ClearScreen();
            CheckBackground(frame.BackgroundImage);

            // Load dialogue
            foreach (var dialogue in frame.Dialogue)
            {
                if (dialogue.Condition())
                {
                    var label = new DialogueLabel(dialogue.Text, LabelType.Dialogue);
                    var result = await SlowlyRevealText(label, dialogue.Text).ConfigureAwait(true);

                    await dialogue.Action.Invoke().ConfigureAwait(false); ;
                }
            }

            // Load buttons
            foreach (var button in frame.Buttons)
            {
                if (button.Condition())
                {
                    Button btn = new Button();
                    btn.Text = button.Text;
                    Action fn = () => {

                         AddButtonClickedText(button.Text);

                         if (button.Action != null)
                             button.Action.Invoke();

                        var destinationFrame = GameController.Traverse(button.Jump);
                        LoadFrame(destinationFrame);
                    };

                    btn.Command = new Command(fn);
                    Buttons.Add(btn);
                }
            }

            // Set player visited
            // I'd love to take this logic out - but visited must be done after frame is loaded, otherwise conditional dialogue logic does not work 
            GameController.Visited(frame);
        }

        public void CheckBackground(string backgroundImage)
        {
            if (CurrentBackgroundImage != backgroundImage)
                GameController.ChangeDialogueBackground(backgroundImage);
        }

        public void ChangeBackground(ImageSource source)
        {
            Background = source;
        }

        public async void ShowAchievement(string text)
        {
            AchievementText = text;

            AchievementTab.TranslateTo(0, 0);
            await Task.Delay(2000);
            AchievementTab.TranslateTo(0, -100);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
