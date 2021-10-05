using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Sequoia
{
    public class DiscoveryAct : ActModel
    {
        public static readonly string Name = "Discovery";
        public static TJunctionScene TJunction;
        public static StorageRoomScene StorageRoomScene;
        public static RecoveryRoomScene RecoveryRoomScene;
        public static InfirmaryScene InfirmaryScene;
        public DiscoveryAct(string film, PlayerModel player)
        {
            Film = film;
            Player = player;

            TJunction = new TJunctionScene(film, Name, player);
            StorageRoomScene = new StorageRoomScene(film, Name, player);
            RecoveryRoomScene = new RecoveryRoomScene(film, Name, player);
            InfirmaryScene = new InfirmaryScene(film, Name, player);

            Scenes = new Dictionary<string, ISceneModel>()
            {
                { TJunctionScene.Scene, TJunction },
                { StorageRoomScene.Scene, StorageRoomScene },
                { RecoveryRoomScene.Scene, RecoveryRoomScene },
                { InfirmaryScene.Scene, InfirmaryScene }
            };
        }

        public void Initialise(Action onEnter = null, Action onExit = null)
        {
            TJunctionScene.Initialise();
            StorageRoomScene.Initialise();
            RecoveryRoomScene.Initialise();
            InfirmaryScene.Initialise();

            OnEnter = onEnter;
            OnExit = onExit;
        }
    }
}
