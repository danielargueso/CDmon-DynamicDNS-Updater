using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CDmonDynamicDNSUpdater.Controllers;
using CDmonDynamicDNSUpdater.Models;

namespace CDmonDynamicDNSUpdater
{
    class Program
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            AddHeaderToLogFile();

            if (!LoadMainConfig())
                ExitApplication(1);

            WebServiceClientController wsController = new WebServiceClientController(CreateWebServiceClientData());

            wsController.RunQuery();


        }

        #region Main Functions
        private static WebServiceClientModel CreateWebServiceClientData()
        {
            WebServiceClientModel wsCliMod = new WebServiceClientModel()
            {
                Encryption = GlobalVars.MAIN_CONFIG.Encryption,
                URL = GlobalVars.MAIN_CONFIG.Url,
                UserName = GlobalVars.MAIN_CONFIG.User,
                Password = GlobalVars.MAIN_CONFIG.Password,
                WebServiceResultSeparator = GlobalVars.MAIN_CONFIG.WebServiceResultSeparator
            };

            return wsCliMod;
        }
        private static void ExitApplication(int exitCode = 0)
        {
            logger.Warn($"Saliendo de la aplicación (exitCode={exitCode})");
            System.Environment.Exit(exitCode);
        }
        private static bool LoadMainConfig()
        {
            try
            {
                var cfgController = new MainConfigController();
                GlobalVars.MAIN_CONFIG = cfgController.LoadConfig(GlobalVars.MAIN_CONFIG_FILE_PATH);

                logger.Info($"Cargada configuración desde el fichero: {GlobalVars.MAIN_CONFIG_FILE_PATH}");
                cfgController = null;
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                return false;
            }
            
        }
        #endregion
        #region Misc
        private static void AddHeaderToLogFile()
        {
            string NameVersion = Assembly.GetExecutingAssembly().GetName().Name;
            string Separador = @"==================================================================================";

            NameVersion = NameVersion.PadLeft(
                ((Separador.Length / 2) - (NameVersion.Length / 2) + NameVersion.Length),
                ' ');
            NameVersion = NameVersion.PadRight(Separador.Length, ' ');

            logger.Info("Iniciando aplicación.");
            logger.Info(Separador);
            logger.Info(NameVersion);
            logger.Info(Separador);
            logger.Info("Información ensamblados:");

            foreach (var AssembliesItem in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (GlobalVars.INTERNAL_IMPORTANT_ASSEMBLIES_TO_SHOW_IN_LOGS.Contains(AssembliesItem.GetName().Name))
                {
                    logger.Info($" {AssembliesItem.GetName().Name} v{AssembliesItem.GetName().Version.ToString()} [{AssembliesItem.GetFiles().FirstOrDefault().Name}]");
                }
                else
                {
                    logger.Debug($" {AssembliesItem.GetName().Name} v{AssembliesItem.GetName().Version.ToString()} [{AssembliesItem.GetFiles().FirstOrDefault().Name}]");
                }
            }

        }
        #endregion
    }
}
