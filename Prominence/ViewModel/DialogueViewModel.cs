using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using Prominence.Model;
using Prominence.Resources.DialogueData.Sequoia;
using Prominence.View;
using Xamarin.Forms;

namespace Prominence.ViewModel
{
    public class DialogueViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public FilmModel CurrentFilm;
        public ActModel CurrentAct;
        public SceneModel CurrentScene;
        public FrameModel CurrentFrame;

        public ObservableCollection<Label> Log { get; set; }
        public ObservableCollection<Button> Buttons { get; set; }

        char[] superthinChars = new char[] { 'f', 'i', 'j', 'l', 'r', 't', '!', '(', ')', '-', '*', '^', '/', '\\', '|', '{', '}', '[', ']', ';', ':', '\'', '"', ',', '.', '/', '?', '`', '~', ' ', '\n' };
        char[] thinChars = new char[] { 'a', 'c', 'd', 'e',  'n', 'o',  's', 'u', 'v',  'x', 'y', 'z', 'b',  'g', 'h',  'k', 'p', 'q' };
        char[] medChars = new char[] {
                'm','w',
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'N', 'O', 'P', 'R', 'S', 'T', 'U', 'V', 'Y',
                '$', '%', '&', '=', '_', '+', '<', '>'};
        char[] largeChars = new char[] { 'M', '@', '#', 'Q', 'W', 'X', 'Z' };


        public DialogueViewModel()
        {
            Log = new ObservableCollection<Label>();
            Buttons = new ObservableCollection<Button>();

            CurrentFilm = SequoiaFilm.Sequoia;
            Traverse(null);
        }

        public void ClearScreen(bool clearAll = false)
        {
            if (clearAll) {
                Log.Clear();
            }
            Buttons.Clear();
        }

        public string GetSmartScrambleString(string text, int length)
        {

            var numIndicesSuperThin = superthinChars.Length - 1;
            var numIndicesThin = thinChars.Length - 1;
            var numIndicesMed = medChars.Length - 1;
            var numIndicesLarge = largeChars.Length - 1;

            var scrambledString = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                if (superthinChars.Contains(text[i]))
                {
                    scrambledString.Append(superthinChars[random.Next(0, numIndicesSuperThin)]);
                    continue;
                }
                if (thinChars.Contains(text[i]))
                {
                    scrambledString.Append(thinChars[random.Next(0, numIndicesThin)]);
                    continue;
                }
                if (medChars.Contains(text[i]))
                {
                    scrambledString.Append(medChars[random.Next(0, numIndicesMed)]);
                    continue;
                }
                if (largeChars.Contains(text[i]))
                {
                    scrambledString.Append(largeChars[random.Next(0, numIndicesLarge)]);
                    continue;
                }
                Console.WriteLine($"I missed a character {text[i]}");
            }

