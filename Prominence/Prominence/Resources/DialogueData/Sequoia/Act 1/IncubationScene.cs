using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Prominence.Model;
using Xamarin.Forms;

namespace Prominence.Resources.DialogueData.Sequoia
{
    public class IncubationScene : ISceneModel
    {

        public IFilmModel Film { get; set; }
        public IActModel Act { get; set; }
        public Dictionary<string, FrameModel> Frames { get; set; }
        public PlayerModel Player { get; set; }
        public string Name { get { return "Incubation"; } }
        public Action OnEnter { get { return null; } }
        public Action OnExit { get { return null; } }

        public FrameModel Start = new FrameModel { Name = "Start" };
        public FrameModel Silent = new FrameModel { Name = "Silent" };
        public FrameModel TalkToDrone = new FrameModel { Name = "TalkToDrone" };
        public FrameModel DroneLeaves = new FrameModel { Name = "DroneLeaves" };
        public FrameModel InspectIncubationRoom = new FrameModel { Name = "InspectIncubationRoom" };
        public FrameModel IncubationHallway = new FrameModel { Name = "IncubationHallway" };

        public IncubationScene()
        {

        }

        public void Initialise(IFilmModel film, IActModel act, PlayerModel player)
        {
            Film = film;
            Act = act;
            Player = player;

            Start = CreateStart(Film, Act, this, player, Start.Name);
            Silent = CreateStart(Film, Act, this, player, Silent.Name);
            TalkToDrone = CreateStart(Film, Act, this, player, TalkToDrone.Name);
            DroneLeaves = CreateStart(Film, Act, this, player, DroneLeaves.Name);
            InspectIncubationRoom = CreateStart(Film, Act, this, player, InspectIncubationRoom.Name);
            IncubationHallway = CreateStart(Film, Act, this, player, IncubationHallway.Name);

            Frames = new Dictionary<string, FrameModel>() {
                {Start.Name, Start},
                {Silent.Name, Silent},
                {TalkToDrone.Name, TalkToDrone},
                {DroneLeaves.Name, DroneLeaves},
                {InspectIncubationRoom.Name, InspectIncubationRoom},
                {IncubationHallway.Name, IncubationHallway},
            };
        }

        public FrameModel CreateStart(IFilmModel Film, IActModel Act, ISceneModel Scene, PlayerModel Player, string Name)
        {
            return new FrameModel(
                Film,
                Act,
                Scene,
                Name,
                new List<DialogueModel>() {
                    new DialogueModel("..."),
                    new DialogueModel("You wake up."),
                    new DialogueModel("Everything is dark, and you can't seem to move."),
                    new DialogueModel("...Where am I?"),
                    new DialogueModel("A short drilling sound comes from your side, followed by a brief pause.")
             },
                new List<ButtonModel>()
                {
                    new ButtonModel("Attempt to talk.", TalkToDrone),
                    new ButtonModel("Remain silent.", Silent)
                }
            );
        }
        public FrameModel CreateSilent(IFilmModel Film, IActModel Act, ISceneModel Scene, PlayerModel Player, string Name)
        {
            return new FrameModel(
               Film,
               Act,
               Scene,
               Name,
               new List<DialogueModel>() {
                    new DialogueModel("The drilling continues.")
            },
               new List<ButtonModel>()
               {
                    new ButtonModel("Continue.", DroneLeaves)/*, buttonActions = {GameState.GC?.ChangeBackground(R.drawable.incubation); GC?.SetTextBackgroundVisiblity(true);}*/
               }
            );
        }
        public FrameModel CreateTalkToDrone(IFilmModel Film, IActModel Act, ISceneModel Scene, PlayerModel Player, string Name)
        {
            return new FrameModel(
                Film,
                Act,
                Scene,
                Name,
                new List<DialogueModel>() {
                    new DialogueModel("\"Hello?\" You ask. \"Who's there?\""),
                    new DialogueModel("The drilling continues.") },
                    new List<ButtonModel>()
                {
                new ButtonModel("Continue.", DroneLeaves)/*, buttonActions = {GameState.GC?.ChangeBackground(R.drawable.incubation); GC?.SetTextBackgroundVisiblity(true);}*/
            }
            );
        }
        public FrameModel CreateDroneLeaves(IFilmModel Film, IActModel Act, ISceneModel Scene, PlayerModel Player, string Name)
        {
            return new FrameModel(
                Film,
                Act,
                Scene,
                Name,
                new List<DialogueModel>() {
                    new DialogueModel("Suddenly, your vision flickers on and you begin being lowered down."),
                    new DialogueModel("Looking to your side, you can just make out a drone hovering out of the room and into a hallway. It turns left."),
                    new DialogueModel("You realise you can move now, you get up.")
                },
                new List<ButtonModel>()
                {
                    new ButtonModel("Inspect the room.", InspectIncubationRoom),
                    new ButtonModel("Head into the hallway.", IncubationHallway)/*, buttonActions = {GameState.GC?.ChangeBackground(R.drawable.corridor)}*/
                }
            );
        }
        public FrameModel CreateInspectIncubationRoom(IFilmModel Film, IActModel Act, ISceneModel Scene, PlayerModel Player, string Name)
        {
            return new FrameModel(
                Film,
                Act,
                Scene,
                Name,
                new List<DialogueModel>() {
                    new DialogueModel("Everything in the room has a plain metal surface."),
                    new DialogueModel("The seat you were in has many circular connection points that match the metallic sockets around your body."),
                    new DialogueModel("You have no memory of this place.")
                 },
                new List<ButtonModel>()
                {
                    new ButtonModel("Continue to the hallway.", IncubationHallway)/*, buttonActions = {GameState.GC?.ChangeBackground(R.drawable.corridor)}*/
                }
            );
        }
        public FrameModel CreateIncubationHallway(IFilmModel Film, IActModel Act, ISceneModel Scene, PlayerModel Player, string Name)
        {
            return new FrameModel(
                Film,
                Act,
                Scene,
                Name,
                new List<DialogueModel>() {
                    new DialogueModel("Dull blue lights line the ceiling along the hallway, many of them flicker every few seconds. It's as if there isn't enough electricity going through the system."),
                    new DialogueModel("To the left, you just make out the back of the drone heading down the hallway."),
                    new DialogueModel("On the right the hallway turns, a faint red light can be seen projected on the floor.")
                },
                new List<ButtonModel>()
                {
                    //new ButtonModel("Follow the drone.", 200),
                    //new ButtonModel("Go towards the red light.", 300)/*, buttonActions = {GameState.GC?.ChangeBackground(R.drawable.computerroom)}*/
                }
            );
        }
    }
}
