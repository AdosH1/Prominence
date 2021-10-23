using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Sequoia
{
    public class EscapeAct : ActModel
    {
        public static readonly string Name = "Escape";
        public static TJunctionScene TJunction;
        public EscapeAct(string film, PlayerModel player)
        {
            Film = film;
            Player = player;

            TJunction = new TJunctionScene(film, Name, player);

            Scenes = new Dictionary<string, ISceneModel>()
            {
                { TJunctionScene.Scene, TJunction },

            };
        }

        public void Initialise(Action onEnter = null, Action onExit = null)
        {
            TJunctionScene.Initialise();

            OnEnter = onEnter;
            OnExit = onExit;
        }
    }
}
