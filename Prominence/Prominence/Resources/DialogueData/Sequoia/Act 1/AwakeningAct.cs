using System;
using System.Collections.Generic;
using System.Text;
using Prominence.Model;
using Prominence.Resources.DialogueData;

namespace Prominence.Resources.DialogueData.Sequoia
{
    public class AwakeningAct : ActModel
    {
        public static readonly string Name = "Awakening";// { get { return "Awakening"; } }
        public static IncubationScene IncubationScene;
        public static DroneRoomScene DroneRoomScene;
        public AwakeningAct(string film, PlayerModel player) 
        {
            Film = film;
            Player = player;

            IncubationScene = new IncubationScene(film, Name, player);
            DroneRoomScene = new DroneRoomScene(film, Name, player);

            Scenes = new Dictionary<string, ISceneModel>()
            {
                { IncubationScene.Scene, IncubationScene },
                { DroneRoomScene.Scene, DroneRoomScene }
            };
        }

        public void Initialise( Action onEnter = null, Action onExit = null)
        {
            IncubationScene.Initialise();
            DroneRoomScene.Initialise();
            
            OnEnter = onEnter;
            OnExit = onExit;
        }
    }
}
