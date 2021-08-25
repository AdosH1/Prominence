using System;
using System.Collections.Generic;
using System.Text;
using Prominence.Model;
using Prominence.Resources.DialogueData;

namespace Prominence.Resources.DialogueData.Sequoia
{
    public class SequoiaFilm : FilmModel
    {
        public string Name { get { return "Sequoia"; } }
        public SequoiaFilm() { }

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
