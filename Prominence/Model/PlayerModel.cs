using System;
using System.Collections.Generic;
using System.Text;
using Prominence.Model;
using Prominence.Model.Interfaces;

namespace Prominence.Model
{
    public class PlayerModel
    {
        public string Name;

        public string Film;
        public string Act;
        public string Scene;
        public string Frame;

        public List<string> Visited;
        public List<string> Log;

        public List<IItemEntity> Inventory; // use item hashes?
        public double Energy;
        public DateTime LastLogin;

        public double Strength;
        public double Magic;
        public double Speed;

        public double Resistance;

        public IItemEntity ActiveWeapon;
        public IItemEntity ActiveArmor;

    }
}
