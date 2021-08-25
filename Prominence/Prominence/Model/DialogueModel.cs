using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prominence.Model
{
    public class DialogueModel
    {
        public string Text;
        public Func<bool> Condition;
        public Color Color;
        public TextAlignment TextAlignment;
        public Func<Task> Action;

        public DialogueModel(
            string text,
            Func<bool> condition = null,
            Color? color = null,
            TextAlignment? textAlignment = null,
            Func<Task> action = null)
        {
            if (condition == null)
                condition = () => { return true; };
            if (color == null)
                color = Color.White;
            if (textAlignment == null)
                textAlignment = TextAlignment.Start;
            if (action == null)
                action = new Func<Task>(async () => { return; });

            Text = text;
            Condition = condition;
            Color = (Color)color;
            TextAlignment = (TextAlignment)textAlignment;
            Action = action;

        }

    }

        public class ButtonModel
    {
        public string Text;
        public FrameModel Jump;
        public Func<Task> Action;
        public Func<bool> Condition;

        public ButtonModel(string text, FrameModel jump, Func<bool> condition = null, Func<Task> action = null)
        {
            if (condition == null)
                condition = () => { return true; };

            Text = text;
            Jump = jump;
            Condition = condition;
            Action = action;
        }
    }

    /// <summary>
    /// An individual screen, displaying text and loading buttons.
    /// </summary>
    public class FrameModel
    {
        private string _name;

        public IFilmModel Film;
        public IActModel Act;
        public ISceneModel Scene;
        public string Name;
        public List<DialogueModel> Dialogue;
        public List<ButtonModel> Buttons;
        public string Location 
        { 
            get 
            { 
                return $"{Film.Name}-{Act.Name}-{Scene.Name}-{Name}"; 
            } 
        }
       

        /// <summary>
        /// Only use this constructor for connecting frames together (eg. construct with Name only)
        /// </summary>
        public FrameModel() { }

        public FrameModel(IFilmModel film, IActModel act, ISceneModel scene, string name, List<DialogueModel> dialogue, List<ButtonModel> buttons)
        {
            Film = film;
            Act = act;
            Scene = scene;
            Name = name;
            Dialogue = dialogue;
            Buttons = buttons;
        }

        public string GetLocation()
        {
            return $"{Film.Name}-{Act.Name}-{Scene.Name}-{Name}";
        }

    }

    /// <summary>
    /// A collection of frames, logically grouped.
    /// </summary>
    public interface ISceneModel
    {
        public IFilmModel Film { get; set; }
        public IActModel Act { get; set; }
        public string Name { get; }
        public PlayerModel Player { get; set; }
        public Action OnEnter { get; } // Eg. change the background of the screen
        public Action OnExit { get; } // If you do any funky, non-standard things here, undo them before leaving 
        //private Dictionary<string, FrameModel> _frames;
        public Dictionary<string, FrameModel> Frames { get; set; } // How do we exit a scene? How do we connect these buttons to the next screen?

        public string GetLocation()
        {
            return $"{Film.Name}-{Act.Name}-{Name}";
        }

    }

    public interface IActModel
    {
        public IFilmModel Film { get; set; }
        public string Name { get; }
        public PlayerModel Player { get; set; }
        public Action OnEnter { get; set; }
        public Action OnExit { get; set; }
        public Dictionary<string, ISceneModel> Scenes { get; set; }

        public string GetLocation()
        {
            return $"{Film.Name}-{Name}";
        }

    }

    /// <summary>
    /// A collection of scenes to create a story.
    /// </summary>
    public interface IFilmModel
    {
        public string Name { get; }

        public Dictionary<string, IActModel> Acts { get; set; }

        public string GetLocation()
        {
            return $"{Name}";
        }
    }

}
