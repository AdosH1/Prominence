using System;
using System.Collections.Generic;
using System.Text;
using Combat.Interfaces;

namespace Combat.Attacks
{
    class Attack : IAttack
    {
        // IAttack Implementation
        public string Name { get; set; }
        public Element Element { get; set; }
        public ICombatEntity Source { get; set; }
        public ICombatEntity Target { get; set; }
        public double Damage { get; set; }
        public IStatusEffect Effect { get; set; }
        public string SpecialString { get; set; }
        public Dictionary<string, object> Tags { get; set; }
    }
}
