using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Sequoia
{
    public class AwakeningAct : ActModel
    {
        public override string Name() { return "Awakening";  }
        public static IncubationScene IncubationScene;
        public static DroneRoomScene DroneRoomScene;
        public static ComputerRoomScene ComputerRoomScene;
        public static RnDScene RnDScene;
        public AwakeningAct(string film, PlayerModel player)
        {
            Film = film;
            Player = player;

            IncubationScene = new IncubationScene(film, Name(), player);
            DroneRoomScene = new DroneRoomScene(film, Name(), player);
            ComputerRoomScene = new ComputerRoomScene(film, Name(), player);
            RnDScene = new RnDScene(film, Name(), player);

            Scenes = new Dictionary<string, ISceneModel>()
            {
                { IncubationScene.Scene, IncubationScene },
                { DroneRoomScene.Scene, DroneRoomScene },
                { ComputerRoomScene.Scene, ComputerRoomScene },
                { RnDScene.Scene, RnDScene }
            };
        }

        public void Initialise(Action onEnter = null, Action onExit = null)
        {
            IncubationScene.Initialise();
            DroneRoomScene.Initialise();
            ComputerRoomScene.Initialise();
            RnDScene.Initialise();

            OnEnter = onEnter;
            OnExit = onExit;
        }
    }
}
