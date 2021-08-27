using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Prominence.Model;
using System.Linq;
using Prominence.Model.Interfaces;

namespace Prominence.Controllers
{
    public class SaveController
    {

        string saveFolderPath;
        const string saveFileName = "prominence-savefile";


        public SaveController()
        {
            saveFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        }

        public void SaveState(PlayerModel player)
        {
            var savePath = Path.Combine(saveFolderPath, saveFileName);
            using (var streamWriter = new StreamWriter(savePath, false))
            {
                var dateTime = DateTime.Now;
                streamWriter.WriteLine("Name:" + player.Name);
                streamWriter.WriteLine("LastLogin:" + dateTime.Ticks.ToString());

                streamWriter.WriteLine("Film:" + player.Film);
                streamWriter.WriteLine("Act:" + player.Act);
                streamWriter.WriteLine("Scene:" + player.Scene);
                streamWriter.WriteLine("Frame:" + player.Frame);

                streamWriter.WriteLine("Energy:" + player.Energy.ToString());

                streamWriter.WriteLine("Inventory:" + string.Join(",", player.Inventory));

                var flagstr = string.Join(";", player.Flags.Select(x => x.Key + "=" + x.Value));
                streamWriter.WriteLine("Flags:" + string.Join(",", player.Flags));

                streamWriter.WriteLine("Visited:" + string.Join(",", player.Visited));
                streamWriter.WriteLine("Log:" + string.Join(",", player.Log));

            }
        }

        public PlayerModel LoadState()
        {
            var savePath = Path.Combine(saveFolderPath, saveFileName);
            var player = new PlayerModel("Ados");

            using (var streamReader = new StreamReader(savePath))
            {
                string content; 

                // ======= Player Stats ====== //
                // Name
                content = streamReader.ReadLine();
                var name = content.Split(':')[1];
                player.Name = name;

                // Last Login
                content = streamReader.ReadLine();
                var lastLogin = content.Split(':')[1];
                long.TryParse(lastLogin, out long lastLoginTicks);
                var datetime = new DateTime(lastLoginTicks);
                player.LastLogin = datetime;

                // Visited
                content = streamReader.ReadLine();
                var visited = content.Split(':')[1];
                player.Visited = new List<string>(visited.Split(','));

                // Log
                content = streamReader.ReadLine();
                var log = content.Split(':')[1];
                player.Log = new List<string>(log.Split(','));

                // ======= Frames and Scenes ====== //
                // Film
                content = streamReader.ReadLine();
                var film = content.Split(':')[1];
                player.Film = film;

                // Act
                content = streamReader.ReadLine();
                var act = content.Split(':')[1];
                player.Act = act;

                // Scene
                content = streamReader.ReadLine();
                var scene = content.Split(':')[1];
                player.Scene = scene;

                // Frame
                content = streamReader.ReadLine();
                var frame = content.Split(':')[1];
                player.Frame = frame;

                // ====== Items ====== // 
                // Inventory
                //content = streamReader.ReadLine();
                //var inventoryStr = content.Split(':')[1];
                //var inventory = new List<IItemEntity>();

                //var ids = inventoryStr.Split(',');
                //foreach (var id in ids)
                //{
                //    // search for item ids here
                //}
                //player.Inventory = inventory;
                content = streamReader.ReadLine();
                var inventoryStr = content.Split(':')[1];
                var inventory = inventoryStr.Split(',').ToList();
                player.Inventory = inventory;

                // Flags
                content = streamReader.ReadLine();
                var flagsStr = content.Split(':')[1];
                var flags = flagsStr.Split(';').ToList();

                Dictionary<string, int> flagDict = new Dictionary<string, int>();
                foreach (var flag in flags)
                {
                    var trimmed = flag.TrimEnd(';');
                    var split = trimmed.Split('=');

                    var key = split[0];
                    int value;
                    if (!int.TryParse(split[1], out value))
                    {
                        value = 1;
                    }

                    flagDict[key] = value;
                }

                player.Flags = flagDict;

            }

            return player;
        }



    }
}
