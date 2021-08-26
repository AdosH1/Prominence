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
        public LocationModel Jump;
        public Func<Task> Action;
        public Func<bool> Condition;

        public ButtonModel(string text, FrameModel jump, Func<bool> condition = null, Func<Task> action = null)
        {
            if (condition == null)
                condition = () => { return true; };

            Text = text;
            Jump = jump.Location;
            Condition = condition;
            Action = action;
        }
     }

    /// <summary>
    /// An individual screen, displaying text and loading buttons.
    /// </summary>
    public class FrameModel : IFrameModel
    {
        public IFilmModel Film { get; set; }
        public IActModel Act { get; set; }
        public ISceneModel Scene { get; set; }
        public string Name { get; set; }
        public List<DialogueModel> Dialogue { get; set; }
        public List<ButtonModel> Buttons { get; set; }
        public LocationModel Location
        {
            get
            {
                return new LocationModel(Film, Act, Scene, this);
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
    }

    public class LocationModel
    {
        public string Film;
        public string Act;
        public string Scene;
        public string Frame;
        public string Location
        {
            get
            {
                return $"{Film}-{Act}-{Scene}-{Frame}";
            }
            set
            {
                var values = value.Split('-');
                if (values.Length >= 1) Film = values[0];
                if (values.Length >= 2) Act = values[1];
                if (values.Length >= 3) Scene = values[2];
                if (values.Length >= 4) Frame = values[3];
            }
        }

        public LocationModel(IFilmModel film = null, IActModel act = null, ISceneModel scene = null, IFrameModel frame = null)
        {
            Film = film != null ? film.Name : null;
            Act = act != null ? act.Name : null;
            Scene = scene != null ? scene.Name : null;
            Frame = frame != null ? frame.Name : null;
        }
    }

    public class SceneModel : ISceneModel
    {
        public IFilmModel Film { get; set; }
        public IActModel Act { get; set; }
        public string Name { get; set; }
        public PlayerModel Player { get; set; }
        public Action OnEnter { get; set; }
        public Action OnExit { get; set; }
        public Dictionary<string, FrameModel> Frames { get; set; }
        public LocationModel Location()
        {
            return new LocationModel(Film, Act, this);
        }
    }

    public class ActModel : IActModel
    {
        public IFilmModel Film { get; set; }
        public string Name { get; }
        public PlayerModel Player { get; set; }
        public Action OnEnter { get; set; }
        public Action OnExit { get; set; }
        public Dictionary<string, ISceneModel> Scenes { get; set; }
        public LocationModel Location()
        {
            return new LocationModel(Film, this);
        }
    }

    public class FilmModel : IFilmModel
    {
        public string Name { get; }
        public PlayerModel Player { get; set; }
        public Dictionary<string, IActModel> Acts { get; set; }
        public LocationModel Location()
        {
            return new LocationModel(this);
        }
    }

    public interface IFrameModel
    {
        public IFilmModel Film { get; set; }
        public IActModel Act { get; set; }
        public ISceneModel Scene { get; set; }
        public string Name { get; set; }
        public List<DialogueModel> Dialogue { get; set; }
        public List<ButtonModel> Buttons { get; set; }
        public LocationModel Location { get; }
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
        public LocationModel Location();
    }

    public interface IActModel
    {
        public IFilmModel Film { get; set; }
        public string Name { get; }
        public PlayerModel Player { get; set; }
        public Action OnEnter { get; set; }
        public Action OnExit { get; set; }
        public Dictionary<string, ISceneModel> Scenes { get; set; }
        public LocationModel Location();

    }

    /// <summary>
    /// A collection of scenes to create a story.
    /// </summary>
    public interface IFilmModel
    {
        public string Name { get; }
        public Dictionary<string, IActModel> Acts { get; set; }
        public LocationModel Location();
    }

}
