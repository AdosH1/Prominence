using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Sequoia
{ 
    public class RecoveryRoomScene : SceneModel
    {
        public static string Film;
        public static string Act;
        public static string Scene = "RecoveryRoom";
        public static PlayerModel Player;

        public static FrameModel RecoveryRoomBase;
        public static FrameModel InspectTheFeral;
        public static FrameModel InspectTheFeral2;
        public static FrameModel InspectTheFeral3;
        public static FrameModel InspectRecoveryRoom;
        public static FrameModel InvestigateControlPanel;
        public static FrameModel EjectTheBattery;
        public static FrameModel PowerMachineByBattery;
        public static FrameModel PowerMachineByHand;
        public static FrameModel PowerMachineByHandSuccess;
        public static FrameModel PowerMachineByHandFail;
        public static FrameModel PowerMachineByHandFail2;
        public static FrameModel ConfigureMachine;
        public static FrameModel ConfigureMachine2;
        public static FrameModel ConfigureMachine3;
        public static FrameModel ConfigureMachine4;
        public static FrameModel MachineRunning;
        public static FrameModel MachineSuccess;
        public static FrameModel MachineFailure;
        public static FrameModel InvestigateTextBooks;
        public static FrameModel ReadManual;
        public static FrameModel ReadManual2;
        public static FrameModel ReadManual3;
        public static FrameModel InvestigateFeralSuccess;
        public static FrameModel InvestigateFeralFail;

        public RecoveryRoomScene(string film, string act, PlayerModel player)
        {
            Film = film;
            Act = act;
            Player = player;

            RecoveryRoomBase = new FrameModel(Film, Act, Scene, "RecoveryRoomBase", Constants.RecoveryRoom);
            InspectTheFeral = new FrameModel(Film, Act, Scene, "InspectTheFeral", Constants.RecoveryRoom);
            InspectTheFeral2 = new FrameModel(Film, Act, Scene, "InspectTheFeral2", Constants.RecoveryRoom);
            InspectTheFeral3 = new FrameModel(Film, Act, Scene, "InspectTheFeral3", Constants.RecoveryRoom);
            InspectRecoveryRoom = new FrameModel(Film, Act, Scene, "InspectRecoveryRoom", Constants.RecoveryRoom);
            InvestigateControlPanel = new FrameModel(Film, Act, Scene, "InvestigateControlPanel", Constants.RecoveryRoom);
            EjectTheBattery = new FrameModel(Film, Act, Scene, "EjectTheBattery", Constants.RecoveryRoom);
            PowerMachineByBattery = new FrameModel(Film, Act, Scene, "PowerMachineByBattery", Constants.RecoveryRoom);
            PowerMachineByHand = new FrameModel(Film, Act, Scene, "PowerMachineByHand", Constants.RecoveryRoom);
            PowerMachineByHandSuccess = new FrameModel(Film, Act, Scene, "PowerMachineByHandSuccess", Constants.RecoveryRoom);
            PowerMachineByHandFail = new FrameModel(Film, Act, Scene, "PowerMachineByHandFail", Constants.RecoveryRoom);
            PowerMachineByHandFail2 = new FrameModel(Film, Act, Scene, "PowerMachineByHandFail2", Constants.RecoveryRoom);
            ConfigureMachine = new FrameModel(Film, Act, Scene, "ConfigureMachine", Constants.RecoveryRoom);
            ConfigureMachine2 = new FrameModel(Film, Act, Scene, "ConfigureMachine2", Constants.RecoveryRoom);
            ConfigureMachine3 = new FrameModel(Film, Act, Scene, "ConfigureMachine3", Constants.RecoveryRoom);
            ConfigureMachine4 = new FrameModel(Film, Act, Scene, "ConfigureMachine4", Constants.RecoveryRoom);
            MachineRunning = new FrameModel(Film, Act, Scene, "MachineRunning", Constants.RecoveryRoom);
            MachineSuccess = new FrameModel(Film, Act, Scene, "MachineSuccess", Constants.RecoveryRoom);
            MachineFailure = new FrameModel(Film, Act, Scene, "MachineFailure", Constants.RecoveryRoom);
            InvestigateTextBooks = new FrameModel(Film, Act, Scene, "InvestigateTextBooks", Constants.RecoveryRoom);
            ReadManual = new FrameModel(Film, Act, Scene, "ReadManual", Constants.RecoveryRoom);
            ReadManual2 = new FrameModel(Film, Act, Scene, "ReadManual2", Constants.RecoveryRoom);
            ReadManual3 = new FrameModel(Film, Act, Scene, "ReadManual3", Constants.RecoveryRoom);
            InvestigateFeralSuccess = new FrameModel(Film, Act, Scene, "InvestigateFeralSuccess", Constants.RecoveryRoom);
            InvestigateFeralFail = new FrameModel(Film, Act, Scene, "InvestigateFeralFail", Constants.RecoveryRoom);

            Frames = new Dictionary<string, FrameModel>() {
                {RecoveryRoomBase.Name,RecoveryRoomBase},
                {InspectTheFeral.Name,InspectTheFeral},
                {InspectTheFeral2.Name,InspectTheFeral2},
                {InspectTheFeral3.Name,InspectTheFeral3},
                {InspectRecoveryRoom.Name,InspectRecoveryRoom},
                {InvestigateControlPanel.Name,InvestigateControlPanel},
                {EjectTheBattery.Name,EjectTheBattery},
                {PowerMachineByBattery.Name,PowerMachineByBattery},
                {PowerMachineByHand.Name,PowerMachineByHand},
                {PowerMachineByHandSuccess.Name,PowerMachineByHandSuccess},
                {PowerMachineByHandFail.Name,PowerMachineByHandFail},
                {PowerMachineByHandFail2.Name,PowerMachineByHandFail2},
                {ConfigureMachine.Name,ConfigureMachine},
                {ConfigureMachine2.Name,ConfigureMachine2},
                {ConfigureMachine3.Name,ConfigureMachine3},
                {ConfigureMachine4.Name,ConfigureMachine4},
                {MachineRunning.Name,MachineRunning},
                {MachineSuccess.Name,MachineSuccess},
                {MachineFailure.Name,MachineFailure},
                {InvestigateTextBooks.Name,InvestigateTextBooks},
                {ReadManual.Name,ReadManual},
                {ReadManual2.Name,ReadManual2},
                {ReadManual3.Name,ReadManual3},
                {InvestigateFeralSuccess.Name,InvestigateFeralSuccess},
                {InvestigateFeralFail.Name,InvestigateFeralFail},
            };
        }

        public static void Initialise()
        {
            InitialiseRecoveryRoomBase(RecoveryRoomBase);
            InitialiseInspectTheFeral(InspectTheFeral);
            InitialiseInspectTheFeral2(InspectTheFeral2);
            InitialiseInspectTheFeral3(InspectTheFeral3);
            InitialiseInspectRecoveryRoom(InspectRecoveryRoom);
            InitialiseInvestigateControlPanel(InvestigateControlPanel);
            InitialiseEjectTheBattery(EjectTheBattery);
            InitialisePowerMachineByBattery(PowerMachineByBattery);
            InitialisePowerMachineByHand(PowerMachineByHand);
            InitialisePowerMachineByHandSuccess(PowerMachineByHandSuccess);
            InitialisePowerMachineByHandFail(PowerMachineByHandFail);
            InitialisePowerMachineByHandFail2(PowerMachineByHandFail2);
            InitialiseConfigureMachine(ConfigureMachine);
            InitialiseConfigureMachine2(ConfigureMachine2);
            InitialiseConfigureMachine3(ConfigureMachine3);
            InitialiseConfigureMachine4(ConfigureMachine4);
            InitialiseMachineRunning(MachineRunning);
            InitialiseMachineSuccess(MachineSuccess);
            InitialiseMachineFailure(MachineFailure);
            InitialiseInvestigateTextBooks(InvestigateTextBooks);
            InitialiseReadManual(ReadManual);
            InitialiseReadManual2(ReadManual2);
            InitialiseReadManual3(ReadManual3);
            InitialiseInvestigateFeralSuccess(InvestigateFeralSuccess);
            InitialiseInvestigateFeralFail(InvestigateFeralFail);
        }

        public static void InitialiseRecoveryRoomBase(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("In the center of the room is a large machine with blood marks all over it."),
                    new DialogueModel("* groan *",
                        condition: new Func<bool>(() => { return !Player.HasVisited(RecoveryRoomBase.CurrentLocation); })),
                    new DialogueModel("The sound comes from a glass chamber from within the machine.",
                        condition: new Func<bool>(() => { return !Player.HasVisited(RecoveryRoomBase.CurrentLocation); })),
                    new DialogueModel("It seems a feral has been entrapped inside.",
                        condition: new Func<bool>(() => { return !Player.HasVisited(RecoveryRoomBase.CurrentLocation); })),
                    new DialogueModel("Inside a glass chamber lies a feral entrapped inside.",
                        condition: new Func<bool>(() => { return Player.HasVisited(RecoveryRoomBase.CurrentLocation); })),
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Inspect the feral..", InspectTheFeral,
                        condition: new Func<bool>(() => { return !Player.HasVisited(InspectTheFeral.CurrentLocation); })),
                    new ButtonModel("Inspect the feral..", InspectTheFeral2,
                        condition: new Func<bool>(() => { return Player.HasVisited(InspectTheFeral.CurrentLocation) && !Player.HasVisited(InspectTheFeral2.CurrentLocation); })),
                    new ButtonModel("Inspect the feral..", InspectTheFeral3,
                        condition: new Func<bool>(() => { return Player.HasVisited(InspectTheFeral.CurrentLocation) && Player.HasVisited(InspectTheFeral2.CurrentLocation); })),
                    new ButtonModel("Inspect the room.", InspectRecoveryRoom),
                    new ButtonModel("Leave.", InfirmaryScene.InfirmaryBase),

                });
        }

        public static void InitialiseInspectTheFeral(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("The feral is injured, the blood seemed to have originated from several wounds coming from around its chest and shoulders."),
                    new DialogueModel("You can see its chest slightly raise and depress as it fights to catch each breath."),
                    new DialogueModel("Is it fear in its eyes?"),
                    new DialogueModel("You can just make out a dog tag hanging around the feral's neck, the tag reads:",
                        condition: new Func<bool>(() => { return Player.HasVisited(ReadManual3.CurrentLocation); })),
                    new DialogueModel("    Name: Jorge Del Sierra",
                        condition: new Func<bool>(() => { return Player.HasVisited(ReadManual3.CurrentLocation); })),
                    new DialogueModel("    Gender: Male",
                        condition: new Func<bool>(() => { return Player.HasVisited(ReadManual3.CurrentLocation); })),
                    new DialogueModel("    Bloodtype: Z+",
                        condition: new Func<bool>(() => { return Player.HasVisited(ReadManual3.CurrentLocation); })),
                },
                new List<ButtonModel>()
                {
                    // Hasn't inspected room
                    new ButtonModel("Inspect the room.", InspectRecoveryRoom,
                        condition: new Func<bool>(() => { return !Player.HasVisited(InspectRecoveryRoom.CurrentLocation); })),
                    // Has inspected room
                    new ButtonModel("Inspect control panel.", InvestigateControlPanel,
                        condition: new Func<bool>(() => { return Player.HasVisited(InspectRecoveryRoom.CurrentLocation); })),
                    new ButtonModel("Investigate text books.", InvestigateTextBooks,
                        condition: new Func<bool>(() => { return Player.HasVisited(InspectRecoveryRoom.CurrentLocation); })),
                    new ButtonModel("Leave.", InfirmaryScene.InfirmaryBase),

                });
        }

        public static void InitialiseInspectTheFeral2(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("The feral weakly raises its hand towards you, but after a brief moment, its hand drops."),
                    new DialogueModel("It now lays motionless in the chamber."),
                    new DialogueModel("You can just make out a dog tag hanging around the feral's neck, the tag reads:",
                        condition: new Func<bool>(() => { return Player.HasVisited(ReadManual3.CurrentLocation); })),
                    new DialogueModel("    Name: Jorge Del Sierra",
                        condition: new Func<bool>(() => { return Player.HasVisited(ReadManual3.CurrentLocation); })),
                    new DialogueModel("    Gender: Male",
                        condition: new Func<bool>(() => { return Player.HasVisited(ReadManual3.CurrentLocation); })),
                    new DialogueModel("    Bloodtype: Z+",
                        condition: new Func<bool>(() => { return Player.HasVisited(ReadManual3.CurrentLocation); })),
                },
                new List<ButtonModel>()
                {
                    // Hasn't inspected room
                    new ButtonModel("Inspect the room.", InspectRecoveryRoom,
                        condition: new Func<bool>(() => { return !Player.HasVisited(InspectRecoveryRoom.CurrentLocation); })),
                    // Has inspected room
                    new ButtonModel("Inspect control panel.", InvestigateControlPanel,
                        condition: new Func<bool>(() => { return Player.HasVisited(InspectRecoveryRoom.CurrentLocation); })),
                    new ButtonModel("Investigate text books.", InvestigateTextBooks,
                        condition: new Func<bool>(() => { return Player.HasVisited(InspectRecoveryRoom.CurrentLocation); })),
                    new ButtonModel("Leave.", InfirmaryScene.InfirmaryBase),

                });
        }

        public static void InitialiseInspectTheFeral3(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("The feral lies motionless in the chamber."),
                    new DialogueModel("You can just make out a dog tag hanging around the feral's neck, the tag reads:",
                        condition: new Func<bool>(() => { return Player.HasVisited(ReadManual3.CurrentLocation); })),
                    new DialogueModel("    Name: Jorge Del Sierra",
                        condition: new Func<bool>(() => { return Player.HasVisited(ReadManual3.CurrentLocation); })),
                    new DialogueModel("    Gender: Male",
                        condition: new Func<bool>(() => { return Player.HasVisited(ReadManual3.CurrentLocation); })),
                    new DialogueModel("    Bloodtype: Z+",
                        condition: new Func<bool>(() => { return Player.HasVisited(ReadManual3.CurrentLocation); })),
                },
                new List<ButtonModel>()
                {
                    // Hasn't inspected room
                    new ButtonModel("Inspect the room.", InspectRecoveryRoom,
                        condition: new Func<bool>(() => { return !Player.HasVisited(InspectRecoveryRoom.CurrentLocation); })),
                    // Has inspected room
                    new ButtonModel("Inspect control panel.", InvestigateControlPanel,
                        condition: new Func<bool>(() => { return Player.HasVisited(InspectRecoveryRoom.CurrentLocation); })),
                    new ButtonModel("Investigate text books.", InvestigateTextBooks,
                        condition: new Func<bool>(() => { return Player.HasVisited(InspectRecoveryRoom.CurrentLocation); })),
                    new ButtonModel("Leave.", InfirmaryScene.InfirmaryBase),

                });
        }

        public static void InitialiseInspectRecoveryRoom(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("The machine sits in the center of the room, taking up most of the space."),
                    new DialogueModel("Off to one side is a control panel embedded into the machine."),
                    new DialogueModel("There are many text books stashed along the shelves on the opposite wall.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Investigate control panel.", InvestigateControlPanel),
                    new ButtonModel("Investigate text books.", InvestigateTextBooks),
                    new ButtonModel("Inspect the feral..", InspectTheFeral,
                        condition: new Func<bool>(() => { return !Player.HasVisited(InspectTheFeral.CurrentLocation) && !Player.HasVisited(MachineSuccess.CurrentLocation) && !Player.HasVisited(MachineFailure.CurrentLocation); })),
                    new ButtonModel("Inspect the feral..", InspectTheFeral2,
                        condition: new Func<bool>(() => { return Player.HasVisited(InspectTheFeral.CurrentLocation) && !Player.HasVisited(InspectTheFeral2.CurrentLocation)  && !Player.HasVisited(MachineSuccess.CurrentLocation) && !Player.HasVisited(MachineFailure.CurrentLocation); })),
                    new ButtonModel("Inspect the feral..", InspectTheFeral3,
                        condition: new Func<bool>(() => { return Player.HasVisited(InspectTheFeral.CurrentLocation) && Player.HasVisited(InspectTheFeral2.CurrentLocation)  && !Player.HasVisited(MachineSuccess.CurrentLocation) && !Player.HasVisited(MachineFailure.CurrentLocation); })),
                    // Feral Machine Success
                    new ButtonModel("Inspect the feral..", InvestigateFeralSuccess,
                        condition: new Func<bool>(() => { return Player.HasVisited(MachineSuccess.CurrentLocation); })),
                    // Feral Machine Fail
                    new ButtonModel("Inspect the feral..", InvestigateFeralFail,
                        condition: new Func<bool>(() => { return Player.HasVisited(MachineFailure.CurrentLocation); })),
                    new ButtonModel("Inspect the room.", InspectRecoveryRoom),
                    new ButtonModel("Leave.", InfirmaryScene.InfirmaryBase),
                });
        }

        public static void InitialiseInvestigateControlPanel(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    // No battery
                    new DialogueModel("The panel is dark and does not respond to any inputs. There is no power.",
                        condition: new Func<bool>(() => { return (!Player.HasVisited(PowerMachineByHandSuccess.CurrentLocation) || !Player.HasVisited(PowerMachineByBattery.CurrentLocation)) && !Player.HasVisited(MachineSuccess.CurrentLocation) && !Player.HasVisited(MachineFailure.CurrentLocation); })),
                    new DialogueModel("It appears to use an external power source.",
                        condition: new Func<bool>(() => { return !Player.HasVisited(EjectTheBattery.CurrentLocation) && (!Player.HasVisited(PowerMachineByHandSuccess.CurrentLocation) || !Player.HasVisited(PowerMachineByBattery.CurrentLocation)) && !Player.HasVisited(MachineSuccess.CurrentLocation) && !Player.HasVisited(MachineFailure.CurrentLocation); })),
                    new DialogueModel("There is a slot below the panel that appears to be holding a power cell.",
                        condition: new Func<bool>(() => { return !Player.HasVisited(EjectTheBattery.CurrentLocation) && (!Player.HasVisited(PowerMachineByHandSuccess.CurrentLocation) || !Player.HasVisited(PowerMachineByBattery.CurrentLocation)) && !Player.HasVisited(MachineSuccess.CurrentLocation) && !Player.HasVisited(MachineFailure.CurrentLocation); })),
                    // Ejected battery
                    new DialogueModel("There is an empty battery slot that needs to be filled to power the machine.",
                        condition: new Func<bool>(() => { return Player.HasVisited(EjectTheBattery.CurrentLocation) && (!Player.HasVisited(PowerMachineByHandSuccess.CurrentLocation) || !Player.HasVisited(PowerMachineByBattery.CurrentLocation)) && !Player.HasVisited(MachineSuccess.CurrentLocation) && !Player.HasVisited(MachineFailure.CurrentLocation); })),
                    // Battery inserted
                    new DialogueModel("The screen is lit up.",
                        condition: new Func<bool>(() => { return (Player.HasVisited(PowerMachineByHandSuccess.CurrentLocation) || Player.HasVisited(PowerMachineByBattery.CurrentLocation)) && !Player.HasVisited(MachineSuccess.CurrentLocation) && !Player.HasVisited(MachineFailure.CurrentLocation); })),
                    new DialogueModel("Welcome to the All-Purpose Recovery Machine (APRM).",
                        condition: new Func<bool>(() => { return (Player.HasVisited(PowerMachineByHandSuccess.CurrentLocation) || Player.HasVisited(PowerMachineByBattery.CurrentLocation)) && !Player.HasVisited(MachineSuccess.CurrentLocation) && !Player.HasVisited(MachineFailure.CurrentLocation); })),
                    new DialogueModel("What would you like to do?",
                        condition: new Func<bool>(() => { return (Player.HasVisited(PowerMachineByHandSuccess.CurrentLocation) || Player.HasVisited(PowerMachineByBattery.CurrentLocation)) && !Player.HasVisited(MachineSuccess.CurrentLocation) && !Player.HasVisited(MachineFailure.CurrentLocation); })),
                    // Machine succeeded
                    new DialogueModel("The machine continues whirring as it works on the feral.",
                        condition: new Func<bool>(() => { return Player.HasVisited(MachineSuccess.CurrentLocation); })),
                    new DialogueModel("The panel continues to display the status:",
                        condition: new Func<bool>(() => { return Player.HasVisited(MachineSuccess.CurrentLocation); })),
                    new DialogueModel("    > Running...",
                        condition: new Func<bool>(() => { return Player.HasVisited(MachineSuccess.CurrentLocation); })),
                    new DialogueModel("It appears you are locked out of any further actions until the process is finished.",
                        condition: new Func<bool>(() => { return Player.HasVisited(MachineSuccess.CurrentLocation); })),
                    // Machine failed
                    new DialogueModel("The machine sits motionless in the room.",
                        condition: new Func<bool>(() => { return Player.HasVisited(MachineFailure.CurrentLocation); })),
                    new DialogueModel("The panel stays red, displaying the status:",
                        condition: new Func<bool>(() => { return Player.HasVisited(MachineFailure.CurrentLocation); })),
                    new DialogueModel("    > Awaiting technician...",
                        condition: new Func<bool>(() => { return Player.HasVisited(MachineFailure.CurrentLocation); })),
                    new DialogueModel("It appears you are locked out until a technician arrives...",
                        condition: new Func<bool>(() => { return Player.HasVisited(MachineFailure.CurrentLocation); })),
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Configure.", ConfigureMachine,
                        condition: new Func<bool>(() => { return (Player.HasVisited(PowerMachineByHandSuccess.CurrentLocation) || Player.HasVisited(PowerMachineByBattery.CurrentLocation)) && !Player.HasVisited(MachineSuccess.CurrentLocation) && !Player.HasVisited(MachineFailure.CurrentLocation); })),
                    new ButtonModel("Eject the battery.", EjectTheBattery,
                        condition: new Func<bool>(() => { return !Player.HasVisited(EjectTheBattery.CurrentLocation) && !Player.HasVisited(MachineSuccess.CurrentLocation) && !Player.HasVisited(MachineFailure.CurrentLocation); })),
                    new ButtonModel("Insert spare battery.", PowerMachineByBattery,
                        condition: new Func<bool>(() => { return Player.HasItem(Sequoia.Constants.SpareBattery) && Player.HasVisited(EjectTheBattery.CurrentLocation) && !Player.HasVisited(MachineSuccess.CurrentLocation) && !Player.HasVisited(MachineFailure.CurrentLocation); })),
                    new ButtonModel("Investigate text books.", InvestigateTextBooks),
                    new ButtonModel("Inspect the feral..", InspectTheFeral,
                        condition: new Func<bool>(() => { return !Player.HasVisited(InspectTheFeral.CurrentLocation) && !Player.HasVisited(MachineSuccess.CurrentLocation) && !Player.HasVisited(MachineFailure.CurrentLocation); })),
                    new ButtonModel("Inspect the feral..", InspectTheFeral2,
                        condition: new Func<bool>(() => { return Player.HasVisited(InspectTheFeral.CurrentLocation) && !Player.HasVisited(InspectTheFeral2.CurrentLocation)  && !Player.HasVisited(MachineSuccess.CurrentLocation) && !Player.HasVisited(MachineFailure.CurrentLocation); })),
                    new ButtonModel("Inspect the feral..", InspectTheFeral3,
                        condition: new Func<bool>(() => { return Player.HasVisited(InspectTheFeral.CurrentLocation) && Player.HasVisited(InspectTheFeral2.CurrentLocation)  && !Player.HasVisited(MachineSuccess.CurrentLocation) && !Player.HasVisited(MachineFailure.CurrentLocation); })),
                    // Feral Machine Success
                    new ButtonModel("Inspect the feral..", InvestigateFeralSuccess,
                        condition: new Func<bool>(() => { return Player.HasVisited(MachineSuccess.CurrentLocation); })),
                    // Feral Machine Fail
                    new ButtonModel("Inspect the feral..", InvestigateFeralFail,
                        condition: new Func<bool>(() => { return Player.HasVisited(MachineFailure.CurrentLocation); })),
                    new ButtonModel("Leave.", ComputerRoomScene.ComputerRoom),
                });
        }

        public static void InitialiseEjectTheBattery(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("A thick layer of dust covers the power cell, at first it gives a bit of resistance, but you pry it free from the machine."),
                    new DialogueModel("The power slot is now empty.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Insert spare battery.", PowerMachineByBattery,
                        condition: new Func<bool>(() => { return Player.HasItem(Sequoia.Constants.SpareBattery); }),
                        action: new Func<System.Threading.Tasks.Task>(async () => { Player.RemoveItem(Sequoia.Constants.SpareBattery); })),
                    new ButtonModel("Investigate text books.", InvestigateTextBooks),
                    new ButtonModel("Inspect the feral..", InspectTheFeral,
                        condition: new Func<bool>(() => { return !Player.HasVisited(InspectTheFeral.CurrentLocation) && !Player.HasVisited(MachineSuccess.CurrentLocation) && !Player.HasVisited(MachineFailure.CurrentLocation); })),
                    new ButtonModel("Inspect the feral..", InspectTheFeral2,
                        condition: new Func<bool>(() => { return Player.HasVisited(InspectTheFeral.CurrentLocation) && !Player.HasVisited(InspectTheFeral2.CurrentLocation)  && !Player.HasVisited(MachineSuccess.CurrentLocation) && !Player.HasVisited(MachineFailure.CurrentLocation); })),
                    new ButtonModel("Inspect the feral..", InspectTheFeral3,
                        condition: new Func<bool>(() => { return Player.HasVisited(InspectTheFeral.CurrentLocation) && Player.HasVisited(InspectTheFeral2.CurrentLocation)  && !Player.HasVisited(MachineSuccess.CurrentLocation) && !Player.HasVisited(MachineFailure.CurrentLocation); })),
                    // Feral Machine Success
                    new ButtonModel("Inspect the feral..", InvestigateFeralSuccess,
                        condition: new Func<bool>(() => { return Player.HasVisited(MachineSuccess.CurrentLocation); })),
                    // Feral Machine Fail
                    new ButtonModel("Inspect the feral..", InvestigateFeralFail,
                        condition: new Func<bool>(() => { return Player.HasVisited(MachineFailure.CurrentLocation); })),
                    new ButtonModel("Inspect the room.", InspectRecoveryRoom),
                    new ButtonModel("Leave.", InfirmaryScene.InfirmaryBase),
                });
        }

        public static void InitialisePowerMachineByHand(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You place your hand into the power socket."),
                    new DialogueModel("Immediately, you notice the power draw is much greater in this machine."),
                    new DialogueModel("This will take a lot out from you.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Power the machine.", PowerMachineByHandSuccess,
                        condition: new Func<bool>(() => { return Player.Energy >= 2; }),
                        action: new Func<System.Threading.Tasks.Task>(async () => { Player.Energy -= 2; })),
                    new ButtonModel("Power the machine", InvestigateFeralFail,
                        condition: new Func<bool>(() => { return Player.Energy <= 1; }),
                        action: new Func<System.Threading.Tasks.Task>(async () => { Player.Energy = 0; })),
                    new ButtonModel("Return.", InvestigateControlPanel),
                });
        }

        public static void InitialisePowerMachineByHandSuccess(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You discharge most of your reserves into the system, your arm burns red hot."),
                    new DialogueModel("Suddenly, the machine jumps to life."),
                    new DialogueModel("You quickly pull your hand out of the socket."),
                    new DialogueModel("The shock from the power loss causes your head to drift from side to side. You feel much weaker.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Return.", InvestigateControlPanel),
                });
        }

        public static void InitialisePowerMachineByHandFail(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You discharge the rest of your reserves into the system, your arm burns red hot."),
                    new DialogueModel("The machine sputters to life, but only for a moment before your body goes completely limp."),
                    new DialogueModel("You didn't have enough energy to power this machine...")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", PowerMachineByHandFail2),
                });
        }

        public static void InitialisePowerMachineByHandFail2(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("Luckily, you had removed yourself from the power socket before losing all power.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Return.", InvestigateControlPanel),
                });
        }

        public static void InitialisePowerMachineByBattery(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You slot the spare battery into its slot and instantly, the machine whirs to life.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Return.", InvestigateControlPanel),
                });
        }

        public static void InitialiseConfigureMachine(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("Please scan your access card.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Use Steinmann's access card.", ConfigureMachine2,
                        condition: new Func<bool>(() => { return Player.HasItem(Constants.SteinmannAccessCard); })),
                    new ButtonModel("Return.", InvestigateControlPanel),
                });
        }

        public static void InitialiseConfigureMachine2(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("Please select a recovery mode.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Azul", ConfigureMachine3,
                        action: new Func<System.Threading.Tasks.Task>(async () => { Player.IncrementFlag(Constants.Azul); Player.DecrementFlag(Constants.Rojo); Player.DecrementFlag(Constants.Verde); })),
                    new ButtonModel("Rojo", ConfigureMachine3,
                        action: new Func<System.Threading.Tasks.Task>(async () => { Player.DecrementFlag(Constants.Azul); Player.IncrementFlag(Constants.Rojo); Player.DecrementFlag(Constants.Verde); })),
                    new ButtonModel("Verde", ConfigureMachine3,
                        action: new Func<System.Threading.Tasks.Task>(async () => { Player.DecrementFlag(Constants.Azul); Player.DecrementFlag(Constants.Rojo); Player.IncrementFlag(Constants.Verde); })),
                    new ButtonModel("Return.", InvestigateControlPanel),
                });
        }

        public static void InitialiseConfigureMachine3(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("Please select a recovery mode.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("XC", ConfigureMachine4,
                        action: new Func<System.Threading.Tasks.Task>(async () => { Player.IncrementFlag(Constants.BloodTypeXC); Player.DecrementFlag(Constants.BloodTypeY); Player.DecrementFlag(Constants.BloodTypeZPlus); })),
                    new ButtonModel("Y-", ConfigureMachine4,
                        action: new Func<System.Threading.Tasks.Task>(async () => { Player.DecrementFlag(Constants.BloodTypeXC); Player.IncrementFlag(Constants.BloodTypeY); Player.DecrementFlag(Constants.BloodTypeZPlus); })),
                    new ButtonModel("Z+", ConfigureMachine4,
                        action: new Func<System.Threading.Tasks.Task>(async () => { Player.DecrementFlag(Constants.BloodTypeXC); Player.DecrementFlag(Constants.BloodTypeY); Player.IncrementFlag(Constants.BloodTypeZPlus); })),
                    new ButtonModel("Return.", InvestigateControlPanel),
                });
        }

        public static void InitialiseConfigureMachine4(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("Configuration complete.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Start the machine.", MachineRunning),
                    new ButtonModel("Return.", InvestigateControlPanel),
                });
        }

        public static void InitialiseMachineRunning(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("The lights turns on in the chamber as you hear the machine spin to life.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", MachineSuccess,
                        condition: new Func<bool>(() => { return Player.HasFlag(Constants.Verde) && Player.HasFlag(Constants.BloodTypeZPlus); }),
                        action: new Func<System.Threading.Tasks.Task>(async () => { Player.IncrementFlag(Constants.FeralSaved); })),
                    new ButtonModel("Continue.", MachineFailure,
                        condition: new Func<bool>(() => { return !Player.HasFlag(Constants.Verde) || !Player.HasFlag(Constants.BloodTypeZPlus); })),
                });
        }

        public static void InitialiseMachineSuccess(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("Slowly, a metallic beam moves up and down the glass chamber, it shines a translucent light onto the feral."),
                    new DialogueModel("The panel lights up again:"),
                    new DialogueModel("    > Conditions stable"),
                    new DialogueModel("    > Running..."),
                    new DialogueModel("This may take a while.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Return.", InvestigateControlPanel),
                });
        }

        public static void InitialiseMachineFailure(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("A metallic beam begins moving up and down the glass chamber, it shines a translucent light onto the feral."),
                    new DialogueModel("* BANG *"),
                    new DialogueModel("Suddenly, the whole machine freezes in place."),
                    new DialogueModel("The panel lights up red:"),
                    new DialogueModel("    > ERROR OCCURRED. "),
                    new DialogueModel("    > Condition unstable."),
                    new DialogueModel("    > Please contact a technician."),
                    new DialogueModel("The panel has locked itself down.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Return.", InvestigateControlPanel),
                });
        }

        public static void InitialiseInvestigateTextBooks(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("The shelf is filled with an assortment of medical text books."),
                    new DialogueModel("One book jumps out to you: 'All-Purpose Recovery Machine (APRM) Manual'."),
                    new DialogueModel("It is broken down into chapters explaining the science and operating procedures required to operate the machine.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Read manual.", ReadManual),
                    new ButtonModel("Return.", InspectRecoveryRoom),
                });
        }

        public static void InitialiseReadManual(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("...Running the machine itself is incredibly simple..."),
                    new DialogueModel("...Most of the options have been pre-configured, but there are two variables dependent on the patient that must be set before operating this machine...")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", ReadManual2),
                    new ButtonModel("Return.", InspectRecoveryRoom),
                });
        }

        public static void InitialiseReadManual2(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("...First is the recovery mode, where there are 3 options..."),
                    new DialogueModel("...Azul is for viruses, bacteria and infection recovery, Verde is primarily for large cuts, internal bruises and other physical wounds and Rojo deals with scarring and the cosmetic recovery of skin...")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", ReadManual3),
                    new ButtonModel("Return.", InspectRecoveryRoom),
                });
        }

        public static void InitialiseReadManual3(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("...You also have to note the blood type of the patient, as an incorrect match could be lethal."),
                    new DialogueModel("Do not operate this machine without configuring the correct blood type."),
                    new DialogueModel("If you do not know the blood type of the patient, each passenger on-board should be wearing a dog-tag that displays this information for you."),
                    new DialogueModel("If you are unsure or have reason to suspect the dog-tag is not theirs - do not operate this machine.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Return.", InspectRecoveryRoom),
                });
        }

        public static void InitialiseInvestigateFeralSuccess(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("A metallic beam slowly shines translucent a light up and down the glass chamber."),
                    new DialogueModel("There's a noticeable improvement in the feral's condition, but it looks like the process has a long way to go."),
                    new DialogueModel("It is best to leave.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Return.", InspectRecoveryRoom),
                });
        }

        public static void InitialiseInvestigateFeralFail(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("A metallic beam is stuck halfway up the glass chamber."),
                    new DialogueModel("The feral's condition hasn't changed."),
                    new DialogueModel("There is nothing else to be done here.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Return.", InspectRecoveryRoom),
                });
        }

    }
}
