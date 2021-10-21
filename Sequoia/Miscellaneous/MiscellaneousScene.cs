using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Sequoia
{
    public class MiscellaneousScene : SceneModel
    {
        public static string Film;
        public static string Act;
        public static string Scene = "Miscellaneous";
        public static PlayerModel Player;

        public static FrameModel Dead;
        public static FrameModel Teleport;
        public static FrameModel UncompletedSections;
        public MiscellaneousScene() { }

        public MiscellaneousScene(string film, string act, PlayerModel player)
        {
            Film = film;
            Act = act;
            Player = player;

            Dead = new FrameModel(Film, Act, Scene, "Dead", Constants.Black);
            Teleport = new FrameModel(Film, Act, Scene, "Teleport", Constants.Black);
            UncompletedSections = new FrameModel(Film, Act, Scene, "UncompletedSections", Constants.Black);
            
            Frames = new Dictionary<string, FrameModel>() {
                {Dead.Name, Dead},
                {Teleport.Name, Teleport},
                {UncompletedSections.Name, UncompletedSections},
            };
        }

        public static void Initialise()
        {
            InitialiseDead(Dead);
            InitialiseTeleport(Teleport);
            InitialiseUncompletedSections(UncompletedSections);
        }

        public static void InitialiseDead(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("We endure the darkness so that we may see the stars."),
                    new DialogueModel("You have perished.")
                },
                    new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", IncubationScene.Start,
                        action: new Func<Task>(async () => { Player.Reset(); }))
                }
            );
        }

        public static void InitialiseTeleport(FrameModel frame)
        {
            frame.Initialise(
               new List<DialogueModel>() {
                    new DialogueModel("Bzzt.. Bzzzt.."),
                    new DialogueModel("Loading..."),
                    new DialogueModel("... done."),
                    new DialogueModel("Welcome to the memory archives. Below are options to relive many of the moments you've experienced within the simulation."),
                    new DialogueModel("Naturally, you will have all possible items unlocked when you start from a future point in time."),
                    new DialogueModel("Please select a memory below.")
               },
               new List<ButtonModel>() {
                    new ButtonModel("Start.", IncubationScene.Start,
                        action: new Func<Task>(async () => { Player.Reset(); })),
                    new ButtonModel("T-Junction.", RnDScene.LeaveScene,
                        action: new Func<Task>(async () => { Player.SetTJunctionScene(); })),
                    new ButtonModel("Infirmary.", InfirmaryScene.InfirmaryBase,
                        action: new Func<Task>(async () => { Player.SetInfirmaryScene(); })),
                    // TODO: Add navigation room
                    //new ButtonModel("Navigation Room.", InfirmaryScene.InfirmaryBase,
                    //    action: new Func<Task>(async () => { })),
               }
            );
        }

        public static void InitialiseUncompletedSections(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You pass through the seven gates of hell."),
                    new DialogueModel("Kicking the demon lord's face in, you emerge victorious in a fountain of blood and gore."),
                    new DialogueModel("All bow before you as you are crowned the new Satan.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Ascend.", IncubationScene.Start),
                }
            );
        }
    }
}
