using System;
using System.Collections.Generic;
using System.Text;
using Prominence.Model;
using Prominence.Resources.DialogueData;
using Prominence.Resources.DialogueData.Sequoia.Act1;

namespace Prominence.Resources.DialogueData.Sequoia.Act_1
{
    public static class AwakeningAct
    {

        public readonly static ActModel Awakening = new ActModel(
            new Dictionary<string, SceneModel>() { 
                { "Incubation", new IncubationScene() } 
            }
        );

    }
}
