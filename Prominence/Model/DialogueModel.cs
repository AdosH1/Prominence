using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Prominence.Model
{
    public class DialogueModel
    {
        public string Text;
        public Func<bool> Condition;
        public Color Color;
        public TextAlignment TextAlignment;

        public DialogueModel(
            string text, 
            Func<bool> condition = null,
            Color? color = null,
            TextAlignment? textAlignment = null)
        {
            if (condition == null)
                condition = () => { return true; };
            if (color == null)
                color = Color.White;
            if (textAlignment == null)
                textAlignment = TextAlignment.Start;
            
            Text = text;
            Condition = condition;
            Color = (Color)color;
            TextAlignment = (TextAlignment)textAlignment;
        }

    }

    public class ButtonModel
    {
        public string Text;
        public string Jump; // string or int? How should we handle this?
        public Action Action;
        public Func<bool> Condition;

        public ButtonModel(string text, string jump, Func<bool> condition = null, Action action = null)
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
        public List<DialogueModel> Dialogue;
        public List<ButtonModel> Buttons;

        public FrameModel(List<DialogueModel> dialogue, List<ButtonModel> buttons)
        {
            Dialogue = dialogue;
            Buttons = buttons;
        }

    }

    /// <summary>
    /// A collection of frames, logically grouped.
    /// </summary>
    public interface SceneModel
    {
        Action OnEnter { get; } // Eg. change the background of the screen
        Action OnExit { get; } // If you do any funky, non-standard things here, undo them before leaving 
        Dictionary<string, FrameModel> Frames { get; } // How do we exit a scene? How do we connect these buttons to the next screen?

        //SceneModel(Dictionary<string, FrameModel> frames, Action onEnter = null, Action onExit = null)
        //{
        //    Frames = frames;
        //    OnEnter = onEnter;
        //    OnExit = onExit;
        //}
    }
//public abstract class SceneModel
//{
//    public Action OnEnter; // Eg. change the background of the screen
//    public Action OnExit; // If you do any funky, non-standard things here, undo them before leaving 

//    public Dictionary<string, FrameModel> Frames; // How do we exit a scene? How do we connect these buttons to the next screen?

//    public SceneModel(Dictionary<string, FrameModel> frames, Action onEnter = null, Action onExit = null)
//    {
//        Frames = frames;
//        OnEnter = onEnter;
//        OnExit = onExit;
//    }
//}

public class ActModel
    {
        public Action OnEnter;
        public Action OnExit;

        public Dictionary<string, SceneModel> Scenes;

        public ActModel(Dictionary<string, SceneModel> scenes, Action onEnter = null, Action onExit = null)
        {
            Scenes = scenes;
            OnEnter = onEnter;
            OnExit = onExit;
        }
    }

    /// <summary>
    /// A collection of scenes to create a story.
    /// </summary>
    public class FilmModel
    {
        public Dictionary<string, ActModel> Acts;

        public FilmModel(Dictionary<string, ActModel> acts)
        {
            Acts = acts;
        }
    }

}
