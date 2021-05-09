using System;
using System.Collections.Generic;
using System.Text;

namespace Combat.Interfaces
{
    public interface ICombatCreature : ICombatEntity
    {

        int AttackIndex { get; set; }
        List<Dictionary<IAttack, (double, string)>> Attacks { get; set; }


    }
}
