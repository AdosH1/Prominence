using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Sequoia
{
    public class EscapeAct : ActModel
    {
        public override string Name() { return "Escape"; }
        public static NavigationRoomScene NavigationRoomScene;
        public static EscapeCorridorScene EscapeCorridorScene;
        public static EscapePodScene EscapePodScene;
        public static FinaleScene FinishScene;
        public EscapeAct(string film, PlayerModel player)
        {
            Film = film;
            Player = player;

            NavigationRoomScene = new NavigationRoomScene(film, Name(), player);
            EscapeCorridorScene = new EscapeCorridorScene(film, Name(), player);
            EscapePodScene = new EscapePodScene(film, Name(), player);
            FinishScene = new FinaleScene(film, Name(), player);

            Scenes = new Dictionary<string, ISceneModel>()
            {
                { NavigationRoomScene.Scene, NavigationRoomScene },
                { EscapeCorridorScene.Scene, EscapeCorridorScene },
                { EscapePodScene.Scene, EscapePodScene },
                { FinaleScene.Scene, FinishScene },
            };
        }

        public void Initialise(Action onEnter = null, Action onExit = null)
        {
            NavigationRoomScene.Initialise();
            EscapeCorridorScene.Initialise();
            EscapePodScene.Initialise();
            FinaleScene.Initialise();

            OnEnter = onEnter;
            OnExit = onExit;
        }
    }
}
