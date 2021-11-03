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

        public static FrameModel ContinueToEscapePods;
        public static FrameModel HelpJanWithBullets;
        public static FrameModel HelpJanWithBullets2;
        public static FrameModel HelpJanNoBullets;
        public static FrameModel HelpJanNoBullets2;
        public static FrameModel KeepLooking;
        public static FrameModel KeepLookingJanEntersWithBullets;
        public static FrameModel KeepLookingJanEntersNoBullets;
        public static FrameModel ContinueToEscapePodsBothInside;
        public static FrameModel JanReadsTerminal;
        public static FrameModel KeepLooking2;

        public EscapePodScene(string film, string act, PlayerModel player)
        {
            Film = film;
            Act = act;
            Player = player;

            ContinueToEscapePods = new FrameModel(Film, Act, Scene, "ContinueToEscapePods", Constants.EscapePods);
            HelpJanWithBullets = new FrameModel(Film, Act, Scene, "HelpJanWithBullets", Constants.EscapePods);
            HelpJanWithBullets2 = new FrameModel(Film, Act, Scene, "HelpJanWithBullets2", Constants.EscapePods);
            HelpJanNoBullets = new FrameModel(Film, Act, Scene, "HelpJanNoBullets", Constants.EscapePods);
            HelpJanNoBullets2 = new FrameModel(Film, Act, Scene, "HelpJanNoBullets2", Constants.EscapePods);
            KeepLooking = new FrameModel(Film, Act, Scene, "KeepLooking", Constants.EscapePods);
            KeepLookingJanEntersWithBullets = new FrameModel(Film, Act, Scene, "KeepLookingJanEntersWithBullets", Constants.EscapePods);
            KeepLookingJanEntersNoBullets = new FrameModel(Film, Act, Scene, "KeepLookingJanEntersNoBullets", Constants.EscapePods);
            ContinueToEscapePodsBothInside = new FrameModel(Film, Act, Scene, "ContinueToEscapePodsBothInside", Constants.EscapePods);
            JanReadsTerminal = new FrameModel(Film, Act, Scene, "JanReadsTerminal", Constants.EscapePods);
            KeepLooking2 = new FrameModel(Film, Act, Scene, "KeepLooking2", Constants.EscapePods);

            Frames = new Dictionary<string, FrameModel>() {
                {ContinueToEscapePods.Name,ContinueToEscapePods},
                {HelpJanWithBullets.Name,HelpJanWithBullets},
                {HelpJanWithBullets2.Name,HelpJanWithBullets2},
                {HelpJanNoBullets.Name,HelpJanNoBullets},
                {HelpJanNoBullets2.Name,HelpJanNoBullets2},
                {KeepLooking.Name,KeepLooking},
                {KeepLookingJanEntersWithBullets.Name,KeepLookingJanEntersWithBullets},
                {KeepLookingJanEntersNoBullets.Name,KeepLookingJanEntersNoBullets},
                {ContinueToEscapePodsBothInside.Name,ContinueToEscapePodsBothInside},
                {JanReadsTerminal.Name,JanReadsTerminal},
                {KeepLooking2.Name,KeepLooking2},
            };
        }

        public static void Initialise()
        {
            InitialiseContinueToEscapePods(ContinueToEscapePods);
            InitialiseHelpJanWithBullets(HelpJanWithBullets);
            InitialiseHelpJanWithBullets2(HelpJanWithBullets2);
            InitialiseHelpJanNoBullets(HelpJanNoBullets);
            InitialiseHelpJanNoBullets2(HelpJanNoBullets2);
            InitialiseKeepLooking(KeepLooking);
            InitialiseKeepLookingJanEntersWithBullets(KeepLookingJanEntersWithBullets);
            InitialiseKeepLookingJanEntersNoBullets(KeepLookingJanEntersNoBullets);
            InitialiseContinueToEscapePodsBothInside(ContinueToEscapePodsBothInside);
            InitialiseJanReadsTerminal(JanReadsTerminal);
            InitialiseKeepLooking2(KeepLooking2);
        }

        public static void InitialiseContinueToEscapePods(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("As you enter the room, you make your way immediately to the evacuation terminal."),
                    new DialogueModel("    > ERROR: Electricity reserve is at critical capacity."),
                    new DialogueModel("    > Systems will automatically shutdown in 3 minutes."),
                    new DialogueModel("    > ERROR: Insufficient power to launch escape pods."),
                    new DialogueModel("You hit the panel. You are stuck.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Help Jan.", HelpJanWithBullets,
                        condition: new Func<bool>(() => { return Player.HasFlag(Constants.JanHasBullets); })),
                    new ButtonModel("Help Jan.", HelpJanNoBullets,
                        condition: new Func<bool>(() => { return !Player.HasFlag(Constants.JanHasBullets); })),
                    new ButtonModel("Keep looking.", KeepLooking),
                });
        }

        public static void InitialiseHelpJanWithBullets(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You hear the fighting continue outside until suddenly, many shots are fired, followed by two distinct clicks."),
                    new DialogueModel("You bump into Jan as he enters the room. There's blood all over him, but its not his."),
                    new DialogueModel("He locks the exit with his access card and gives out a sigh."),
                    new DialogueModel("\"Are we ready to go?\"."),
                    new DialogueModel("You shake your head.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", HelpJanWithBullets2),
                });
        }

        public static void InitialiseHelpJanWithBullets2(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("Reading over the terminal, Jan gives a few nods."),
                    new DialogueModel("\"We must've used all the power sending the others to the surface...\""),
                    new DialogueModel("He takes a seat by the escape pod."),
                    new DialogueModel("\"It's not all bad, we saved the others. Perhaps they'll be able to continue our mission...\""),
                    new DialogueModel("\"...All we can do now is sit it out and relax, the ship is flooding out anyway.\"")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Join Jan.", FinaleScene.JoinJanEnding),
                    new ButtonModel("Keep looking.", KeepLooking,
                        condition: new Func<bool>(() => { return !Player.HasVisited(KeepLooking.CurrentLocation); })),
                    new ButtonModel("Keep looking.", FinaleScene.PowerEscapePod,
                        condition: new Func<bool>(() => { return Player.HasVisited(KeepLooking.CurrentLocation); })),
                });
        }

        public static void InitialiseHelpJanNoBullets(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You hear the fighting continue outside until suddenly, a brutal crack is heard."),
                    new DialogueModel("As you head through the doorway you bump into Jan. He is covered in blood, stemming from a wound in his chest."),
                    new DialogueModel("He slaps his bloodied access card on you, \"Close the door will you?\"."),
                    new DialogueModel("Looking out, you see the large feral has been defeated outside. You close the door."),
                    new DialogueModel("\"Are we ready to go?\" You shake your head.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", HelpJanNoBullets2),
                });
        }

        public static void InitialiseHelpJanNoBullets2(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("Collapsing over the terminal, Jan steadies himself to read. He gives a couple weak nods."),
                    new DialogueModel("\"Makes sense, we must've used all the power sending the others to the surface...\""),
                    new DialogueModel("He takes a seat by the escape pod."),
                    new DialogueModel("\"It's not all bad, we saved the others. Perhaps they'll be able to continue our mission...\""),
                    new DialogueModel("\"...All we can do now is sit it out and relax, I'm not long for this world anyway.\"")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Join Jan.", FinaleScene.JoinJanEnding),
                    new ButtonModel("Keep looking.", KeepLooking,
                        condition: new Func<bool>(() => { return !Player.HasVisited(KeepLooking.CurrentLocation); })),
                    new ButtonModel("Keep looking.", FinaleScene.PowerEscapePod,
                        condition: new Func<bool>(() => { return Player.HasVisited(KeepLooking.CurrentLocation); })),
                });
        }

        public static void InitialiseKeepLooking(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You keep looking for an alternative solution."),
                    new DialogueModel("Suddenly, you remember that there were hidden power panels around the doors in the ship."),
                    new DialogueModel("And certainly enough, you found one connected to the escape pod.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Join Jan.", FinaleScene.JoinJanEnding),
                    new ButtonModel("Keep looking.", FinaleScene.PowerEscapePod,
                        condition: new Func<bool>(() => { return Player.HasVisited(KeepLooking.CurrentLocation); })),
                    new ButtonModel("Keep looking.", KeepLooking,
                        condition: new Func<bool>(() => { return !Player.HasVisited(KeepLooking.CurrentLocation); })),
                    
                });
        }



        public static void InitialiseKeepLookingJanEntersWithBullets(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("Many shots are fired outside followed by a couple mechanical clicks."),
                    new DialogueModel("Jan enters into the room. There's blood all over him - but its not his."),
                    new DialogueModel("He locks the exit with his access card and gives out a sigh."),
                    new DialogueModel("\"Are we ready to go?\" You shake your head.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", HelpJanWithBullets2),
                });
        }

        public static void InitialiseKeepLookingJanEntersNoBullets(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You hear the fighting continue outside until suddenly, a brutal crack is heard."),
                    new DialogueModel("Jan enters the room, bumping into the access panel, he uses his bloodied access card to close the doorway."),
                    new DialogueModel("It looks like he is suffering from a wound on his chest."),
                    new DialogueModel("\"Are we ready to go?\" He asks."),
                    new DialogueModel("You shake your head.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", HelpJanNoBullets2),
                });
        }

        public static void InitialiseContinueToEscapePodsBothInside(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You and Jan enter the room and lock the door behind, you make your way immediately to the escape pod terminal."),
                    new DialogueModel("  > ERROR: Electricity reserve is at critical capacity."),
                    new DialogueModel("  > Systems will automatically shutdown in 3 minutes."),
                    new DialogueModel("  > ERROR: Insufficient power to launch escape pods."),
                    new DialogueModel("You hit the panel. You are stuck.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", JanReadsTerminal),
                });
        }

        public static void InitialiseJanReadsTerminal(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("Reading over the terminal, Jan gives a few nods."),
                    new DialogueModel("\"We must've used all the power sending the others to the surface..\""),
                    new DialogueModel("He takes a seat by the escape pod."),
                    new DialogueModel("\"It's not all bad, we saved the others. Perhaps they'll be able to continue our mission...\""),
                    new DialogueModel("\"...All we can do now is sit it out and relax, the ship is going to shutdown soon anyway.\"")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Join Jan.", FinaleScene.JoinJanEnding),
                    new ButtonModel("Keep looking.", KeepLooking2),
                });
        }

        public static void InitialiseKeepLooking2(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You keep looking for an alternative solution."),
                    new DialogueModel("Suddenly, you remember that there were hidden power panels around the doors in the ship."),
                    new DialogueModel("And certainly enough, you found one connected to the escape pod.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Join Jan.", FinaleScene.JoinJanEnding),
                    new ButtonModel("Power escape pod.", FinaleScene.PowerEscapePod),
                });
        }

    }
}
