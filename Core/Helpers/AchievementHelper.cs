using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Helpers
{
    public class AchievementHelper
    {

        public static Func<PlayerModel, bool> PlayerInventoryCondition(string item)
        {
            return new Func<PlayerModel, bool>((PlayerModel player) => { return player.HasItem(item); });
        }

        public static Func<PlayerModel, bool> PlayerVisitedCondition(string location)
        {
            return new Func<PlayerModel, bool>((PlayerModel player) => { return player.HasVisited(location); });
        }

    }
}
