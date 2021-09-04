using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Prominence.Model;
using Xamarin.Forms;
using Prominence.Contexts;
using Prominence.Model.Constants;
using Prominence.Controllers;

namespace Prominence.Resources.DialogueData.Sequoia
{
    public class IncubationScene : SceneModel
    {
        public string Name { get { return "Incubation"; } }
        public FrameModel Start = new FrameModel { Name = "Start" };
        public FrameModel Silent = new FrameModel { Name = "Silent" };
        public FrameModel TalkToDrone = new FrameModel { Name = "TalkToDrone" };
        public FrameModel DroneLeaves = new FrameModel { Name = "DroneLeaves" };
        public FrameModel InspectIncubationRoom = new FrameModel { Name = "InspectIncubationRoom" };
        public FrameModel IncubationHallway = new FrameModel { Name = "IncubationHallway" };
        public IncubationScene() { }

        public void Initialise(string film, string act, PlayerModel player)
        {
            Film = film;
            Act = act;
            Player = player;

            Start = CreateStart(Film, Act, this.Name, player, Start.Name);
            Silent = CreateSilent(Film, Act, this.Name, player, Silent.Name);
            TalkToDrone = CreateTalkToDrone(Film, Act, this.Name, player, TalkToDrone.Name);
            DroneLeaves = CreateDroneLeaves(Film, Act, this.Name, player, DroneLeaves.Name);
            InspectIncubationRoom = CreateInspectIncubationRoom(Film, Act, this.Name, player, InspectIncubationRoom.Name);
            IncubationHallway = CreateIncubationHallway(Film, Act, this.Name, player, IncubationHallway.Name);

            Frames = new Dictionary<string, FrameModel>() {
                {Start.Name, Start},
                {Silent.Name, Silent},
                {TalkToDrone.Name, TalkToDrone},
                {DroneLeaves.Name, DroneLeaves},
                {InspectIncubationRoom.Name, InspectIncubationRoom},
                {IncubationHallway.Name, IncubationHallway},
            };
        }

        public FrameModel CreateStart(string Film, string Act, string Scene, PlayerModel Player, string Name)
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
        public FrameModel CreateSilent(string Film, string Act, string Scene, PlayerModel Player, string Name)
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
                    new ButtonModel("Continue.", DroneLeaves, action: new Func<Task>(async () => { GameController.ChangeBackground(SequoiaConstants.Incubation); }))
               }
            );
        }
        public FrameModel CreateTalkToDrone(string Film, string Act, string Scene, PlayerModel Player, string Name)
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
                new ButtonModel("Continue.", DroneLeaves, action: new Func<Task>(async () => { GameController.ChangeBackground(SequoiaConstants.Incubation); }))
            }
            );
        }
        public FrameModel CreateDroneLeaves(string Film, string Act, string Scene, PlayerModel Player, string Name)
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
                    new ButtonModel("Head into the hallway.", IncubationHallway, action: new Func<Task>(async () => { GameController.ChangeBackground(SequoiaConstants.Corridor); }))
                }
            );
        }
        public FrameModel CreateInspectIncubationRoom(string Film, string Act, string Scene, PlayerModel Player, string Name)
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
                    new ButtonModel("Continue to the hallway.", IncubationHallway, action: new Func<Task>(async () => { GameController.ChangeBackground(SequoiaConstants.Corridor); }))
                }
            );
        }
        public FrameModel CreateIncubationHallway(string Film, string Act, string Scene, PlayerModel Player, string Name)
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
