using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Core.Models;
using Core.Extensions;

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

        public static List<LabelSaveModel> CreateLogSaveModel(ObservableCollection<DialogueLabel> log)
        {
            List<LabelSaveModel> outputLog = new List<LabelSaveModel>();

            foreach(DialogueLabel label in log)
            {
                LabelSaveModel labelSaveModel = label.GetSaveModel();
                outputLog.Add(labelSaveModel);
            }

            var count = outputLog.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                if (outputLog[i].Type == LabelType.Dialogue) outputLog.RemoveAt(i);
                else break;
            }

            return outputLog;
        }
    }
}
