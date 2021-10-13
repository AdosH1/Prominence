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
        public static FrameModel PushTheDoor12;

        public InfirmaryScene(string film, string act, PlayerModel player)
        {
            Film = film;
            Act = act;
            Player = player;

            InfirmaryBase = new FrameModel(Film, Act, Scene, "InfirmaryBase", Constants.Infirmary);
            HeadTowardsClosedDoor = new FrameModel(Film, Act, Scene, "HeadTowardsClosedDoor", Constants.Infirmary);
            InvestigateVent = new FrameModel(Film, Act, Scene, "InvestigateVent", Constants.Infirmary);
            VentEntrance = new FrameModel(Film, Act, Scene, "VentEntrance", Constants.Infirmary);
            ClimbThroughVent = new FrameModel(Film, Act, Scene, "ClimbThroughVent", Constants.Infirmary);
            ClimbThroughVent2 = new FrameModel(Film, Act, Scene, "ClimbThroughVent2", Constants.Infirmary);
            FollowBloodTrail = new FrameModel(Film, Act, Scene, "FollowBloodTrail", Constants.Infirmary);
            PushTheDoor = new FrameModel(Film, Act, Scene, "PushTheDoor", Constants.Infirmary);
            PushTheDoor2 = new FrameModel(Film, Act, Scene, "PushTheDoor2", Constants.Infirmary);
            PushTheDoor3 = new FrameModel(Film, Act, Scene, "PushTheDoor3", Constants.Infirmary);
            PushTheDoor4 = new FrameModel(Film, Act, Scene, "PushTheDoor4", Constants.Infirmary);
            PushTheDoor5 = new FrameModel(Film, Act, Scene, "PushTheDoor5", Constants.Infirmary);
            PushTheDoor6 = new FrameModel(Film, Act, Scene, "PushTheDoor6", Constants.Infirmary);
            PushTheDoor7 = new FrameModel(Film, Act, Scene, "PushTheDoor7", Constants.Infirmary);
            PushTheDoor8 = new FrameModel(Film, Act, Scene, "PushTheDoor8", Constants.Infirmary);
            PushTheDoor9 = new FrameModel(Film, Act, Scene, "PushTheDoor9", Constants.Infirmary);
            PushTheDoor10 = new FrameModel(Film, Act, Scene, "PushTheDoor10", Constants.Infirmary);
            PushTheDoor11 = new FrameModel(Film, Act, Scene, "PushTheDoor11", Constants.Infirmary);
            PushTheDoor12 = new FrameModel(Film, Act, Scene, "PushTheDoor12", Constants.Infirmary);

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
                {PushTheDoor12.Name,PushTheDoor12},
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
            InitialisePushTheDoor12(PushTheDoor12);
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


    }
}
