using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;
using System.Linq;

namespace Prominence.Contexts
{
    public static class AssemblyContext
    {
        public static System.Reflection.Assembly Assembly { get; set; }
        public static System.Resources.ResourceManager ResourceManager { get; set; }

        public static void Initialise(string projectName)
        {
            //Assembly = System.Reflection.Assembly.GetExecutingAssembly();
            Assembly = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.Contains(projectName)).First();
            string resourceName = Assembly.GetName().Name + ".Properties.Resources";
            
            ResourceManager = new System.Resources.ResourceManager(resourceName, Assembly);
        }

        public static ImageSource GetImageByName(string imageName)
        {
            var obj = ResourceManager.GetObject(imageName);
            if (obj != null)
            {
                var bytes = (byte[])obj;
                var im = ImageSource.FromStream(() => new MemoryStream(bytes));
                return im;
            }
            return null;
        }


    }
}
