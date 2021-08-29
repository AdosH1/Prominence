using System;
using System.Collections.Generic;
using System.Text;

namespace Prominence.Controllers
{
    public static class AppPropertiesContext
    {
        const string ACCESSKEY = "UserSettings";
        public static void Save(string jsonStringToSave)
        {
            App.Current.Properties[ACCESSKEY] = jsonStringToSave;
        }

        public static string Load()
        {
            return App.Current.Properties[ACCESSKEY] as string;
        }
    }
}
