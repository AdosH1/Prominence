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

        public void Initialise(PlayerModel player, Action showInterstitalAd = null)
        {
            Player = player;
            var awakeningAct = new AwakeningAct(Name, player);
            var discoveryAct = new DiscoveryAct(Name, player);
            var escapeAct = new EscapeAct(Name, player);
            var miscAct = new MiscellaneousAct(Name, player);

            awakeningAct.Initialise();
            discoveryAct.Initialise(onEnter: showInterstitalAd);
            escapeAct.Initialise(onEnter: showInterstitalAd);
            miscAct.Initialise();


            Acts = new Dictionary<string, IActModel>()
            {
                { awakeningAct.Name(), awakeningAct },
                { discoveryAct.Name(), discoveryAct },
                { escapeAct.Name(), escapeAct},
                { miscAct.Name(), miscAct }
            };
        }
    }
}
