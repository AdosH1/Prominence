using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using Prominence.Model;
using Prominence.Resources.DialogueData.Prominence;
using Prominence.Resources.DialogueData.Sequoia;
using Prominence.View;
using Xamarin.Forms;
using Utilities;
using Prominence.Controllers;
using System.Runtime.CompilerServices;
using Prominence.Model.Constants;

namespace Prominence.ViewModel
{
    public class DialogueViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public ObservableCollection<Label> Log { get; set; }
        public ObservableCollection<Button> Buttons { get; set; }
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

        public DialogueViewModel()
        {
            Log = new ObservableCollection<Label>();
            Buttons = new ObservableCollection<Button>();

            GameController.ViewModel = this;
            GameController.ChangeBackground(SequoiaConstants.Black);
            GameController.Player = new PlayerModel("Ados");

            var seqFilm = new SequoiaFilm();
            seqFilm.Initialise(GameController.Player);
            GameController.CurrentFilm = seqFilm;

            var destinationFrame = GameController.Traverse(GameController.Player.Location);
            LoadFrame(destinationFrame);
        }

        public void ClearScreen(bool clearAll = false)
        {
            if (clearAll) {
                Log.Clear();
            }
            Buttons.Clear();
        }

        public async Task<bool> SlowlyRevealText(Label label, string text)
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

        public async void AddButtonClickedText(string text)
        {
            string breaker = "--------------------------";

            var label1 = new Label();
            label1.Text = breaker;
            label1.HorizontalTextAlignment = TextAlignment.Center;
            label1.FontSize = 12;
            label1.TextColor = Color.Black;
            Log.Add(label1);

            var label2 = new Label();
            label2.Text = text;
            label2.HorizontalTextAlignment = TextAlignment.Center;
            label2.FontSize = 12;
            label2.TextColor = Color.Red;
            Log.Add(label2);

            Log.Add(label1);
        }

        public async void LoadFrame(FrameModel frame)
        {
            ClearScreen();

            // Load dialogue
            foreach (var dialogue in frame.Dialogue)
            {
                if (dialogue.Condition())
                {
                    var label = new Label();
                    label.Text = dialogue.Text;
                    label.TextColor = dialogue.Color;
                    label.HorizontalTextAlignment = dialogue.TextAlignment;

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
        }

        public void ChangeBackground(ImageSource source)
        {
            Background = source;
        }
    }
}
