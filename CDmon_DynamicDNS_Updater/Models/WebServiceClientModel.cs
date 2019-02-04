using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDmonDynamicDNSUpdater.Enums;

namespace CDmonDynamicDNSUpdater.Models
{
    public class WebServiceClientModel
    {
        public EncryptionType Encryption { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string IP { get; set; }
        public string URL { get; set; }
        public List<WebServiceClientResponseModel> Response { get; set; }
        public WebServiceClientSeparator WebServiceResultSeparator { get; set; }
    }
}
