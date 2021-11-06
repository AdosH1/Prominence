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
        public static FrameModel ThankYouForPlaying;
        public static FrameModel ThankYouForPlayingGoodEnding;
        public MiscellaneousScene() { }

        public MiscellaneousScene(string film, string act, PlayerModel player)
        {
            Film = film;
            Act = act;
            Player = player;

            Dead = new FrameModel(Film, Act, Scene, "Dead", Constants.Black);
            Teleport = new FrameModel(Film, Act, Scene, "Teleport", Constants.Black);
            UncompletedSections = new FrameModel(Film, Act, Scene, "UncompletedSections", Constants.Black);
            ThankYouForPlaying = new FrameModel(Film, Act, Scene, "ThankYouForPlaying", Constants.Black);
            ThankYouForPlayingGoodEnding = new FrameModel(Film, Act, Scene, "ThankYouForPlayingGoodEnding", Constants.Sea);

            Frames = new Dictionary<string, FrameModel>() {
                {Dead.Name, Dead},
                {Teleport.Name, Teleport},
                {UncompletedSections.Name, UncompletedSections},
                {ThankYouForPlaying.Name, ThankYouForPlaying},
                {ThankYouForPlayingGoodEnding.Name, ThankYouForPlayingGoodEnding},
            };
        }

        public static void Initialise()
        {
            InitialiseDead(Dead);
            InitialiseTeleport(Teleport);
            InitialiseUncompletedSections(UncompletedSections);
            InitialiseThankYouForPlaying(ThankYouForPlaying);
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
                    new ButtonModel("T-Junction.", TJunctionScene.HearSound,
                        action: new Func<Task>(async () => { Player.SetTJunctionScene(); })),
                    new ButtonModel("Infirmary.", InfirmaryScene.InfirmaryBase,
                        action: new Func<Task>(async () => { Player.SetInfirmaryScene(); })),
                    new ButtonModel("Navigation Room.", NavigationRoomScene.Entrance,
                        action: new Func<Task>(async () => { Player.SetNavigationScene(); })),
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

        public static void InitialiseThankYouForPlaying(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("Thank you for playing."),
                    new DialogueModel("If you would like to explore what you missed or hunt for achievements, feel free to restart the game."),
                    new DialogueModel("Alternatively, you may access the archives by tapping on the special thanks area in the settings menu. This will allow you to skip to certain parts of the story."),
                    new DialogueModel("If you would like to hear more about our titles in the future, please consider providing your email below.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Restart.", IncubationScene.Start, 
                        action: new Func<Task>(async() =>{ Player.Reset(); })),
                    //new ButtonModel("Let me know about future titles.", IncubationScene.Start),
                }
            );
        }

        public static void InitialiseThankYouForPlayingGoodEnding(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("Thank you for playing."),
                    new DialogueModel("If you would like to explore what you missed or hunt for achievements, feel free to restart the game."),
                    new DialogueModel("Alternatively, you may access the archives by tapping on the special thanks area in the settings menu. This will allow you to skip to certain parts of the story."),
                    new DialogueModel("If you would like to hear more about our titles in the future, please consider providing your email below.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Restart.", IncubationScene.Start,
                        action: new Func<Task>(async() =>{ Player.Reset(); })),
                    //new ButtonModel("Let me know about future titles.", IncubationScene.Start),
                }
            );
        }
    }
}
