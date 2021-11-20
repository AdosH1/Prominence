using System;
using System.Collections.Generic;
using System.Text;

namespace Prominence.Contexts
{
    public static class AppPropertiesContext
    {
        const string ACCESSKEY = "UserSettings";
        public static void Save(string jsonStringToSave)
        {
            App.Current.Properties[ACCESSKEY] = jsonStringToSave;
            App.Current.SavePropertiesAsync();
        }

        public static string Load()
        {
            if (App.Current.Properties.ContainsKey(ACCESSKEY))
                return App.Current.Properties[ACCESSKEY] as string;
            return null;
        }

        public static bool IsAvailable()
        {
            return App.Current.Properties.ContainsKey(ACCESSKEY);
        }

        public static void Delete()
        {
            App.Current.Properties.Clear();
            App.Current.SavePropertiesAsync();
        }
    }
}
