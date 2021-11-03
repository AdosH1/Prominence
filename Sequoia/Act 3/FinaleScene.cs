using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Sequoia
{
    public class FinaleScene : SceneModel
    {
        public static string Film;
        public static string Act;
        public static string Scene = "Finale";
        public static PlayerModel Player;

        public static FrameModel JoinJanEnding;
        public static FrameModel JoinJanEnding2;
        public static FrameModel PowerEscapePod;
        public static FrameModel NoEnergyEnding;
        public static FrameModel NoEnergyEnding2;
        public static FrameModel PowerEscapePod2;
        public static FrameModel MediumEnergyEnding;
        public static FrameModel MediumEnergyEnding2;
        public static FrameModel HighEnergyEnding;
        public static FrameModel HighEnergyEnding2;
        public static FrameModel HighEnergyEnding3;
        public static FrameModel HighEnergyEnding4;
        public static FrameModel BatteryEnding;
        public static FrameModel BatteryEnding2;
        public static FrameModel BatteryEnding3;
        public static FrameModel BatteryEnding4;
        public static FrameModel BatteryEnding5;

        public FinaleScene(string film, string act, PlayerModel player)
        {
            Film = film;
            Act = act;
            Player = player;

            JoinJanEnding = new FrameModel(Film, Act, Scene, "JoinJanEnding", Constants.EscapePods);
            JoinJanEnding2 = new FrameModel(Film, Act, Scene, "JoinJanEnding2", Constants.EscapePods);
            PowerEscapePod = new FrameModel(Film, Act, Scene, "PowerEscapePod", Constants.EscapePods);
            NoEnergyEnding = new FrameModel(Film, Act, Scene, "NoEnergyEnding", Constants.EscapePods);
            NoEnergyEnding2 = new FrameModel(Film, Act, Scene, "NoEnergyEnding2", Constants.EscapePods);
            PowerEscapePod2 = new FrameModel(Film, Act, Scene, "PowerEscapePod2", Constants.EscapePods);
            MediumEnergyEnding = new FrameModel(Film, Act, Scene, "MediumEnergyEnding", Constants.EscapePods);
            MediumEnergyEnding2 = new FrameModel(Film, Act, Scene, "MediumEnergyEnding2", Constants.EscapePods);
            HighEnergyEnding = new FrameModel(Film, Act, Scene, "HighEnergyEnding", Constants.EscapePods);
            HighEnergyEnding2 = new FrameModel(Film, Act, Scene, "HighEnergyEnding2", Constants.EscapePods);
            HighEnergyEnding3 = new FrameModel(Film, Act, Scene, "HighEnergyEnding3", Constants.Sea);
            HighEnergyEnding4 = new FrameModel(Film, Act, Scene, "HighEnergyEnding4", Constants.Sea);
            BatteryEnding = new FrameModel(Film, Act, Scene, "BatteryEnding", Constants.EscapePods);
            BatteryEnding2 = new FrameModel(Film, Act, Scene, "BatteryEnding2", Constants.EscapePods);
            BatteryEnding3 = new FrameModel(Film, Act, Scene, "BatteryEnding3", Constants.Sea);
            BatteryEnding4 = new FrameModel(Film, Act, Scene, "BatteryEnding4", Constants.Sea);
            BatteryEnding5 = new FrameModel(Film, Act, Scene, "BatteryEnding5", Constants.Sea);

            Frames = new Dictionary<string, FrameModel>() {
                {JoinJanEnding.Name,JoinJanEnding},
                {JoinJanEnding2.Name,JoinJanEnding2},
                {PowerEscapePod.Name,PowerEscapePod},
                {NoEnergyEnding.Name,NoEnergyEnding},
                {NoEnergyEnding2.Name,NoEnergyEnding2},
                {PowerEscapePod2.Name,PowerEscapePod2},
                {MediumEnergyEnding.Name,MediumEnergyEnding},
                {MediumEnergyEnding2.Name,MediumEnergyEnding2},
                {HighEnergyEnding.Name,HighEnergyEnding},
                {HighEnergyEnding2.Name,HighEnergyEnding2},
                {HighEnergyEnding3.Name,HighEnergyEnding3},
                {HighEnergyEnding4.Name,HighEnergyEnding4},
                {BatteryEnding.Name,BatteryEnding},
                {BatteryEnding2.Name,BatteryEnding2},
                {BatteryEnding3.Name,BatteryEnding3},
                {BatteryEnding4.Name,BatteryEnding4},
                {BatteryEnding5.Name,BatteryEnding5},
            };
        }

        public static void Initialise()
        {
            InitialiseJoinJanEnding(JoinJanEnding);
            InitialiseJoinJanEnding2(JoinJanEnding2);
            InitialisePowerEscapePod(PowerEscapePod);
            InitialiseNoEnergyEnding(NoEnergyEnding);
            InitialiseNoEnergyEnding2(NoEnergyEnding2);
            InitialisePowerEscapePod2(PowerEscapePod2);
            InitialiseMediumEnergyEnding(MediumEnergyEnding);
            InitialiseMediumEnergyEnding2(MediumEnergyEnding2);
            InitialiseHighEnergyEnding(HighEnergyEnding);
            InitialiseHighEnergyEnding2(HighEnergyEnding2);
            InitialiseHighEnergyEnding3(HighEnergyEnding3);
            InitialiseHighEnergyEnding4(HighEnergyEnding4);
            InitialiseBatteryEnding(BatteryEnding);
            InitialiseBatteryEnding2(BatteryEnding2);
            InitialiseBatteryEnding3(BatteryEnding3);
            InitialiseBatteryEnding4(BatteryEnding4);
            InitialiseBatteryEnding5(BatteryEnding5);
        }

        public static void InitialiseJoinJanEnding(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You take a seat by Jan as the ship continues to flood."),
                    new DialogueModel("Slowly, the sound of ferals and the gushing water fade into the background, leaving a tranquil silence in the room.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", JoinJanEnding2),
                    
                });
        }

        public static void InitialiseJoinJanEnding2(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("The ship eventually shuts down and the room goes dark."),
                    new DialogueModel("At this point, no response can be gained the ship's systems anymore."),
                    new DialogueModel("You enter into hibernation mode, in hopes of a better future.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("The end.", MiscellaneousScene.ThankYouForPlaying),

                });
        }

        public static void InitialisePowerEscapePod(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You socket your hand into the power panel."),
                    new DialogueModel("A flashing red light appears on the escape pod, indicating it needs more power."),
                    new DialogueModel("You can feel the power draw from the pod is much greater than anything you've encountered.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Electrify.", NoEnergyEnding,
                        condition: new Func<bool>(() => { return Player.Energy <= 1; }),
                        action: new Func<System.Threading.Tasks.Task>(async() => { Player.Energy--; })),
                    new ButtonModel("Electrify.", NoEnergyEnding,
                        condition: new Func<bool>(() => { return Player.Energy >= 2; }),
                        action: new Func<System.Threading.Tasks.Task>(async() => { Player.Energy--; })),
                    new ButtonModel("Use spare battery.", BatteryEnding,
                        condition: new Func<bool>(() => { return Player.HasItem(Constants.SpareBattery); }),
                        action: new Func<System.Threading.Tasks.Task>(async() => { Player.RemoveItem(Constants.SpareBattery); })),

                });
        }

        public static void InitialiseNoEnergyEnding(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You put everything into the escape pod, the exertion causes you to drop to your knees."),
                    new DialogueModel("It wasn't enough. The red light slowly dims back to nothing."),
                    new DialogueModel("The shock from the power loss is causing you to black out, you're spent.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", NoEnergyEnding2),

                });
        }

        public static void InitialiseNoEnergyEnding2(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    // Jan unhurt
                    new DialogueModel("Your vision fades in and out of focus.",
                        condition: new Func<bool>(() => { return Player.HasFlag(Constants.JanHasBullets); })),
                    new DialogueModel("The last thing you see is Jan dragging you to his side by the escape pod.",
                        condition: new Func<bool>(() => { return Player.HasFlag(Constants.JanHasBullets); })),
                    new DialogueModel("\"It's okay, you tried\".",
                        condition: new Func<bool>(() => { return Player.HasFlag(Constants.JanHasBullets); })),
                    new DialogueModel("You fade to black.",
                        condition: new Func<bool>(() => { return Player.HasFlag(Constants.JanHasBullets); })),
                    // Jan hurt
                    new DialogueModel("Your vision fades in and out of focus.",
                        condition: new Func<bool>(() => { return !Player.HasFlag(Constants.JanHasBullets); })),
                    new DialogueModel("The last thing you see is Jan yelling something and trying to crawling towards you. You don't make out any of the words.",
                        condition: new Func<bool>(() => { return !Player.HasFlag(Constants.JanHasBullets); })),
                    new DialogueModel("You fade to black.",
                        condition: new Func<bool>(() => { return !Player.HasFlag(Constants.JanHasBullets); })),
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("The end.", MiscellaneousScene.ThankYouForPlaying),

                });
        }

        public static void InitialisePowerEscapePod2(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("Your arm burns red hot as you discharge electricity into the escape pod."),
                    new DialogueModel("The flashing red light turns yellow, it still needs more power."),
                    new DialogueModel("You are feeling light-headed from the exertion.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Give it everything.", MediumEnergyEnding,
                        condition: new Func<bool>(() => { return Player.Energy == 1; }),
                        action: new Func<System.Threading.Tasks.Task>(async() => { Player.Energy--; })),
                    new ButtonModel("Give it everything.", HighEnergyEnding,
                        condition: new Func<bool>(() => { return Player.Energy >= 2; }),
                        action: new Func<System.Threading.Tasks.Task>(async() => { Player.Energy--; })),
                });
        }

        public static void InitialiseMediumEnergyEnding(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You put everything into it, the shock from the power loss causes you to drop to the floor."),
                new DialogueModel("The pod jumps to life as the yellow light now shines green."),
                new DialogueModel("You are getting small blackouts from the exertion.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", MediumEnergyEnding2)
                });
        }

        public static void InitialiseMediumEnergyEnding2(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    // Jan unhurt
                    new DialogueModel("Your vision fades in and out of focus.",
                        condition: new Func<bool>(() => { return Player.HasFlag(Constants.JanHasBullets); })),
                    new DialogueModel("You see is Jan dragging you into the escape pod.",
                        condition: new Func<bool>(() => { return Player.HasFlag(Constants.JanHasBullets); })),
                    new DialogueModel("\"It's going to be alright,\" He says, \"We're getting out of here.\"",
                        condition: new Func<bool>(() => { return Player.HasFlag(Constants.JanHasBullets); })),
                    new DialogueModel("You lose consciousness before you reach the escape pod.",
                        condition: new Func<bool>(() => { return Player.HasFlag(Constants.JanHasBullets); })),
                    // Jan hurt
                    new DialogueModel("Your vision fades in and out of focus.",
                        condition: new Func<bool>(() => { return !Player.HasFlag(Constants.JanHasBullets); })),
                    new DialogueModel("You see is Jan trying to pull you towards the escape pod, but his injuries are too dire.",
                        condition: new Func<bool>(() => { return !Player.HasFlag(Constants.JanHasBullets); })),
                    new DialogueModel("\"I'm so sorry\". He turns and stumbles his way into the escape pod.",
                        condition: new Func<bool>(() => { return !Player.HasFlag(Constants.JanHasBullets); })),
                    new DialogueModel("Your vision fades to black.",
                        condition: new Func<bool>(() => { return !Player.HasFlag(Constants.JanHasBullets); })),
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("The end.", MiscellaneousScene.ThankYouForPlaying)
                });
        }

        public static void InitialiseHighEnergyEnding(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You put everything into it, the shock from the power loss causes you to drop to your knees."),
                    new DialogueModel("The pod jumps to life as the yellow light now shines green."),
                    // Jan unhurt
                    new DialogueModel("Jan rips your hand out of the socket. You take a few moments to steady yourself. You're okay.",
                        condition: new Func<bool>(() => { return Player.HasFlag(Constants.JanHasBullets); })),
                    new DialogueModel("\"You did it!\" He exclaims.",
                        condition: new Func<bool>(() => { return Player.HasFlag(Constants.JanHasBullets); })),
                    new DialogueModel("Pulling your arm over his shoulder, he helps you into the escape pod.",
                        condition: new Func<bool>(() => { return Player.HasFlag(Constants.JanHasBullets); })),
                    // Jan hurt
                    new DialogueModel("You twist your arm free from the sock and  take a few moments to steady yourself. You're okay.",
                        condition: new Func<bool>(() => { return !Player.HasFlag(Constants.JanHasBullets); })),
                    new DialogueModel("You pull his Jan's arm over your shoulder as you help him into the escape pod.",
                        condition: new Func<bool>(() => { return !Player.HasFlag(Constants.JanHasBullets); })),
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", HighEnergyEnding2)
                });
        }

        public static void InitialiseHighEnergyEnding2(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    // Jan unhurt
                    new DialogueModel("He sits you down and works the escape pod terminal.",
                        condition: new Func<bool>(() => { return Player.HasFlag(Constants.JanHasBullets); })),
                    // Jan hurt
                    new DialogueModel("Sitting him down, you work the escape pod panel.",
                        condition: new Func<bool>(() => { return !Player.HasFlag(Constants.JanHasBullets); })),
                    new DialogueModel("\"Thank you.\"",
                        condition: new Func<bool>(() => { return !Player.HasFlag(Constants.JanHasBullets); })),
                    new DialogueModel("Soon, the pod door closes and a large jolt sends you towards the surface."),
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", HighEnergyEnding3)
                });
        }

        public static void InitialiseHighEnergyEnding3(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("As you near the surface, rays of light pierce through the water."),
                    new DialogueModel("You can see just ahead of you, many of the other escape pods you had saved from the ship.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", HighEnergyEnding4)
                });
        }

        public static void InitialiseHighEnergyEnding4(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("As you reach the surface, you both look out the window to see a coastline nearby filled with a lush green forest."),
                    new DialogueModel("With revitalized hopes, you and the remaining colonists venture forth into a brand new world.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("The end.", MiscellaneousScene.ThankYouForPlayingGoodEnding)
                });
        }

        public static void InitialiseBatteryEnding(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You take out the spare battery. \"Huh, right. I still got this.\""),
                    new DialogueModel("The battery slots perfectly into the socket and the pod jumps to life. The red light now shines green."),
                    new DialogueModel("Jan jumps up. \"You did it!\" and you, having even more energy than him - chuck him into the escape pod.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", BatteryEnding2)
                });
        }

        public static void InitialiseBatteryEnding2(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("\"Like they say, Vespenergy always delivers!\" you involuntarily quip."),
                    new DialogueModel("You slap yourself. Earth's marketing has really gone too far."),
                    new DialogueModel("You enter the pod and prepare your immaculate escape.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", BatteryEnding3)
                });
        }

        public static void InitialiseBatteryEnding3(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("Soon, the pod decouples from the ship and a large jolt sends you towards the surface."),
                    new DialogueModel("Nothing but ads play in the background, \"Vespenergy, all you'll ever need!\"."),
                    new DialogueModel("It really kills the mood.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", BatteryEnding4)
                });
        }

        public static void InitialiseBatteryEnding4(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("As you near the surface, rays of light pierce through the water."),
                    new DialogueModel("You can see just ahead of you, many of the other escape pods you had saved from the ship."),
                    new DialogueModel("They look like beautiful, energy efficient batteries, glistening in the water.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", BatteryEnding5)
                });
        }

        public static void InitialiseBatteryEnding5(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("Reaching the surface, you both look out the window to see a coastline nearby filled with a lush green forest."),
                    new DialogueModel("With high hopes and a dream, you, the remaining colonists and *VESPENERGY* venture forth to find the next big battery.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("The end.", MiscellaneousScene.ThankYouForPlayingGoodEnding)
                });
        }


    }
}
