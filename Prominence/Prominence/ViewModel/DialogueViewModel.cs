using Prominence.Model;
using Prominence.Resources.DialogueData.Sequoia;
using Prominence.Controllers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prominence.ViewModel
{
    public class DialogueViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public IFilmModel CurrentFilm;
        public IActModel CurrentAct;
        public ISceneModel CurrentScene;
        public FrameModel CurrentFrame;
        public PlayerModel Player;
        public SaveData SaveController;
        public SaveState CurrentSave;

        public ObservableCollection<Label> Log { get; set; }
        public ObservableCollection<Button> Buttons { get; set; }

        char[] superthinChars = new char[] { 'f', 'i', 'j', 'l', 'r', 't', '!', '(', ')', '-', '*', '^', '/', '\\', '|', '{', '}', '[', ']', ';', ':', '\'', '"', ',', '.', '/', '?', '`', '~', ' ', '\n' };
        char[] thinChars = new char[] { 'a', 'c', 'd', 'e',  'n', 'o',  's', 'u', 'v',  'x', 'y', 'z', 'b',  'g', 'h',  'k', 'p', 'q', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        char[] medChars = new char[] {
                'm','w',
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'N', 'O', 'P', 'R', 'S', 'T', 'U', 'V', 'Y',
                '$', '%', '&', '=', '_', '+', '<', '>'};
        char[] largeChars = new char[] { 'M', '@', '#', 'Q', 'W', 'X', 'Z' };

        public PlayerModel CreateBasePlayer()
        {
            var player = new PlayerModel();
            player.Name = "Ados";
            player.Strength = 1;
            player.Magic = 1;
            player.Speed= 1;

            

            return player;
        }

        public DialogueViewModel()
        {
            Log = new ObservableCollection<Label>();
            Buttons = new ObservableCollection<Button>();

            Player = CreateBasePlayer();
            SaveController = new SaveData();

            var promFilm = new ProminenceFilm();
            promFilm.Initialise(Player);
            CurrentFilm = promFilm;//SequoiaFilm.Sequoia;
            //ProminenceFilm.Player = Player;
            
            //Let's load the saved game
            if(Application.Current.Properties.ContainsKey(Player.Name))
            {
                CurrentSave = SaveController.LoadFromDisc<SaveState>(Player.Name);
                if(CurrentSave.Log != null)
                {
                    Log.Clear();
                    foreach(var item in CurrentSave.Log)
                    {
                        Log.Add(item);
                    }
                }
                
                if(CurrentSave.CurrentFrame != null)
                {
                    //Traverse(CurrentSave.CurrentFrame);
                    Traverse(null);
                }
                else
                {
                    Traverse(null);
                }
            }
            else
            {
                CurrentSave = new SaveState(player: Player.Name, film: CurrentFilm.Name);
                Traverse(null);
            }
            //if(Application.Current.Properties.ContainsKey("visited"))
            //{
            //    string[] visitedList = ((string)Application.Current.Properties["visited"]).Split(",");

            //    for (int i = visitedList.Length - 1; i >= 0; i--)
            //    {
            //        FrameModel currentFrame = getFrameModel(CurrentFilm, visitedList[i]);
            //        if (currentFrame != null)
            //        {
            //            CurrentFilm = currentFrame.Film;
            //            CurrentAct = currentFrame.Act;
            //            CurrentScene = currentFrame.Scene;
            //            CurrentFrame = currentFrame;
            //            break;
            //        }
            //    }

            //    Array.Resize(ref visitedList, visitedList.Length - 1);
            //    Application.Current.Properties["visited"] = string.Join(",", visitedList);
            //    Application.Current.SavePropertiesAsync();

            //    foreach (string frameName in visitedList)
            //    {
            //        if(getFrameModel(CurrentFilm, frameName) != null)
            //        {
            //            renderFrameText(getFrameModel(CurrentFilm, frameName), false);
            //        }
            //    }
                
            //}

           
            //if (CurrentFrame != null)
            //{
            //    Traverse(CurrentFrame.Name);
            //}
            //else
            //{
            //    Traverse(null);
            //}
            
        }


        public FrameModel getFrameModel(IFilmModel film, string frameName)
        {
            foreach(KeyValuePair<string, IActModel> act in film.Acts)
            {
                foreach(KeyValuePair<string, ISceneModel> scene in act.Value.Scenes)
                {
                    foreach(KeyValuePair<string, FrameModel> frame in scene.Value.Frames)
                    {
                        if(frame.Value.Name == frameName)
                        {
                            return frame.Value;
                        }
                    }
                }
            }
            return null;
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

                await Task.Delay(10);

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

        public void SetScene(ISceneModel scene)
        {
            if (CurrentScene != null) {
                if (CurrentScene.OnExit != null)
                    CurrentScene.OnExit.Invoke();
            }
                
            CurrentScene = scene;

            if (CurrentScene.OnEnter != null)
                CurrentScene.OnEnter.Invoke();
        }

        public void SetAct(IActModel act)
        {
            if (act.Player == null) act.Player = Player;

            if (CurrentAct != null) {
                if (CurrentAct.OnExit != null)
                    CurrentAct.OnExit.Invoke();
            }

            CurrentAct = act;

            if (CurrentAct.OnEnter != null) 
                CurrentAct.OnEnter.Invoke();
            
        }

        public void Visited(FrameModel frame)
        {
            if (!Player.Visited.Contains(frame.Name))            
                Player.Visited.Add(frame.Name);
        }

        public async void renderFrameText(FrameModel Frame, bool renderSlowly = true)
        {
            ClearScreen();
            foreach (var dialogue in Frame.Dialogue)
            {
                if (dialogue.Condition())
                {
                    var label = new Label();
                    label.Text = dialogue.Text;
                    label.TextColor = dialogue.Color;
                    label.HorizontalTextAlignment = dialogue.TextAlignment;

                    var result = SlowlyRevealText(label, dialogue.Text).ConfigureAwait(true);
                    await dialogue.Action.Invoke().ConfigureAwait(false);
                    
                }
            }
        }

        public async void LoadFrame(FrameModel Frame)
        {
            ClearScreen();

            Visited(Frame);
            //if(!Application.Current.Properties.ContainsKey("visited"))
            //{
            //    Application.Current.Properties["visited"] = Frame.Name;
            //}
            //else
            //{
            //    string visitedList = Application.Current.Properties["visited"] as string;
            //    Application.Current.Properties["visited"] = string.Concat(visitedList, ",", Frame.Name);
            //}
            
            //Application.Current.SavePropertiesAsync();
            CurrentFrame = Frame;
            renderFrameText(CurrentFrame);
            // Load dialogue
            CurrentSave.UpdateSaveState(player: Player.Name, film: CurrentFilm.Name, act: CurrentAct.Name, scene: CurrentScene.Name, frame: CurrentFrame.Name, log: Log);
            SaveController.SaveToDisc<SaveState>(CurrentSave.playerName, CurrentSave);
            
            

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
            
            Player.AddVisited($"{Frame.Film.Name}-{Frame.Act.Name}-{Frame.Scene.Name}-{Frame.Name}");
        }

        public bool TraverseScene(ISceneModel scene, string location = null)
        {
            if (scene == null) 
                return false;

            // If no location, load first frame in scene
            if (location == null)
            {
                //var test = scene.Frames;
                //var test2 = scene.Frames.Keys;
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

        public bool TraverseAct(IActModel act, string location = null)
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

        public bool TraverseFilm(IFilmModel film, string location)
        {
            if (film == null)
                return false;

            // If no location, load first act in film
            if (location == null)
            {
                var firstAct = film.Acts.Keys.First();
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
