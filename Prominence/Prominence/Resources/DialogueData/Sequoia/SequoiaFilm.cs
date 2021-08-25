using System;
using System.Collections.Generic;
using System.Text;
using Prominence.Model;
using Prominence.Resources.DialogueData;

namespace Prominence.Resources.DialogueData.Sequoia
{
    public class SequoiaFilm : IFilmModel
    {
        public string Name { get { return "Sequoia"; } }
        public PlayerModel Player { get; set; }
        public Dictionary<string, IActModel> Acts { get; set; }

        public SequoiaFilm()
        {

        }

        public void Initialise(PlayerModel player)
        {
            Player = player;
            var awakeningAct = new AwakeningAct();
            awakeningAct.Initialise(this, player);

            Acts = new Dictionary<string, IActModel>()
            {
                { awakeningAct.Name, awakeningAct }
            };
        }
    }
}
