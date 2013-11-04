using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loogn.Common
{
    public static class ConfigHelper
    {
        public static string ConnString(string name)
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        public static string AppSetting(string name)
        {
            return System.Configuration.ConfigurationManager.AppSettings[name];
        }
    }
}
