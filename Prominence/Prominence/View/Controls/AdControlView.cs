using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Prominence.View.Controls
{
    public class AdControlView : Xamarin.Forms.View
    {

        public static readonly BindableProperty AdUnitIdProperty = BindableProperty.Create(nameof(AdUnitId), typeof(string), typeof(AdControlView), string.Empty);

        public string AdUnitId
        {
            get { return (string)GetValue(AdUnitIdProperty); }
            set { SetValue(AdUnitIdProperty, value); }
        }

    }
}
