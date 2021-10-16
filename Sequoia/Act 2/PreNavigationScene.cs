using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Sequoia
{
    public class PreNavigationScene : SceneModel
    {
        public static string Film;
        public static string Act;
        public static string Scene = "PreNavigation";
        public static PlayerModel Player;

        public static FrameModel Entrance;

        public PreNavigationScene(string film, string act, PlayerModel player)
        {
            Film = film;
            Act = act;
            Player = player;

            Entrance = new FrameModel(Film, Act, Scene, "Entrance", Constants.ResearchDoor);

            Frames = new Dictionary<string, FrameModel>() {
                {Entrance.Name, Entrance},
            };
        }

        public static void Initialise()
        {
            InitialiseEntrance(Entrance);
        }

        public static void InitialiseEntrance(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("As the hallway bends, you find a large door with an access panel to its side."),
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Head towards the office.", ComputerRoomScene.ComputerRoom),

                });
        }


    }
}
