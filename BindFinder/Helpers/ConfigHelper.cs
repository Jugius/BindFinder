using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindFinder.Helpers
{
    internal static class ConfigHelper
    {
        public static string RoamingDirectory { get { return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\BindFinder"; } }
        public static bool IsRegistered { get { return true; } }
    }
}
