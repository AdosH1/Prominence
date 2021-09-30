using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Sequoia
{
    public class IncubationScene : SceneModel
    {
        public static string Film;
        public static string Act;
        public static string Scene = "Incubation";
        public static PlayerModel Player;

        public static FrameModel Start;
        public static FrameModel Silent;
        public static FrameModel TalkToDrone;
        public static FrameModel DroneLeaves;
        public static FrameModel InspectIncubationRoom;
        public static FrameModel IncubationHallway;
        public IncubationScene() { }

        public IncubationScene(string film, string act, PlayerModel player)
        {
            Film = film;
            Act = act;
            Player = player;

            Start = new FrameModel(Film, Act, Scene, "Start", Constants.Black);
            Silent = new FrameModel(Film, Act, Scene, "Silent", Constants.Black);
            TalkToDrone = new FrameModel(Film, Act, Scene, "TalkToDrone", Constants.Black);
            DroneLeaves = new FrameModel(Film, Act, Scene, "DroneLeaves", Constants.Incubation);
            InspectIncubationRoom = new FrameModel(Film, Act, Scene, "InspectIncubationRoom", Constants.Incubation);
            IncubationHallway = new FrameModel(Film, Act, Scene, "IncubationHallway", Constants.Corridor);

            Frames = new Dictionary<string, FrameModel>() {
                {Start.Name, Start},
                {Silent.Name, Silent},
                {TalkToDrone.Name, TalkToDrone},
                {DroneLeaves.Name, DroneLeaves},
                {InspectIncubationRoom.Name, InspectIncubationRoom},
                {IncubationHallway.Name, IncubationHallway},
            };
        }

        public static void Initialise()
        {
            InitialiseIncubationHallway(IncubationHallway);
            InitialiseInspectIncubationRoom(InspectIncubationRoom);
            InitialiseDroneLeaves(DroneLeaves);
            InitialiseTalkToDrone(TalkToDrone);
            InitialiseSilent(Silent);
            InitialiseStart(Start);
        }

        public static void InitialiseStart(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("..."),
                    new DialogueModel("You wake up."),
                    new DialogueModel("Everything is dark, and you can't seem to move."),
                    new DialogueModel("...Where am I?"),
                    new DialogueModel("A short drilling sound comes from your side, followed by a brief pause.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Attempt to talk.", TalkToDrone),
                    new ButtonModel("Remain silent.", Silent)
                }
            );
        }
        public static void InitialiseSilent(FrameModel frame)
        {
            frame.Initialise(
               new List<DialogueModel>() {
                    new DialogueModel("The drilling continues.")
               },
               new List<ButtonModel>() {
                    new ButtonModel("Continue.", DroneLeaves)
               }
            );
        }
        public static void InitialiseTalkToDrone(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("\"Hello?\" You ask. \"Who's there?\""),
                    new DialogueModel("The drilling continues.") },
                    new List<ButtonModel>()
                {
                new ButtonModel("Continue.", DroneLeaves)
            }
            );
        }
        public static void InitialiseDroneLeaves(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("Suddenly, your vision flickers on and you begin being lowered down."),
                    new DialogueModel("Looking to your side, you can just make out a drone hovering out of the room and into a hallway. It turns left."),
                    new DialogueModel("You realise you can move now, you get up.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Inspect the room.", InspectIncubationRoom),
                    new ButtonModel("Head into the hallway.", IncubationHallway)
                }
            );
        }
        public static void InitialiseInspectIncubationRoom(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("Everything in the room has a plain metal surface."),
                    new DialogueModel("The seat you were in has many circular connection points that match the metallic sockets around your body."),
                    new DialogueModel("You have no memory of this place.")
                 },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue to the hallway.", IncubationHallway)
                }
            );
        }
        public static void InitialiseIncubationHallway(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("Dull blue lights line the ceiling along the hallway, many of them flicker every few seconds. It's as if there isn't enough electricity going through the system."),
                    new DialogueModel("To the left, you just make out the back of the drone heading down the hallway."),
                    new DialogueModel("On the right the hallway turns, a faint red light can be seen projected on the floor.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Follow the drone.", DroneRoomScene.Entrance),
                    new ButtonModel("Go towards the red light.", ComputerRoomScene.ComputerRoom)
                }
            );
        }
    }
}
