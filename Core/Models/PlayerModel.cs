﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class PlayerModel
    {
        public string Name { get; set; } = "Ados";
        public LocationModel Location { get; set; }

        public double Energy;
        public double MaxEnergy;
        public DateTime LastLogin;

        public List<string> Inventory = new List<string>(); // use item hashes?
        public List<string> Visited = new List<string>();
        public List<string> Log = new List<string>();
        public Dictionary<string, int> Flags = new Dictionary<string, int>();

        public PlayerModel(string name)
        {
            Name = name;
            Location = new LocationModel();
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
            if (!Visited.Contains(location))
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
    }
}