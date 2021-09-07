using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Prominence.Model;
using Xamarin.Forms;

namespace Prominence.Resources.DialogueData.Prominence
{
    public class EscapePodScene : SceneModel
    {
        public string Name { get { return "EscapePod"; } }
        public FrameModel Wakeup = new FrameModel { Name = "Wakeup" };
        public FrameModel LookAround = new FrameModel { Name = "LookAround" };
        public FrameModel ListenToMessage = new FrameModel { Name = "ListenToMessage" };
        public FrameModel Interruption = new FrameModel { Name = "Interruption" };
        public FrameModel StayStill = new FrameModel { Name = "StayStill" };
        public FrameModel TryOpenPod = new FrameModel { Name = "TryOpenPod" };
        public FrameModel Upheaval = new FrameModel { Name = "Upheaval" };
        public FrameModel VillianLeaves = new FrameModel { Name = "VillianLeaves" };
        public FrameModel ListenToRestOfTheMessage = new FrameModel { Name = "ListenToRestOfTheMessage" };
        public FrameModel PodAutoOpens = new FrameModel { Name = "PodAutoOpens" };
        public FrameModel PunchThroughThePodGlass = new FrameModel { Name = "PunchThroughThePodGlass" };
        public FrameModel CryostasisRoom = new FrameModel { Name = "CryostasisRoom" };
        public FrameModel LookAroundCryostasisRoom = new FrameModel { Name = "LookAroundCryostasisRoom" };
        public FrameModel InspectStasisPods = new FrameModel { Name = "InspectStasisPods" };
        public FrameModel PickUpDevice = new FrameModel { Name = "PickUpDevice" };
        public EscapePodScene() { }

        public void Initialise(string film, string act, PlayerModel player)
        {
            Film = film;
            Act = act;
            Player = player;

            Wakeup = CreateWakeup(Film, Act, this.Name, player, Wakeup.Name);
            LookAround = CreateLookAround(Film, Act, this.Name, player, LookAround.Name);
            ListenToMessage = CreateListenToMessage(Film, Act, this.Name, player, ListenToMessage.Name);
            Interruption = CreateInterruption(Film, Act, this.Name, player, Interruption.Name);
            StayStill = CreateStayStill(Film, Act, this.Name, player, StayStill.Name);
            TryOpenPod = CreateTryOpenPod(Film, Act, this.Name, player, TryOpenPod.Name);
            Upheaval = CreateUpheaval(Film, Act, this.Name, player, Upheaval.Name);
            VillianLeaves = CreateVillianLeaves(Film, Act, this.Name, player, VillianLeaves.Name);
            ListenToRestOfTheMessage = CreateListenToRestOfTheMessage(Film, Act, this.Name, player, ListenToRestOfTheMessage.Name);
            PodAutoOpens = CreatePodAutoOpens(Film, Act, this.Name, player, PodAutoOpens.Name);
            PunchThroughThePodGlass = CreatePunchThroughThePodGlass(Film, Act, this.Name, player, PunchThroughThePodGlass.Name);
            CryostasisRoom = CreateCryostasisRoom(Film, Act, this.Name, player, CryostasisRoom.Name);
            LookAroundCryostasisRoom = CreateLookAroundCryostasisRoom(Film, Act, this.Name, player, LookAroundCryostasisRoom.Name);
            InspectStasisPods = CreateInspectStasisPods(Film, Act, this.Name, player, InspectStasisPods.Name);
            PickUpDevice = CreatePickUpDevice(Film, Act, this.Name, player, PickUpDevice.Name);

            Frames = new Dictionary<string, FrameModel>() {
                    {Wakeup.Name, Wakeup},
                    {LookAround.Name, LookAround},
                    {ListenToMessage.Name, ListenToMessage},
                    {Interruption.Name, Interruption},
                    {StayStill.Name, StayStill},
                    {TryOpenPod.Name, TryOpenPod},
                    {Upheaval.Name, Upheaval},
                    {VillianLeaves.Name, VillianLeaves},
                };
        }

        public FrameModel CreateWakeup(string Film, string Act, string Scene, PlayerModel Player, string Name) 
        {
            return new FrameModel(
                Film,
                Act,
                Scene,
                Name,
                new List<DialogueModel>() {
                    new DialogueModel("...", action: new Func<Task>(async () => { await Task.Delay(2000); })),
                    new DialogueModel("*THUMP*...", action: new Func<Task>(async () => { await Task.Delay(2000); })),
                    new DialogueModel("You gasp for air, it is hard to breathe.", action: new Func<Task>(async () => { await Task.Delay(2000); })),
                    new DialogueModel("A message begins playing from an overhead speaker."),
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Listen to the message.", ListenToMessage),
                    new ButtonModel("Look around.", LookAround),
                }
            );
        }

