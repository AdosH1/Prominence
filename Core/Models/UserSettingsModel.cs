﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Models.SaveModels;

namespace Core.Models
{
    public class UserSettingsModel
    {

        public bool DisplayAds;
        public bool MuteSound;

        public UserSettingsModel(UserSettingsSaveModel theModel)
        {
            DisplayAds = theModel.DisplayAds;
            MuteSound = theModel.MuteSound;
        }
    }
}
