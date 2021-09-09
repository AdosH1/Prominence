﻿using Prominence.Controllers;
using Prominence.Model;
using Prominence.Model.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prominence.Resources.DialogueData.Sequoia
{
    public class DroneRoomScene : SceneModel
    {
        public static string Film;
        public static string Act;
        public static string Scene = "DroneRoom";
        public static PlayerModel Player;

        public static FrameModel Entrance;
        public static FrameModel DroneRoom;
        public static FrameModel InspectTheRoom;
        public static FrameModel InspectTheDrone1;
        public static FrameModel InspectTheDrone2;
        public static FrameModel InspectTheDrone3;
        public static FrameModel InspectTheTable;
        public static FrameModel SmashDrawer;
        public static FrameModel LockpickDrawer;
        public static FrameModel GrabBattery;
        public static FrameModel TakeTheChip;

        public DroneRoomScene(string film, string act, PlayerModel player)
        {
            Film = film;
            Act = act;
            Player = player;

            Entrance = new FrameModel(Film, Act, Scene, "Entrance", SequoiaConstants.Corridor);
            DroneRoom = new FrameModel(Film, Act, Scene, "DroneRoom", SequoiaConstants.DroneRoom);
            InspectTheRoom = new FrameModel(Film, Act, Scene, "InspectTheRoom", SequoiaConstants.DroneRoom);
            InspectTheDrone1 = new FrameModel(Film, Act, Scene, "InspectTheDrone1", SequoiaConstants.Terminal);
            InspectTheDrone2 = new FrameModel(Film, Act, Scene, "InspectTheDrone2", SequoiaConstants.Terminal);
            InspectTheDrone3 = new FrameModel(Film, Act, Scene, "InspectTheDrone3", SequoiaConstants.Terminal);
            InspectTheTable = new FrameModel(Film, Act, Scene, "InspectTheTable", SequoiaConstants.DroneRoom);
            SmashDrawer = new FrameModel(Film, Act, Scene, "SmashDrawer", SequoiaConstants.DroneRoom);
            LockpickDrawer = new FrameModel(Film, Act, Scene, "LockpickDrawer", SequoiaConstants.DroneRoom);
            GrabBattery = new FrameModel(Film, Act, Scene, "GrabBattery", SequoiaConstants.DroneRoom);
            TakeTheChip = new FrameModel(Film, Act, Scene, "TakeTheChip", SequoiaConstants.Terminal);

            Frames = new Dictionary<string, FrameModel>() {
                {Entrance.Name, Entrance},
                {DroneRoom.Name, DroneRoom},
                {InspectTheRoom.Name, InspectTheRoom},
                {InspectTheDrone1.Name, InspectTheDrone1},
                {InspectTheDrone2.Name, InspectTheDrone2},
                {InspectTheDrone3.Name, InspectTheDrone3},
                {InspectTheTable.Name, InspectTheTable},
                {SmashDrawer.Name, SmashDrawer},
                {LockpickDrawer.Name, LockpickDrawer},
                {GrabBattery.Name, GrabBattery},
                {TakeTheChip.Name, TakeTheChip},
            };
        }

        public static void Initialise()
        {
            InitialiseEntrance(Entrance);
            InitialiseDroneRoom(DroneRoom);
            InitialiseInspectTheRoom(InspectTheRoom);
            InitialiseInspectTheDrone1(InspectTheDrone1);
            InitialiseInspectTheDrone2(InspectTheDrone2);
            InitialiseInspectTheDrone3(InspectTheDrone3);
            InitialiseInspectTheTable(InspectTheTable);
            InitialiseSmashDrawer(SmashDrawer);
            InitialiseLockpickDrawer(LockpickDrawer);
            InitialiseGrabBattery(GrabBattery);
            InitialiseTakeTheChip(TakeTheChip);
        }

        public static void InitialiseEntrance(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {  
                    // Visit first
                    new DialogueModel("The drone silently hovers further down the hallway.", condition: new Func<bool>(() => { return !Player.HasVisited(DroneRoom.CurrentLocation); }) ),//fun(): Boolean { return !GameState.HasVisited.contains(200) && !GameState.HasVisited.contains(300) }),
                    new DialogueModel("As you follow it, you pass many other similar rooms, but there's no sign of any people around.", condition: new Func<bool>(() => { return !Player.HasVisited(DroneRoom.CurrentLocation); }) ),//fun(): Boolean { return !GameState.HasVisited.contains(200) && !GameState.HasVisited.contains(300) }),
                    new DialogueModel("The drone enters a side room just as the hallway turns.", condition: new Func<bool>(() => { return !Player.HasVisited(DroneRoom.CurrentLocation); })),//fun(): Boolean { return !GameState.HasVisited.contains(200) && !GameState.HasVisited.contains(300) }),
                    new DialogueModel("A sign outside the room reads:", condition: new Func<bool>(() => { return !Player.HasVisited(DroneRoom.CurrentLocation); })),//fun(): Boolean { return !GameState.HasVisited.contains(200) && !GameState.HasVisited.contains(300) }),
                    new DialogueModel("      Drone Maintenance Room", condition: new Func<bool>(() => { return !Player.HasVisited(DroneRoom.CurrentLocation); })),//fun(): Boolean { return !GameState.HasVisited.contains(200) && !GameState.HasVisited.contains(300) }),
                    // After first visit
                    new DialogueModel("The hallway looks indifferent down both ends... perhaps the only way to find your bearings is to track the flickering lights above.", condition: new Func<bool>(() => { return Player.HasVisited(DroneRoom.CurrentLocation); }) ),//fun(): Boolean { return GameState.HasVisited.contains(200) }),
                    // Computer room first
                    new DialogueModel("You pass many rooms similar to the one you woke up in, but there's no sign of any people around..", condition: new Func<bool>(() => { return !Player.HasVisited(DroneRoom.CurrentLocation); }) ),//fun(): Boolean { return !GameState.HasVisited.contains(200) && GameState.HasVisited.contains(300) }),
                    new DialogueModel("You reach a room with a sign outside marked: Drone Maintenance Room.", condition: new Func<bool>(() => { return !Player.HasVisited(DroneRoom.CurrentLocation); }) ),//fun(): Boolean { return !GameState.HasVisited.contains(200) && GameState.HasVisited.contains(300) }) },
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Enter Maintenance Room.", DroneRoom),
                    new ButtonModel("Go towards the red light.", DroneRoom),//300, fun(): Boolean { return !GameState.HasVisited.contains(300)}, buttonActions = {GameState.GC?.ChangeBackground(R.drawable.computerroom)}),
                    //new ButtonModel("Head to the office.", DroneRoom, 
                    //    action: new Func<System.Threading.Tasks.Task>(async () => { GameController.ChangeBackground(SequoiaConstants.ComputerRoom); }) ),//fun(): Boolean {return GameState.HasVisited.contains(300)}, buttonActions = { GameState.GC?.ChangeBackground(R.drawable.computerroom)}),
                    new ButtonModel("Continue down the hallway.", DroneRoom), //400, fun(): Boolean {return !GameState.HasVisited.contains(400)}, buttonActions = { GameState.GC?.ChangeBackground(R.drawable.researchdoor)}),
                    //new ButtonModel("Head to R&D Exit.", DroneRoom, 
                    //    action: new Func<System.Threading.Tasks.Task>(async () => { GameController.ChangeBackground(SequoiaConstants.ComputerRoom); }))//400, fun(): Boolean {return GameState.HasVisited.contains(400)}, buttonActions = { GameState.GC?.ChangeBackground(R.drawable.researchdoor)})
                });
        }


        // ========= Drone Room ========= //
        public static void InitialiseDroneRoom(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>()
                {
                    new DialogueModel("Many drones line the sides of a relatively small room, a thick layer of dust covers most of the them. They don't seem to have moved in a very long time."),
                    new DialogueModel("You see the drone from earlier docked in its station at the end of the room.")
                 },
                new List<ButtonModel>()
                {
                    new ButtonModel("Survey the room.", InspectTheRoom),
                    new ButtonModel("Inspect the drone.", InspectTheDrone1),
                    new ButtonModel("Exit the room.", Entrance)
                });
        }

        // ========= Inspect the Room ========= //
        public static void InitialiseInspectTheRoom(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>()
                {
                    new DialogueModel("None of the drones in the room have power, even though they're docked in their charging stations."),
                    new DialogueModel("In the corner of the room there is a table covered in miscellaneous tools and schematics.")
                 },
                new List<ButtonModel>()
                {
                    new ButtonModel("Investigate the table.", InspectTheTable),
                    new ButtonModel("Inspect the drone.", InspectTheDrone1),//buttonActions = {if (!GameState.HasVisited.contains(203)) GameState.GC?.ChangeBackground(R.drawable.terminal)}),
                    new ButtonModel("Exit the room.", Entrance)
                });
        }

        // ========= Inspect the Drone ========= //
        public static void InitialiseInspectTheDrone1(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {  
                    // First time visit
                    new DialogueModel("The drone has an interface on its back.", condition: new Func<bool>(() => { return !Player.HasVisited(InspectTheDrone1.CurrentLocation); })),
                    new DialogueModel("The screen flickers on, revealing a command terminal.", condition: new Func<bool>(() => { return !Player.HasVisited(InspectTheDrone1.CurrentLocation); })),
                    new DialogueModel("The battery icon in the corner indicates that the device is about to die.", condition: new Func<bool>(() => { return !Player.HasVisited(InspectTheDrone1.CurrentLocation); })),

                    // Visted before
                    new DialogueModel("A dead drone lies on its station, unable to charge.", condition: new Func<bool>(() => { return Player.HasVisited(InspectTheDrone1.CurrentLocation); })),
                    new DialogueModel("You notice a chip protruding out from underneath the terminal.", condition: new Func<bool>(() => { return Player.HasVisited(InspectTheDrone1.CurrentLocation) && Player.HasItem(SequoiaConstants.DroneAccessCard); }))
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Take the chip.", TakeTheChip,
                        condition: new Func<bool>(() => { return Player.HasItem(SequoiaConstants.DroneAccessCard) && Player.HasVisited(InspectTheDrone1.CurrentLocation); })), //fun(): Unit { GameState.Inventory.add("Drone Id Card"); GC?.ShowItemNotification("Drone Access Card"); }),
                    new ButtonModel("Read the terminal.", InspectTheDrone2,
                        condition: new Func<bool>(() => { return !Player.HasVisited(InspectTheDrone1.CurrentLocation); })),
                    new ButtonModel("Inspect the room.", InspectTheRoom),
                    new ButtonModel("Exit the room.", Entrance)
                });
        }

        // ========= Inspect the Drone 2 ========= //
        public static void InitialiseInspectTheDrone2(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>()
                {
                    new DialogueModel("  > Override successful."),
                    new DialogueModel("  > Running android initialization protocol... complete."),
                    new DialogueModel("  > Warning: Device is at critical battery levels."),
                    new DialogueModel("  > Returning to station... complete."),
                    new DialogueModel("  > Error: Device is not charging - please check your output port to begin charging."),
                    new DialogueModel("  > Shutting down...")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", InspectTheDrone3)
                });
        }

        // ========= Inspect the Drone 3 ========= //
        public static void InitialiseInspectTheDrone3(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>()
                {
                    new DialogueModel("The screen fades to black and a chip ejects from underneath the terminal.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Take the chip.", TakeTheChip,
                        condition: new Func<bool>(() => { return !Player.HasItem(SequoiaConstants.DroneAccessCard); })), //GC?.ShowItemNotification("Drone Access Card");}
                    new ButtonModel("Inspect the room.", InspectTheRoom),
                    new ButtonModel("Exit the room.", Entrance)
                });
        }

        // ========= Inspect the Table ========= //
        public static void InitialiseInspectTheTable(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>()
                {
                    new DialogueModel("The table contains various tools like screw drivers, tweezers and clamps."),
                    new DialogueModel("There are schematics sprawled across the desk for several types of drones, along with charts on how to assemble them."),
                    new DialogueModel("Underneath the desk is a locked wooden drawer.",
                        condition: new Func<bool>(() => { return !Player.HasVisited(SmashDrawer.CurrentLocation) && !Player.HasVisited(LockpickDrawer.CurrentLocation); })),
                    new DialogueModel("The smashed remains of the drawer and battery lay splattered on the floor.",
                        condition: new Func<bool>(() => { return Player.HasVisited(SmashDrawer.CurrentLocation); })),
                    new DialogueModel("Underneath the desk is an opened drawer, a spare battery sits within it.",
                        condition: new Func<bool>(() => { return Player.HasVisited(LockpickDrawer.CurrentLocation) && !Player.HasItem(SequoiaConstants.SpareBattery); })),
                    new DialogueModel("Underneath the desk is a open drawer, nothing is inside of it.",
                        condition: new Func<bool>(() => { return Player.HasVisited(LockpickDrawer.CurrentLocation) && Player.HasItem(SequoiaConstants.SpareBattery); }))
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Smash drawer open.", SmashDrawer,
                        condition: new Func<bool>(() => { return !Player.HasVisited(SmashDrawer.CurrentLocation) && !Player.HasVisited(LockpickDrawer.CurrentLocation); })),
                    new ButtonModel("Attempt lockpick (with tweezers).", LockpickDrawer,
                        condition: new Func<bool>(() => { return !Player.HasVisited(SmashDrawer.CurrentLocation) && !Player.HasVisited(LockpickDrawer.CurrentLocation); })),
                    new ButtonModel("Take the spare battery.", GrabBattery,
                        condition: new Func<bool>(() => { return Player.HasVisited(LockpickDrawer.CurrentLocation) && !Player.HasItem(SequoiaConstants.SpareBattery); }),
                        action: new Func<System.Threading.Tasks.Task>(async () => { Player.AddItem(SequoiaConstants.SpareBattery); })),// GC?.ShowItemNotification("Spare Battery"); }),
                    new ButtonModel("Return.", DroneRoom)
                });
        }

        // ========= Smash Drawer ========= //
        public static void InitialiseSmashDrawer(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>()
                {
                    new DialogueModel("You perform a downward stomp, angled into the lock of the drawer."),
                    new DialogueModel("With a loud snap, the whole thing caves in and its contents shatter on the floor."),
                    new DialogueModel("It appears to have been holding a battery cell, its fluids now splattered across the floor.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Return.", DroneRoom)
                });
        }

        // ========= Lockpick Drawer ========= //
        public static void InitialiseLockpickDrawer(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>()
                {
                    new DialogueModel("You bend a pair of tweezers so that it fits within the lock."),
                    new DialogueModel("After a while of fiddling with the lock mechanism, you hear a distinct click. The drawer is now unlocked."),
                    new DialogueModel("Inside holds a spare battery cell. It looks as if it might still hold charge.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Take the spare battery.", GrabBattery,
                        action: new Func<System.Threading.Tasks.Task>(async () => { Player.AddItem(SequoiaConstants.SpareBattery); })),//GC?.ShowItemNotification("Spare Battery");}),
                    new ButtonModel("Return.", DroneRoom)
                });
        }

        // ========= Grab Battery ========= //
        public static void InitialiseGrabBattery(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>()
                {
                    new DialogueModel("The battery is hefty. A label on the side reads: Vespenergy - Power your way through the stars!"),
                    new DialogueModel("Vespenergy - Power your way through the stars!")
                 },
                new List<ButtonModel>()
                {
                    new ButtonModel("Inspect the drone.", InspectTheDrone1),
                    new ButtonModel("Exit the room.", Entrance)
                });
        }

        // ========= Take the Chip ========= //
        public static void InitialiseTakeTheChip(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>()
                {
                    new DialogueModel("You pull the chip out. On the back, the chip reads:"),
                    new DialogueModel("    Drone Identification Card"),
                    new DialogueModel("    N1L-159")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Inspect the room.", InspectTheRoom),
                    new ButtonModel("Exit the room.", Entrance),
                });
        }

    }
}
