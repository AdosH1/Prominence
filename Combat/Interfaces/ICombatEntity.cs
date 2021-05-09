using System;
using System.Collections.Generic;
using System.Text;

namespace Combat.Interfaces
{
    public interface ICombatEntity
    {

        string Name { get; set; }
        double Experience { get; set; }
        double Health { get; set; }
        double MaxHealth { get; set; }
        double Strength { get; set; }
        double Magic { get; set; }
        double Speed { get; set; }
        List<IStatusEffect> Statuses { get; set; }
        Dictionary<Element, double> Resistances { get; set; }
    }
}
