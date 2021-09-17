using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class UserModel
    {
        public AchievementsModel AchievementsModel;
        public PlayerModel PlayerModel;
        public UserSettingsModel SettingsModel;

        public UserModel(UserSettingsModel settings, PlayerModel player, AchievementsModel achievements)
        {
            SettingsModel = settings;
            PlayerModel = player;
            AchievementsModel = achievements;
        }
    }
}
