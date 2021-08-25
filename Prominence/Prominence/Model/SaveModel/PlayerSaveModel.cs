using System;
using System.Collections.Generic;
using System.Text;

namespace Prominence.Model.SaveModel
{
    public class PlayerSaveModel
    {
        public string name;
        public string Film;
        public string Act;
        public string Scene;
        public string Frame;

        public double Energy;
        public double MaxEnergy;

        public List<LabelSaveModel> Log;
        public List<string> Inventory;
        public List<string> Visited;
        // Consider adding the flags dictionary
    }
}
