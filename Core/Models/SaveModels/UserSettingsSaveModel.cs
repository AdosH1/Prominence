using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.SaveModels
{
    public class UserSettingsSaveModel
    {
        public bool DisplayAds;
        public bool MuteSound;

        public UserSettingsSaveModel(UserSettingsModel theModel)
        {
            DisplayAds = theModel.DisplayAds;
            MuteSound = theModel.MuteSound;
        }
    }
}
