using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.SaveModels
{
    public class LabelSaveModel
    {
        public string Text { get; set; }
        public LabelType Type { get; set; }

        public LabelSaveModel(DialogueModel theLabel)
        {
            Text = theLabel.Text;
            Type = theLabel.Type;
        }
    }
}
