using System;
using System.Collections.Generic;
using System.Text;

namespace Prominence.Model.Interfaces
{
    public interface ICreatureEntity
    {

        string Name { get; set; }
        double Experience { get; set; }
        double MaxHealth { get; set; }
        double Health { get; set; }
        double Strength { get; set; }
        double Magic { get; set; }
        double Speed { get; set; }


    }
}
