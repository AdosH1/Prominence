using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Sequoia
{
    public class ComputerRoomScene : SceneModel
    {
        public static string Film;
        public static string Act;
        public static string Scene = "ComputerRoom";
        public static PlayerModel Player;

        public static FrameModel ComputerRoom;
        public static FrameModel InvestigateTheResearch;
        public static FrameModel GrabSteinmannsCard;
        public static FrameModel InvestigateTheComputer;
        public static FrameModel LogEntry1;
        public static FrameModel LogEntry2;
        public static FrameModel LogEntry3;

        public ComputerRoomScene(string film, string act, PlayerModel player)
        {
            Film = film;
            Act = act;
            Player = player;

            ComputerRoom = new FrameModel(Film, Act, Scene, "ComputerRoom", Constants.ComputerRoom);
            InvestigateTheResearch = new FrameModel(Film, Act, Scene, "InvestigateTheResearch", Constants.ComputerRoom);
            GrabSteinmannsCard = new FrameModel(Film, Act, Scene, "GrabSteinmannsCard", Constants.ComputerRoom);
            InvestigateTheComputer = new FrameModel(Film, Act, Scene, "InvestigateTheComputer", Constants.Terminal);
            LogEntry1 = new FrameModel(Film, Act, Scene, "LogEntry1", Constants.Terminal);
            LogEntry2 = new FrameModel(Film, Act, Scene, "LogEntry2", Constants.Terminal);
            LogEntry3 = new FrameModel(Film, Act, Scene, "LogEntry3", Constants.Terminal);

            Frames = new Dictionary<string, FrameModel>() {
                {ComputerRoom.Name, ComputerRoom},
                {InvestigateTheResearch.Name, InvestigateTheResearch},
                {GrabSteinmannsCard.Name, GrabSteinmannsCard},
                {InvestigateTheComputer.Name, InvestigateTheComputer},
                {LogEntry1.Name, LogEntry1},
                {LogEntry2.Name, LogEntry2},
                {LogEntry3.Name, LogEntry3},
            };
        }

        public static void Initialise()
        {
            InitialiseComputerRoom(ComputerRoom);
            InitialiseInvestigateTheResearch(InvestigateTheResearch);
            InitialiseGrabSteinmannsCard(GrabSteinmannsCard);
            InitialiseInvestigateTheComputer(InvestigateTheComputer);
            InitialiseLogEntry1(LogEntry1);
            InitialiseLogEntry2(LogEntry2);
            InitialiseLogEntry3(LogEntry3);
        }

        public static void InitialiseComputerRoom(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("On top of a small desk stands a computer monitor shining a red light onto the floor."),
                    new DialogueModel("The room contains many shelves and cabinets filled with what looks like research papers and manuals."),
                    new DialogueModel("The hallway continues out from one side of the room.", 
                        condition: new Func<bool>(() => { return !Player.HasVisited(RnDScene.RnDExit.CurrentLocation); })) 
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Investigate the research papers.", InvestigateTheResearch),
                    new ButtonModel("Investigate the computer.", InvestigateTheComputer),

                    new ButtonModel("Head back towards drone.", DroneRoomScene.Entrance, condition: new Func<bool>(() => { return !Player.HasVisited(DroneRoomScene.Entrance.CurrentLocation) && !Player.HasVisited(RnDScene.RnDExit.CurrentLocation); })),
                    new ButtonModel("Head towards the Maintenance Room.", DroneRoomScene.Entrance, condition: new Func<bool>(() => { return Player.HasVisited(DroneRoomScene.Entrance.CurrentLocation) || Player.HasVisited(RnDScene.RnDExit.CurrentLocation); })),

                    new ButtonModel("Continue through the hallway.", RnDScene.RnDExit, condition: new Func<bool>(() => { return !Player.HasVisited(RnDScene.RnDExit.CurrentLocation); })),
                    new ButtonModel("Head to R&D Exit.", RnDScene.RnDExit, condition: new Func<bool>(() => { return Player.HasVisited(RnDScene.RnDExit.CurrentLocation); })),
                });
        }

        public static void InitialiseInvestigateTheResearch(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>()
                {
                    new DialogueModel("The papers include research work into many topics including terra-forming a planet named Andrea, the effects of cryostasis and the creation of androids."),
                    new DialogueModel("More recent work shows scribblings attempting to map the electrical grid on the ship, indicating many areas onboard where power is no longer available."),
                    new DialogueModel("While flipping through the notes, a card slips out from between the documents.", condition: new Func<bool>(() => { return !Player.HasVisited(InvestigateTheResearch.CurrentLocation); })),
                    new DialogueModel("A card sits between the papers that doesn't seem to belong there.", condition: new Func<bool>(() => { return Player.HasVisited(InvestigateTheResearch.CurrentLocation) && !Player.HasItem(Constants.SteinmannAccessCard); })),
                 },
                new List<ButtonModel>()
                {
                    new ButtonModel("Take the card.", GrabSteinmannsCard,
                        condition: new Func<bool>(() => { return !Player.HasItem(Constants.SteinmannAccessCard); }),
                        action: new Func<System.Threading.Tasks.Task>(async () => { Player.AddItem(Constants.SteinmannAccessCard); })),
                    new ButtonModel("Return.", ComputerRoom),
                });
        }

        public static void InitialiseGrabSteinmannsCard(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>()
                {
                    new DialogueModel("You take the card, it reads:"),
                    new DialogueModel("    Celesta Access Card"),
                    new DialogueModel("    Name: Dr. Jan Steinmann"),
                    new DialogueModel("    Position: Senior Research Officer")
                 },
                new List<ButtonModel>()
                {
                    new ButtonModel("Return.", ComputerRoom),
                });
        }

        public static void InitialiseInvestigateTheComputer(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("The computer shines a red warning message:"),
                    new DialogueModel("  > Attention: Ship is under lockdown until further notice. If you require to move between sectors, please find a senior officer to escort you. Sorry for the inconvenience."),
                    new DialogueModel("There appears to be log entries left on the computer.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Log Entry 1.", LogEntry1),
                    new ButtonModel("Log Entry 2.", LogEntry2),
                    new ButtonModel("Return.", ComputerRoom)
                });
        }

        // ========= Inspect the Drone 2 ========= //
        public static void InitialiseLogEntry1(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>()
                {
                    new DialogueModel(" > Dr. Steinmann reporting in."),
                    new DialogueModel(" > It appears I've awaken from cryo-sleep early, a blimp in the power grid must've released me from stasis."),
                    new DialogueModel(" > It's weird, I don't see anyone else around... and I have no idea how far along we are to planet Andrea."),
                    new DialogueModel(" > I feel something is very wrong here. I will investigate further.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Log Entry 2.", LogEntry2),
                    new ButtonModel("Return.", ComputerRoom)
                });
        }

        public static void InitialiseLogEntry2(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>()
                {
                    new DialogueModel(" > Dr. Steinmann reporting in."),
                    new DialogueModel(" > I've investigated further into the blips in the electricity grid, and it looks like we're running out of power..."),
                    new DialogueModel(" > We had initially set out with enough power to establish a colony on Andrea... this must mean we're long overdue to our destination."),
                    new DialogueModel(" > Maybe we've flown off course?")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", LogEntry3)
                });
        }

        public static void InitialiseLogEntry3(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>()
                {
                    new DialogueModel(" > As if that's not enough, I hear weird sounds coming from the vents... there's something... alive. They don't respond to me at all."),
                    new DialogueModel(" > Either way, I'm heading to the navigation room to figure out where we are, and hopefully get us back on track before we lose all power aboard this ship."),
                    new DialogueModel(" > Steinmann out.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Log Entry 1.", LogEntry1),
                    new ButtonModel("Return.", ComputerRoom)
                });
        }

    }
}
