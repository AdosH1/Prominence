using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public enum LabelType
    {
        Dialogue,
        Button,
        Ignore
    }

    public class DialogueModel
    {
        public string Text;
        public LabelType Type = LabelType.Dialogue;
        public Func<bool> Condition;
        public Func<Task> Action;

        public DialogueModel(
            string text,
            Func<bool> condition = null,
            Func<Task> action = null)
        {
            if (condition == null)
                condition = () => { return true; };
            if (action == null)
                action = new Func<Task>(async () => { return; });

            Text = text;
            Condition = condition;
            Action = action;
        }

    }

    public class ButtonModel
    {
        public string Text;
        public LabelType Type = LabelType.Button;
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
        public string Film { get; set; }
        public string Act { get; set; }
        public string Scene { get; set; }
        public string Name { get; set; }
        public string BackgroundImage { get; set; }
        public List<DialogueModel> Dialogue { get; set; }
        public List<ButtonModel> Buttons { get; set; }

        private LocationModel _location;
        public LocationModel Location
        {
            get
            {
                if (_location == null)
                    _location = new LocationModel(Film, Act, Scene, this.Name);
                return _location;
            }
            set { _location = value; }
        }
        public string CurrentLocation
        {
            get { return Location.Location; }
        }

        /// <summary>
        /// Only use this constructor for connecting frames together (eg. construct with Name only)
        /// </summary>
        public FrameModel() { }

        public FrameModel(string film, string act, string scene, string name, string backgroundImage)
        {
            Film = film;
            Act = act;
            Scene = scene;
            Name = name;
            BackgroundImage = backgroundImage;
        }

        public void Initialise(List<DialogueModel> dialogue, List<ButtonModel> buttons)
        {
            Dialogue = dialogue;
            Buttons = buttons;
        }
    }

    public class LocationModel
    {
        public string Film { get; set; }
        public string Act { get; set; }
        public string Scene { get; set; }
        public string Frame { get; set; }
        public string Location
        {
            get
            {
                return $"{Film}-{Act}-{Scene}-{Frame}";
            }
        }

        public LocationModel(string film = null, string act = null, string scene = null, string frame = null)
        {
            Film = film;
            Act = act;
            Scene = scene;
            Frame = frame;
        }
        public LocationModel(string location)
        {
            var values = location.Split('-');
            if (values.Length >= 1) Film = values[0];
            if (values.Length >= 2) Act = values[1];
            if (values.Length >= 3) Scene = values[2];
            if (values.Length >= 4) Frame = values[3];
        }
    }

    public class SceneModel : ISceneModel
    {
        public static string Film { get; set; }
        public static string Act { get; set; }
        public static string Scene { get; set; }
        public static PlayerModel Player { get; set; }
        public Action OnEnter { get; set; }
        public Action OnExit { get; set; }
        public Dictionary<string, FrameModel> Frames { get; set; }
        public LocationModel Location()
        {
            return new LocationModel(Film, Act, Scene);
        }
    }

    public class ActModel : IActModel
    {
        public string Film { get; set; }
        public virtual string Name() { throw new Exception("Uninitialized"); }
        public PlayerModel Player { get; set; }
        public Action OnEnter { get; set; }
        public Action OnExit { get; set; }
        public Dictionary<string, ISceneModel> Scenes { get; set; }
        public LocationModel Location()
        {
            return new LocationModel(Film, this.Name());
        }
    }

    public class FilmModel : IFilmModel
    {
        public string Name { get; }
        public PlayerModel Player { get; set; }
        public Dictionary<string, IActModel> Acts { get; set; }
        public LocationModel Location()
        {
            return new LocationModel(this.Name);
        }
    }

    public interface IFrameModel
    {
        public string Film { get; set; }
        public string Act { get; set; }
        public string Scene { get; set; }
        public string Name { get; set; }
        public string BackgroundImage { get; set; }
        public List<DialogueModel> Dialogue { get; set; }
        public List<ButtonModel> Buttons { get; set; }
        public LocationModel Location { get; }
    }

    /// <summary>
    /// A collection of frames, logically grouped.
    /// </summary>
    public interface ISceneModel
    {
        public static string Film { get; set; }
        public static string Act { get; set; }
        public static string Name { get; }
        public static PlayerModel Player { get; set; }
        public Action OnEnter { get; } // Eg. change the background of the screen
        public Action OnExit { get; } // If you do any funky, non-standard things here, undo them before leaving 
        public Dictionary<string, FrameModel> Frames { get; set; } // How do we exit a scene? How do we connect these buttons to the next screen?
        public LocationModel Location();
    }

    public interface IActModel
    {
        public string Film { get; set; }
        //public string Name { get; }
        public string Name();
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
