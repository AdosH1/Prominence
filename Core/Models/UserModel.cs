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

        // Please add achievements model manually if you use this constructor.
        public UserModel(UserSettingsModel settings, PlayerModel player)
        {
            SettingsModel = settings;
            PlayerModel = player;
        }
    }
}