        public FrameModel CreateListenToMessage(string Film, string Act, string Scene, PlayerModel Player, string Name)
        {
            return new FrameModel(
                Film,
                Act,
                Scene,
                Name,
                new List<DialogueModel>() {
                    new DialogueModel("\"Greetings Amelia, welcome back to the Priscillia.\""),
                    new DialogueModel("\"It has been 846 days since you've entered cryosleep.\""),
                    new DialogueModel("\"This is an unscheduled awaking.\""),
                    new DialogueModel("\"No reasoning has been provided.\""),
                },
                new List<ButtonModel>()
                {
                   new ButtonModel("Continue", Interruption),
                }
            );
        }

        public FrameModel CreateLookAround(string Film, string Act, string Scene, PlayerModel Player, string Name)
        {
            return new FrameModel(
                Film,
                Act,
                Scene,
                Name,
                new List<DialogueModel>() {
                new DialogueModel("You look around, and see movement in the darkness."),
                new DialogueModel("You're inside a glass chamber, a standard cryostasis pod among a row of other occupied pods."),
                new DialogueModel("Two figures come into view, they appear to be fighting and struggling with each other."),
               },
               new List<ButtonModel>()
               {
                new ButtonModel("Continue.", Interruption),
               }
           );
        }

        public FrameModel CreateInterruption(string Film, string Act, string Scene, PlayerModel Player, string Name)
        {
            return new FrameModel(
                Film,
                Act,
                Scene,
                Name,
                new List<DialogueModel>() {
                    new DialogueModel("The two figures suddenly crash onto your pod, cracking a hole through the glass.", condition: new Func<bool>(() => { return Player.HasVisited(ListenToMessage.CurrentLocation); })),
                    new DialogueModel("Suddenly one of them is shoved onto your pod, cracking the hole through the glass.", condition: new Func<bool>(() => { return Player.HasVisited(LookAround.CurrentLocation); })),
                    new DialogueModel("One is in a lightly armored space suit, with a large scaley being looming over, pinning them to the pod."),
                    new DialogueModel("You manage to take a deep breath."),
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Stay still.", StayStill),
                    new ButtonModel("Try open the pod.", TryOpenPod),
                }
            );
        }

        public FrameModel CreateStayStill(string Film, string Act, string Scene, PlayerModel Player, string Name)
        {
            return new FrameModel(
                Film,
                Act,
                Scene,
                Name,
                new List<DialogueModel>() {
                    new DialogueModel("You stay in place, blending in with the other cryosleepers."),
                    new DialogueModel("As they struggle, they don't seem to notice your presence."),

                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", Upheaval),
                }
            );
        }

        public FrameModel CreateTryOpenPod(string Film, string Act, string Scene, PlayerModel Player, string Name)
        {
            return new FrameModel(
                Film,
                Act,
                Scene,
                Name,
                new List<DialogueModel>() {
                    new DialogueModel("You attempt to pull the emergency release latch, but the frozen handle is jammed and shatters in your hand."),
                    new DialogueModel("The blue scaley form sees you past his struggling opponent, but seems to pay you no mind."),

                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", Upheaval),
                }
            );
        }

        public FrameModel CreateUpheaval(string Film, string Act, string Scene, PlayerModel Player, string Name)
        {
            return new FrameModel(
                Film,
                Act,
                Scene,
                Name,
                new List<DialogueModel>() {
                    new DialogueModel("With a sudden upheaval, the suited stranger is thrown into the plating of the next pod, smashing the front glass of their helmet."),
                    new DialogueModel("They quickly place a hand over the crack but air still seems to slip out. Within a moment, they fall unconcious on the floor."),
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", VillianLeaves),
                }
            );
        }

        public FrameModel CreateVillianLeaves(string Film, string Act, string Scene, PlayerModel Player, string Name)
        {
            return new FrameModel(
                Film,
                Act,
                Scene,
                Name,
                new List<DialogueModel>() {
                    new DialogueModel("The scaled being begins mumbling to himself as they pick up the stranger."),
                    new DialogueModel("They carry the person out of the room, turning left out the hallway."),
                    new DialogueModel("\"...areas are currently under lockdown. Please detour around the following sect...\". The message continues in the background."),
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Listen to the rest of the message", ListenToRestOfTheMessage),
                    new ButtonModel("Smash through pod glass", PunchThroughThePodGlass),
                }
            );
        }

