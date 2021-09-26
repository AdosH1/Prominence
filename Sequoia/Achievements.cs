﻿using Core.Helpers;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Utilities;

namespace Sequoia
{
    public static class Achievements
    {
        public static Achievement FullyCharged { get; set; }
        public static Achievement Merciful { get; set; }
        public static Achievement Persistent { get; set; }
        public static Achievement Firepower { get; set; }
        public static Achievement PerfectEscape { get; set; }
        public static Achievement VespenergyAlwaysDelivers { get; set; }

        public static string GetDisplayName(string input)
        {
            return StringFunctions.RemoveFromString(input, $"{Constants.AssemblyName}.");
        }

        public static void Initialise()
        {
            // Create achievements here
            // Requires initialization as LocationModels are only created at runtime, otherwise, it'd be great to keep this compile time friendly
            // TODO: All  these achievements need to be updated (conditions) in order to work (we don't have enough story done to implement them atm)
            FullyCharged = new Achievement(Constants.FullyCharged, GetDisplayName(Constants.FullyCharged), AchievementHelper.PlayerVisitedCondition(IncubationScene.IncubationHallway.CurrentLocation));
            //Merciful = new Achievement(Constants.Merciful, GetDisplayName(Constants.Merciful), AchievementHelper.PlayerVisitedCondition(IncubationScene.IncubationHallway.CurrentLocation));
            //Persistent = new Achievement(Constants.Persistent, GetDisplayName(Constants.Persistent), AchievementHelper.PlayerVisitedCondition(IncubationScene.IncubationHallway.CurrentLocation));
            //Firepower = new Achievement(Constants.Firepower, GetDisplayName(Constants.Firepower), AchievementHelper.PlayerVisitedCondition(IncubationScene.IncubationHallway.CurrentLocation));
            //PerfectEscape = new Achievement(Constants.PerfectEscape, GetDisplayName(Constants.PerfectEscape), AchievementHelper.PlayerVisitedCondition(IncubationScene.IncubationHallway.CurrentLocation));
            //VespenergyAlwaysDelivers = new Achievement(Constants.VespenergyAlwaysDelivers, GetDisplayName(Constants.VespenergyAlwaysDelivers), AchievementHelper.PlayerVisitedCondition(IncubationScene.IncubationHallway.CurrentLocation));
        }
        public static AchievementsModel GetAchievements()
        {
            var achievements = new Dictionary<string, Achievement>
            {
                {FullyCharged.Name, FullyCharged },
                {Merciful.Name, Merciful },
                {Persistent.Name, Persistent },
                {Firepower.Name, Firepower },
                {PerfectEscape.Name, PerfectEscape },
                {VespenergyAlwaysDelivers.Name, VespenergyAlwaysDelivers }
            };
            return new AchievementsModel() { Achievements = achievements };
        }


    }
}