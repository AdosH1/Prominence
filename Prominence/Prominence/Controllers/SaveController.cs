using Newtonsoft.Json;
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
        public SaveController()
        {
           
        }

        public string JsonSerialize<T>(T itemToSerialize)
        {
            return JsonConvert.SerializeObject(itemToSerialize);
        }

        public T JsonDeserialize<T>(string stringToDeserialize)
        {
            T outputItem = JsonConvert.DeserializeObject<T>(stringToDeserialize);
            return outputItem;
        }

        public void SaveToAppProperties<T>(string propertiesKey, T objectToSave)
        {
            App.Current.Properties[propertiesKey] = JsonSerialize<T>(objectToSave);
            App.Current.SavePropertiesAsync();
        }

    }
}
