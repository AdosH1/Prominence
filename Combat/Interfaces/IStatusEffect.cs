using System;
using System.Collections.Generic;
using System.Text;

namespace Combat.Interfaces
{
    public interface IStatusEffect
    {

        ICombatEntity Source { get; set; }
        ICombatEntity Target { get; set; }

        string Name { get; }
        double Duration { get; set; }
        void Apply();
        void StartOfTurn();
        void PrePlayerCombat();
        void PreEnemyCombat();
        void EndOfTurn();
        void Cleanup();

    }

}
