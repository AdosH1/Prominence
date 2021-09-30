using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class AchievementsModel
    {
        public Dictionary<string, Achievement> Achievements;
    }

    public class AchievementsState
    {
        public Dictionary<string, AchievementState> State;
        public AchievementsState(Dictionary<string, AchievementState> state)
        {
            State = state;
        }
    }

    public class Achievement
    {
        public string DisplayName { get; }
        public string Name { get; }
        public int Count { get; set; } = 0;
        public bool Completed { get; set; } = false;
        public Func<PlayerModel, bool> Condition { get; }

        public Achievement(string name, string displayName, Func<PlayerModel, bool> condition)
        {
            Name = name;
            DisplayName = displayName;
            Condition = condition;
        }

        public bool Check(PlayerModel player)
        {
            return Condition(player);
        }

        public bool Evaluate(PlayerModel player)
        {
            if (!Completed) Completed = Condition(player);
            return Completed;
        }

        public AchievementState ToState(PlayerModel player)
        {
            return new AchievementState(Name, Check(player), this);
        }
    }

    public class AchievementState
    {
        public string Name;
        public bool Completed;
        public Achievement Achievement;

        public AchievementState(string name, bool completed, Achievement achievement)
        {
            Name = name;
            Completed = completed;
            Achievement = achievement;
        }

        public Achievement GetAchievement()
        {
            return Achievement;
        }
    }

}
