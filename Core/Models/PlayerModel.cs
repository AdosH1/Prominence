using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Core.Models.SaveModels;
using Xamarin.Forms;

namespace Core.Models
{

    public class PlayerModel
    {
        public string Name { get; set; } = "Ados";
        public LocationModel Location { get; set; }

        public double Energy;
        public double MaxEnergy = 3;
        public DateTime LastLogin;

        public List<string> Inventory = new List<string>(); // use item hashes?
        public List<string> Visited = new List<string>();
        public ObservableCollection<DialogueLabel> Log = new ObservableCollection<DialogueLabel>();
        public Dictionary<string, int> Flags = new Dictionary<string, int>();

        public PlayerModel(string name)
        {
            Name = name;
            Energy = 2;
            Location = new LocationModel();
        }

        public PlayerModel(PlayerSaveModel playerSaveModel)
        {
            Name = playerSaveModel.Name;
            Location = new LocationModel(playerSaveModel.Location);
            Energy = playerSaveModel.Energy;
            MaxEnergy = playerSaveModel.MaxEnergy;
            LastLogin = playerSaveModel.LastLogin;
            Inventory = playerSaveModel.Inventory;
            Visited = playerSaveModel.Visited;
            Log = CreateDialogueLabelLog(playerSaveModel.Log);
            Flags = playerSaveModel.Flags;
        }

        public ObservableCollection<DialogueLabel> CreateDialogueLabelLog(List<LabelSaveModel> theLog)
        {
            ObservableCollection<DialogueLabel> outputLog = new ObservableCollection<DialogueLabel>();

            foreach(LabelSaveModel label in theLog)
            {
                DialogueLabel newLabel = new DialogueLabel(label);
                outputLog.Add(newLabel);
            }
            return outputLog;
        }

        public bool HasItem(string item)
        {
            return Inventory.Contains(item);
        }
        public void AddItem(string item)
        {
            Inventory.Add(item);
        }
        public void RemoveItem(string item)
        {
            Inventory.Remove(item);
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

        public Func<Task> AddVisitedFunc(string location)
        {
            return new Func<Task>(async () => {
                if (!Visited.Contains(location))
                    Visited.Add(location);
            });
            
        }

        public bool HasFlag(string flag)
        {
            if (Flags.ContainsKey(flag))
            {
                return Flags[flag] > 0;
            }
            return false;
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

        public void DecrementFlag(string flag)
        {
            if (Flags.ContainsKey(flag))
            {
                Flags[flag] -= 1;
            }
        }

        public void Reset()
        {
            Inventory.Clear();
            Visited.Clear();
            Log.Clear();
            Flags.Clear();

            Energy = 3;
            Location = new LocationModel();
        }
    }
}
