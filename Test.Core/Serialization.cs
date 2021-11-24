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
        public void TestAchievementsSerialization()
        {
            // Assemble
            var achievementsModel = new AchievementsModel()
            {
                Achievements = new System.Collections.Generic.Dictionary<string, Achievement>() {
                    {
                        "Test", new Achievement("Test", "TestDisplay", new System.Func<PlayerModel, bool>((PlayerModel p) => { return true; })) { Completed = true }
                    }
                }
            };
            var saveModel = achievementsModel.GetSaveModel();

            // Act
            var serialised = JsonSerializer.Serialize(saveModel);
            var deserialised = JsonSerializer.Deserialize<AchievementsSaveModel>(serialised);
            var savedAchievements = deserialised.GetAchievementsModel();

            // Assert
            Assert.IsTrue(savedAchievements.Achievements.Count > 0);

        }

        [Test]
        public void TestUserSerialization()
        {
            // Assemble
            var playerName = "Test";
            var displayAds = true;
            var muteSound = false;

            var player = new PlayerModel(playerName);
            var settings = new UserSettingsModel()
            {
                DisplayAds = displayAds,
                MuteSound = muteSound
            };

            var achievementsModel = new AchievementsModel()
            {
                Achievements = new System.Collections.Generic.Dictionary<string, Achievement>() {
                    {
                        "Test", new Achievement("Test", "TestDisplay", new System.Func<PlayerModel, bool>((PlayerModel p) => { return true; })) { Completed = true }
                    }
                }
            };

            var user = new UserModel(settings, player, achievementsModel);
            var saveModel = user.GetSaveModel();

            // Act
            var serialised = JsonSerializer.Serialize(saveModel);
            var deserialised = JsonSerializer.Deserialize<UserSaveModel>(serialised);
            var savedUser = deserialised.GetUserModel();

            // Assert
            Assert.AreEqual(playerName, savedUser.PlayerModel.Name);
            Assert.AreEqual(displayAds, savedUser.SettingsModel.DisplayAds);
            Assert.AreEqual(muteSound, savedUser.SettingsModel.MuteSound);
            Assert.IsTrue(savedUser.AchievementsModel.Achievements.Count > 0);

        }
    }
}