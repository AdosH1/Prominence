using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Prominence.Controllers
{
    public class SaveData
    {
        public SaveData()
        {

        }

        public string Serialize<T>(T item)
        {
            string output = JsonConvert.SerializeObject(item);
            return output;
        }

        public T Deserialize<T>(string jsonString)
        {
            T output = JsonConvert.DeserializeObject<T>(jsonString);
            return output;
        }

        public void SaveToDisc<T>(string key, T item)
        {
            Application.Current.Properties[key] = Serialize<T>(item);
            Application.Current.SavePropertiesAsync();
        }

        public T LoadFromDisc<T>(string key)
        {
            T output = default(T);
            if(Application.Current.Properties.ContainsKey(key))
            {
                output = Deserialize<T>(Application.Current.Properties[key] as string);
                return output;
            }

            return output;
        }
    }
}
