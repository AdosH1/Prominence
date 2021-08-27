using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Prominence.Model;
using System.Linq;
using Prominence.Model.Interfaces;
using Xamarin.Forms;

namespace Prominence.Controllers
{
    public class SaveController
    {
        public SaveController()
        {

        }

        public string Serialize<T>(T item)
        {
            return JsonConvert.SerializeObject(item);
        }

        public T Deserialize<T>(string jsonString)
        {
            T output = JsonConvert.DeserializeObject<T>(jsonString);
            return output;
        }

        public void SaveToAppProperties<T>(string key, T itemToSave)
        {
            Application.Current.Properties[key] = Serialize<T>(itemToSave);
            Application.Current.SavePropertiesAsync();
        }

        public T LoadFromAppProperties<T>(string key)
        {
            T output = default(T);
            if (Application.Current.Properties.ContainsKey(key))
            {
                output = Deserialize<T>(Application.Current.Properties[key] as string);
                return output;
            }

            return output;
        }



    }
}
