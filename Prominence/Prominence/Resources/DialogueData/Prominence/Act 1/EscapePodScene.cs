using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Prominence.Model;
using Xamarin.Forms;

namespace Prominence.Resources.DialogueData.Sequoia.Act1
{
    public class EscapePodScene : ISceneModel
    {
        //public ISceneModel.Player Player;
        public IFilmModel Film { get; set; }
        public IActModel Act { get; set; }
        public PlayerModel Player { get; set; }
        public string Name { get { return "EscapePod"; } }
        public Action OnEnter { get { return null; } }
        public Action OnExit { get { return null; } }

        public FrameModel Wakeup = new FrameModel { Name = "Wakeup" };
        public FrameModel LookAround = new FrameModel { Name = "LookAround" };
        public FrameModel ListenToMessage = new FrameModel { Name = "ListenToMessage" };
        public FrameModel Interruption = new FrameModel { Name = "Interruption" };
        public FrameModel StayStill = new FrameModel { Name = "StayStill" };
        public FrameModel TryOpenPod = new FrameModel { Name = "TryOpenPod" };
        public FrameModel Upheaval = new FrameModel { Name = "Upheaval" };
        public FrameModel VillianLeaves = new FrameModel { Name = "VillianLeaves" };
        public FrameModel ListenToTheRestOfTheMessage = new FrameModel { Name = "ListenToTheRestOfTheMessage" };
        public FrameModel PunchThroughTheGlass = new FrameModel { Name = "PunchThroughTheGlass" };

        public EscapePodScene()
        {
            
        }

        // action: new Func<Task>(async () => { Player.IncrementFlag("EscapePod_OpenPod"); })

        public void Initialise(IFilmModel film, IActModel act, PlayerModel player)
        {
            Film = film;
            Act = act;
            Player = player;

            Wakeup = CreateWakeup(Film, Act, this, player, Wakeup.Name);
            LookAround = CreateLookAround(Film, Act, this, player, LookAround.Name);
            ListenToMessage = CreateListenToMessage(Film, Act, this, player, ListenToMessage.Name);
            Interruption = CreateInterruption(Film, Act, this, player, Interruption.Name);
            StayStill = CreateStayStill(Film, Act, this, player, StayStill.Name);
            TryOpenPod = CreateTryOpenPod(Film, Act, this, player, TryOpenPod.Name);
            Upheaval = CreateUpheaval(Film, Act, this, player, Upheaval.Name);
            VillianLeaves = CreateVillianLeaves(Film, Act, this, player, VillianLeaves.Name);
            ListenToTheRestOfTheMessage = CreateListenToTheRestOfTheMessage(Film, Act, this, player, ListenToTheRestOfTheMessage.Name);
            PunchThroughTheGlass = CreatePunchThroughTheGlass(Film, Act, this, player, PunchThroughTheGlass.Name);

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

        public FrameModel CreateWakeup(IFilmModel Film, IActModel Act, ISceneModel Scene, PlayerModel Player, string Name) 
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
                    new ButtonModel("Listen to the message.", ListenToMessage.Name),
                    new ButtonModel("Look around.", LookAround.Name),
                }
            );
        }

        // TODO: This
        public FrameModel CreateListenToMessage(IFilmModel Film, IActModel Act, ISceneModel Scene, PlayerModel Player, string Name)
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
                   new ButtonModel("Continue", Interruption.Name),
                }
            );
        }

        public FrameModel CreateLookAround(IFilmModel Film, IActModel Act, ISceneModel Scene, PlayerModel Player, string Name)
        {
            return new FrameModel(
                Film,
                Act,
                Scene,
                Name,
                new List<DialogueModel>() {
                new DialogueModel("You look around, and see two figures struggling with each other in the darkness."),
                new DialogueModel("You're inside a glass chamber, a standard cryostasis pod among a row of other occupied pods."),
               },
               new List<ButtonModel>()
               {
                new ButtonModel("Continue.", Interruption.Name),
               }
           );
        }

        public FrameModel CreateInterruption(IFilmModel Film, IActModel Act, ISceneModel Scene, PlayerModel Player, string Name)
        {
            return new FrameModel(
                Film,
                Act,
                Scene,
                Name,
                new List<DialogueModel>() {
                    new DialogueModel("Two figures suddenly crash onto your pod, cracking a hole through the glass.", condition: new Func<bool>(() => { return Player.HasVisited($"{Scene.GetLocation()}-{LookAround.Name}"); })),
                    new DialogueModel("The two figures suddenly crash onto your pod, cracking a hole through the glass.", condition: new Func<bool>(() => { return Player.HasVisited($"{Scene.GetLocation()}-{ListenToMessage.Name}"); })),
                    new DialogueModel("One is in a lightly armored space suit, with a large scaley being looming over, pinning them to the pod."),
                    new DialogueModel("You manage to take a deep breath."),
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Stay still.", StayStill.Name),
                    new ButtonModel("Try open the pod.", TryOpenPod.Name),
                }
            );
        }

        public FrameModel CreateStayStill(IFilmModel Film, IActModel Act, ISceneModel Scene, PlayerModel Player, string Name)
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
                    new ButtonModel("Continue.", Upheaval.Name),
                }
            );
        }

        public FrameModel CreateTryOpenPod(IFilmModel Film, IActModel Act, ISceneModel Scene, PlayerModel Player, string Name)
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
                    new ButtonModel("Continue.", Upheaval.Name),
                }
            );
        }

        public FrameModel CreateUpheaval(IFilmModel Film, IActModel Act, ISceneModel Scene, PlayerModel Player, string Name)
        {
            return new FrameModel(
                Film,
                Act,
                Scene,
                Name,
                new List<DialogueModel>() {
                    new DialogueModel("With a sudden upheaval, the suited stranger is thrown into the plating of the next pod, smashing the front glass of their helmet."),
                    new DialogueModel("They quickly try hold a hand over the cracks but the damage is too great, and within a moment, fall unconcious on the floor."),
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", VillianLeaves.Name),
                }
            );
        }

        public FrameModel CreateVillianLeaves(IFilmModel Film, IActModel Act, ISceneModel Scene, PlayerModel Player, string Name)
        {
            return new FrameModel(
                Film,
                Act,
                Scene,
                Name,
                new List<DialogueModel>() {
                    new DialogueModel("The scaled being begins mumbling to themselves as they pick up the stranger."),
                    new DialogueModel("They carry the person out of the room, turning left out the hallway."),
                    new DialogueModel("\"...areas are currently under lockdown. Avoid sectors...\". The message continues in the background."),
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Listen to the rest of the message.", ListenToTheRestOfTheMessage.Name),
                    new ButtonModel("Punch through the glass.", PunchThroughTheGlass.Name),
                }
            );
        }

        public FrameModel CreateListenToTheRestOfTheMessage(IFilmModel Film, IActModel Act, ISceneModel Scene, PlayerModel Player, string Name)
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
                    new DialogueModel("\"Reason given: Sectors partially or completely flooded.\""),
                    new DialogueModel("How did a spaceship get flooded?"),
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue.", ""),
                }
            );
        }

        public FrameModel CreatePunchThroughTheGlass(IFilmModel Film, IActModel Act, ISceneModel Scene, PlayerModel Player, string Name)
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
                    new ButtonModel("Continue.", ""),
                }
            );
        }

        private Dictionary<string, FrameModel> _frames;
        public Dictionary<string, FrameModel> Frames
        {
            get { return _frames; }
            set { _frames = value; }
        }

    }
}
