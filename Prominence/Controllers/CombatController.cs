using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Combat;
using Combat.Interfaces;
using Prominence.Model;

namespace Prominence.Controllers
{
    class CombatController
    {

        #region Battle Conditions

        public bool ToDeath_BattleCondition(PlayerModel player, ICombatCreature creature)
        {
            if (creature.Health >= 0 && player.Health >= 0) 
                return true;
            return false;
        }

        #endregion

        #region Win Conditions

        public bool ToDeath_WinCondition(PlayerModel player, ICombatCreature creature)
        {
            if (creature.Health <= 0)
                return true;
            return false;
        }

        #endregion

        public bool Fight(PlayerModel player, ICombatCreature creature, Func<bool> battleCondition, Func<bool> winCondition)
        {


            while (battleCondition())
            {






            }

            return winCondition();


        }

    }
}
