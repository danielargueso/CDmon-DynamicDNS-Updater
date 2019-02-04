using System.Collections.Generic;
using System.Xml.Serialization;
using CDmonDynamicDNSUpdater.Enums;

namespace CDmonDynamicDNSUpdater.Models
{
    [XmlRoot(ElementName = "MainConfig")]
    public class MainConfigModel
    {
        public EncryptionType Encryption { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Url { get; set; }
        public WebServiceClientSeparator WebServiceResultSeparator { get; set; }
    }
    
}
