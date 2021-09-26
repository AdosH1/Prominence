using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Core.Controllers
{
    public static class AchievementsController
    {

        public static AchievementsState GetState(AchievementsModel model, PlayerModel player)
        {
            var state = new Dictionary<string, AchievementState>();
            foreach (var achievement in model.Achievements)
            {
                state.Add(achievement.Key, achievement.Value.ToState(player));
            }

            return new AchievementsState(state);
        }

        public static List<Achievement> CompareState(AchievementsState initial, AchievementsState current)
        {
            var newAchievements = new List<Achievement>();
            foreach (var init in initial.State)
            {
                if (init.Value.Completed != current.State[init.Key].Completed)
                {
                    newAchievements.Add(init.Value.GetAchievement());
                }
            }

            return newAchievements;
        }

    }
}
