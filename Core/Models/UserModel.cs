using System;
using System.Collections.Generic;
using System.Text;
using Core.Models.SaveModels;
using Core.Extensions;

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

        public UserModel(UserSaveModel saveModel)
        {
            SettingsModel = saveModel.Settings.GetSettingsModel();
            PlayerModel = saveModel.Player.GetPlayerModel();
            AchievementsModel = saveModel.Achievements.GetAchievementsModel();
        }

        // Please add achievements model manually if you use this constructor.
        public UserModel(UserSettingsModel settings, PlayerModel player)
        {
            SettingsModel = settings;
            PlayerModel = player;
        }
    }
}
