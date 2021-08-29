using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities
{
    public static class JsonSerializer
    {
        public static string Serialize<T>(T itemToSerialize)
        {
            return JsonConvert.SerializeObject(itemToSerialize);
        }

        public static T Deserialize<T>(string stringToDeserialize)
        {
            T outputItem = JsonConvert.DeserializeObject<T>(stringToDeserialize);
            return outputItem;
        }
    }
}
