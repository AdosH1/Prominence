using System;
using System.Collections.Generic;
using System.Text;
using Prominence.Model;
using Prominence.Model.Interfaces;
using Combat.Interfaces;
using Prominence.Model.SaveModel;

namespace Prominence.Model
{
    public class PlayerModel : ICombatEntity, ICreatureEntity
    {
        public string Name { get; set; } = "Ados";

        public string Film;
        public string Act;
        public string Scene;
        public string Frame;

        public double Energy;
        public double MaxEnergy;
        public DateTime LastLogin;

        public List<string> Inventory = new List<string>(); // use item hashes?
        public List<string> Visited = new List<string>();
        public List<string> Log = new List<string>();
        public Dictionary<string, int> Flags = new Dictionary<string, int>();

        public PlayerSaveModel SaveState;

        public void SavePlayerModel()
        {
            UpdateSaveState();
        }

        public void UpdateSaveState()
        {

        }
        public bool HasItem(string item)
        {
            return Inventory.Contains(item);
        }
        public void AddItem(string item)
        {
            Inventory.Add(item);
        }

        public bool HasVisited(string location)
        {
            return Visited.Contains(location);
        }

        public void AddVisited(string location)
        {
            Visited.Add(location);
        }

        public bool HasFlag(string flag)
        {
            return Flags.ContainsKey(flag);
        }

        public int GetFlag(string flag)
        {
            if (Flags.ContainsKey(flag))
            {
                return Flags[flag];
            }
            return 0;
        }

        public void IncrementFlag(string flag)
        {
            if (Flags.ContainsKey(flag))
            {
                Flags[flag] += 1;
            }
            else
            {
                Flags[flag] = 1;
            }
        }


        // ================== Unused models =============== //
        public double Experience { get; set; } = 0;
        public double Health { get; set; } = 1;
        public double MaxHealth { get; set; } = 1;
        public double Strength { get; set; } = 1;
        public double Magic { get; set; } = 1;
        public double Speed { get; set; } = 1;
        public List<IStatusEffect> Statuses { get; set; }
        public Dictionary<Element, double> Resistances { get; set; }

        public IItemEntity ActiveWeapon;
        public IItemEntity ActiveArmor;



    }
}
