using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DoffingDotCom.Web.Services
{
    public class ConfigProvider
    {
        public static string Environment
        {
            get { return get("connEnvironment"); }
        }

        public static string ImagePath
        {
            get { return get("imagePath"); }
        }

        private static string get(string key)
        {
            return ConfigurationManager.AppSettings.Get(key);
        }
    }
}