using System;
using System.Collections.Generic;
using System.Text;
using Prominence.Model;
using Prominence.Resources.DialogueData;
using Prominence.Resources.DialogueData.Sequoia.Act_1;

namespace Prominence.Resources.DialogueData.Sequoia
{
    public class ProminenceFilm : IFilmModel
    {

        public string Name { get { return "Prominence";  } }
        public PlayerModel Player { get; set; }
        public Dictionary<string, IActModel> Acts { get; set; }

        public ProminenceFilm()
        {
            
        }

        public void Initialise(PlayerModel player)
        {
            Player = player;
            var questionsAct = new QuestionsAct();
            questionsAct.Initialise(this, player);

            Acts = new Dictionary<string, IActModel>()
            {
                { 
                    questionsAct.Name, questionsAct 
                }
            };
        }

    }
}
