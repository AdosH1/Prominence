using System;
using System.Collections.Generic;
using System.Text;
using Prominence.Model;
using Prominence.Resources.DialogueData;
using Prominence.Resources.DialogueData.Sequoia.Act_1;

namespace Prominence.Resources.DialogueData.Sequoia
{
    public static class SequoiaFilm
    {
        public readonly static FilmModel Sequoia = new FilmModel(
            new Dictionary<string, ActModel>()
            {
                { "Awakening", AwakeningAct.Awakening }
            }
        );



    }
}
