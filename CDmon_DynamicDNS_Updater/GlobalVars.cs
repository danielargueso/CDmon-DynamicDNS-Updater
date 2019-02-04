using CDmonDynamicDNSUpdater.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CDmonDynamicDNSUpdater
{
    public static class GlobalVars
    {
        #region System Config
        public static MainConfigModel MAIN_CONFIG;
        public static readonly string MAIN_CONFIG_PATH = Path.Combine(Environment.CurrentDirectory, @"config");
        public static readonly string MAIN_CONFIG_FILE_PATH = Path.Combine(Environment.CurrentDirectory, @"config", @"MainConfig.xml");
        #endregion

        #region Internal Vars
        public static readonly string[] INTERNAL_IMPORTANT_ASSEMBLIES_TO_SHOW_IN_LOGS = {
            Assembly.GetExecutingAssembly().GetName().Name,
            @"log4net" };
        #endregion

    }
}
