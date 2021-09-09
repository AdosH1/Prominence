using System;
using System.Collections.Generic;
using System.Text;
using Prominence.Model;
using Prominence.Resources.DialogueData;
using Prominence.Controllers;
using Prominence.Model.Constants;

namespace Prominence.Resources.DialogueData.Sequoia
{
    public class SequoiaFilm : FilmModel
    {
        public string Name = "Sequoia";
        public SequoiaFilm() { }

        public void Initialise(PlayerModel player)
        {
            Player = player;
            var awakeningAct = new AwakeningAct(this.Name, player);
            awakeningAct.Initialise();

            Acts = new Dictionary<string, IActModel>()
            {
                { awakeningAct.Name, awakeningAct }
            };
        }
    }
}
