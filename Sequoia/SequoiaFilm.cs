using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Sequoia
{
    public class SequoiaFilm : FilmModel
    {
        public static readonly string Name = "Sequoia";
        public SequoiaFilm() { }

        public void Initialise(PlayerModel player)
        {
            Player = player;
            var awakeningAct = new AwakeningAct(Name, player);
            var discoveryAct = new DiscoveryAct(Name, player);
            var escapeAct = new EscapeAct(Name, player);
            var miscAct = new MiscellaneousAct(Name, player);

            awakeningAct.Initialise();
            discoveryAct.Initialise();
            escapeAct.Initialise();
            miscAct.Initialise();


            Acts = new Dictionary<string, IActModel>()
            {
                { AwakeningAct.Name, awakeningAct },
                { DiscoveryAct.Name, discoveryAct },
                { EscapeAct.Name, escapeAct},
                { MiscellaneousAct.Name, miscAct }
            };
        }
    }
}