            return scrambledString.ToString();
        }

        public string GetScrambleString(int length)
        {
            var chars = new char[] {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                '@', '!', '#', '$', '%', '^', '&', '*', '(', ')', '-', '=', '_', '+', '/', '\\', '|', '{', '}', '[', ']', ';', ':', '\'', '"', ',', '<', '.', '>', '/', '?', '`', '~'};

            var numChars = chars.Length;
            var numIndices = numChars - 1;

            var scrambledString = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < length; i++) {
                scrambledString.Append(chars[random.Next(0, numIndices)]);
            }

            return scrambledString.ToString();
        }

        public async Task<bool> SlowlyRevealText(Label label, string text)
        {
            var len = text.Length;
            //var currString = GetScrambleString(len);
            var currString = GetSmartScrambleString(text, len);

            var strBuilder = new StringBuilder(currString);

            label.Text = strBuilder.ToString(); ;
            Log.Add(label);

            for (var i = 0; i < len; i++)
            {
                strBuilder.Insert(i+1, text[i]);
                strBuilder.Remove(i, 1);

                label.Text = strBuilder.ToString();

                await Task.Delay(5);
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
            //var result = await SlowlyRevealText(label2, text);
            Log.Add(label2);

            Log.Add(label1);
            
        }

        public void SetScene(SceneModel scene)
        {
            if (CurrentScene != null) {
                if (CurrentScene.OnExit != null)
                    CurrentScene.OnExit.Invoke();
            }
                
            CurrentScene = scene;

            if (CurrentScene.OnEnter != null)
                CurrentScene.OnEnter.Invoke();
        }

        public void SetAct(ActModel act)
        {
            if (CurrentAct != null) {
                if (CurrentAct.OnExit != null)
                    CurrentAct.OnExit.Invoke();
            }

            CurrentAct = act;

            if (CurrentAct.OnEnter != null) 
                CurrentAct.OnEnter.Invoke();
            
        }

        public async void LoadFrame(FrameModel Frame)
        {
            ClearScreen();

            CurrentFrame = Frame;
            // Load dialogue
            foreach (var dialogue in Frame.Dialogue)
            {
                if (dialogue.Condition())
                {
                    var label = new Label();
                    label.Text = dialogue.Text;
                    label.TextColor = dialogue.Color;
                    label.HorizontalTextAlignment = dialogue.TextAlignment;

                    var result = await SlowlyRevealText(label, dialogue.Text).ConfigureAwait(true);
                    //Log.Add(label);
                }
            }

            // Load buttons
            foreach (var button in Frame.Buttons)
            {
                if (button.Condition())
                {
                    Button btn = new Button();
                    btn.Text = button.Text;
                    Action fn = () => {

                         AddButtonClickedText(button.Text);

                         if (button.Action != null)
                             button.Action.Invoke();

                         Traverse(button.Jump);
                    };

                    btn.Command = new Command(fn);
                    Buttons.Add(btn);
                }
            }
        }

        public bool TraverseScene(SceneModel scene, string location = null)
        {
            if (scene == null) 
                return false;

            // If no location, load first frame in scene
            if (location == null)
            {
                var firstFrame = scene.Frames.Keys.First();
                SetScene(scene);
                LoadFrame(scene.Frames[firstFrame]);
                return true;
            }

            foreach (var frame in scene.Frames.Keys)
            {
                if (frame == location)
                {
                    SetScene(scene);
                    LoadFrame(scene.Frames[frame]);
                    return true;
                }
            }
            return false;
        }

        public bool TraverseAct(ActModel act, string location = null)
        {
            if (act == null)
                return false;

            // If no location, load first scene in act
            if (location == null)
            {
                var firstScene = act.Scenes.Keys.First();
                SetAct(act);
                TraverseScene(act.Scenes[firstScene]);
                return true;
            }

            foreach (var scene in act.Scenes.Keys)
            {
                if (scene == location)
                {
                    SetAct(act);
                    var firstScene = act.Scenes.Keys.First();
                    TraverseScene(act.Scenes[firstScene], location);
                    return true;
                }

                if (TraverseScene(act.Scenes[scene], location))
                    return true;
            }

            return false;
        }

        public bool TraverseFilm(FilmModel film, string location)
        {
            if (film == null)
                return false;

            // If no location, load first act in film
            if (location == null)
            {
                var firstAct= film.Acts.Keys.First();
                CurrentFilm = film;
                TraverseAct(film.Acts[firstAct]);
                return true;
            }

            foreach (var act in film.Acts.Keys)
            {
                if (act == location)
                {
                    CurrentFilm = film;
                    var firstAct = film.Acts.Keys.First();
                    TraverseAct(film.Acts[firstAct], location);
                    return true;
                }

                if (TraverseAct(film.Acts[act], location))
                    return true;
            }

            return false;
        }

        public bool Traverse(string location)
        {
            // Attempt to find frame in current scene
            if (TraverseScene(CurrentScene, location))
                return true;

            // Attempt to find scene in current act, or frame in any child
            if (TraverseAct(CurrentAct, location))
                return true;

            // Attempt to find act in film, or scene / frame in any child
            if (TraverseFilm(CurrentFilm, location))
                return true;

            return false;
        }

    }
}
