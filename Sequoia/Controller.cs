using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;
using Utilities;

namespace Sequoia
{
    public static class Controller
    {
        public static string GetDisplayName(string input)
        {
            return StringFunctions.RemoveFromString(input, $"{Constants.AssemblyName}.");
        }
        public static AchievementsModel GetAchievements()
        {
            var achievements = new List<Achievement>
            {
                new Achievement(Constants.FullyCharged, GetDisplayName(Constants.FullyCharged)),
                new Achievement(Constants.Merciful, GetDisplayName(Constants.Merciful)),
                new Achievement(Constants.Persistent, GetDisplayName(Constants.Persistent)),
                new Achievement(Constants.Firepower, GetDisplayName(Constants.Firepower)),
                new Achievement(Constants.PerfectEscape, GetDisplayName(Constants.PerfectEscape)),
                new Achievement(Constants.VespenergyAlwaysDelivers, GetDisplayName(Constants.VespenergyAlwaysDelivers))
            };
            return new AchievementsModel() { Achievements = achievements };
        }

        public static FilmModel GetFilm(PlayerModel player)
        {
            var film = new Sequoia.SequoiaFilm();
            film.Initialise(player);

            return film;
        }

    }
}
