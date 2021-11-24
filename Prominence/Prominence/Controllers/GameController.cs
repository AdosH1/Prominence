using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prominence.ViewModel;
using Prominence.Contexts;
using Core.Controllers;

namespace Prominence.Controllers
{
    public class GameController
    {
        public static IFilmModel CurrentFilm;
        public static IActModel CurrentAct;
        public static ISceneModel CurrentScene;
        public static FrameModel CurrentFrame;
        public static UserModel User;
        public static PlayerModel Player { get => User.PlayerModel; }
        public static DialogueViewModel DialogueViewModel;
        public static MenuViewModel MenuViewModel;

        public static LocationModel TeleporterLocation;

        public static FrameModel Traverse(LocationModel location)
        {
            // Attempt to find frame in current scene
            var DestinationFrame = TraverseScene(CurrentScene, location);
            if (DestinationFrame != null)
                return DestinationFrame;

            // Attempt to find scene in current act, or frame in any child
            DestinationFrame = TraverseAct(CurrentAct, location);
            if (DestinationFrame != null)
                return DestinationFrame;

            // Attempt to find act in film, or scene / frame in any child
            DestinationFrame = TraverseFilm(CurrentFilm, location);
            if (DestinationFrame != null)
                return DestinationFrame;

            throw new Exception("Destination Frame not found.");
        }

        public static FrameModel TraverseScene(ISceneModel scene, LocationModel location)
        {
            if (scene == null)
                return null;

            // If no location, load first frame in scene
            if (location.Frame == null)
            {
                var firstFrame = scene.Frames.Keys.First();
                EnterScene(scene);
                EnterFrame(scene.Frames[firstFrame]);
                return scene.Frames[firstFrame];
            }

            foreach (var frame in scene.Frames.Keys)
            {
                if (frame == location.Frame)
                {
                    EnterScene(scene);
                    EnterFrame(scene.Frames[frame]);
                    return scene.Frames[frame];
                }
            }
            return null;
        }

        public static FrameModel TraverseAct(IActModel act, LocationModel location)
        {
            if (act == null)
                return null;

            // If no scene, load first scene in act
            if (location.Scene == null)
            {
                var firstScene = act.Scenes.Keys.First();
                EnterAct(act);
                return TraverseScene(act.Scenes[firstScene], location);
            }

            foreach (var scene in act.Scenes.Keys)
            {
                if (scene == location.Scene)
                {
                    EnterAct(act);
                    return TraverseScene(act.Scenes[scene], location);
                }
            }
            return null;
        }

        public static FrameModel TraverseFilm(IFilmModel film, LocationModel location)
        {
            if (film == null)
                return null;

            // If no location, load first act in film
            if (location.Act == null)
            {
                var firstAct = film.Acts.Keys.First();
                return TraverseAct(film.Acts[firstAct], location);
            }

            foreach (var act in film.Acts.Keys)
            {
                if (act == location.Act)
                {
                    CurrentFilm = film;
                    return TraverseAct(film.Acts[act], location);
                }
            }
            return null;
        }

        public static void EnterFrame(FrameModel frame)
        {
            CurrentFrame = frame;
        }

        public static void EnterScene(ISceneModel scene)
        {
            if (CurrentScene != null)
            {
                if (CurrentScene.OnExit != null)
                    CurrentScene.OnExit.Invoke();
            }

            CurrentScene = scene;

            if (CurrentScene.OnEnter != null)
                CurrentScene.OnEnter.Invoke();
        }

        public static void EnterAct(IActModel act)
        {
            if (act.Player == null) act.Player = Player;

            if (CurrentAct != null)
            {
                if (CurrentAct.Name() != act.Name() &&
                    CurrentAct.OnExit != null)
                        CurrentAct.OnExit.Invoke();

                if (CurrentAct.Name() != act.Name() &&
                    act.OnEnter != null)
                        act.OnEnter.Invoke();
            }
            else
            {
                CurrentAct?.OnEnter?.Invoke();
            }

            CurrentAct = act;

        }

        public static void ChangeDialogueBackground(string background)
        {
            var bg = AssemblyContext.GetImageByName(background);
            DialogueViewModel.ChangeBackground(bg);
        }

        public static void ChangeMenuBackground(string background)
        {
            var bg = AssemblyContext.GetImageByName(background);
            MenuViewModel.ChangeBackground(bg);
        }

        public static void ShowAchievement(string text)
        {
            DialogueViewModel.ShowAchievement(text);
        }

        // This function doesn't currently wait when showing achievements
        // Will need to be adjusted in the future to show multiple achievements at the same time
        // Currently, achievements will overlap. Out of scope for the current iteration though.
        public static void ShowAchievements(List<Achievement> achievements)
        {
            foreach (var achievement in achievements)
            {
                ShowAchievement(achievement.DisplayName);
            }
        }

        public static void Visited(FrameModel frame)
        {
            // Here we want to create a generate state comparison, and handle events accordingly
            Player.Location = frame.Location;
            var stateDifferences = PlayerStateController.DoTaskAndEvaluate(Player.AddVisitedFunc(frame.CurrentLocation), User);
            ShowAchievements(stateDifferences.Achievements);
        }

        /// Load achievements from saveData, save data will only store whether its completed or not.
        public static AchievementsModel LoadAchievements(AchievementsModel user, AchievementsModel storyAchievements)
        {
            foreach (var achievement in user.Achievements)
            {
                if (storyAchievements.Achievements.ContainsKey(achievement.Key))
                {
                    storyAchievements.Achievements[achievement.Key].Completed = true;
                }
            }
            return storyAchievements;
        }

    }
}
