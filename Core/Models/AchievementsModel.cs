using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class AchievementsModel
    {
        public List<Achievement> Achievements;
    }

    public class Achievement
    {
        public string DisplayName { get; }
        public string Name { get; }
        public int Count { get; set; } = 0;

        public Achievement(string name, string displayName)
        {
            Name = name;
            DisplayName = displayName;
        }
    }
}
