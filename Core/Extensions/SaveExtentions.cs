using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;
using Core.Models.SaveModels;

namespace Core.Extensions
{
    public static class SaveExtentions
    {

        public static PlayerModel GetPlayerModel(this PlayerSaveModel saveModel)
        {
            return new PlayerModel(saveModel);
        }

        public static PlayerSaveModel GetSaveModel(this PlayerModel playerModel)
        {
            var saveModel = new PlayerSaveModel()
            {
                Name = playerModel.Name,
                Location = playerModel.Location.Location,
                Energy = playerModel.Energy,
                MaxEnergy = playerModel.MaxEnergy,
                LastLogin = playerModel.LastLogin,
                Inventory = playerModel.Inventory,
                Visited = playerModel.Visited,
                Log = PlayerSaveModel.CreateLogSaveModel(playerModel.Log),
                Flags = playerModel.Flags
            };
            return saveModel;
        }

        public static UserSettingsModel GetSettingsModel(this UserSettingsSaveModel saveModel)
        {
            return new UserSettingsModel(saveModel);
        }

        public static UserSettingsSaveModel GetSaveModel(this UserSettingsModel settings)
        {
            var saveModel = new UserSettingsSaveModel()
            {
                DisplayAds = settings.DisplayAds,
                MuteSound = settings.MuteSound
            };
            return saveModel;
        }

        public static UserModel GetUserModel(this UserSaveModel saveModel)
        {
            return new UserModel(saveModel);
        }

        public static UserSaveModel GetSaveModel(this UserModel userModel)
        {
            return new UserSaveModel()
            {
                Player = userModel.PlayerModel.GetSaveModel(),
                Settings = userModel.SettingsModel.GetSaveModel()
            };
        }

        public static DialogueLabel GetDialogueLabel(this LabelSaveModel saveModel)
        {
            return new DialogueLabel(saveModel);
        }

        public static LabelSaveModel GetSaveModel(this DialogueLabel label)
        {
            return new LabelSaveModel()
            {
                Text = label.Text,
                Type = label.Type
            };
        }


    }
}
