using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Controllers
{
    public class PlayerState
    {
        public string Name { get; set; }
        public double Energy { get; set; }
        public List<string> Inventory { get; set; }
        public Dictionary<string, int> Flags { get; set; }
    }

    public class PlayerDifferences
    {
        public PlayerDifferences(PlayerState state, List<Achievement> achievements)
        {
            Name = state.Name;
            Energy = state.Energy;
            Inventory = state.Inventory;
            Flags = state.Flags;
            Achievements = achievements;
        }
        public string Name { get; set; }
        public double Energy { get; set; }
        public List<string> Inventory { get; set; }
        public Dictionary<string, int> Flags { get; set; }
        public List<Achievement> Achievements { get; set; }
    }

    public static class PlayerStateController
    {

        public static PlayerState GetState(PlayerModel player)
        {
            return new PlayerState
            {
                Name = player.Name,
                Energy = player.Energy,
                Inventory = player.Inventory,
                Flags = player.Flags
            };
        }

        public static PlayerState GetStateDifferences(PlayerState initial, PlayerState current)
        {
            var diffState = new PlayerState
            {
                Name = initial.Name != current.Name ? current.Name : null,
                Inventory = current.Inventory.Except(initial.Inventory).ToList(),
                Flags = initial.Flags.Except(current.Flags).Concat(current.Flags.Except(initial.Flags)).ToDictionary((keyValue) => keyValue.Key, (keyValue) => keyValue.Value)
            };

            if (initial.Energy != current.Energy) diffState.Energy = current.Energy;

            return diffState;
        }

        public static PlayerDifferences DoTaskAndEvaluate(Func<Task> task, UserModel user)
        {
            var initialAchievements = AchievementsController.GetState(user.AchievementsModel, user.PlayerModel);
            var initialPlayer = GetState(user.PlayerModel);

            task();

            var currentAchievements = AchievementsController.GetState(user.AchievementsModel, user.PlayerModel);
            var currentPlayer = GetState(user.PlayerModel);

            var achievementDifferences = AchievementsController.GetStateDifferences(initialAchievements, currentAchievements);
            var playerDifferences = GetStateDifferences(initialPlayer, currentPlayer);

            return new PlayerDifferences(playerDifferences, achievementDifferences);
        }

    }
}
