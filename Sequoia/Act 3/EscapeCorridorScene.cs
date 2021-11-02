using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Sequoia
{
    public class EscapeCorridorScene : SceneModel
    {
        public static string Film;
        public static string Act;
        public static string Scene = "EscapeCorridor";
        public static PlayerModel Player;

        public static FrameModel HeadToCorridor;
        public static FrameModel SideDoorBursts;
        public static FrameModel ElectrifyTheWater;
        public static FrameModel LetJanFire;
        public static FrameModel KeepRunning;
        public static FrameModel GetToShelf;
        public static FrameModel ToppleTheShelf;
        public static FrameModel CaughtFeralsAlive;
        public static FrameModel CaughtFeralsDead;
        public static FrameModel CaughtFeralsDead2;
        public static FrameModel CaughtFeralsDeadFail;
        public static FrameModel DontToppleShelfFeralsDead;
        public static FrameModel SavedFeralHelps;
        public static FrameModel EscapePodsEntrance;

        public EscapeCorridorScene(string film, string act, PlayerModel player)
        {
            Film = film;
            Act = act;
            Player = player;

            HeadToCorridor = new FrameModel(Film, Act, Scene, "HeadToCorridor", Constants.Black);
            SideDoorBursts = new FrameModel(Film, Act, Scene, "SideDoorBursts", Constants.Black);
            ElectrifyTheWater = new FrameModel(Film, Act, Scene, "ElectrifyTheWater", Constants.Black);
            LetJanFire = new FrameModel(Film, Act, Scene, "LetJanFire", Constants.Black);
            KeepRunning = new FrameModel(Film, Act, Scene, "KeepRunning", Constants.Black);
            GetToShelf = new FrameModel(Film, Act, Scene, "GetToShelf", Constants.Black);
            ToppleTheShelf = new FrameModel(Film, Act, Scene, "ToppleTheShelf", Constants.Black);
            CaughtFeralsAlive = new FrameModel(Film, Act, Scene, "CaughtFeralsAlive", Constants.Black);
            CaughtFeralsDead = new FrameModel(Film, Act, Scene, "CaughtFeralsDead", Constants.Black);
            CaughtFeralsDead2 = new FrameModel(Film, Act, Scene, "CaughtFeralsDead2", Constants.Black);
            CaughtFeralsDeadFail = new FrameModel(Film, Act, Scene, "CaughtFeralsDeadFail", Constants.Black);
            DontToppleShelfFeralsDead = new FrameModel(Film, Act, Scene, "DontToppleShelfFeralsDead", Constants.Black);
            SavedFeralHelps = new FrameModel(Film, Act, Scene, "SavedFeralHelps", Constants.Black);
            EscapePodsEntrance = new FrameModel(Film, Act, Scene, "EscapePodsEntrance", Constants.Black);

            Frames = new Dictionary<string, FrameModel>() {
                {HeadToCorridor.Name,HeadToCorridor},
                {SideDoorBursts.Name,SideDoorBursts},
                {ElectrifyTheWater.Name,ElectrifyTheWater},
                {LetJanFire.Name,LetJanFire},
                {KeepRunning.Name,KeepRunning},
                {GetToShelf.Name,GetToShelf},
                {ToppleTheShelf.Name,ToppleTheShelf},
                {CaughtFeralsAlive.Name,CaughtFeralsAlive},
                {CaughtFeralsDead.Name,CaughtFeralsDead},
                {CaughtFeralsDead2.Name,CaughtFeralsDead2},
                {CaughtFeralsDeadFail.Name,CaughtFeralsDeadFail},
                {DontToppleShelfFeralsDead.Name,DontToppleShelfFeralsDead},
                {SavedFeralHelps.Name,SavedFeralHelps},
                {EscapePodsEntrance.Name,EscapePodsEntrance},
            };
        }

        public static void Initialise()
        {
            InitialiseHeadToCorridor(HeadToCorridor);
            InitialiseSideDoorBursts(SideDoorBursts);
            InitialiseElectrifyTheWater(ElectrifyTheWater);
            InitialiseLetJanFire(LetJanFire);
            InitialiseKeepRunning(KeepRunning);
            InitialiseGetToShelf(GetToShelf);
            InitialiseToppleTheShelf(ToppleTheShelf);
            InitialiseCaughtFeralsAlive(CaughtFeralsAlive);
            InitialiseCaughtFeralsDead(CaughtFeralsDead);
            InitialiseCaughtFeralsDead2(CaughtFeralsDead2);
            InitialiseCaughtFeralsDeadFail(CaughtFeralsDeadFail);
            InitialiseDontToppleShelfFeralsDead(DontToppleShelfFeralsDead);
            InitialiseSavedFeralHelps(SavedFeralHelps);
            InitialiseEscapePodsEntrance(EscapePodsEntrance);
        }

        public static void InitialiseHeadToCorridor(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You make it back to the infirmary, water spews from the door as it attempts to close."),
                    new DialogueModel("The ship is slightly tilted due to the impact, and water is draining back behind you."),
                    new DialogueModel("You hear the ferals in a frenzy all around you.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", SideDoorBursts),
                });
        }

        public static void InitialiseSideDoorBursts(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You run behind Jan up a separate corridor."),
                    new DialogueModel("Suddenly, a side door bursts open just behind you, and a gush of ferals flood out."),
                    new DialogueModel("The slant of the ship has caused the water to pool by their feet."),
                    new DialogueModel("Jan looks back, he is getting ready to fire.",
                        condition: new Func<bool>(() => { return Player.HasFlag(Constants.JanHasBullets); })),
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Electrify the water.", ElectrifyTheWater,
                        condition: new Func<bool>(() => { return Player.Energy > 0; }),
                        action: new Func<System.Threading.Tasks.Task>(async () => { Player.Energy--; Player.IncrementFlag(Constants.FeralsDead); })),
                    new ButtonModel("Let Jan fire.", LetJanFire,
                        condition: new Func<bool>(() => { return Player.HasFlag(Constants.JanHasBullets); }),
                        action: new Func<System.Threading.Tasks.Task>(async () => { Player.DecrementFlag(Constants.JanHasBullets); Player.IncrementFlag(Constants.FeralsDead); })),
                    new ButtonModel("Pull Jan away, keep running.", KeepRunning),
                    
                });
        }

        public static void InitialiseElectrifyTheWater(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("Electricity courses through your arms as you discharge it into the water."),
                    new DialogueModel("Almost instantly, the ferals lock up and stop dead in their tracks."),
                    new DialogueModel("However, a much larger feral emerges from the side. It seems unaffected by your attack."),
                    new DialogueModel("The feral runs along the wall towards you.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue running.", GetToShelf),
                });
        }

        public static void InitialiseLetJanFire(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You get out of the way as Jan unloads the entire magazine into the group."),
                    new DialogueModel("The ferals are resilient and only some were maimed. Luckily the firing caused them disperse and go elsewhere on the ship."),
                    new DialogueModel("However, a much larger feral emerges from the side door. It looks much more determined."),
                    new DialogueModel("The feral runs along the wall towards you.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue running.", GetToShelf),
                });
        }

        public static void InitialiseKeepRunning(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You pull Jan away and keep running.",
                        condition: new Func<bool>(() => { return Player.HasFlag(Constants.JanHasBullets); })),
                    new DialogueModel("You keep running..",
                        condition: new Func<bool>(() => { return !Player.HasFlag(Constants.JanHasBullets); })),
                    new DialogueModel("The ferals are catching up from behind."),
                    new DialogueModel("Looking back, a much larger feral has emerged from the group and is moving along the walls.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", GetToShelf),
                });
        }

        public static void InitialiseGetToShelf(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("The room for the escape pods is just up ahead and the door is open."),
                    // Ferals Alive
                    new DialogueModel("The ferals are on your heels, their grunts and snickers getting ever closer. You don't dare look back.",
                        condition: new Func<bool>(() => { return !Player.HasFlag(Constants.FeralsDead); })),
                    // Alpha Alive (always)
                    new DialogueModel("The larger feral is now jumping side to side on the walls, its getting ready to pounce."),
                    new DialogueModel("Between you and the escape pods is a metal shelf filled with an assortment of folders."),
                    new DialogueModel("There's a good chance you can topple it over.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Topple the shelf.", ToppleTheShelf,
                        condition: new Func<bool>(() => { return !Player.HasFlag(Constants.FeralSaved); })),
                    new ButtonModel("Don't stop, keep running.", CaughtFeralsAlive,
                        condition: new Func<bool>(() => { return !Player.HasFlag(Constants.FeralsDead) && !Player.HasFlag(Constants.FeralSaved); })),
                    new ButtonModel("Don't stop, keep running.", DontToppleShelfFeralsDead,
                        condition: new Func<bool>(() => { return Player.HasFlag(Constants.FeralsDead) && !Player.HasFlag(Constants.FeralSaved); })),
                    new ButtonModel("Topple the shelf.", SavedFeralHelps,
                        condition: new Func<bool>(() => { return Player.HasFlag(Constants.FeralSaved); })),
                    new ButtonModel("Don't stop, keep running.", SavedFeralHelps,
                        condition: new Func<bool>(() => { return Player.HasFlag(Constants.FeralSaved); })),
                });
        }

        public static void InitialiseToppleTheShelf(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("As you run past the shelf, you turn and topple it over."),
                    // Ferals Alive && Alpha Alive (always)
                    new DialogueModel("The ferals leap for you, but is met with the shelf tumbling on top of them.",
                        condition: new Func<bool>(() => { return !Player.HasFlag(Constants.FeralsDead); })),
                    new DialogueModel("The larger feral gets caught up in the mess, with all of them fighting to get past each other.",
                        condition: new Func<bool>(() => { return !Player.HasFlag(Constants.FeralsDead); })),
                    // Ferals Dead && Alpha Alive (always)
                    new DialogueModel("The shelf drops down, but the large feral easily avoids it from the walls.",
                        condition: new Func<bool>(() => { return Player.HasFlag(Constants.FeralsDead); })),
                    new DialogueModel("It takes the brief moment of opportunity to lunge at you.",
                        condition: new Func<bool>(() => { return Player.HasFlag(Constants.FeralsDead); })),
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Head to escape pods.", ToppleTheShelf,
                        condition: new Func<bool>(() => { return !Player.HasFlag(Constants.FeralsDead); })),
                    new ButtonModel("Dodge.", CaughtFeralsDead,
                        condition: new Func<bool>(() => { return Player.HasFlag(Constants.FeralsDead); })),
                });
        }

        public static void InitialiseCaughtFeralsAlive(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("The ferals pounce, gaining just enough distance to latch onto your ankle."),
                    new DialogueModel("Jan looks back, \"Sequoia!\""),
                    new DialogueModel("You fall down, and the ferals collapse upon you.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", MiscellaneousScene.Dead),
                });
        }

        public static void InitialiseCaughtFeralsDead(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You try to jump out of the way but the feral is too fast."),
                    new DialogueModel("It lands upon you, its heavy weight crushing you from above."),
                    new DialogueModel("Jan is running back, but hes too far away to help.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Overcharge defences.", CaughtFeralsDead2,
                        condition: new Func<bool>(() => { return Player.Energy > 0; }),
                        action: new Func<System.Threading.Tasks.Task>(async () => { Player.Energy--; })),
                    new ButtonModel("Continue.", CaughtFeralsDeadFail,
                        condition: new Func<bool>(() => { return Player.Energy <= 0; })),
                });
        }

        public static void InitialiseCaughtFeralsDead2(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("Energy courses through you, electrifying the air around you."),
                    new DialogueModel("The feral reels back in pain, giving just enough time for help to arrive. Jan kicks the feral off and pulls you away from it."),
                    new DialogueModel("He motions towards the doorway, \"We have to keep moving.\" ")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", EscapePodsEntrance)
                });
        }

        public static void InitialiseCaughtFeralsDeadFail(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("There was not enough time for help to arrive."),
                new DialogueModel("You try to fight back against the feral but it crushes you with its claws.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", MiscellaneousScene.Dead)
                });
        }

        public static void InitialiseDontToppleShelfFeralsDead(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You run past the shelf and continue down the hallway. It becomes obvious the feral is going to catch up."),
                    new DialogueModel("Jan stops in his tracks, blocking its way towards you. The large feral stops as well, as if accepting a challenge."),
                    new DialogueModel("Jan looks towards you, \"Go ahead and prepare our escape, I'll handle this.\""),
                    new DialogueModel("With a loaded gun in hand, he gives you a nod.",
                        condition: new Func<bool>(() => { return Player.HasFlag(Constants.JanHasBullets); })),
                    new DialogueModel("With his empty gun in hand, he gives you a nod.",
                        condition: new Func<bool>(() => { return !Player.HasFlag(Constants.JanHasBullets); })),
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", EscapePodScene.ContinueToEscapePods)
                });
        }

        public static void InitialiseSavedFeralHelps(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("But out of nowhere, a large screech is heard and a familiar feral jumps out from a side hallway and tackles the larger feral."),
                    new DialogueModel("It looks just like the one you had saved from the recovery room."),
                    new DialogueModel("They both drop to the floor, blocking the way and causing a massive ruckus among the pack of ferals.",
                        condition: new Func<bool>(() => { return !Player.HasFlag(Constants.FeralsDead); })),
                    new DialogueModel("They both drop to the floor, continuing to brawl it out in the hallway.",
                        condition: new Func<bool>(() => { return Player.HasFlag(Constants.FeralsDead); })),
                    new DialogueModel("You've been given a chance to make it to the escape pods."),
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", EscapePodScene.ContinueToEscapePodsBothInside)
                });
        }

        public static void InitialiseEscapePodsEntrance(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("As you both run towards the escape pods, a piercing snarl sounds from behind."),
                    new DialogueModel("\"You've got to be joking.\" Jan stops in his tracks."),
                    new DialogueModel("The large feral has made it behind the two of you again, and its challenging you to a fight."),
                    new DialogueModel("Jan turns to you, \"I'll handle this.\""),
                    new DialogueModel("With a loaded gun in hand, he gives you a nod.",
                        condition: new Func<bool>(() => { return Player.HasFlag(Constants.JanHasBullets); })),
                    new DialogueModel("With his empty gun in hand, he gives you a nod.",
                        condition: new Func<bool>(() => { return !Player.HasFlag(Constants.JanHasBullets); })),
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", EscapePodScene.ContinueToEscapePods)
                });
        }

    }
}
