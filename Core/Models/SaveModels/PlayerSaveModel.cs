using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Core.Models;

namespace Core.Models.SaveModels
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
            Log = CreateLabelSaveModelLog(thePlayerModel.Log);
            Flags = thePlayerModel.Flags;
        }

        public List<LabelSaveModel> CreateLabelSaveModelLog(ObservableCollection<DialogueLabel> theLog)
        {
            List<LabelSaveModel> outputLog = new List<LabelSaveModel>();

            foreach(DialogueLabel label in theLog)
            {
                LabelSaveModel newLabelSaveModel = new LabelSaveModel(label);
                outputLog.Add(newLabelSaveModel);
            }
            return outputLog;
        }
    }
}
