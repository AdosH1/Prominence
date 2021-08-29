using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Prominence.Model.SaveModels
{
    public class PlayerSaveModel
    {
        public string Name { get; set; }

        public string Film { get; set; }
        public string Act { get; set; }
        public string Scene { get; set; }
        public string Frame { get; set; }
        public double Energy { get; set; }
        public double MaxEnergy { get; set; }
        public DateTime LastLogin { get; set; }
        public List<string> Inventory = new List<string>();
        public List<string> Visited = new List<string>();
        public List<Label> Log = new List<Label>();
        public Dictionary<string, int> Flags = new Dictionary<string, int>();
    }
}
