//using System;
//using System.Collections.Generic;
//using System.Text;
//using Prominence.Model;
//using Prominence.Resources.DialogueData;
////using Prominence.Resources.DialogueData.Sequoia.Act_1;

//namespace Prominence.Resources.DialogueData.Prominence
//{
//    public class ProminenceFilm : FilmModel
//    {
//        public string Name = "Prominence"; //{ get { return "Prominence";  } }
//        public ProminenceFilm() { }
//        public void Initialise(PlayerModel player)
//        {
//            Player = player;
//            var questionsAct = new QuestionsAct();
//            questionsAct.Initialise(this.Name, player);

//            Acts = new Dictionary<string, IActModel>()
//            {
//                { 
//                    questionsAct.Name, questionsAct 
//                }
//            };
//        }

//    }
//}
