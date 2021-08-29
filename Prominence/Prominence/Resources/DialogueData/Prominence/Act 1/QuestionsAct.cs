using System;
using System.Collections.Generic;
using System.Text;
using Prominence.Model;
using Prominence.Resources.DialogueData;

namespace Prominence.Resources.DialogueData.Prominence
{
    public class QuestionsAct : ActModel
    {
        public string Name { get { return "Questions"; } }
        public QuestionsAct() { }

        public void Initialise(string film, PlayerModel player, Action onEnter = null, Action onExit = null)
        {
            Film = film;
            Player = player;
            var escapePodScene = new EscapePodScene();
            escapePodScene.Initialise(Film, this.Name, player);

            Scenes = new Dictionary<string, ISceneModel>()
            {
                { escapePodScene.Name, escapePodScene }
            };

            OnEnter = onEnter;
            OnExit = onExit;
        }

    }
}
