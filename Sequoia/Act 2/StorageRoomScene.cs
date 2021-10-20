using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Sequoia
{
    public class StorageRoomScene : SceneModel
    {
        public static string Film;
        public static string Act;
        public static string Scene = "StorageRoom";
        public static PlayerModel Player;

        public static FrameModel StorageRoomBase;
        public static FrameModel ExamineBoxes;
        public static FrameModel OpenBatteryBox;
        public static FrameModel UsePRK;
        public static FrameModel InspectTheRoom;
        public static FrameModel InspectTheRoom2;
        public static FrameModel StackBoxesByVent;
        public static FrameModel UseDroneAccessCard;
        public static FrameModel BreakThroughVent;
        public static FrameModel EnterVentNoSound;
        public static FrameModel EnterVentWithSound;
        public static FrameModel StopAndStaySilentVent;
        public static FrameModel RushToVentExit;

        public StorageRoomScene(string film, string act, PlayerModel player)
        {
            Film = film;
            Act = act;
            Player = player;

            StorageRoomBase = new FrameModel(Film, Act, Scene, "StorageRoomBase", Constants.StorageRoom);
            ExamineBoxes = new FrameModel(Film, Act, Scene, "ExamineBoxes", Constants.StorageRoom);
            OpenBatteryBox = new FrameModel(Film, Act, Scene, "OpenBatteryBox", Constants.StorageRoom);
            UsePRK = new FrameModel(Film, Act, Scene, "UsePRK", Constants.StorageRoom);
            InspectTheRoom = new FrameModel(Film, Act, Scene, "InspectTheRoom", Constants.StorageRoom);
            InspectTheRoom2 = new FrameModel(Film, Act, Scene, "InspectTheRoom2", Constants.StorageRoom);
            StackBoxesByVent = new FrameModel(Film, Act, Scene, "StackBoxesByVent", Constants.StorageRoom);
            UseDroneAccessCard = new FrameModel(Film, Act, Scene, "UseDroneAccessCard", Constants.StorageRoom);
            BreakThroughVent = new FrameModel(Film, Act, Scene, "BreakThroughVent", Constants.StorageRoom);
            EnterVentNoSound = new FrameModel(Film, Act, Scene, "EnterVentNoSound", Constants.StorageRoom);
            EnterVentWithSound = new FrameModel(Film, Act, Scene, "EnterVentWithSound", Constants.Black);
            StopAndStaySilentVent = new FrameModel(Film, Act, Scene, "StopAndStaySilentVent", Constants.Black);
            RushToVentExit = new FrameModel(Film, Act, Scene, "RushToVentExit", Constants.Black);

            Frames = new Dictionary<string, FrameModel>() {
                {StorageRoomBase.Name, StorageRoomBase},
                {ExamineBoxes.Name, ExamineBoxes},
                {OpenBatteryBox.Name, OpenBatteryBox},
                {UsePRK.Name, UsePRK},
                {InspectTheRoom.Name, InspectTheRoom},
                {InspectTheRoom2.Name, InspectTheRoom2},
                {StackBoxesByVent.Name, StackBoxesByVent},
                {UseDroneAccessCard.Name, UseDroneAccessCard},
                {BreakThroughVent.Name, BreakThroughVent},
                {EnterVentNoSound.Name, EnterVentNoSound},
                {EnterVentWithSound.Name, EnterVentWithSound},
                {StopAndStaySilentVent.Name, StopAndStaySilentVent},
                {RushToVentExit.Name, RushToVentExit},
            };
        }

        public static void Initialise()
        {
            InitialiseStorageRoomBase(StorageRoomBase);
            InitialiseExamineBoxes(ExamineBoxes);
            InitialiseOpenBatteryBox(OpenBatteryBox);
            InitialiseUsePRK(UsePRK);
            InitialiseInspectTheRoom(InspectTheRoom);
            InitialiseInspectTheRoom2(InspectTheRoom2);
            InitialiseStackBoxesByVent(StackBoxesByVent);
            InitialiseUseDroneAccessCard(UseDroneAccessCard);
            InitialiseBreakThroughVent(BreakThroughVent);
            InitialiseEnterVentNoSound(EnterVentNoSound);
            InitialiseEnterVentWithSound(EnterVentWithSound);
            InitialiseStopAndStaySilentVent(StopAndStaySilentVent);
            InitialiseRushToVentExit(RushToVentExit);
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
                    new ButtonModel("Examine the boxes.", ExamineBoxes),
                    new ButtonModel("Inspect the room.", InspectTheRoom,
                        condition: new Func<bool>(() => { return !Player.HasVisited(InspectTheRoom2.CurrentLocation); })),
                    new ButtonModel("Inspect the room.", InspectTheRoom,
                        condition: new Func<bool>(() => { return Player.HasVisited(InspectTheRoom2.CurrentLocation) && !Player.HasVisited(StackBoxesByVent.CurrentLocation); })),
                    new ButtonModel("Go to vent.", InspectTheRoom,
                        condition: new Func<bool>(() => { return Player.HasVisited(StackBoxesByVent.CurrentLocation); })),
                });
        }

        public static void InitialiseExamineBoxes(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("The boxes were split into sections, some contained assortments of food satchels while others were filled with general purpose items like stationary and spare clothing."),
                    new DialogueModel("You get the impression these supplies were meant to last decades."),
                    // Hasn't stacked boxes
                    new DialogueModel("Some of these boxes look sturdy enough to stand on.",
                        condition: new Func<bool>(() => { return Player.HasVisited(InspectTheRoom2.CurrentLocation) && !Player.HasVisited(StackBoxesByVent.CurrentLocation); })),
                    // Stacked boxes
                    new DialogueModel("You have removed some of the boxes and stacked them underneath the vent.",
                        condition: new Func<bool>(() => { return Player.HasVisited(InspectTheRoom2.CurrentLocation) && Player.HasVisited(StackBoxesByVent.CurrentLocation); })),
                    // Battery box
                    new DialogueModel("Out of the corner of your eye, you see a box with battery symbols on it.",
                        condition: new Func<bool>(() => { return !Player.HasVisited(ExamineBoxes.CurrentLocation); })),
                    new DialogueModel("There is a box with battery symbols on it on one of the shelves in the room.",
                        condition: new Func<bool>(() => { return Player.HasVisited(ExamineBoxes.CurrentLocation); })),
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Open the box.", OpenBatteryBox),
                    new ButtonModel("Use boxes to reach vent.", StackBoxesByVent,
                        condition: new Func<bool>(() => { return Player.HasVisited(InspectTheRoom2.CurrentLocation) && !Player.HasVisited(StackBoxesByVent.CurrentLocation); })),
                    new ButtonModel("Return.", StorageRoomBase),
                });
        }

        public static void InitialiseOpenBatteryBox(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("The box has a rectangular case inside with a socket on top about the size of your hand."),
                    new DialogueModel("There is a label on top that reads:"),
                    new DialogueModel("> [Experimental] Vespenergy Portable Recharge Kit (VPRK)"),
                    new DialogueModel("Followed by many warnings for possible explosions, liquid fires and radiation when used."),
                    new DialogueModel("It appears the kit has been spent, it no longer holds any charge.",
                        condition: new Func<bool>(() => { return Player.HasVisited(UsePRK.CurrentLocation); })),
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Use Portable Recharge Kit.", UsePRK,
                        condition: new Func<bool>(() => { return !Player.HasVisited(UsePRK.CurrentLocation); }),
                        action: new Func<System.Threading.Tasks.Task>(async () => { Player.Energy = Player.MaxEnergy; })),
                    new ButtonModel("Return.", StorageRoomBase),
                });
        }

        public static void InitialiseUsePRK(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You socket your hand into the case."),
                    new DialogueModel("A whirring sound begins as the box vibrates and begins to heat up."),
                    new DialogueModel("You feel your arm involuntarily engage, as power soars through it."),
                    new DialogueModel("After a long minute, the whirring comes to a stop and your arm disengages."),
                    new DialogueModel("You feel reinvigorated.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Return.", StorageRoomBase),
                });
        }

        public static void InitialiseInspectTheRoom(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You walk around the room, peering into the dark for an alternative exit."),
                new DialogueModel("The low lighting made the room look a bit smaller than you had first imagined."),
                new DialogueModel("However, most of it is simply filled with more shelves for storage."),
                new DialogueModel("As you circle around, you do not find any other exits.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue search.", InspectTheRoom2),
                    new ButtonModel("Examine the boxes.", ExamineBoxes),
                });
        }

        public static void InitialiseInspectTheRoom2(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    //first visit
                    new DialogueModel("Suddenly you feel a faint whaft of air across your neck.",
                        condition: new Func<bool>(() => { return !Player.HasVisited(InspectTheRoom2.CurrentLocation); })),
                    new DialogueModel("As you try to look for the source, it brings you to a corner of the room.",
                        condition: new Func<bool>(() => { return !Player.HasVisited(InspectTheRoom2.CurrentLocation); })),
                    new DialogueModel("Up above, is a vent that looks like what the drones would use to traverse the ship.",
                        condition: new Func<bool>(() => { return !Player.HasVisited(InspectTheRoom2.CurrentLocation); })),
                    new DialogueModel("It is a bit too high up for you to reach it.",
                        condition: new Func<bool>(() => { return !Player.HasVisited(InspectTheRoom2.CurrentLocation); })),
                    // subsequent visit (no boxes)
                     new DialogueModel("Among the many shelves, there's a vent high up in the corner of the room.",
                        condition: new Func<bool>(() => { return Player.HasVisited(InspectTheRoom2.CurrentLocation) && !Player.HasVisited(StackBoxesByVent.CurrentLocation); })),
                     new DialogueModel("It is a bit too far up for you to reach.",
                        condition: new Func<bool>(() => { return Player.HasVisited(InspectTheRoom2.CurrentLocation) && !Player.HasVisited(StackBoxesByVent.CurrentLocation); })),
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Examine the boxes.", ExamineBoxes),
                    new ButtonModel("Return.", StorageRoomBase),
                });
        }

        public static void InitialiseStackBoxesByVent(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    //first visit
                    new DialogueModel("You stack several boxes on top of each other to use as footing to reach the vent.",
                        condition: new Func<bool>(() => { return !Player.HasVisited(StackBoxesByVent.CurrentLocation); })),
                    new DialogueModel("Climbing up, a panel is activated by proximity.",
                        condition: new Func<bool>(() => { return !Player.HasVisited(StackBoxesByVent.CurrentLocation); })),
                    new DialogueModel("  > Awaiting identification...",
                        condition: new Func<bool>(() => { return !Player.HasVisited(StackBoxesByVent.CurrentLocation); })),
                    new DialogueModel("The vent entrance looks flimsy enough to break.",
                        condition: new Func<bool>(() => { return !Player.HasVisited(StackBoxesByVent.CurrentLocation); })),
                    // subsequent visit
                    new DialogueModel("The panel lights up as you get close to it.",
                        condition: new Func<bool>(() => { return Player.HasVisited(StackBoxesByVent.CurrentLocation) && !Player.HasVisited(UseDroneAccessCard.CurrentLocation) && !Player.HasVisited(BreakThroughVent.CurrentLocation); })),
                    new DialogueModel("  > Awaiting identification...",
                        condition: new Func<bool>(() => { return Player.HasVisited(StackBoxesByVent.CurrentLocation) && !Player.HasVisited(UseDroneAccessCard.CurrentLocation) && !Player.HasVisited(BreakThroughVent.CurrentLocation); })),
                    // used drone card
                    new DialogueModel("The panel lights up as you get close to it.",
                        condition: new Func<bool>(() => { return Player.HasVisited(StackBoxesByVent.CurrentLocation) && Player.HasVisited(UseDroneAccessCard.CurrentLocation); })),
                    new DialogueModel("  > Access granted",
                        condition: new Func<bool>(() => { return Player.HasVisited(StackBoxesByVent.CurrentLocation) && Player.HasVisited(UseDroneAccessCard.CurrentLocation); })),
                    new DialogueModel("The vent is already open for you to enter.",
                        condition: new Func<bool>(() => { return Player.HasVisited(StackBoxesByVent.CurrentLocation) && Player.HasVisited(UseDroneAccessCard.CurrentLocation); })),
                    // broken through vent
                    new DialogueModel("The panel lights up as you get close to it.",
                        condition: new Func<bool>(() => { return Player.HasVisited(StackBoxesByVent.CurrentLocation) && Player.HasVisited(BreakThroughVent.CurrentLocation); })),
                    new DialogueModel("  > Error. Unable to operate vent lock.",
                        condition: new Func<bool>(() => { return Player.HasVisited(StackBoxesByVent.CurrentLocation) && Player.HasVisited(BreakThroughVent.CurrentLocation); })),
                    new DialogueModel("The vent has been pryed open, allowing you to enter.",
                        condition: new Func<bool>(() => { return Player.HasVisited(StackBoxesByVent.CurrentLocation) && Player.HasVisited(BreakThroughVent.CurrentLocation); })),
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Use drone access card.", UseDroneAccessCard,
                        condition: new Func<bool>(() => { return !Player.HasVisited(UseDroneAccessCard.CurrentLocation) && !Player.HasVisited(BreakThroughVent.CurrentLocation); })),
                    new ButtonModel("Break through vent.", BreakThroughVent,
                        condition: new Func<bool>(() => { return !Player.HasVisited(UseDroneAccessCard.CurrentLocation) && !Player.HasVisited(BreakThroughVent.CurrentLocation); })),
                    new ButtonModel("Enter vent.", EnterVentNoSound,
                        condition: new Func<bool>(() => { return Player.HasVisited(UseDroneAccessCard.CurrentLocation) && !Player.HasVisited(BreakThroughVent.CurrentLocation); })),
                    new ButtonModel("Enter vent.", EnterVentWithSound,
                        condition: new Func<bool>(() => { return !Player.HasVisited(UseDroneAccessCard.CurrentLocation) && Player.HasVisited(BreakThroughVent.CurrentLocation); })),
                    new ButtonModel("Return.", StorageRoomBase),
                });
        }

        public static void InitialiseUseDroneAccessCard(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("The panel gives an affirmative beep as the access card is detected."),
                    new DialogueModel("The screen displays:."),
                    new DialogueModel("  > ID: Drone N1L-159."),
                    new DialogueModel("  > Access Granted."),
                    new DialogueModel("The panel swings open, allowing you to enter the vent.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Enter vent.", EnterVentNoSound),
                    new ButtonModel("Return.", StorageRoomBase),
                });
        }

        public static void InitialiseBreakThroughVent(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You jab your elbow into the vent and it caves in."),
                    new DialogueModel("The impact of the blow echoes throughout the ventilation system."),
                    new DialogueModel("Prying the uneven edges of the opening out, you create a hole large enough to climb through.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Enter vent.", EnterVentWithSound),
                    new ButtonModel("Return.", StorageRoomBase),
                });
        }

        public static void InitialiseEnterVentNoSound(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("The vent is dark, but you see a light protruding down one end of the tunnel."),
                    new DialogueModel("Its claustrophobic climbing through system, and you hear distant scampering within the vents."),
                    new DialogueModel("Luckily, it hadn't noticed your presence. Making as little noise as possible, you reach the exit."),
                    new DialogueModel("Looking down, you see the way is clear.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", InfirmaryScene.InfirmaryBase),
                });
        }

        public static void InitialiseEnterVentWithSound(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("The vent is dark, but soon you see a light protruding down one end of the tunnel."),
                    new DialogueModel("It's claustrophobic climbing through system, and moving forward is difficult."),
                    new DialogueModel("Suddenly, you hear scampering close by in the vents.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Stop and stay silent.", StopAndStaySilentVent),
                    new ButtonModel("Rush to exit.", RushToVentExit),
                });
        }

        public static void InitialiseStopAndStaySilentVent(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You stop and wait for the scampering to pass."),
                    new DialogueModel("You stay still for a long while, until the sound is long gone."),
                    new DialogueModel("Cautiously crawling ahead, you reach the exit."),
                    new DialogueModel("Looking down, you can see the way is clear.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", InfirmaryScene.InfirmaryBase),
                });
        }

        public static void InitialiseRushToVentExit(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You pick up the pace, trading stealth for speed."),
                    new DialogueModel("The scampering suddenly changes direction, and is getting louder."),
                    new DialogueModel("You crawl as fast as you can, making it to the exit."),
                    new DialogueModel("Just as you're about to jump down, something grabs you by the foot."),
                    new DialogueModel("Its strength far surpasses yours, and you are dragged back into the vent system.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", MiscellaneousScene.Dead),
                });
        }


    }
}
