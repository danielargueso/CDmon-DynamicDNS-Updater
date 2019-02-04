using CDmonDynamicDNSUpdater.Enums;
using CDmonDynamicDNSUpdater.Models;
using System;
using System.IO;
using System.Xml.Serialization;

namespace CDmonDynamicDNSUpdater.Controllers
{
    class MainConfigController
    {
        #region Public
        public MainConfigModel LoadConfig(string MainConfigFilePath)
        {
            if (string.IsNullOrWhiteSpace(MainConfigFilePath)) throw new ArgumentNullException($"No se ha especificado la ruta de la configuración principal.");
            if (!File.Exists(MainConfigFilePath))
            {
                SaveConfig(
                    CreateDefaultConfig(),
                    MainConfigFilePath
                    );

                throw new IOException($"No se encuentra el fichero: {MainConfigFilePath} Se intenta crear fichero de configuración por defecto.");
            }

            return Deserialize(MainConfigFilePath);
        }
        public void SaveConfig(MainConfigModel config, string MainConfigFilePath)
        {
            Serialize(config, MainConfigFilePath);
        }
        public MainConfigModel CreateDefaultConfig()
        {
            return new MainConfigModel
            {
                User = @"user",
                Password = @"Pa$$w0rd",
                Encryption = EncryptionType.MD5,
                Url = @"https://dinamico.cdmon.org/onlineService.php",
                WebServiceResultSeparator = WebServiceClientSeparator.Ampersand
            };
        }
        #endregion
        #region Private
        private void Serialize(MainConfigModel ConfigObject, string FilePath)
        {
            if (!Directory.Exists(Path.GetDirectoryName(FilePath)))
                Directory.CreateDirectory(Path.GetDirectoryName(FilePath));

            XmlSerializer xsSubmit = new XmlSerializer(typeof(MainConfigModel));

            using (var sww = new StreamWriter(FilePath))
            {
                xsSubmit.Serialize(sww, ConfigObject);
            }
        }
        private MainConfigModel Deserialize(string ConfigFilePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(MainConfigModel));
            MainConfigModel result = new MainConfigModel();
            using (StreamReader reader = new StreamReader(ConfigFilePath))
            {
                result = (MainConfigModel)serializer.Deserialize(reader);
            }
            return result;
        }
        #endregion
    }
}