        public FrameModel CreateListenToRestOfTheMessage(string Film, string Act, string Scene, PlayerModel Player, string Name)
        {
            return new FrameModel(
                Film,
                Act,
                Scene,
                Name,
                new List<DialogueModel>() {
                    new DialogueModel("\"Please detour around the following sectors: \""),
                    new DialogueModel("\"Western Greenhouse\""),
                    new DialogueModel("\"Auditorium\""),
                    new DialogueModel("\"Andreas Datacentre\""),
                    new DialogueModel("\"Reason given: Sectors are currently partially or completely flooded.\""),
                    new DialogueModel(""),
                    new DialogueModel("How did a spaceship get flooded?"),

                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue", PodAutoOpens),
                }
            );
        }

        public FrameModel CreatePodAutoOpens(string Film, string Act, string Scene, PlayerModel Player, string Name)
        {
            return new FrameModel(
                Film,
                Act,
                Scene,
                Name,
                new List<DialogueModel>() {
                    new DialogueModel("\"Thank you for using Vespenergy Cryostasis Systems.\""),
                    new DialogueModel("The pod door automatically unseals and opens, opening up to a cold, dark room."),

                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue", CryostasisRoom),
                }
            );
        }

        public FrameModel CreatePunchThroughThePodGlass(string Film, string Act, string Scene, PlayerModel Player, string Name)
        {
            return new FrameModel(
                Film,
                Act,
                Scene,
                Name,
                new List<DialogueModel>() {
                    new DialogueModel("You punch through the cracked glass and the window shatters. The sound of shattering glass was deafening inside the pod."),
                    new DialogueModel("As the glass settles, it opens up a cold, dark room. It is eerily quiet."),

                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue", CryostasisRoom),
                }
            );
        }

        public FrameModel CreateCryostasisRoom(string Film, string Act, string Scene, PlayerModel Player, string Name)
        {
            return new FrameModel(
                Film,
                Act,
                Scene,
                Name,
                new List<DialogueModel>() {
                    new DialogueModel("The only source of light in the room comes from the dim glow of the cryopod backlights."),
                    new DialogueModel("Besides your pod, the others people on the ship have seemed to remain dormant."),

                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Look around", LookAroundCryostasisRoom), 
                    //new ButtonModel("Enter hallway", ""), /// TODO
                }
            );
        }

        public FrameModel CreateLookAroundCryostasisRoom(string Film, string Act, string Scene, PlayerModel Player, string Name)
        {
            return new FrameModel(
                Film,
                Act,
                Scene,
                Name,
                new List<DialogueModel>() {
                    new DialogueModel("Shattered glass covers the floor from where you smashed through the cryopod.", new Func<bool>(() => { return Player.HasVisited(PunchThroughThePodGlass.Name); })),
                    new DialogueModel("The room looks clean and untouched besides the minor signs of cracked glass from your cryopod.", new Func<bool>(() => { return Player.HasVisited(ListenToRestOfTheMessage.Name); })),
                    new DialogueModel("A few lines of cryopods fill the room, with empty ones scattered among the occupied."),
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Inspect stasis pods", InspectStasisPods),
                    //new ButtonModel("Exit room", ""), /// TODO
                }
            );
        }

        public FrameModel CreateInspectStasisPods(string Film, string Act, string Scene, PlayerModel Player, string Name)
        {
            return new FrameModel(
                Film,
                Act,
                Scene,
                Name,
                new List<DialogueModel>() {
                    new DialogueModel("Looking at the data plates, the people in the pods are from a very diverse background."),
                    new DialogueModel("You recall that people are usually grouped together into functional units, though it does not seem to be the case here."),
                    new DialogueModel("From where the earlier struggle was occuring, you notice a small device was dropped.", new Func<bool>(() => { return !Player.HasVisited(PickUpDevice.Name); })),
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Pick up device", PickUpDevice),
                    new ButtonModel("Back", LookAroundCryostasisRoom),
                }
            );
        }

        public FrameModel CreatePickUpDevice(string Film, string Act, string Scene, PlayerModel Player, string Name)
        {
            return new FrameModel(
                Film,
                Act,
                Scene,
                Name,
                new List<DialogueModel>() {
                    new DialogueModel("The small device looks like some kind of communicator."),
                    new DialogueModel("It looks familiar yet somewhat different, as if the technology was branched off at some point in the past."),
                    new DialogueModel("You turn the communicator on."),
                    new DialogueModel(""),
                    new DialogueModel("...*static*..."),
                    new DialogueModel("The scaled being begins mumbling to themselves as they pick up the stranger."),
                    new DialogueModel("They carry the person out of the room, turning left out the hallway."),
                    new DialogueModel("\"...areas are currently under lockdown. Avoid sectors...\". The message continues in the background."),
                },
                new List<ButtonModel>()
                {
                    //new ButtonModel("Listen to the rest of the message.", ""),
                    //new ButtonModel("Punch through the glass.", ""),
                }
            );
        }

    }
}
