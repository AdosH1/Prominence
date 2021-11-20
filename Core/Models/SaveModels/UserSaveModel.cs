using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.SaveModels
{
    public class UserSaveModel
    {
        public PlayerSaveModel Player { get; set; }
        public UserSettingsSaveModel Settings { get; set; }
        // TODO: Add achievements
    }
}
