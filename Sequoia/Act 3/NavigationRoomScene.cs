using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Sequoia
{
    public class NavigationRoomScene : SceneModel
    {
        public static string Film;
        public static string Act;
        public static string Scene = "NavigationRoom";
        public static PlayerModel Player;

        public static FrameModel Entrance;
        public static FrameModel Introduction;
        public static FrameModel WhatIsHappeningHere;
        public static FrameModel WhatAreThoseCreatures;
        public static FrameModel HandOverAccessCard;
        public static FrameModel HandOverAccessCard2;
        public static FrameModel RestoringSystemsPlayer;
        public static FrameModel RestoringSystemsJan;
        public static FrameModel PeerOutTheViewPort;
        public static FrameModel InspectTheRoom;
        public static FrameModel TalkToSteinmann;
        public static FrameModel TalkToSteinmann2;
        public static FrameModel GiveSpareMagazine;
        public static FrameModel ExamineTerminal;
        public static FrameModel LogEntry1;
        public static FrameModel LogEntry2;
        public static FrameModel LogEntry3;
        public static FrameModel CalculateTrajectory;
        public static FrameModel ShowJanTrajectory;
        public static FrameModel WhatsGoingOn;
        public static FrameModel TurnOnShipLight;
        public static FrameModel SeaCreatureGroan;
        public static FrameModel KillTheLights;
        public static FrameModel WhatWillWeDo;
        public static FrameModel WhatHappensToTheFerals;
        public static FrameModel ActivateEvacuationProtocol;
        public static FrameModel ActivateEvacuationProtocol2;
        public static FrameModel ActivateEvacuationProtocol3;

        public NavigationRoomScene(string film, string act, PlayerModel player)
        {
            Film = film;
            Act = act;
            Player = player;

            Entrance = new FrameModel(Film, Act, Scene, "Entrance", Constants.NavigationRoom);
            Introduction = new FrameModel(Film, Act, Scene, "Introduction", Constants.NavigationRoom);
            WhatIsHappeningHere = new FrameModel(Film, Act, Scene, "WhatIsHappeningHere", Constants.NavigationRoom);
            WhatAreThoseCreatures = new FrameModel(Film, Act, Scene, "WhatAreThoseCreatures", Constants.NavigationRoom);
            HandOverAccessCard = new FrameModel(Film, Act, Scene, "HandOverAccessCard", Constants.NavigationRoom);
            HandOverAccessCard2 = new FrameModel(Film, Act, Scene, "HandOverAccessCard2", Constants.NavigationRoom);
            RestoringSystemsPlayer = new FrameModel(Film, Act, Scene, "RestoringSystemsPlayer", Constants.NavigationRoom);
            RestoringSystemsJan = new FrameModel(Film, Act, Scene, "RestoringSystemsJan", Constants.NavigationRoom);
            PeerOutTheViewPort = new FrameModel(Film, Act, Scene, "PeerOutTheViewPort", Constants.Black);
            InspectTheRoom = new FrameModel(Film, Act, Scene, "InspectTheRoom", Constants.NavigationRoom);
            TalkToSteinmann = new FrameModel(Film, Act, Scene, "TalkToSteinmann", Constants.NavigationRoom);
            TalkToSteinmann2 = new FrameModel(Film, Act, Scene, "TalkToSteinmann2", Constants.NavigationRoom);
            GiveSpareMagazine = new FrameModel(Film, Act, Scene, "GiveSpareMagazine", Constants.NavigationRoom);
            ExamineTerminal = new FrameModel(Film, Act, Scene, "ExamineTerminal", Constants.Terminal);
            LogEntry1 = new FrameModel(Film, Act, Scene, "LogEntry1", Constants.Terminal);
            LogEntry2 = new FrameModel(Film, Act, Scene, "LogEntry2", Constants.Terminal);
            LogEntry3 = new FrameModel(Film, Act, Scene, "LogEntry3", Constants.Terminal);
            CalculateTrajectory = new FrameModel(Film, Act, Scene, "CalculateTrajectory", Constants.Terminal);
            ShowJanTrajectory = new FrameModel(Film, Act, Scene, "ShowJanTrajectory", Constants.Terminal);
            WhatsGoingOn = new FrameModel(Film, Act, Scene, "WhatsGoingOn", Constants.NavigationRoom);
            TurnOnShipLight = new FrameModel(Film, Act, Scene, "TurnOnShipLight", Constants.NavigationRoom);
            SeaCreatureGroan = new FrameModel(Film, Act, Scene, "SeaCreatureGroan", Constants.NavigationRoom);
            KillTheLights = new FrameModel(Film, Act, Scene, "KillTheLights", Constants.NavigationRoom); // TODO: Discuss added red light background here?
            WhatWillWeDo = new FrameModel(Film, Act, Scene, "WhatWillWeDo", Constants.NavigationRoom);
            WhatHappensToTheFerals = new FrameModel(Film, Act, Scene, "WhatHappensToTheFerals", Constants.NavigationRoom);
            ActivateEvacuationProtocol = new FrameModel(Film, Act, Scene, "ActivateEvacuationProtocol", Constants.NavigationRoom);
            ActivateEvacuationProtocol2 = new FrameModel(Film, Act, Scene, "ActivateEvacuationProtocol2", Constants.NavigationRoom);
            ActivateEvacuationProtocol3 = new FrameModel(Film, Act, Scene, "ActivateEvacuationProtocol3", Constants.NavigationRoom);

            Frames = new Dictionary<string, FrameModel>() {
                {Entrance.Name,Entrance},
                {Introduction.Name,Introduction},
                {WhatIsHappeningHere.Name,WhatIsHappeningHere},
                {WhatAreThoseCreatures.Name,WhatAreThoseCreatures},
                {HandOverAccessCard.Name,HandOverAccessCard},
                {HandOverAccessCard2.Name,HandOverAccessCard2},
                {RestoringSystemsPlayer.Name,RestoringSystemsPlayer},
                {RestoringSystemsJan.Name,RestoringSystemsJan},
                {PeerOutTheViewPort.Name,PeerOutTheViewPort},
                {InspectTheRoom.Name,InspectTheRoom},
                {TalkToSteinmann.Name,TalkToSteinmann},
                {TalkToSteinmann2.Name,TalkToSteinmann2},
                {GiveSpareMagazine.Name,GiveSpareMagazine},
                {ExamineTerminal.Name,ExamineTerminal},
                {LogEntry1.Name,LogEntry1},
                {LogEntry2.Name,LogEntry2},
                {LogEntry3.Name,LogEntry3},
                {CalculateTrajectory.Name,CalculateTrajectory},
                {ShowJanTrajectory.Name,ShowJanTrajectory},
                {WhatsGoingOn.Name,WhatsGoingOn},
                {TurnOnShipLight.Name,TurnOnShipLight},
                {SeaCreatureGroan.Name,SeaCreatureGroan},
                {KillTheLights.Name,KillTheLights},
                {WhatWillWeDo.Name,WhatWillWeDo},
                {WhatHappensToTheFerals.Name,WhatHappensToTheFerals},
                {ActivateEvacuationProtocol.Name,ActivateEvacuationProtocol},
                {ActivateEvacuationProtocol2.Name,ActivateEvacuationProtocol2},
                {ActivateEvacuationProtocol3.Name,ActivateEvacuationProtocol3},
            };
        }

        public static void Initialise()
        {
            InitialiseEntrance(Entrance);
            InitialiseIntroduction(Introduction);
            InitialiseWhatIsHappeningHere(WhatIsHappeningHere);
            InitialiseWhatAreThoseCreatures(WhatAreThoseCreatures);
            InitialiseHandOverAccessCard(HandOverAccessCard);
            InitialiseHandOverAccessCard2(HandOverAccessCard2);
            InitialiseRestoringSystemsPlayer(RestoringSystemsPlayer);
            InitialiseRestoringSystemsJan(RestoringSystemsPlayer);
            InitialisePeerOutTheViewPort(PeerOutTheViewPort);
            InitialiseInspectTheRoom(InspectTheRoom);
            InitialiseTalkToSteinmann(TalkToSteinmann);
            InitialiseTalkToSteinmann2(TalkToSteinmann2);
            InitialiseGiveSpareMagazine(GiveSpareMagazine);
            InitialiseExamineTerminal(ExamineTerminal);
            InitialiseLogEntry1(LogEntry1);
            InitialiseLogEntry2(LogEntry2);
            InitialiseLogEntry3(LogEntry3);
            InitialiseCalculateTrajectory(CalculateTrajectory);
            InitialiseShowJanTrajectory(ShowJanTrajectory);
            InitialiseWhatsGoingOn(WhatsGoingOn);
            InitialiseTurnOnShipLight(TurnOnShipLight);
            InitialiseSeaCreatureGroan(SeaCreatureGroan);
            InitialiseKillTheLights(KillTheLights);
            InitialiseWhatWillWeDo(WhatWillWeDo);
            InitialiseWhatHappensToTheFerals(WhatHappensToTheFerals);
            InitialiseActivateEvacuationProtocol(ActivateEvacuationProtocol);
            InitialiseActivateEvacuationProtocol2(ActivateEvacuationProtocol2);
            InitialiseActivateEvacuationProtocol3(ActivateEvacuationProtocol3);
        }

        public static void InitialiseEntrance(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("The heavy door raises up."),
                    new DialogueModel("Large shutters cover the viewport out into space, and the terminals in the room are lit up with the words 'LOCKED'."),
                    new DialogueModel("A man is sitting in the center of the room, with his head between his arms."),
                    new DialogueModel("His face pops up, \"Sequoia!\".")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Who are you?", Introduction),
                    new ButtonModel("Remain silent.", Introduction)
                });
        }

        public static void InitialiseIntroduction(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("\"Oh - ofcourse,\" he slaps his head, \"you wouldn't remember me.\""),
                new DialogueModel("\"I am Dr. Steinmann, senior research officer of the ship and creator of..\""),
                new DialogueModel("He gestures towards you."),
                new DialogueModel("\"..androids. I got caught in here during the lock-down, and the only thing I could do was to send a drone to activate you.\""),
                new DialogueModel("\"I have been hoping you would find me.\"")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("What is happening here?", WhatIsHappeningHere),
                    new ButtonModel("What are those creatures?", WhatAreThoseCreatures)
                });
        }

        public static void InitialiseWhatIsHappeningHere(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("\"Something has gone very wrong.. we must have flown off course for a very long time to be running out of power now.\""),
                    new DialogueModel("\"I came here to figure out where we are, but the lockdown has closed everything off.\""),
                    new DialogueModel("\"I can override the protocol, but I need my access card... Did you happen to come across it from the R&D sector?\"")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("What are those creatures?", WhatAreThoseCreatures),
                    new ButtonModel("Hand over access card.", HandOverAccessCard,
                        condition: new Func<bool>(() => { return Player.HasItem(Constants.SteinmannAccessCard); }),
                        action: new Func<System.Threading.Tasks.Task>(async () => { Player.RemoveItem(Constants.SteinmannAccessCard); })),
                    new ButtonModel("Continue.", HandOverAccessCard2,
                        condition: new Func<bool>(() => { return Player.HasVisited(HandOverAccessCard.CurrentLocation); })),
                });
        }

        public static void InitialiseWhatAreThoseCreatures(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("Jan takes a moment to pause."),
                    new DialogueModel("\"This expedition was a mistake. This is the longest time anyone has been in cryostasis before, and the effects of the cryofluids in the body can be... dire.\""),
                    new DialogueModel("\"Some of the passengers awoken by the power outages have become feral, and now they run around the ship.\"")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("What is happening here?", WhatIsHappeningHere),
                    new ButtonModel("Hand over access card.", HandOverAccessCard,
                        condition: new Func<bool>(() => { return Player.HasItem(Constants.SteinmannAccessCard); }),
                        action: new Func<System.Threading.Tasks.Task>(async () => { Player.RemoveItem(Constants.SteinmannAccessCard); })),
                    new ButtonModel("Continue.", HandOverAccessCard2,
                        condition: new Func<bool>(() => { return Player.HasVisited(HandOverAccessCard.CurrentLocation); })),
                });
        }

        public static void InitialiseHandOverAccessCard(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("His face lights up."),
                    new DialogueModel("\"That's the one!\" Taking the card, he quickly swivels towards the navigation terminal."),
                    new DialogueModel("\"We can finally figure out where we are and steer us back on course\".")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Follow him.", HandOverAccessCard2),
                });
        }

        public static void InitialiseHandOverAccessCard2(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("Jan uses his access card to unlock the navigation panel."),
                    new DialogueModel("Looking over his shoulder, you can see the terminal:"),
                    new DialogueModel("  > Welcome back, Dr. Jan Steinmann!"),
                    new DialogueModel("  > Override lockdown protocol?"),
                    new DialogueModel("He looks back towards you."),
                    new DialogueModel("\"Would you like to do the honours?\"")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Override protocol.", RestoringSystemsPlayer),
                    new ButtonModel("Let Jan override.", RestoringSystemsJan),
                });
        }

        public static void InitialiseRestoringSystemsPlayer(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You take control of the panel and override the lockdown."),
                    new DialogueModel("The screen lights up."),
                    new DialogueModel("  > Restoring systems..."),
                    new DialogueModel("The steel shutters in the viewport begin to raise, providing an outlook into space."),
                    new DialogueModel("\"Just unbelievable...\", Jan peers outwards."),
                    new DialogueModel("\"This doesn't make any sense.\"")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Peer out the viewport.", PeerOutTheViewPort),
                });
        }

        public static void InitialiseRestoringSystemsJan(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("\"Not a problem\", he says as he takes control of the terminal."),
                    new DialogueModel("The screen lights up."),
                    new DialogueModel("  > Restoring systems..."),
                    new DialogueModel("The steel shutters in the viewport begin to raise, providing an outlook into space."),
                    new DialogueModel("\"Just unbelievable...\", Jan peers outwards."),
                    new DialogueModel("\"This doesn't make any sense.\"")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Peer out the viewport.", PeerOutTheViewPort),
                });
        }

        public static void InitialisePeerOutTheViewPort(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("What lies beyond the viewport is complete darkness - pitch black."),
                    new DialogueModel("A dark void without any sign of a distant galaxy or star."),
                    new DialogueModel("Where could you possibly be?"),
                    new DialogueModel("Jan has retreated to the center desk in deep thought.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Inspect the room.", InspectTheRoom),
                    new ButtonModel("Talk to Steinmann.", TalkToSteinmann),
                    new ButtonModel("Examine terminal.", ExamineTerminal),
                });
        }

        public static void InitialiseInspectTheRoom(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("The navigation room is messy, clearly people have been living here prior."),
                    new DialogueModel("Papers are sprawled around the room, with scribblings that map the ventilation system aboard the ship."),
                    new DialogueModel("It appears the navigation crew also had issues early on with ferals onboard."),
                    new DialogueModel("Interestingly, the mappings show that in one way or another, the ventilation system connects all rooms together.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Talk to Steinmann.", TalkToSteinmann),
                    new ButtonModel("Examine terminal.", ExamineTerminal),
                });
        }

        public static void InitialiseTalkToSteinmann(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("Steinmann looks over as you approach."),
                    new DialogueModel("\"Sorry, I just needed a moment to recuperate.\""),
                    new DialogueModel("\"There are good people on this ship, many of whom are my colleagues...\""),
                    new DialogueModel("Jan is fiddling with an empty gun in his hands, its handle covered with dry blood."),
                    new DialogueModel("\"I have mapped the electricity grid aboard, and almost half the passengers are in blackout zones - they're gone..\"")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", TalkToSteinmann2),
                });
        }

        public static void InitialiseTalkToSteinmann2(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("\"With the lockdown removed, I thought we could steer the ship to a nearby planet.\""),
                    new DialogueModel("Jan shakes his head."),
                    new DialogueModel("\"Instead we're completely lost and with the lockdown removed, we've just unlocked all the doors on the ship for the ferals...\""),
                    new DialogueModel("There must be something else we can do.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Give spare magazine.", GiveSpareMagazine,
                        condition: new Func<bool>(() => { return Player.HasItem(Constants.SpareMagazine); }),
                        action: new Func<System.Threading.Tasks.Task>(async () => { Player.RemoveItem(Constants.SpareMagazine); Player.IncrementFlag(Constants.JanHasBullets); })),
                    new ButtonModel("Examine terminal.", ExamineTerminal),
                    new ButtonModel("Inspect the room.", InspectTheRoom),
                });
        }

        public static void InitialiseGiveSpareMagazine(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("Jan pauses as you offer him the magazine, he takes a moment to contemplate."),
                    new DialogueModel("\"I still think we can save these ferals, but we have to establish a colony first in order to study their disease.\""),
                    new DialogueModel("\"So until then,\" Jan takes the magazine and cocks the gun back."),
                    new DialogueModel("\"We will have to ensure our mission succeeds.\"")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Examine terminal.", ExamineTerminal),
                    new ButtonModel("Inspect the room.", InspectTheRoom),
                });
        }

        public static void InitialiseExamineTerminal(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("The terminal has basic system diagnostics:"),
                    new DialogueModel("SYSTEM STATUS:"),
                    new DialogueModel("    CURRENT SPEED: 0 KM/H"),
                    new DialogueModel("    EST. DESTINATION ARRIVAL: INF."),
                    new DialogueModel("    POWER: EMERGENCY BACKUP"),
                    new DialogueModel("    ENGINE 1: UNAVAILABLE"),
                    new DialogueModel("    ENGINE 2: UNAVAILABLE"),
                    new DialogueModel("    GENERATOR: UNAVAILABLE"),
                    new DialogueModel("There are also log entries from the previous crew.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Log entries.", LogEntry1),
                    new ButtonModel("Inspect the room.", InspectTheRoom),
                    new ButtonModel("Talk to Steinmann", TalkToSteinmann),
                    new ButtonModel("Diagnostics: Ship Trajectory", CalculateTrajectory),
                });
        }

        public static void InitialiseLogEntry1(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("Roger from Team 6, reporting in."),
                    new DialogueModel("We've just awoken to take over Team 5's post for the last stretch towards Andrea and rest assured, you're in good hands!"),
                    new DialogueModel("Admittedly, a few of us a taking the defrostation period a bit hard.. but they'll have the next decade to recover now won't they? Hah."),
                    new DialogueModel("Team 5 will be with us for one more week for the handover before they return to cryostasis.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Log entry 2.", LogEntry2),
                    new ButtonModel("Log entry 3.", LogEntry3),
                    new ButtonModel("Return", ExamineTerminal),
                });
        }

        public static void InitialiseLogEntry2(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("Roger of Team 6 reporting in."),
                    new DialogueModel("I'm a bit worried. The medication isn't helping the crew quite as much as I thought, and some of the team are getting a little paranoid out here in deep space."),
                    new DialogueModel("They are professionals though, and I trust their training will pull through."),
                    new DialogueModel("I will organise a crew meeting to better address the paranoia and issues at hand.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Log entry 1.", LogEntry1),
                    new ButtonModel("Log entry 3.", LogEntry3),
                    new ButtonModel("Return", ExamineTerminal),
                });
        }

        public static void InitialiseLogEntry3(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("Roger, reporting in."),
                    new DialogueModel("I fear the worst. Several of our crew have gone missing and no one knows where they are."),
                    new DialogueModel("We're now organizing a search party to try find them."),
                    new DialogueModel("If this fails, we'll have to involuntarily awaken some of the previous crew to service... and maybe some security while we're at it too...")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Log entry 1.", LogEntry1),
                    new ButtonModel("Log entry 2.", LogEntry2),
                    new ButtonModel("Return", ExamineTerminal),
                });
        }

        public static void InitialiseCalculateTrajectory(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You access the trajectory information aboard the ship."),
                    new DialogueModel("  > Processing..."),
                    new DialogueModel("  > ... done."),
                    new DialogueModel("A time lapse is shown of the ship's trajectory through space."),
                    new DialogueModel("It shows a smooth path followed by an abrupt stop."),
                    new DialogueModel("It appears the ship was on the right path.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Show Jan.", ShowJanTrajectory),
                    new ButtonModel("Return", ExamineTerminal),
                });
        }

        public static void InitialiseShowJanTrajectory(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You call Jan over."),
                    new DialogueModel("He gives a brief look at the console, \"We could overlay it with our model of this solar system...\""),
                    new DialogueModel("He runs a few commands."),
                    new DialogueModel("The terminal shows the ship perfectly intersects with the rotation of planet Andrea around its star."),
                    new DialogueModel("Jan has a moment of realisation."),
                    new DialogueModel("\"Sequioa, can you turn on the ship's lights?\"")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("What is going on?", WhatsGoingOn),
                    new ButtonModel("Turn on the ship's light.", TurnOnShipLight),
                });
        }

        public static void InitialiseWhatsGoingOn(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("\"We have arrived, Sequoia. We've been here for far too long.\""),
                    new DialogueModel("Jan gives you a nod to turn on the lights.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Turn on the ship's light.", TurnOnShipLight),
                });
        }

        public static void InitialiseTurnOnShipLight(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("The lights flicker, and takes a couple moments to kick in."),
                    new DialogueModel("Two beams shoot forward, catching on what appears to be a sea floor."),
                    new DialogueModel("\"We've been on Andrea the entire time... decades, even.\""),
                    new DialogueModel("\"If we activate the evacuation protocols, we can save the remaining passengers in cryostasis...\""),
                    new DialogueModel("\"...They can be sent to the surface.\"")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", SeaCreatureGroan),
                });
        }

        public static void InitialiseSeaCreatureGroan(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("A load groan from outside interrupts you, and by the sound alone it vibrates walls of the ship. Whatever it is, it must be collosal."),
                    new DialogueModel("A deathly silence falls between the two of you."),
                    new DialogueModel("\"Kill the lights.\"")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Turn off lights.", KillTheLights),
                });
        }

        public static void InitialiseKillTheLights(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("You shut the lights off, and the viewport fades to black just as before."),
                    new DialogueModel("Rendezvousing with Jan, you can see he is planning a course of action.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("What will we do?", WhatWillWeDo),
                    new ButtonModel("What happens to the ferals?", WhatHappensToTheFerals),
                });
        }

        public static void InitialiseWhatWillWeDo(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("\"We'll have to find an escape pod, the closest one would be here.\""),
                    new DialogueModel("He points to a map on the wall detailing evacuation procedures."),
                    new DialogueModel("The escape pod is back through the infirmary down another hallway."),
                    new DialogueModel("\"We just have to be careful of the ferals..\"")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("What happens to the ferals?", WhatHappensToTheFerals),
                    new ButtonModel("Activate evacuation protocol.", ActivateEvacuationProtocol),
                });
        }

        public static void InitialiseWhatHappensToTheFerals(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("Jan takes a pause."),
                    new DialogueModel("\"I don't know.\""),
                    new DialogueModel("\"Until we find a cure, IF there is a cure, we can't save them.\"")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("What will we do?", WhatWillWeDo),
                    new ButtonModel("Activate evacuation protocol.", ActivateEvacuationProtocol),
                });
        }

        public static void InitialiseActivateEvacuationProtocol(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("Another massive groan shudders the walls..."),
                    new DialogueModel("... * BANG *"),
                    new DialogueModel("Suddenly, you're thrown hard onto the floor."),
                    new DialogueModel("The lights in the room go red."),
                    new DialogueModel("Cracks are forming in the ship's viewscreen.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue", ActivateEvacuationProtocol2),
                });
        }

        public static void InitialiseActivateEvacuationProtocol2(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("An update comes through the terminal:"),
                    new DialogueModel("  > ERROR: HULL BREACHED."),
                    new DialogueModel("  > SECTORS 3, 4, 6 FLOODING."),
                    new DialogueModel("  > PLEASE EVACUATE SAFELY."),
                    new DialogueModel("Jan is yelling at you from behind."),
                    new DialogueModel("\"THERE IS NO TIME, SEND THE SIGNAL!\"")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Send evacuation signal.", ActivateEvacuationProtocol3),
                });
        }

        public static void InitialiseActivateEvacuationProtocol3(FrameModel frame)
        {
            frame.Initialise(
                new List<DialogueModel>() {
                    new DialogueModel("  > Emergency evacuation procedures initiated..."),
                    new DialogueModel("  > Evacuating..."),
                    new DialogueModel("The terminal shows a visualization of the escape pods launching out from the ship."),
                    new DialogueModel("Suddenly, the viewscreen caves in."),
                    new DialogueModel("Jan yanks you backwards just in time to evade the initial impact of water flooding in."),
                    new DialogueModel("\"GO! GO! GO!\" He pushes you forward as water gushes into the room.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Run.", EscapeCorridorScene.HeadToCorridor),
                });
        }
    }

}
