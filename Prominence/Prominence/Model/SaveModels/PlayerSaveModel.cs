using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Prominence.Model.SaveModels
{
    public class PlayerSaveModel
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public double Energy { get; set; }
        public double MaxEnergy { get; set; }
        public DateTime LastLogin { get; set; }
        public List<string> Inventory = new List<string>();
        public List<string> Visited = new List<string>();
        public List<LabelSaveModel> Log = new List<LabelSaveModel>();
        public Dictionary<string, int> Flags = new Dictionary<string, int>();

        public PlayerSaveModel(PlayerModel thePlayerModel)
        {
            Name = thePlayerModel.Name;
            Location = thePlayerModel.Location.Location;
            Energy = thePlayerModel.Energy;
            MaxEnergy = thePlayerModel.MaxEnergy;
            LastLogin = thePlayerModel.LastLogin;
            Inventory = thePlayerModel.Inventory;
            Visited = thePlayerModel.Visited;
            Flags = thePlayerModel.Flags;
        }
    }
}
