using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Core.Models;
using Core.Models.SaveModels;

namespace Core.Models
{
    /// <summary>
    /// Just do label with text type?
    /// </summary>

    public class DialogueLabel : Label
    {
        public LabelType Type;
        public DialogueLabel(string text, LabelType type)
        {
            Text = text;
            Type = type;

            if (type == LabelType.Dialogue)
            {
                TextColor = Color.White;
                HorizontalTextAlignment = TextAlignment.Start;
            }
            else if (type == LabelType.Button)
            {
                HorizontalTextAlignment = TextAlignment.Center;
                FontSize = 12;
                TextColor = Color.Red;
            }
            else if (type == LabelType.Break)
            {
                HorizontalTextAlignment = TextAlignment.Center;
                FontSize = 12;
                TextColor = Color.White;
            }
            else if (type == LabelType.Ignore)
            {

            }
            else
            {
                throw new Exception("LabelType not implemented.");
            }
        }

        public DialogueLabel(LabelSaveModel theSaveModel) : this(theSaveModel.Text, theSaveModel.Type) { }
    }
}
