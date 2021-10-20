using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Sequoia
{
    public class MiscellaneousAct : ActModel
    {
        public static readonly string Name = "Miscellaneous";
        public static MiscellaneousScene MiscellaneousScene;
        public MiscellaneousAct(string film, PlayerModel player)
        {
            Film = film;
            Player = player;

            MiscellaneousScene = new MiscellaneousScene(film, Name, player);

            Scenes = new Dictionary<string, ISceneModel>()
            {
                { MiscellaneousScene.Scene, MiscellaneousScene },
            };
        }

        public void Initialise(Action onEnter = null, Action onExit = null)
        {
            MiscellaneousScene.Initialise();

            OnEnter = onEnter;
            OnExit = onExit;
        }
    }
}
