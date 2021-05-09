using System;
using System.Collections.Generic;
using System.Text;
using Prominence.Model;
using Prominence.Resources.DialogueData;
using Prominence.Resources.DialogueData.Sequoia.Act1;

namespace Prominence.Resources.DialogueData.Sequoia.Act_1
{
    public class AwakeningAct : IActModel
    {

        public IFilmModel Film { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Name { get { return "Awakening"; } }

        public PlayerModel Player { get; set; }
        public Action OnEnter { get; set; }
        public Action OnExit { get; set; }
        public Dictionary<string, ISceneModel> Scenes { get; set; }
        
    }
}
