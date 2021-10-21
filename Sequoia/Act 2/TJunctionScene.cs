using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Sequoia
{
    public class TJunctionScene : SceneModel
    {
        public static string Film;
        public static string Act;
        public static string Scene = "TJunction";
        public static PlayerModel Player;

        public static FrameModel HearSound;
        public static FrameModel InvestigateSound;
        public static FrameModel RollOffPin;
        public static FrameModel ShoveItOff;
        public static FrameModel LookAtCreature;
        public static FrameModel IgnoreSound;
        public static FrameModel FightCreature;
        public static FrameModel TwoPaths;
        public static FrameModel GoToInfirmary;
        public static FrameModel OutrunIt;
        public static FrameModel DodgeThePounce;
        public static FrameModel HeadBackToStorage;
        public static FrameModel EnterIntoStorageRoom;
        public static FrameModel DodgeBackToInfirmary;
        public static FrameModel PowerDoorHand;
        public static FrameModel PowerDoorBattery;

        public TJunctionScene(string film, string act, PlayerModel player)
        {
            Film = film;
            Act = act;
            Player = player;

            HearSound = new FrameModel(Film, Act, Scene, "HearSound", Constants.TJunction);
            InvestigateSound = new FrameModel(Film, Act, Scene, "InvestigateSound", Constants.TJunction);
            RollOffPin = new FrameModel(Film, Act, Scene, "RollOffPin", Constants.TJunction);
            ShoveItOff = new FrameModel(Film, Act, Scene, "HearShoveItOffSound", Constants.TJunction);
            LookAtCreature = new FrameModel(Film, Act, Scene, "LookAtCreature", Constants.TJunction);
            IgnoreSound = new FrameModel(Film, Act, Scene, "IgnoreSound", Constants.TJunction);
            FightCreature = new FrameModel(Film, Act, Scene, "FightCreature", Constants.TJunction);
            TwoPaths = new FrameModel(Film, Act, Scene, "TwoPaths", Constants.TJunction);
            GoToInfirmary = new FrameModel(Film, Act, Scene, "GoToInfirmary", Constants.TJunction);
            OutrunIt = new FrameModel(Film, Act, Scene, "OutrunIt", Constants.TJunction);
            DodgeThePounce = new FrameModel(Film, Act, Scene, "DodgeThePounce", Constants.TJunction);
            HeadBackToStorage = new FrameModel(Film, Act, Scene, "HeadBackToStorage", Constants.TJunction);
            EnterIntoStorageRoom = new FrameModel(Film, Act, Scene, "EnterIntoStorageRoom", Constants.StorageRoom);
            DodgeBackToInfirmary = new FrameModel(Film, Act, Scene, "DodgeBackToInfirmary", Constants.TJunction);
            PowerDoorHand = new FrameModel(Film, Act, Scene, "PowerDoorHand", Constants.StorageRoom);
            PowerDoorBattery = new FrameModel(Film, Act, Scene, "PowerDoorBattery", Constants.StorageRoom);

            Frames = new Dictionary<string, FrameModel>() {
                {HearSound.Name, HearSound},
                {InvestigateSound.Name, InvestigateSound},
                {RollOffPin.Name, RollOffPin},
                {ShoveItOff.Name, ShoveItOff},
                {LookAtCreature.Name, LookAtCreature},
                {IgnoreSound.Name, IgnoreSound},
                {FightCreature.Name, FightCreature},
                {TwoPaths.Name, TwoPaths},
                {GoToInfirmary.Name, GoToInfirmary},
                {OutrunIt.Name, OutrunIt},
                {DodgeThePounce.Name, DodgeThePounce},
                {HeadBackToStorage.Name, HeadBackToStorage},
                {EnterIntoStorageRoom.Name, EnterIntoStorageRoom},
                {DodgeBackToInfirmary.Name, DodgeBackToInfirmary},
                {PowerDoorHand.Name, PowerDoorHand},
                {PowerDoorBattery.Name, PowerDoorBattery},
            };
        }

        public static void Initialise()
        {
            InitialiseHearSound(HearSound);
            InitialiseInvestigateSound(InvestigateSound);
            InitialiseRollOffPin(RollOffPin);
            InitialiseShoveItOff(ShoveItOff);
            InitialiseLookAtCreature(LookAtCreature);
            InitialiseIgnoreSound(IgnoreSound);
            InitialiseFightCreature(FightCreature);
            InitialiseTwoPaths(TwoPaths);
            InitialiseGoToInfirmary(GoToInfirmary);
            InitialiseOutrunIt(OutrunIt);
            InitialiseDodgeThePounce(DodgeThePounce);
            InitialiseHeadBackToStorage(HeadBackToStorage);
            InitialiseEnterIntoStorageRoom(EnterIntoStorageRoom);
            InitialiseDodgeBackToInfirmary(DodgeBackToInfirmary);
            InitialisePowerDoorHand(PowerDoorHand);
            InitialisePowerDoorBattery(PowerDoorBattery);
        }

        public static void InitialiseHearSound(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("It takes a while to readjust to the darker hallway."),
                    new DialogueModel("Most of the rooms in this sector are unpowered, leaving only the main path dimly lit."),
                    new DialogueModel("As you head further down the corridor, you can hear scampering in the vents above."),
                    new DialogueModel("The sound is nearby, but its hard to tell where, as there are several ventilation panels around.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue forward.", IgnoreSound),
                    new ButtonModel("Investigate sound.", InvestigateSound),
                });
        }

        public static void InitialiseInvestigateSound(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You head towards one of the vent exits and press your ear against it."),
                    new DialogueModel("The scampering gets closer and closer, its fast - too fast."),
                    new DialogueModel("The vent bursts open and a shadowy figure lands upon you."),
                    new DialogueModel("The creature pins you to the ground, its claw-like hands digging into your chest.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Roll off.", RollOffPin),
                    new ButtonModel("Shove it off.", ShoveItOff,
                        action: new Func<System.Threading.Tasks.Task>(async () => { Player.Energy--; })),
                });
        }

        public static void InitialiseRollOffPin(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You twist your body and shove it to the side."),
                    new DialogueModel("Quickly, you turn and sprint down the corridor."),
                    new DialogueModel("Within a moment, you hear the tread of footsteps behind you..")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Take a peek backwards.", LookAtCreature),
                    new ButtonModel("Continue running.", TwoPaths),
                });
        }

        public static void InitialiseShoveItOff(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You try to shove the creature back but its too strong."),
                    new DialogueModel("Suddenly, its claws crack a portion of your chest plate."),
                    new DialogueModel("Involuntarily, electricity pulses throughout your body, stunning the creature in its place."),
                    new DialogueModel("It drops to the ground next to you."),
                    new DialogueModel("You feel weaker from the exertion.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Run.", TwoPaths),
                    new ButtonModel("Take a look at the creature.", LookAtCreature),
                });
        }

        public static void InitialiseLookAtCreature(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You can see it is human, but its skin is a shade of blue."),
                    new DialogueModel("Its hands are claws, as if the index and middle finger are fused together and the ring and pinky fingers are fused as well."),
                    new DialogueModel("The creature gives out a low growl...",
                        condition: new Func<bool>(() => { return Player.HasVisited(ShoveItOff.CurrentLocation); })),
                    new DialogueModel("You decide its best to leave now.",
                        condition: new Func<bool>(() => { return Player.HasVisited(ShoveItOff.CurrentLocation); })),
                    new DialogueModel("Its charging towards you.",
                        condition: new Func<bool>(() => { return Player.HasVisited(RollOffPin.CurrentLocation); })),
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", TwoPaths),
                });
        }

        public static void InitialiseIgnoreSound(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("Suddenly, a vent bursts open behind you and a shadowy figure jumps out from it, growling."),
                    new DialogueModel("Its head turns towards you, it charges.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Run.", TwoPaths),
                    new ButtonModel("Fight.", FightCreature),
                });
        }

        public static void InitialiseFightCreature(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You steel yourself for the engagement."),
                    new DialogueModel("The creature pounces and its fast - too fast."),
                    new DialogueModel("Catching you off guard it pins you to the ground, its claws digging into your chest..")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Roll off the pin.", RollOffPin),
                    new ButtonModel("Shove it off.", ShoveItOff,
                        action: new Func<System.Threading.Tasks.Task>(async () => { Player.Energy--; })),
                });
        }

        public static void InitialiseTwoPaths(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("As you continue down the corridor, two paths lay ahead."),
                    // roll off pin, peeked backwards
                    new DialogueModel("You can see the creature is only short distance behind, you need to keep moving.",
                        condition: new Func<bool>(() => { return Player.HasVisited(RollOffPin.CurrentLocation) && Player.HasVisited(LookAtCreature.CurrentLocation); })),
                    new DialogueModel("You can already hear the creature coming back - you need to keep moving.",
                        condition: new Func<bool>(() => { return Player.HasVisited(ShoveItOff.CurrentLocation); })),
                    new DialogueModel("You can see the creature is only a short distance behind, you need to keep moving.",
                        condition: new Func<bool>(() => { return Player.HasVisited(IgnoreSound.CurrentLocation) &&  !Player.HasVisited(FightCreature.CurrentLocation);; })),
                    new DialogueModel("On the main path, a large sign hangs ahead that reads: 'INFIRMARY'. The door is closed. "),
                    new DialogueModel("Painted in red on the door are the words: \"BEWARE THE FERALS\"."),
                    new DialogueModel("If you break off to the left there is a storage room. It is dark but may contain useful supplies within.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Go to infirmary.", GoToInfirmary),
                    new ButtonModel("Go towards storage room.", EnterIntoStorageRoom),
                });
        }

        public static void InitialiseGoToInfirmary(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You continue straight and run towards the infirmary."),
                    new DialogueModel("You notice an access panel off to the side of the doorway."),
                    new DialogueModel("The creature is gaining ground, its almost in striking distance.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Run evasively.", DodgeThePounce),
                    new ButtonModel("Outrun it.", OutrunIt),
                });
        }

        public static void InitialiseOutrunIt(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You run full speed ahead."),
                    new DialogueModel("Just as you get to the doorway, the creature pounces."),
                    new DialogueModel("Its claws dig into your back as it knocks you into the wall."),
                    new DialogueModel("Your head hits the door frame."),
                    new DialogueModel("You are knocked unconscious.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", MiscellaneousScene.Dead)
                });
        }

        public static void InitialiseDodgeThePounce(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You run evasively, weaving left and right as you head down the hallway."),
                    new DialogueModel("Just as you get to the doorway, the creature pounces."),
                    new DialogueModel("You tricked it. Dodging to the side, the creature face plants into the wall."),
                    new DialogueModel("You use the time to swipe your access card on the panel, but it lights up with 'DISABLED'."),
                    new DialogueModel("There's no time, you have to go back.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Run back.", HeadBackToStorage)
                });
        }

        public static void InitialiseHeadBackToStorage(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You run back down the corridor and turn towards the storage room."),
                    new DialogueModel("The red-faced feral is seemingly unfazed by its broken nose. It is again running towards you.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", EnterIntoStorageRoom)
                });
        }

        public static void InitialiseEnterIntoStorageRoom(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You pivot left and run into the storage room.",
                        condition: new Func<bool>(() => { return !Player.HasVisited(HeadBackToStorage.CurrentLocation); })),
                    new DialogueModel("As you pass through the storage room's doorway, you enter into a dark room.",
                        condition: new Func<bool>(() => { return Player.HasVisited(HeadBackToStorage.CurrentLocation); })),
                    new DialogueModel("There is no power here."),
                    new DialogueModel("Looking back, the creature is running full sprint towards you."),
                    new DialogueModel("With some quick thinking, you find the hidden power panel by the door.")

                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Power the door.", PowerDoorHand,
                        condition: new Func<bool>(() => { return Player.Energy > 0; }),
                        action: new Func<System.Threading.Tasks.Task>(async () => { Player.Energy--; })),
                    new ButtonModel("Use spare battery", PowerDoorBattery,
                        condition: new Func<bool>(() => { return Player.HasItem(Sequoia.Constants.SpareBattery); }),
                        action: new Func<System.Threading.Tasks.Task>(async () => { Player.RemoveItem(Sequoia.Constants.SpareBattery); })),
                    new ButtonModel("Try to dodge back to infirmary.", DodgeBackToInfirmary),
                });
        }

        public static void InitialiseDodgeBackToInfirmary(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You run back towards the creature and prepare to dodge, but the narrow hallway makes the it difficult."),
                    new DialogueModel("The creature pounces."),
                    new DialogueModel("You slide underneath but its knee catches your temple."),
                    new DialogueModel("You are knocked unconscious.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", MiscellaneousScene.Dead)
                });
        }

        public static void InitialisePowerDoorHand(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You socket your hand into the panel and pulse electricity."),
                    new DialogueModel("The door panel lights up and you slam the close button."),
                    new DialogueModel("The creature pounces, but the door drops down just in time. A heavy clunk sounds from other side of the door."),
                    new DialogueModel("You won't be heading back through that way..."),
                    new DialogueModel("You feel weaker from the exertion.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", StorageRoomScene.StorageRoomBase)
                });
        }

        public static void InitialisePowerDoorBattery(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You socket the battery into the panel."),
                    new DialogueModel("The door panel lights up and you slam the close button."),
                    new DialogueModel("The creature pounces, but the door drops down just in time."),
                    new DialogueModel("A heavy clunk sounds from other side of the door."),
                    new DialogueModel("You won't be heading back through that way...")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", StorageRoomScene.StorageRoomBase)
                });
        }
    }
}
