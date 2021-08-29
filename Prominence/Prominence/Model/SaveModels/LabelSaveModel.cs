using System;
using System.Collections.Generic;
using System.Text;

namespace Prominence.Model.SaveModels
{
    public class LabelSaveModel
    {
        public string Text { get; set; }
        public string Type { get; set; }

        public LabelSaveModel(TypedLabel theLabel)
        {
            Text = theLabel.Text;
            Type = theLabel.LabelType;
        }
    }
}
