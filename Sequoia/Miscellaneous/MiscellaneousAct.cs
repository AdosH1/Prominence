using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Sequoia
{
    public class MiscellaneousAct : ActModel
    {
        public static readonly string Name = "Miscellaneous";
        public static IncubationScene IncubationScene;
        public MiscellaneousAct(string film, PlayerModel player)
        {
            Film = film;
            Player = player;

            IncubationScene = new IncubationScene(film, Name, player);

            Scenes = new Dictionary<string, ISceneModel>()
            {
                { IncubationScene.Scene, IncubationScene },
            };
        }

        public void Initialise(Action onEnter = null, Action onExit = null)
        {
            IncubationScene.Initialise();

            OnEnter = onEnter;
            OnExit = onExit;
        }
    }
}
