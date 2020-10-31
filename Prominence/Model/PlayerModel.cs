using System;
using System.Collections.Generic;
using System.Text;
using Prominence.Model;
using Prominence.Model.Interfaces;
using Combat.Interfaces;

namespace Prominence.Model
{
    public class PlayerModel : ICombatEntity, ICreatureEntity
    {
        public string Name { get; set; }
        public double Experience { get; set; }
        public double Health { get; set; }
        public double MaxHealth { get; set; }

        public string Film;
        public string Act;
        public string Scene;
        public string Frame;

        public List<string> Visited;
        public List<string> Log;

        public List<IItemEntity> Inventory; // use item hashes?
        public double Energy;
        public double MaxEnergy;
        public DateTime LastLogin;

        public double Strength { get; set; }
        public double Magic { get; set; }
        public double Speed { get; set; }

        public List<IStatusEffect> Statuses { get; set; }
        public Dictionary<Element, double> Resistances { get; set; }

        public IItemEntity ActiveWeapon;
        public IItemEntity ActiveArmor;

    }
}
