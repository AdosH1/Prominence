using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
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
