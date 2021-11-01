using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Sequoia
{
    public class EscapePodScene : SceneModel
    {
        public static string Film;
        public static string Act;
        public static string Scene = "EscapePod";
        public static PlayerModel Player;

        public static FrameModel StorageRoomBase;

        public EscapePodScene(string film, string act, PlayerModel player)
        {
            Film = film;
            Act = act;
            Player = player;

            StorageRoomBase = new FrameModel(Film, Act, Scene, "StorageRoomBase", Constants.StorageRoom);

            Frames = new Dictionary<string, FrameModel>() {
                {StorageRoomBase.Name, StorageRoomBase},
            };
        }

        public static void Initialise()
        {
            InitialiseStorageRoomBase(StorageRoomBase);
        }

        public static void InitialiseStorageRoomBase(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("In the storage room, a dim light shines from the ceiling above."),
                    new DialogueModel("There are many shelves in the room, filled with an assortment of miscellaneous boxes."),
                    new DialogueModel("The shelves cast large shadows, keeping the corners of the room dark. It gives you an uneasy feeling.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Examine the boxes.", StorageRoomBase),
                    new ButtonModel("Inspect the room.", StorageRoomBase,
                        condition: new Func<bool>(() => { return !Player.HasVisited(StorageRoomBase.CurrentLocation); })),
                });
        }


    }
}
