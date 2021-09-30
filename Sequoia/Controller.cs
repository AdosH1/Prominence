using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;
using Utilities;

namespace Sequoia
{
    public static class Controller
    {
        public static AchievementsModel GetAchievements()
        {
            return Achievements.GetAchievements();
        }

        public static FilmModel GetFilm(PlayerModel player)
        {
            var film = new Sequoia.SequoiaFilm();
            film.Initialise(player);

            Achievements.Initialise();

            return film;
        }

    }
}
