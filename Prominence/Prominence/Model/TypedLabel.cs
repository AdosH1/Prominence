using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Prominence.Model
{
    public class TypedLabel : Label
    {
        public string LabelType;

        public TypedLabel(string type) : base()
        {
            LabelType = type;
        }

    }
}
