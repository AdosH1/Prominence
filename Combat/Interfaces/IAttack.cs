using System;
using System.Collections.Generic;
using System.Text;

namespace Combat.Interfaces
{
    public enum Element
    {
        Physical,
        Fire,
        Water,
        Earth
    }

    public interface IAttack
    {
        string Name { get; set; }
        Element Element { get; set; }
        ICombatEntity Source { get; set; }
        ICombatEntity Target { get; set; }
        double Damage { get; set; }
        IStatusEffect Effect { get; set; }
        string SpecialString { get; set; }
        Dictionary<string, object> Tags { get; set; }

    }
}
