using System;
using System.Collections.Generic;
using System.Text;
using Prominence.Model;
using Prominence.Resources.DialogueData;

namespace Prominence.Resources.DialogueData.Sequoia
{
    public class AwakeningAct : IActModel
    {
        public IFilmModel Film { get; set; }
        public string Name { get { return "Awakening"; } }
        public PlayerModel Player { get; set; }

        public Action OnEnter { get; set; }
        public Action OnExit { get; set; }

        public Dictionary<string, ISceneModel> Scenes { get; set; }

        public AwakeningAct()
        {

        }

        public void Initialise(IFilmModel film, PlayerModel player, Action onEnter = null, Action onExit = null)
        {
            Film = film;
            Player = player;
            var incubationScene = new IncubationScene();
            incubationScene.Initialise(Film, this, player);

            Scenes = new Dictionary<string, ISceneModel>()
            {
                { incubationScene.Name, incubationScene }
            };

            OnEnter = onEnter;
            OnExit = onExit;
        }
    }
}
