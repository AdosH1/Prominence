using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Sequoia
{
    public class RnDScene : SceneModel
    {
        public static string Film;
        public static string Act;
        public static string Scene = "RnDExit";
        public static PlayerModel Player;

        public static FrameModel RnDExit;
        public static FrameModel InvestigateAccessPanel;
        public static FrameModel SocketHand;
        public static FrameModel PowerUpExit;
        public static FrameModel InvestigateFurther;
        public static FrameModel PullHandOutOfSocket;
        public static FrameModel PowerUpExit2;
        public static FrameModel LeaveScene;

        public RnDScene(string film, string act, PlayerModel player)
        {
            Film = film;
            Act = act;
            Player = player;

            RnDExit = new FrameModel(Film, Act, Scene, "RnDExit", Constants.ResearchDoor);
            InvestigateAccessPanel = new FrameModel(Film, Act, Scene, "InvestigateAccessPanel", Constants.ResearchDoor);
            SocketHand = new FrameModel(Film, Act, Scene, "SocketHand", Constants.ResearchDoor);
            PowerUpExit = new FrameModel(Film, Act, Scene, "PowerUpExit", Constants.ResearchDoor);
            InvestigateFurther = new FrameModel(Film, Act, Scene, "InvestigateFurther", Constants.ResearchDoor);
            PullHandOutOfSocket = new FrameModel(Film, Act, Scene, "PullHandOutOfSocket", Constants.ResearchDoor);
            PowerUpExit2 = new FrameModel(Film, Act, Scene, "PowerUpExit2", Constants.ResearchDoor);
            LeaveScene = new FrameModel(Film, Act, Scene, "LeaveScene", Constants.ResearchDoor);

            Frames = new Dictionary<string, FrameModel>() {
                {RnDExit.Name, RnDExit},
                {InvestigateAccessPanel.Name, InvestigateAccessPanel},
                {SocketHand.Name, SocketHand},
                {PowerUpExit.Name, PowerUpExit},
                {InvestigateFurther.Name, InvestigateFurther},
                {PullHandOutOfSocket.Name, PullHandOutOfSocket},
                {PowerUpExit2.Name, PowerUpExit2},
                {LeaveScene.Name, LeaveScene},
            };
        }

        public static void Initialise()
        {
            InitialiseRnDExit(RnDExit);
            InitialiseInvestigateAccessPanel(InvestigateAccessPanel);
            InitialiseSocketHand(SocketHand);
            InitialisePowerUpExit(PowerUpExit);
            InitialiseInvestigateFurther(InvestigateFurther);
            InitialisePullHandOutOfSocket(PullHandOutOfSocket);
            InitialisePowerUpExit2(PowerUpExit2);
            InitialiseLeaveScene(LeaveScene);
        }

        public static void InitialiseRnDExit(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("As the hallway bends, you find a large door with an access panel to its side."),
                    new DialogueModel("On the wall is a map of the ship, it shows the layout of this zone and indicates you are within the R&D sector."),
                    new DialogueModel("Beyond the door, it indicates a path towards the navigation sector through the ship's infirmary."),
                    new DialogueModel("The door's access panel shows a blank screen and does not respond.", new Func<bool>(() => { return !Player.HasItem(PowerUpExit.CurrentLocation); })),
                    new DialogueModel("The door's access panel lights up.", new Func<bool>(() => { return Player.HasItem(PowerUpExit.CurrentLocation); })),
                    new DialogueModel("It requests senior privileges to open the door.", new Func<bool>(() => { return Player.HasItem(PowerUpExit.CurrentLocation); })),
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Investigate access panel.", InvestigateAccessPanel, 
                        condition: new Func<bool>(() => { return !Player.HasVisited(PowerUpExit.CurrentLocation); })),
                    new ButtonModel("Use access card.", LeaveScene, 
                        condition: new Func<bool>(() => { return (Player.HasVisited(PowerUpExit.CurrentLocation) || Player.HasVisited(PowerUpExit2.CurrentLocation)) && Player.HasItem(Constants.SteinmannAccessCard); })),
                    new ButtonModel("Head towards the Maintenance Room.", DroneRoomScene.Entrance),
                    new ButtonModel("Head towards the office.", ComputerRoomScene.ComputerRoom),

                });
        }

        public static void InitialiseInvestigateAccessPanel(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>()
                {
                    new DialogueModel("It appears the door has no power."),
                    new DialogueModel("Looking around, you notice a hidden panel off to the side that hides a socket about the size of your hand.", 
                        condition: new Func<bool>(() => { return !Player.HasVisited(InvestigateAccessPanel.CurrentLocation); })),
                    new DialogueModel("There is a hidden panel off to the side that hides a socket about the size of your hand.", 
                        condition: new Func<bool>(() => { return Player.HasVisited(InvestigateAccessPanel.CurrentLocation); })),
                 },
                new List<ButtonModel>()
                {
                    new ButtonModel("Place hand in socket.", SocketHand),
                    new ButtonModel("Investigate further.", InvestigateFurther),
                    new ButtonModel("Place spare battery inside.", PowerUpExit2,
                        condition: new Func<bool>(() => { return Player.HasItem(Constants.SpareBattery); }),
                        action: new Func<System.Threading.Tasks.Task>(async () => { Player.RemoveItem(Constants.SpareBattery); }))
                });
        }

        public static void InitialiseSocketHand(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>()
                {
                    new DialogueModel("You push your hand into the socket, it fits well into the opening."),
                    new DialogueModel("Just as your palm touches the bottom of the socket, a charging symbol displays on the access panel.")
                 },
                new List<ButtonModel>()
                {
                    new ButtonModel("Discharge energy into socket.", PowerUpExit,
                        condition: new Func<bool>(() => { return Player.Energy > 0; }),
                        action: new Func<System.Threading.Tasks.Task>(async () => { Player.Energy--; })),
                    new ButtonModel("Unsocket your hand.", PullHandOutOfSocket),
                });
        }

        public static void InitialisePowerUpExit(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("Electricity arcs down your arm and into the socket."),
                    new DialogueModel("The screen lights up."),
                    new DialogueModel("  > System in lock-down."),
                    new DialogueModel("  > Please be advised: Only those accompanied by senior officers may pass between sectors."),
                    new DialogueModel("You feel a bit weaker from the exertion."),
                    new DialogueModel("You unsocket your hand.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Use access card.", LeaveScene),
                    new ButtonModel("Head towards Maintenance Room.", DroneRoomScene.Entrance),
                    new ButtonModel("Head towards the office.", ComputerRoomScene.ComputerRoom)
                });
        }

        public static void InitialiseInvestigateFurther(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>()
                {
                    new DialogueModel("It appears the socket is used in the event of an emergency."),
                new DialogueModel("Backup batteries can be placed within the socket in order to power the door."),
                new DialogueModel("Looking at your hands, they look like they can fit into the socket just as well.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Place hand in socket.", SocketHand),
                    new ButtonModel("Place spare battery inside.", PowerUpExit2,
                    condition: new Func<bool>(() => { return Player.HasItem(Constants.SpareBattery); }),
                        action: new Func<System.Threading.Tasks.Task>(async () => { Player.RemoveItem(Constants.SpareBattery); })),
                    new ButtonModel("Return.", RnDExit)
                });
        }

        public static void InitialisePullHandOutOfSocket(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>()
                {
                    new DialogueModel("You pull your hand out of the socket."),
                    new DialogueModel("There must be another way.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Return.", RnDExit)
                });
        }

        public static void InitialisePowerUpExit2(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>()
                {
                    new DialogueModel("You socket the battery into the opening, it fits well into the slot."),
                new DialogueModel("The screen lights up."),
                new DialogueModel("  > System in lock-down."),
                new DialogueModel("  > Please be advised: Only those accompanied by senior officers may pass between sectors.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Use access card.", LeaveScene, 
                        condition: new Func<bool>(() => { return Player.HasItem(Constants.SteinmannAccessCard); })),
                    new ButtonModel("Head towards Maintenance Room.", DroneRoomScene.Entrance),
                    new ButtonModel("Head towards the office.", ComputerRoomScene.ComputerRoom)
                });
        }

        public static void InitialiseLeaveScene(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>()
                {
                    new DialogueModel("The panel lights up green."),
                    new DialogueModel("    > Welcome, Dr. Jan Steinmann"),
                    new DialogueModel("    > Access granted."),
                    new DialogueModel("The large door opens slowly, revealing a much darker corridor."),
                    new DialogueModel("It seems electricity is having trouble making it through this part of the ship.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue forward.", TJunctionScene.HearSound),
                });
        }

    }
}
