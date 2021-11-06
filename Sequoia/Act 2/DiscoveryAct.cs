using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Sequoia
{
    public class DiscoveryAct : ActModel
    {
        public override string Name() { return "Discovery"; }
        public static TJunctionScene TJunction;
        public static StorageRoomScene StorageRoomScene;
        public static RecoveryRoomScene RecoveryRoomScene;
        public static InfirmaryScene InfirmaryScene;
        public static PreNavigationScene PreNavigationScene;

        public DiscoveryAct(string film, PlayerModel player)
        {
            Film = film;
            Player = player;

            TJunction = new TJunctionScene(film, Name(), player);
            StorageRoomScene = new StorageRoomScene(film, Name(), player);
            RecoveryRoomScene = new RecoveryRoomScene(film, Name(), player);
            InfirmaryScene = new InfirmaryScene(film, Name(), player);
            PreNavigationScene = new PreNavigationScene(film, Name(), player);

            Scenes = new Dictionary<string, ISceneModel>()
            {
                { TJunctionScene.Scene, TJunction },
                { StorageRoomScene.Scene, StorageRoomScene },
                { RecoveryRoomScene.Scene, RecoveryRoomScene },
                { InfirmaryScene.Scene, InfirmaryScene },
                { PreNavigationScene.Scene, PreNavigationScene }
            };
        }

        public void Initialise(Action onEnter = null, Action onExit = null)
        {
            TJunctionScene.Initialise();
            StorageRoomScene.Initialise();
            RecoveryRoomScene.Initialise();
            InfirmaryScene.Initialise();
            PreNavigationScene.Initialise();

            OnEnter = onEnter;
            OnExit = onExit;
        }
    }
}
