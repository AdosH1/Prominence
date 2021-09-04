﻿using Prominence.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prominence.ViewModel;
using Prominence.Contexts;
using Prominence.Model.Constants;

namespace Prominence.Controllers
{
    public class GameController
    {
        public static IFilmModel CurrentFilm;
        public static IActModel CurrentAct;
        public static ISceneModel CurrentScene;
        public static FrameModel CurrentFrame;
        public static PlayerModel Player;
        public static DialogueViewModel ViewModel;

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
                if (CurrentAct.OnExit != null)
                    CurrentAct.OnExit.Invoke();
            }

            CurrentAct = act;

            if (CurrentAct.OnEnter != null)
                CurrentAct.OnEnter.Invoke();
        }

        public static void ChangeBackground(string background)
        {
            var bg = AssemblyContext.GetImageByName(background);
            ViewModel.ChangeBackground(bg);
        }

    }
}
