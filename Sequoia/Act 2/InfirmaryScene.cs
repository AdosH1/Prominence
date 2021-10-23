using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Sequoia
{
    public class InfirmaryScene : SceneModel
    {
        public static string Film;
        public static string Act;
        public static string Scene = "Infirmary";
        public static PlayerModel Player;

        public static FrameModel InfirmaryBase;
        public static FrameModel HeadTowardsClosedDoor;
        public static FrameModel InvestigateVent;
        public static FrameModel VentEntrance;
        public static FrameModel ClimbThroughVent;
        public static FrameModel ClimbThroughVent2;
        public static FrameModel FollowBloodTrail;
        public static FrameModel PushTheDoor;
        public static FrameModel PushTheDoor2;
        public static FrameModel PushTheDoor3;
        public static FrameModel PushTheDoor4;
        public static FrameModel PushTheDoor5;
        public static FrameModel PushTheDoor6;
        public static FrameModel PushTheDoor7;
        public static FrameModel PushTheDoor8;
        public static FrameModel PushTheDoor9;
        public static FrameModel PushTheDoor10;
        public static FrameModel PushTheDoor11;
        public static FrameModel HeadThroughGap;

        public InfirmaryScene(string film, string act, PlayerModel player)
        {
            Film = film;
            Act = act;
            Player = player;

            InfirmaryBase = new FrameModel(Film, Act, Scene, "InfirmaryBase", Constants.RecoveryBase);
            HeadTowardsClosedDoor = new FrameModel(Film, Act, Scene, "HeadTowardsClosedDoor", Constants.RecoveryBase);
            InvestigateVent = new FrameModel(Film, Act, Scene, "InvestigateVent", Constants.RecoveryBase);
            VentEntrance = new FrameModel(Film, Act, Scene, "VentEntrance", Constants.RecoveryBase);
            ClimbThroughVent = new FrameModel(Film, Act, Scene, "ClimbThroughVent", Constants.RecoveryBase);
            ClimbThroughVent2 = new FrameModel(Film, Act, Scene, "ClimbThroughVent2", Constants.Black);
            FollowBloodTrail = new FrameModel(Film, Act, Scene, "FollowBloodTrail", Constants.RecoveryBase);
            PushTheDoor = new FrameModel(Film, Act, Scene, "PushTheDoor", Constants.RecoveryBase);
            PushTheDoor2 = new FrameModel(Film, Act, Scene, "PushTheDoor2", Constants.RecoveryBase);
            PushTheDoor3 = new FrameModel(Film, Act, Scene, "PushTheDoor3", Constants.RecoveryBase);
            PushTheDoor4 = new FrameModel(Film, Act, Scene, "PushTheDoor4", Constants.RecoveryBase);
            PushTheDoor5 = new FrameModel(Film, Act, Scene, "PushTheDoor5", Constants.RecoveryBase);
            PushTheDoor6 = new FrameModel(Film, Act, Scene, "PushTheDoor6", Constants.RecoveryBase);
            PushTheDoor7 = new FrameModel(Film, Act, Scene, "PushTheDoor7", Constants.RecoveryBase);
            PushTheDoor8 = new FrameModel(Film, Act, Scene, "PushTheDoor8", Constants.RecoveryBase);
            PushTheDoor9 = new FrameModel(Film, Act, Scene, "PushTheDoor9", Constants.RecoveryBase);
            PushTheDoor10 = new FrameModel(Film, Act, Scene, "PushTheDoor10", Constants.RecoveryBase);
            PushTheDoor11 = new FrameModel(Film, Act, Scene, "PushTheDoor11", Constants.RecoveryBase);
            HeadThroughGap = new FrameModel(Film, Act, Scene, "HeadThroughGap", Constants.Black);

            Frames = new Dictionary<string, FrameModel>() {
                {InfirmaryBase.Name,InfirmaryBase},
                {HeadTowardsClosedDoor.Name,HeadTowardsClosedDoor},
                {InvestigateVent.Name,InvestigateVent},
                {VentEntrance.Name,VentEntrance},
                {ClimbThroughVent.Name,ClimbThroughVent},
                {ClimbThroughVent2.Name,ClimbThroughVent2},
                {FollowBloodTrail.Name,FollowBloodTrail},
                {PushTheDoor.Name,PushTheDoor},
                {PushTheDoor2.Name,PushTheDoor2},
                {PushTheDoor3.Name,PushTheDoor3},
                {PushTheDoor4.Name,PushTheDoor4},
                {PushTheDoor5.Name,PushTheDoor5},
                {PushTheDoor6.Name,PushTheDoor6},
                {PushTheDoor7.Name,PushTheDoor7},
                {PushTheDoor8.Name,PushTheDoor8},
                {PushTheDoor9.Name,PushTheDoor9},
                {PushTheDoor10.Name,PushTheDoor10},
                {PushTheDoor11.Name,PushTheDoor11},
                {HeadThroughGap.Name,HeadThroughGap},
            };
        }

        public static void Initialise()
        {
            InitialiseInfirmaryBase(InfirmaryBase);
            InitialiseHeadTowardsClosedDoor(HeadTowardsClosedDoor);
            InitialiseInvestigateVent(InvestigateVent);
            InitialiseVentEntrance(VentEntrance);
            InitialiseClimbThroughVent(ClimbThroughVent);
            InitialiseClimbThroughVent2(ClimbThroughVent2);
            InitialiseFollowBloodTrail(FollowBloodTrail);
            InitialisePushTheDoor(PushTheDoor);
            InitialisePushTheDoor2(PushTheDoor2);
            InitialisePushTheDoor3(PushTheDoor3);
            InitialisePushTheDoor4(PushTheDoor4);
            InitialisePushTheDoor5(PushTheDoor5);
            InitialisePushTheDoor6(PushTheDoor6);
            InitialisePushTheDoor7(PushTheDoor7);
            InitialisePushTheDoor8(PushTheDoor8);
            InitialisePushTheDoor9(PushTheDoor9);
            InitialisePushTheDoor10(PushTheDoor10);
            InitialisePushTheDoor11(PushTheDoor11);
            InitialiseHeadThroughGap(HeadThroughGap);
        }

        public static void InitialiseInfirmaryBase(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You enter into a dimly lit room, the lights give a blue hue to everything in the room.", 
                        condition: new Func<bool>(() => { return !Player.HasVisited(InfirmaryBase.CurrentLocation); })),
                    new DialogueModel("The place is in shambles, but it looks like it used to be a reception area, with seats lining the walls and an arcing desk protruding out from the wall."),
                    new DialogueModel("Blood stains trail onto the desk from another vent above. It continues off to the side and leads into another room."),
                    new DialogueModel("On the opposite end is a set of closed swing doors.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Investigate vent.", InvestigateVent),
                    new ButtonModel("Follow blood trail.", FollowBloodTrail,
                        condition: new Func<bool>(() => { return !Player.HasVisited(FollowBloodTrail.CurrentLocation); })),
                    new ButtonModel("Go to Recovery Room.", RecoveryRoomScene.RecoveryRoomBase,
                        condition: new Func<bool>(() => { return Player.HasVisited(FollowBloodTrail.CurrentLocation) && !Player.HasVisited(RecoveryRoomScene.InspectRecoveryRoom.CurrentLocation); })),
                    new ButtonModel("Go to Recovery Room.", RecoveryRoomScene.InspectRecoveryRoom,
                        condition: new Func<bool>(() => { return Player.HasVisited(RecoveryRoomScene.InspectRecoveryRoom.CurrentLocation); })),
                    new ButtonModel("Head towards closed doors.", HeadTowardsClosedDoor),

                });
        }

        public static void InitialiseHeadTowardsClosedDoor(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    // Door closed
                    new DialogueModel("You attempt to open the door, it is not locked.",
                        condition: new Func<bool>(() => { return !Player.HasVisited(PushTheDoor11.CurrentLocation); })),
                    new DialogueModel("But the door does not budge. There seems to be something blocking it from the other side.",
                        condition: new Func<bool>(() => { return !Player.HasVisited(PushTheDoor11.CurrentLocation); })),
                    new DialogueModel("Hmm.",
                        condition: new Func<bool>(() => { return !Player.HasVisited(PushTheDoor11.CurrentLocation); })),
                    // Second time through
                    new DialogueModel("Your mind might be playing tricks on you, but was there the slightest budge?",
                        condition: new Func<bool>(() => { return !Player.HasVisited(PushTheDoor11.CurrentLocation) && Player.HasVisited(HeadTowardsClosedDoor.CurrentLocation); })),
                    // Door open
                    new DialogueModel("The door is slightly ajar, allowing you to slip through.",
                        condition: new Func<bool>(() => { return Player.HasVisited(PushTheDoor11.CurrentLocation); })),
                    new DialogueModel("If you squeeze through the gap, you won't be able to come back.",
                        condition: new Func<bool>(() => { return Player.HasVisited(PushTheDoor11.CurrentLocation); })),
                },
                new List<ButtonModel>()
                {
                    // Push door, haven't made it to the end
                    new ButtonModel("Push the door.", PushTheDoor,
                        condition: new Func<bool>(() => { return Player.HasVisited(HeadTowardsClosedDoor.CurrentLocation) && !Player.HasVisited(PushTheDoor11.CurrentLocation); })),
                    // Made it to the end
                    new ButtonModel("Head through the gap.", HeadThroughGap,
                        condition: new Func<bool>(() => { return Player.HasVisited(PushTheDoor11.CurrentLocation); })),
                    // Investigate vent (have not been to entrance)
                    new ButtonModel("Investigate vent.", InvestigateVent,
                        condition: new Func<bool>(() => { return !Player.HasVisited(VentEntrance.CurrentLocation); })),
                    new ButtonModel("Head to vent.", VentEntrance,
                        condition: new Func<bool>(() => { return Player.HasVisited(VentEntrance.CurrentLocation); })),
                    new ButtonModel("Follow blood trail.", FollowBloodTrail,
                        condition: new Func<bool>(() => { return !Player.HasVisited(FollowBloodTrail.CurrentLocation); })),
                    new ButtonModel("Go to Recovery Room.", RecoveryRoomScene.RecoveryRoomBase,
                        condition: new Func<bool>(() => { return Player.HasVisited(FollowBloodTrail.CurrentLocation) && !Player.HasVisited(RecoveryRoomScene.InspectRecoveryRoom.CurrentLocation); })),
                    new ButtonModel("Go to Recovery Room.", RecoveryRoomScene.InspectRecoveryRoom,
                        condition: new Func<bool>(() => { return Player.HasVisited(RecoveryRoomScene.InspectRecoveryRoom.CurrentLocation); })),
                });
        }

        public static void InitialiseInvestigateVent(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("Towards the vent is the reception desk."),
                    new DialogueModel("There is blood, now dark and dry, splattered across its surface."),
                    new DialogueModel("It looks like you can reach the vent by jumping onto the desk.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Hop onto desk.", VentEntrance),
                    new ButtonModel("Head to closed doors.", HeadTowardsClosedDoor),
                    new ButtonModel("Follow blood trail.", FollowBloodTrail,
                        condition: new Func<bool>(() => { return !Player.HasVisited(FollowBloodTrail.CurrentLocation); })),
                    new ButtonModel("Go to Recovery Room.", RecoveryRoomScene.RecoveryRoomBase,
                        condition: new Func<bool>(() => { return Player.HasVisited(FollowBloodTrail.CurrentLocation) && !Player.HasVisited(RecoveryRoomScene.InspectRecoveryRoom.CurrentLocation); })),
                    new ButtonModel("Go to Recovery Room.", RecoveryRoomScene.InspectRecoveryRoom,
                        condition: new Func<bool>(() => { return Player.HasVisited(RecoveryRoomScene.InspectRecoveryRoom.CurrentLocation); })),
                });
        }

        public static void InitialiseVentEntrance(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("The smell of iron fills the air as you approach the outlet. The vent is dark but you can feel a faint breeze coming from the other end."),
                    new DialogueModel("You cannot see what lies ahead, but it goes further forward from where you are now."),
                    new DialogueModel("The vent is just wide enough for you to fit inside.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Climb through vent.", ClimbThroughVent),
                    new ButtonModel("Head to closed doors.", HeadTowardsClosedDoor),
                    new ButtonModel("Follow blood trail.", FollowBloodTrail,
                        condition: new Func<bool>(() => { return !Player.HasVisited(FollowBloodTrail.CurrentLocation); })),
                    new ButtonModel("Go to Recovery Room.", RecoveryRoomScene.RecoveryRoomBase,
                        condition: new Func<bool>(() => { return Player.HasVisited(FollowBloodTrail.CurrentLocation) && !Player.HasVisited(RecoveryRoomScene.InspectRecoveryRoom.CurrentLocation); })),
                    new ButtonModel("Go to Recovery Room.", RecoveryRoomScene.InspectRecoveryRoom,
                        condition: new Func<bool>(() => { return Player.HasVisited(RecoveryRoomScene.InspectRecoveryRoom.CurrentLocation); })),
                });
        }

        public static void InitialiseClimbThroughVent(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("The vent is claustrophobic and difficult to maneuver in."),
                    new DialogueModel("If you head through now you will not be able to head back."),
                    new DialogueModel("Do you wish to continue?")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", ClimbThroughVent2),
                    new ButtonModel("Return.", InfirmaryBase),
                });
        }

        public static void InitialiseClimbThroughVent2(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You head in the direction of the breeze you felt earlier."),
                    new DialogueModel("The crawl space is unpleasant, and the blood seems to continue down the path you're taking.."),
                    new DialogueModel("Upon reaching the end of the vent, you look down to see a marble floor. You do not hear anything around.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Jump down.", PreNavigationScene.PreNavigationBase),
                });
        }

        public static void InitialiseFollowBloodTrail(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You follow the trail into another room."),
                    new DialogueModel("Outside the doorway is a sign labelled 'Recovery Center'."),
                    new DialogueModel("You hear a faint groan from within.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", RecoveryRoomScene.RecoveryRoomBase),
                });
        }

        public static void InitialisePushTheDoor(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You push the door, but the door does not budge.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Investigate vent.", InvestigateVent,
                        condition: new Func<bool>(() => { return !Player.HasVisited(VentEntrance.CurrentLocation); })),
                    new ButtonModel("Head to vent.", VentEntrance,
                        condition: new Func<bool>(() => { return Player.HasVisited(VentEntrance.CurrentLocation); })),
                    new ButtonModel("Push the door.", PushTheDoor2),
                    new ButtonModel("Follow blood trail.", FollowBloodTrail,
                        condition: new Func<bool>(() => { return !Player.HasVisited(FollowBloodTrail.CurrentLocation); })),
                    new ButtonModel("Go to Recovery Room.", RecoveryRoomScene.RecoveryRoomBase,
                        condition: new Func<bool>(() => { return Player.HasVisited(FollowBloodTrail.CurrentLocation) && !Player.HasVisited(RecoveryRoomScene.InspectRecoveryRoom.CurrentLocation); })),
                    new ButtonModel("Go to Recovery Room.", RecoveryRoomScene.InspectRecoveryRoom,
                        condition: new Func<bool>(() => { return Player.HasVisited(RecoveryRoomScene.InspectRecoveryRoom.CurrentLocation); })),
                });
        }

        public static void InitialisePushTheDoor2(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You push the door, but the door does not budge.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Investigate vent.", InvestigateVent,
                        condition: new Func<bool>(() => { return !Player.HasVisited(VentEntrance.CurrentLocation); })),
                    new ButtonModel("Head to vent.", VentEntrance,
                        condition: new Func<bool>(() => { return Player.HasVisited(VentEntrance.CurrentLocation); })),
                    new ButtonModel("Follow blood trail.", FollowBloodTrail,
                        condition: new Func<bool>(() => { return !Player.HasVisited(FollowBloodTrail.CurrentLocation); })),
                    new ButtonModel("Go to Recovery Room.", RecoveryRoomScene.RecoveryRoomBase,
                        condition: new Func<bool>(() => { return Player.HasVisited(FollowBloodTrail.CurrentLocation) && !Player.HasVisited(RecoveryRoomScene.InspectRecoveryRoom.CurrentLocation); })),
                    new ButtonModel("Go to Recovery Room.", RecoveryRoomScene.InspectRecoveryRoom,
                        condition: new Func<bool>(() => { return Player.HasVisited(RecoveryRoomScene.InspectRecoveryRoom.CurrentLocation); })),
                    new ButtonModel("Push the door.", PushTheDoor3),
                });
        }

        public static void InitialisePushTheDoor3(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You push the door, but the door does not budge.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Push the door.", PushTheDoor4),
                    new ButtonModel("Investigate vent.", InvestigateVent,
                        condition: new Func<bool>(() => { return !Player.HasVisited(VentEntrance.CurrentLocation); })),
                    new ButtonModel("Head to vent.", VentEntrance,
                        condition: new Func<bool>(() => { return Player.HasVisited(VentEntrance.CurrentLocation); })),
                    new ButtonModel("Follow blood trail.", FollowBloodTrail,
                        condition: new Func<bool>(() => { return !Player.HasVisited(FollowBloodTrail.CurrentLocation); })),
                    new ButtonModel("Go to Recovery Room.", RecoveryRoomScene.RecoveryRoomBase,
                        condition: new Func<bool>(() => { return Player.HasVisited(FollowBloodTrail.CurrentLocation) && !Player.HasVisited(RecoveryRoomScene.InspectRecoveryRoom.CurrentLocation); })),
                    new ButtonModel("Go to Recovery Room.", RecoveryRoomScene.InspectRecoveryRoom,
                        condition: new Func<bool>(() => { return Player.HasVisited(RecoveryRoomScene.InspectRecoveryRoom.CurrentLocation); })),
                });
        }

        public static void InitialisePushTheDoor4(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You push the door, but the door does not budge.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Investigate vent.", InvestigateVent,
                        condition: new Func<bool>(() => { return !Player.HasVisited(VentEntrance.CurrentLocation); })),
                    new ButtonModel("Head to vent.", VentEntrance,
                        condition: new Func<bool>(() => { return Player.HasVisited(VentEntrance.CurrentLocation); })),
                    new ButtonModel("Follow blood trail.", FollowBloodTrail,
                        condition: new Func<bool>(() => { return !Player.HasVisited(FollowBloodTrail.CurrentLocation); })),
                    new ButtonModel("Go to Recovery Room.", RecoveryRoomScene.RecoveryRoomBase,
                        condition: new Func<bool>(() => { return Player.HasVisited(FollowBloodTrail.CurrentLocation) && !Player.HasVisited(RecoveryRoomScene.InspectRecoveryRoom.CurrentLocation); })),
                    new ButtonModel("Go to Recovery Room.", RecoveryRoomScene.InspectRecoveryRoom,
                        condition: new Func<bool>(() => { return Player.HasVisited(RecoveryRoomScene.InspectRecoveryRoom.CurrentLocation); })),
                    new ButtonModel("Push the door.", PushTheDoor5),
                });
        }

        public static void InitialisePushTheDoor5(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You push the door, but the door does not budge.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Investigate vent.", InvestigateVent,
                        condition: new Func<bool>(() => { return !Player.HasVisited(VentEntrance.CurrentLocation); })),
                    new ButtonModel("Head to vent.", VentEntrance,
                        condition: new Func<bool>(() => { return Player.HasVisited(VentEntrance.CurrentLocation); })),
                    new ButtonModel("Push the door.", PushTheDoor6),
                    new ButtonModel("Follow blood trail.", FollowBloodTrail,
                        condition: new Func<bool>(() => { return !Player.HasVisited(FollowBloodTrail.CurrentLocation); })),
                    new ButtonModel("Go to Recovery Room.", RecoveryRoomScene.RecoveryRoomBase,
                        condition: new Func<bool>(() => { return Player.HasVisited(FollowBloodTrail.CurrentLocation) && !Player.HasVisited(RecoveryRoomScene.InspectRecoveryRoom.CurrentLocation); })),
                    new ButtonModel("Go to Recovery Room.", RecoveryRoomScene.InspectRecoveryRoom,
                        condition: new Func<bool>(() => { return Player.HasVisited(RecoveryRoomScene.InspectRecoveryRoom.CurrentLocation); })),
                });
        }

        public static void InitialisePushTheDoor6(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You push the door again, did it just budge?"),
                    new DialogueModel("It's hard to tell.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Push the door.", PushTheDoor7),
                    new ButtonModel("Investigate vent.", InvestigateVent,
                        condition: new Func<bool>(() => { return !Player.HasVisited(VentEntrance.CurrentLocation); })),
                    new ButtonModel("Head to vent.", VentEntrance,
                        condition: new Func<bool>(() => { return Player.HasVisited(VentEntrance.CurrentLocation); })),
                    new ButtonModel("Follow blood trail.", FollowBloodTrail,
                        condition: new Func<bool>(() => { return !Player.HasVisited(FollowBloodTrail.CurrentLocation); })),
                    new ButtonModel("Go to Recovery Room.", RecoveryRoomScene.RecoveryRoomBase,
                        condition: new Func<bool>(() => { return Player.HasVisited(FollowBloodTrail.CurrentLocation) && !Player.HasVisited(RecoveryRoomScene.InspectRecoveryRoom.CurrentLocation); })),
                    new ButtonModel("Go to Recovery Room.", RecoveryRoomScene.InspectRecoveryRoom,
                        condition: new Func<bool>(() => { return Player.HasVisited(RecoveryRoomScene.InspectRecoveryRoom.CurrentLocation); })),
                });
        }

        public static void InitialisePushTheDoor7(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You push the door, but the door does not budge.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Investigate vent.", InvestigateVent,
                        condition: new Func<bool>(() => { return !Player.HasVisited(VentEntrance.CurrentLocation); })),
                    new ButtonModel("Head to vent.", VentEntrance,
                        condition: new Func<bool>(() => { return Player.HasVisited(VentEntrance.CurrentLocation); })),
                    new ButtonModel("Push the door.", PushTheDoor8),
                    new ButtonModel("Follow blood trail.", FollowBloodTrail,
                        condition: new Func<bool>(() => { return !Player.HasVisited(FollowBloodTrail.CurrentLocation); })),
                    new ButtonModel("Go to Recovery Room.", RecoveryRoomScene.RecoveryRoomBase,
                        condition: new Func<bool>(() => { return Player.HasVisited(FollowBloodTrail.CurrentLocation) && !Player.HasVisited(RecoveryRoomScene.InspectRecoveryRoom.CurrentLocation); })),
                    new ButtonModel("Go to Recovery Room.", RecoveryRoomScene.InspectRecoveryRoom,
                        condition: new Func<bool>(() => { return Player.HasVisited(RecoveryRoomScene.InspectRecoveryRoom.CurrentLocation); })),
                });
        }

        public static void InitialisePushTheDoor8(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You push the door, but the door does not budge.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Push the door.", PushTheDoor9),
                    new ButtonModel("Investigate vent.", InvestigateVent,
                        condition: new Func<bool>(() => { return !Player.HasVisited(VentEntrance.CurrentLocation); })),
                    new ButtonModel("Head to vent.", VentEntrance,
                        condition: new Func<bool>(() => { return Player.HasVisited(VentEntrance.CurrentLocation); })),
                    new ButtonModel("Follow blood trail.", FollowBloodTrail,
                        condition: new Func<bool>(() => { return !Player.HasVisited(FollowBloodTrail.CurrentLocation); })),
                    new ButtonModel("Go to Recovery Room.", RecoveryRoomScene.RecoveryRoomBase,
                        condition: new Func<bool>(() => { return Player.HasVisited(FollowBloodTrail.CurrentLocation) && !Player.HasVisited(RecoveryRoomScene.InspectRecoveryRoom.CurrentLocation); })),
                    new ButtonModel("Go to Recovery Room.", RecoveryRoomScene.InspectRecoveryRoom,
                        condition: new Func<bool>(() => { return Player.HasVisited(RecoveryRoomScene.InspectRecoveryRoom.CurrentLocation); })),
                });
        }

        public static void InitialisePushTheDoor9(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You push the door, but the door does not budge.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Investigate vent.", InvestigateVent,
                        condition: new Func<bool>(() => { return !Player.HasVisited(VentEntrance.CurrentLocation); })),
                    new ButtonModel("Head to vent.", VentEntrance,
                        condition: new Func<bool>(() => { return Player.HasVisited(VentEntrance.CurrentLocation); })),
                    new ButtonModel("Follow blood trail.", FollowBloodTrail,
                        condition: new Func<bool>(() => { return !Player.HasVisited(FollowBloodTrail.CurrentLocation); })),
                    new ButtonModel("Go to Recovery Room.", RecoveryRoomScene.RecoveryRoomBase,
                        condition: new Func<bool>(() => { return Player.HasVisited(FollowBloodTrail.CurrentLocation) && !Player.HasVisited(RecoveryRoomScene.InspectRecoveryRoom.CurrentLocation); })),
                    new ButtonModel("Go to Recovery Room.", RecoveryRoomScene.InspectRecoveryRoom,
                        condition: new Func<bool>(() => { return Player.HasVisited(RecoveryRoomScene.InspectRecoveryRoom.CurrentLocation); })),
                    new ButtonModel("Push the door.", PushTheDoor10),
                });
        }

        public static void InitialisePushTheDoor10(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You push the door, but the door does not budge.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Push the door.", PushTheDoor11),
                    new ButtonModel("Investigate vent.", InvestigateVent,
                        condition: new Func<bool>(() => { return !Player.HasVisited(VentEntrance.CurrentLocation); })),
                    new ButtonModel("Head to vent.", VentEntrance,
                        condition: new Func<bool>(() => { return Player.HasVisited(VentEntrance.CurrentLocation); })),
                    new ButtonModel("Follow blood trail.", FollowBloodTrail,
                        condition: new Func<bool>(() => { return !Player.HasVisited(FollowBloodTrail.CurrentLocation); })),
                    new ButtonModel("Go to Recovery Room.", RecoveryRoomScene.RecoveryRoomBase,
                        condition: new Func<bool>(() => { return Player.HasVisited(FollowBloodTrail.CurrentLocation) && !Player.HasVisited(RecoveryRoomScene.InspectRecoveryRoom.CurrentLocation); })),
                    new ButtonModel("Go to Recovery Room.", RecoveryRoomScene.InspectRecoveryRoom,
                        condition: new Func<bool>(() => { return Player.HasVisited(RecoveryRoomScene.InspectRecoveryRoom.CurrentLocation); })),
                });
        }

        public static void InitialisePushTheDoor11(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("Suddenly the door gives way just a little, leaving a little gap for you to fit through."),
                    new DialogueModel("On the other side, there is a lot of furniture and rubble stacked against the doorway, making it very tricky to navigate past."),
                    new DialogueModel("If you squeeze through the gap, you won't be able to come back.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Head through the gap.", HeadThroughGap),
                    new ButtonModel("Investigate vent.", InvestigateVent,
                        condition: new Func<bool>(() => { return !Player.HasVisited(VentEntrance.CurrentLocation); })),
                    new ButtonModel("Head to vent.", VentEntrance,
                        condition: new Func<bool>(() => { return Player.HasVisited(VentEntrance.CurrentLocation); })),
                    new ButtonModel("Follow blood trail.", FollowBloodTrail,
                        condition: new Func<bool>(() => { return !Player.HasVisited(FollowBloodTrail.CurrentLocation); })),
                    new ButtonModel("Go to Recovery Room.", RecoveryRoomScene.RecoveryRoomBase,
                        condition: new Func<bool>(() => { return Player.HasVisited(FollowBloodTrail.CurrentLocation) && !Player.HasVisited(RecoveryRoomScene.InspectRecoveryRoom.CurrentLocation); })),
                    new ButtonModel("Go to Recovery Room.", RecoveryRoomScene.InspectRecoveryRoom,
                        condition: new Func<bool>(() => { return Player.HasVisited(RecoveryRoomScene.InspectRecoveryRoom.CurrentLocation); })),
                });
        }

        public static void InitialiseHeadThroughGap(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You carefully navigate through the gap, slowly climbing through a long section of rubble, shelves and chairs."),
                    new DialogueModel("Soon, you make it through the other end.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", PreNavigationScene.PreNavigationBase),
                });
        }

    }
}
