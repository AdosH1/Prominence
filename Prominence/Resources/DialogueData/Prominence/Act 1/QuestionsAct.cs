using System;
using System.Collections.Generic;
using System.Text;
using Prominence.Model;
using Prominence.Resources.DialogueData;
using Prominence.Resources.DialogueData.Sequoia.Act1;

namespace Prominence.Resources.DialogueData.Sequoia.Act_1
{
    public class QuestionsAct : IActModel
    {
        public IFilmModel Film { get; set; }
        public string Name { get { return "Questions"; } }
        public PlayerModel Player { get; set; }

        public Action OnEnter { get; set; }
        public Action OnExit { get; set; }

        public Dictionary<string, ISceneModel> Scenes { get; set; }

        public QuestionsAct()
        {
            
        }

        public void Initialise(IFilmModel film, PlayerModel player, Action onEnter = null, Action onExit = null)
        {
            Film = film;
            Player = player;
            var escapePodScene = new EscapePodScene();
            escapePodScene.Initialise(Film, this, player);

            Scenes = new Dictionary<string, ISceneModel>()
            {
                { escapePodScene.Name, escapePodScene }
            };

            OnEnter = onEnter;
            OnExit = onExit;
        }

    }
}
