using NUnit.Framework;
using Core.Models;
using Core.Models.SaveModels;
using Utilities;
using Core.Extensions;

namespace Test.Core
{
    public class Serialization
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestPlayerSerialization()
        {
            // Assemble
            var playerName = "Test";
            var player = new PlayerModel(playerName);
            var saveModel = player.GetSaveModel();

            // Act
            var serialised = JsonSerializer.Serialize(saveModel);
            var deserialised = JsonSerializer.Deserialize<PlayerSaveModel>(serialised);
            var savedPlayer = deserialised.GetPlayerModel();

            // Assert
            Assert.AreEqual(playerName, savedPlayer.Name);
        }

        [Test]
        public void TestSettingsSerialization()
        {
            // Assemble
            var displayAds = true;
            var muteSound = false;
            var settings = new UserSettingsModel()
            {
                DisplayAds = displayAds,
                MuteSound = muteSound
            };
            var saveModel = settings.GetSaveModel();

            // Act
            var serialised = JsonSerializer.Serialize(saveModel);
            var deserialised = JsonSerializer.Deserialize<UserSettingsSaveModel>(serialised);
            var savedSettings = deserialised.GetSettingsModel();

            // Assert
            Assert.AreEqual(displayAds, savedSettings.DisplayAds);
            Assert.AreEqual(muteSound, savedSettings.MuteSound);
        }

        [Test]
        public void TestUserSerialization()
        {
            // Assemble
            var playerName = "Test";
            var displayAds = true;
            var muteSound = false;

            var player = new PlayerModel(playerName);
            var settings = new UserSettingsModel() { 
                DisplayAds = displayAds, 
                MuteSound = muteSound  
            };

            var user = new UserModel(settings, player);
            var saveModel = user.GetSaveModel();

            // Act
            var serialised = JsonSerializer.Serialize(saveModel);
            var deserialised = JsonSerializer.Deserialize<UserSaveModel>(serialised);
            var savedUser = deserialised.GetUserModel();

            // Assert
            Assert.AreEqual(playerName, savedUser.PlayerModel.Name);
            Assert.AreEqual(displayAds, savedUser.SettingsModel.DisplayAds);
            Assert.AreEqual(muteSound, savedUser.SettingsModel.MuteSound);


        }
    }
}