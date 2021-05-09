using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Prominence.Model;
using Xamarin.Forms;

namespace Prominence.Resources.DialogueData.Sequoia.Act1
{
    public class IncubationScene : ISceneModel
    {

        public IFilmModel Film { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IActModel Act { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public PlayerModel Player { get; set; } = null;
        public string Name { get { return "incubation"; } }
        public  Action OnEnter { get { return null; } }
        public  Action OnExit { get { return null; } }
        public Dictionary<string, FrameModel> Frames { get; set; }
        

        //public IncubationScene()
        //{
        //    Frames = new Dictionary<string, FrameModel>() {
        //            {Wakeup.Name, Wakeup},
        //            {TalkToDrone.Name, TalkToDrone},
        //            {DrillingContinues.Name, DrillingContinues},
        //            {DroneLeaves.Name, DroneLeaves},
        //            {InspectRoom.Name, InspectRoom},
        //        };
        //}

        //public readonly static FrameModel Wakeup = new FrameModel(
        //    "Wakeup",
        //    new List<DialogueModel>() { 
        //        //new DialogueModel("...", action: new Task<bool>(() => { Task.Delay(3000); return true; })),
        //        //new DialogueModel("You wake up.", action: new Task<bool>(() => { Task.Delay(3000); return true; })),
        //        //new DialogueModel("Everything is dark, and you can't seem to move.", action: new Task<bool>(() => { Task.Delay(3000); return true; })),
        //        //new DialogueModel("...Where am I?", action: new Task<bool>(() => { Task.Delay(3000); return true; })),
        //        new DialogueModel("A short drilling sound comes from your side, followed by a brief pause."),
        //    },
        //    new List<ButtonModel>()
        //    {
        //        new ButtonModel("Attempt to talk.", "TalkToDrone"),
        //        new ButtonModel("Remain silent.", "DrillingContinues"),
        //    }
        //);

        //readonly static FrameModel TalkToDrone = new FrameModel(
        //    "TalkToDrone",
        //    new List<DialogueModel>() {
        //        new DialogueModel("\"Hello?\" You ask. \"Who's there?\""),
        //        new DialogueModel("The drilling continues.", color: Color.Red, textAlignment: TextAlignment.Center),
        //    },
        //    new List<ButtonModel>()
        //    {
        //        new ButtonModel("Continue", "DroneLeaves"),
        //    }
        //);

        //readonly static FrameModel DrillingContinues = new FrameModel(
        //    "DrillingContinues",
        //    new List<DialogueModel>() {
        //        new DialogueModel("The drilling continues."),
        //    },
        //    new List<ButtonModel>()
        //    {
        //        new ButtonModel("Continue", "DroneLeaves"),
        //    }
        //);

        //readonly static FrameModel DroneLeaves = new FrameModel(
        //    "DroneLeaves",
        //    new List<DialogueModel>() {
        //        new DialogueModel("Suddenly, your vision flickers on and you begin being lowered down."),
        //        new DialogueModel("Looking to your side, you can just make out a drone hovering out of the room and into a hallway. It turns left."),
        //        new DialogueModel("You realise you can move now, you get up."),
        //    },
        //    new List<ButtonModel>()
        //    {
        //        new ButtonModel("Inspect the room.", "InspectRoom"),
        //        new ButtonModel("Head into the hallway.", "HallwayScene"),
        //    }
        //);

        //readonly static FrameModel InspectRoom = new FrameModel(
        //    "InspectRoom",
        //    new List<DialogueModel>() {
        //        new DialogueModel("Everything in the room has a plain metal surface."),
        //        new DialogueModel("The seat you were in has many circular connection points that match the metallic sockets around your body."),
        //        new DialogueModel("You have no memory of this place."),
        //    },
        //    new List<ButtonModel>()
        //    {
        //        new ButtonModel("Continue to the hallway.", "HallwayScene"),
        //    }
        //);

    }
}
