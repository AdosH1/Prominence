using System;
using System.Collections.Generic;
using System.Text;
using Core.Models.SaveModels;

namespace Core.Models
{
    public class UserSettingsModel
    {

        public bool DisplayAds;
        public bool MuteSound;

        public UserSettingsModel()
        {
            DisplayAds = true;
            MuteSound = false;
        }

        public UserSettingsModel(UserSettingsSaveModel settings)
        {
            DisplayAds = settings.DisplayAds;
            MuteSound = settings.MuteSound;
        }
    }
}
