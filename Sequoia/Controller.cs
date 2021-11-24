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
            Achievements.Initialise();
            return Achievements.GetAchievements();
        }

        public static FilmModel GetFilm(PlayerModel player, Action showInterstitialAd = null)
        {
            var film = new Sequoia.SequoiaFilm();
            film.Initialise(player, showInterstitialAd);

            return film;
        }

        public static LocationModel GetTeleporterLocation()
        {
            return MiscellaneousScene.Teleport.Location;
        }

        // Sets player variables when jumping scenes.
        // Don't need to set visited histories as its mostly irrelevant (I think there's only one (insubstantial) passage late in the game)
        public static void SetTJunctionScene(this PlayerModel player)
        {
            player.Reset();
            player.AddItem(Constants.DroneAccessCard);
            player.AddItem(Constants.SpareBattery);
            player.AddItem(Constants.SteinmannAccessCard);
        }

        public static void SetInfirmaryScene(this PlayerModel player)
        {
            player.Reset();
            player.AddItem(Constants.DroneAccessCard);
            player.AddItem(Constants.SpareBattery);
            player.AddItem(Constants.SteinmannAccessCard);
        }

        public static void SetNavigationScene(this PlayerModel player)
        {
            player.Reset();
            player.AddItem(Constants.DroneAccessCard);
            player.AddItem(Constants.SpareBattery);
            player.AddItem(Constants.SpareMagazine);
            player.AddItem(Constants.SteinmannAccessCard);
            player.IncrementFlag(Constants.FeralSaved);
        }



    }
}
