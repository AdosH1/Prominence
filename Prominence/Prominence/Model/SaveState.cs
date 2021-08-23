using Prominence.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Prominence.Model
{
    public class SaveState
    {
        public string playerName;
        public string CurrentFilm;
        public string CurrentAct;
        public string CurrentScene;
        public string CurrentFrame;

        public SaveData SaveController = new SaveData();
        public ObservableCollection<Label> Log { get; set; }
        public SaveState(string player=null, string film=null, string act=null, string scene=null, string frame=null, ObservableCollection<Label> log=null)
        {
            playerName = player;
            CurrentFilm = film;
            CurrentAct = act;
            CurrentScene = scene;
            CurrentFrame = frame;
            Log = log;
        }

        public void UpdateSaveState(string player = null, string film = null, string act = null, string scene = null, string frame = null, ObservableCollection<Label> log = null)
        {
            playerName = player;
            CurrentFilm = film;
            CurrentAct = act;
            CurrentScene = scene;
            CurrentFrame = frame;
            Log = log;
        }
    }
}
