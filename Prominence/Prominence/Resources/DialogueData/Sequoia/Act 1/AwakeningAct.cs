using System;
using System.Collections.Generic;
using System.Text;
using Prominence.Model;
using Prominence.Resources.DialogueData;

namespace Prominence.Resources.DialogueData.Sequoia
{
    public class AwakeningAct : ActModel
    {
        public string Name { get { return "Awakening"; } }
        public AwakeningAct() { }

        public void Initialise(string film, PlayerModel player, Action onEnter = null, Action onExit = null)
        {
            Film = film;
            Player = player;
            var incubationScene = new IncubationScene();
            var droneRoomScene = new DroneRoomScene();

            droneRoomScene.Initialise(Film, this.Name, player);
            incubationScene.Initialise(Film, this.Name, player);
            


            Scenes = new Dictionary<string, ISceneModel>()
            {
                { incubationScene.Name, incubationScene },
                { droneRoomScene.Name, droneRoomScene }
            };

            OnEnter = onEnter;
            OnExit = onExit;
        }
    }
}
