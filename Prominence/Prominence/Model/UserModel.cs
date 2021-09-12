using System;
using System.Collections.Generic;
using System.Text;

namespace Prominence.Model
{
    public class UserModel
    {
        public AchievementsModel Achievements;
        public PlayerModel Player;
        public UserSettingsModel Settings;

        public UserModel(UserSettingsModel settings, PlayerModel player, AchievementsModel achievements)
        {
            Settings = settings;
            Player = player;
            Achievements = achievements;
        }
    }
}
