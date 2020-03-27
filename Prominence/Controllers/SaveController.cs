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
        const string saveFileName = "save";


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

                streamWriter.WriteLine("Strength:" + player.Strength.ToString());
                streamWriter.WriteLine("Magic:" + player.Magic.ToString());
                streamWriter.WriteLine("Speed:" + player.Speed.ToString());
                streamWriter.WriteLine("Resistance:" + player.Resistance.ToString());
                streamWriter.WriteLine("Energy:" + player.Energy.ToString());

                var items = string.Join(",", player.Inventory.SelectMany(x => x.Id));
                streamWriter.WriteLine("Inventory:" + items);

                streamWriter.WriteLine("ActiveWeapon:" + player.ActiveWeapon.Id);
                streamWriter.WriteLine("ActiveArmor:" + player.ActiveArmor.Id);

                streamWriter.WriteLine("Visited:" + string.Join(",", player.Visited));
                streamWriter.WriteLine("Log:" + string.Join(",", player.Log));

            }
        }

        public PlayerModel LoadState()
        {
            var savePath = Path.Combine(saveFolderPath, saveFileName);
            var player = new PlayerModel();

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

                // ====== Stats ====== //
                // Strength
                content = streamReader.ReadLine();
                var strengthStr = content.Split(':')[1];
                double.TryParse(strengthStr, out double strength);
                player.Strength = strength;

                // Magic
                content = streamReader.ReadLine();
                var magicStr = content.Split(':')[1];
                double.TryParse(magicStr, out double magic);
                player.Magic = magic;

                // Speed
                content = streamReader.ReadLine();
                var speedStr = content.Split(':')[1];
                double.TryParse(speedStr, out double speed);
                player.Speed = speed;

                // Resistance
                content = streamReader.ReadLine();
                var resistanceStr = content.Split(':')[1];
                double.TryParse(resistanceStr, out double resistance);
                player.Resistance = resistance;

                // ====== Items ====== // 
                // Inventory
                content = streamReader.ReadLine();
                var inventoryStr = content.Split(':')[1];
                var inventory = new List<IItemEntity>();

                var ids = inventoryStr.Split(',');
                foreach (var id in ids)
                {
                    // search for item ids here
                }
                player.Inventory = inventory;

                // Active Weapon
                // Search item here or null
                player.ActiveWeapon = null;

                // Active Armor
                // Search item here or null
                player.ActiveArmor = null;


            }

            return player;
        }



    }
}
