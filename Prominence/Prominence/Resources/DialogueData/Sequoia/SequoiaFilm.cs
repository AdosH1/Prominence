using System;
using System.Collections.Generic;
using System.Text;
using Prominence.Model;
using Prominence.Resources.DialogueData;
using Prominence.Resources.DialogueData.Sequoia.Act_1;

namespace Prominence.Resources.DialogueData.Sequoia
{
    public class SequoiaFilm : IFilmModel
    {
        //public readonly static IFilmModel Sequoia = new IFilmModel(
        //    new Dictionary<string, IActModel>()
        //    {
        //        { "Awakening", AwakeningAct.Awakening }
        //    }
        //);

        public string Name { get { return "Sequoia";  } }

        public Dictionary<string, IActModel> Acts { get; set; }
    }
}
