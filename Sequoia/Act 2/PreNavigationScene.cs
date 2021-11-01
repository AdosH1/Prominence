using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Sequoia
{
    public class PreNavigationScene : SceneModel
    {
        public static string Film;
        public static string Act;
        public static string Scene = "PreNavigation";
        public static PlayerModel Player;

        public static FrameModel PreNavigationBase;
        public static FrameModel NavigationDoor;
        public static FrameModel NavigationDoor2;
        public static FrameModel InspectTheRoom;
        public static FrameModel ExamineThePapers;
        public static FrameModel Note1;
        public static FrameModel Note2;
        public static FrameModel SideRoomBase;
        public static FrameModel ExamineTheBody;
        public static FrameModel InspectSideRoom;
        public static FrameModel CheckUnderSeat;
        public static FrameModel GrabMagazine;

        public PreNavigationScene(string film, string act, PlayerModel player)
        {
            Film = film;
            Act = act;
            Player = player;

            PreNavigationBase = new FrameModel(Film, Act, Scene, "PreNavigationBase", Constants.Infirmary);
            NavigationDoor = new FrameModel(Film, Act, Scene, "NavigationDoor", Constants.Infirmary);
            NavigationDoor2 = new FrameModel(Film, Act, Scene, "NavigationDoor2", Constants.Infirmary);
            InspectTheRoom = new FrameModel(Film, Act, Scene, "InspectTheRoom", Constants.Infirmary);
            ExamineThePapers = new FrameModel(Film, Act, Scene, "ExamineThePapers", Constants.Infirmary);
            Note1 = new FrameModel(Film, Act, Scene, "Note1", Constants.Infirmary);
            Note2 = new FrameModel(Film, Act, Scene, "Note2", Constants.Infirmary);
            SideRoomBase = new FrameModel(Film, Act, Scene, "SideRoomBase", Constants.SideRoom);
            ExamineTheBody = new FrameModel(Film, Act, Scene, "ExamineTheBody", Constants.SideRoom);
            InspectSideRoom = new FrameModel(Film, Act, Scene, "InspectSideRoom", Constants.SideRoom);
            CheckUnderSeat = new FrameModel(Film, Act, Scene, "CheckUnderSeat", Constants.SideRoom);
            GrabMagazine = new FrameModel(Film, Act, Scene, "GrabMagazine", Constants.SideRoom);

            Frames = new Dictionary<string, FrameModel>() {
                {PreNavigationBase.Name,PreNavigationBase},
                {NavigationDoor.Name,NavigationDoor},
                {NavigationDoor2.Name,NavigationDoor2},
                {InspectTheRoom.Name,InspectTheRoom},
                {ExamineThePapers.Name,ExamineThePapers},
                {Note1.Name,Note1},
                {Note2.Name,Note2},
                {SideRoomBase.Name,SideRoomBase},
                {ExamineTheBody.Name,ExamineTheBody},
                {InspectSideRoom.Name,InspectSideRoom},
                {CheckUnderSeat.Name,CheckUnderSeat},
                {GrabMagazine.Name,GrabMagazine},
            };
        }

        public static void Initialise()
        {
            InitialisePreNavigationBase(PreNavigationBase);
            InitialiseNavigationDoor(NavigationDoor);
            InitialiseNavigationDoor2(NavigationDoor2);
            InitialiseInspectTheRoom(InspectTheRoom);
            InitialiseExamineThePapers(ExamineThePapers);
            InitialiseNote1(Note1);
            InitialiseNote2(Note2);
            InitialiseSideRoomBase(SideRoomBase);
            InitialiseExamineTheBody(ExamineTheBody);
            InitialiseInspectSideRoom(InspectSideRoom);
            InitialiseCheckUnderSeat(CheckUnderSeat);
            InitialiseGrabMagazine(GrabMagazine);
        }

        public static void InitialisePreNavigationBase(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You jump down into a well lit room.",
                        condition: new Func<bool>(() => { return Player.HasVisited(InfirmaryScene.ClimbThroughVent2.CurrentLocation) && !Player.HasVisited(PreNavigationBase.CurrentLocation); })),
                    new DialogueModel("You enter into a well lit room.",
                        condition: new Func<bool>(() => { return Player.HasVisited(InfirmaryScene.HeadThroughGap.CurrentLocation) && !Player.HasVisited(PreNavigationBase.CurrentLocation); })),
                    new DialogueModel("The whole place is a mess, with hospital beds overturned, and papers thrown across the floor."),
                    new DialogueModel("There appears to have been some struggle that has happened here."),
                    new DialogueModel("On the opposite end of room, you see the navigation room door.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Inspect the room.", InspectTheRoom),
                    new ButtonModel("Head to navigation door.", NavigationDoor)
                });
        }

        public static void InitialiseNavigationDoor(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("The mess continues towards the navigation door."),
                    new DialogueModel("The access panel activates, revealing a familiar message."),
                    new DialogueModel("  > Attention: Ship is under lockdown until further notice. If you require to move between sectors, please find your senior officer to escort you. Sorry for the inconvenience."),
                    new DialogueModel("The door requires an access card.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Use access card.", NavigationDoor2,
                        condition: new Func<bool>(() => { return Player.HasItem(Constants.SteinmannAccessCard); })),
                    new ButtonModel("Return.", PreNavigationBase)
                });
        }

        public static void InitialiseNavigationDoor2(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("Using this door will take you to the next room."),
                    new DialogueModel("Are you sure?")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", NavigationRoomScene.Entrance),
                    new ButtonModel("Return.", PreNavigationBase)
                });
        }

        public static void InitialiseInspectTheRoom(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("The papers thrown across the floor appear to be medical papers for several patients that had been here."),
                    new DialogueModel("There's spots of dry blood splattered on the papers. You notice that it stems from a trail of blood leading into seperate room to the side.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Examine the papers.", ExamineThePapers),
                    new ButtonModel("Head to side room.", SideRoomBase),
                    new ButtonModel("Head to navigation door.", NavigationDoor)
                });
        }

        public static void InitialiseExamineThePapers(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("The papers detail several patients and their medical records."),
                    new DialogueModel("Common among them are signs of schizophrenia, internal pains and aggression."),
                    new DialogueModel("Several notes were made by a doctor named Jacob Miles.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Note 1.", Note1),
                    new ButtonModel("Note 2.", Note2),
                    new ButtonModel("Return.", InspectTheRoom)
                });
        }

        public static void InitialiseNote1(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("The medication is not working on the crew as it did on Earth, and the patients are getting less cooperative."),
                    new DialogueModel("We've never experienced such prolonged cryostasis before, and I fear the crew will worsen."),
                    new DialogueModel("I advised the captain to put the affected crew back on ice until we reach Andrea, maybe awaken some the previous officers..."),
                    new DialogueModel("...But he's having none of it, as long as they're their doing their jobs.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Note 2.", Note2),
                    new ButtonModel("Return.", InspectTheRoom)
                });
        }

        public static void InitialiseNote2(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("Just the other day I was hit by a patient, they are acting increasingly feral."),
                    new DialogueModel("We had to tie some of them down to the beds to stop them from lashing out."),
                    new DialogueModel("Somethings not right, and there's definitely more happening than we know."),
                    new DialogueModel("The only peace of mind I have right now is that I have been keeping a gun underneath the chair in my office.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Note 1.", Note1),
                    new ButtonModel("Return.", InspectTheRoom)
                });
        }

        public static void InitialiseSideRoomBase(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You follow the trail back into a small office.",
                        condition: new Func<bool>(() => { return !Player.HasVisited(SideRoomBase.CurrentLocation); })),
                    new DialogueModel("A sign next to the doorway reads:"),
                    new DialogueModel("      Chief Medical Officer"),
                    new DialogueModel("      Jacob Miles"),
                    new DialogueModel("As you enter the room, you can immediately see a body on the floor, its back resting against a cabinet.",
                        condition: new Func<bool>(() => { return !Player.HasVisited(SideRoomBase.CurrentLocation); })),
                    new DialogueModel("It doesn't move, and dry blood covers most of its chest.",
                        condition: new Func<bool>(() => { return !Player.HasVisited(SideRoomBase.CurrentLocation); })),
                    new DialogueModel("A dead body lies on the floor, its back resting against a cabinet.",
                        condition: new Func<bool>(() => { return Player.HasVisited(SideRoomBase.CurrentLocation); })),
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Inspect the room.", InspectSideRoom),
                    new ButtonModel("Examine the body.", ExamineTheBody),
                    new ButtonModel("Exit.", InspectTheRoom)
                });
        }

        public static void InitialiseExamineTheBody(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("The man is wearing a lab coat with the letters 'J.M.' sewn into his chest pocket."),
                    new DialogueModel("He and something else seemed to be the cause of the blood splatters."),
                    new DialogueModel("Across from the body are bullet holes that indicate he was firing in that direction, but the gun in nowhere in sight."),
                    new DialogueModel("The man shows no vital signs and looks to be long dead.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Inspect the room.", InspectSideRoom),
                    new ButtonModel("Exit.", InspectTheRoom)
                });
        }

        public static void InitialiseInspectSideRoom(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("The office has many folders and cabinets but are mostly filled with medical records."),
                    new DialogueModel("Bullet marks on the walls show the victim had some form of defense against the assailant, but he ultimately met his demise."),
                    new DialogueModel("There is not much to note about this room.",
                        condition: new Func<bool>(() => { return !Player.HasVisited(Note2.CurrentLocation); })),
                    new DialogueModel("You remember Jacob writing about his gun.",
                        condition: new Func<bool>(() => { return Player.HasVisited(Note2.CurrentLocation); })),
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Check underneath his seat.", CheckUnderSeat,
                        condition: new Func<bool>(() => { return Player.HasVisited(Note2.CurrentLocation); })),
                    new ButtonModel("Examine the body.", ExamineTheBody),
                    new ButtonModel("Exit.", InspectTheRoom)
                });
        }

        public static void InitialiseCheckUnderSeat(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("Underneath his seat is a holster for a hand gun, though the gun slot is empty."),
                    new DialogueModel("There are 3 additional slots for ammunition, with one slot still holding a spare magazine.",
                        condition: new Func<bool>(() => { return !Player.HasVisited(GrabMagazine.CurrentLocation); })),
                    new DialogueModel("There are 3 additional slots for ammunition, however all of the magazines are gone.",
                        condition: new Func<bool>(() => { return Player.HasVisited(GrabMagazine.CurrentLocation); })),
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Grab spare magazine.", GrabMagazine,
                        condition: new Func<bool>(() => { return !Player.HasVisited(GrabMagazine.CurrentLocation); }),
                        action: new Func<System.Threading.Tasks.Task>(async () => { Player.AddItem(Constants.SpareMagazine); })),
                    new ButtonModel("Examine the body.", ExamineTheBody),
                    new ButtonModel("Exit.", InspectTheRoom)
                });
        }

        public static void InitialiseGrabMagazine(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You grab the spare magazine."),
                    new DialogueModel("It is an 8 bullet cartridge with a label on the side that reads:"),
                    new DialogueModel("    > Kospre Industries")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Examine the body.", ExamineTheBody),
                    new ButtonModel("Exit.", InspectTheRoom)
                });
        }


    }
}
