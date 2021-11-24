using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Prominence.Model;
using System.Linq;
using Prominence.Model.Interfaces;
using Core.Models;
using Core.Models.SaveModels;
using Utilities;
using Prominence.Contexts;
using Core.Extensions;

namespace Prominence.Controllers
{
    public static class SaveController
    {

        public static void SaveUser(UserModel user)
        {
            PlayerModel player = user.PlayerModel;
            UserSettingsModel settings = user.SettingsModel;
            AchievementsModel achievements = user.AchievementsModel;

            PlayerSaveModel playerSaveModel = player.GetSaveModel();
            UserSettingsSaveModel settingsSaveModel = settings.GetSaveModel();
            AchievementsSaveModel achievementsSaveModel = achievements.GetSaveModel();

            UserSaveModel userSaveModel = new UserSaveModel()
            {
                Player = playerSaveModel,
                Settings = settingsSaveModel,
                Achievements = achievementsSaveModel
            };

            var serializedUser = JsonSerializer.Serialize(userSaveModel);

            AppPropertiesContext.Save(serializedUser);
        }

        public static UserModel LoadUser()
        {
            var saveData = AppPropertiesContext.Load();
            if (saveData != null)
            {
                var deserializedUser = JsonSerializer.Deserialize<UserSaveModel>(saveData);
                return deserializedUser.GetUserModel();
            }
            return null;
        }

        public static void TestSave(PlayerModel player)
        {
            PlayerSaveModel playerSaveModel = player.GetSaveModel();
            var serializedUser = JsonSerializer.Serialize(playerSaveModel);
            AppPropertiesContext.Save(serializedUser);
        }

        public static PlayerModel TestLoad()
        {
            var saveData = AppPropertiesContext.Load();
            if (saveData != null)
            {
                var deserializedUser = JsonSerializer.Deserialize<PlayerSaveModel>(saveData);
                Console.WriteLine(deserializedUser);
                return new PlayerModel(deserializedUser);
            }
            return null;
        }

        public static void ClearSave()
        {
            AppPropertiesContext.Delete();
        }



    }
}
