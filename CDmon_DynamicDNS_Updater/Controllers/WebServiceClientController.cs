using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CDmonDynamicDNSUpdater.Models;
using log4net;

namespace CDmonDynamicDNSUpdater.Controllers
{
    public class WebServiceClientController
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(WebServiceClientController));
        private WebClient client = new WebClient();
        private WebServiceClientModel wsClient = new WebServiceClientModel();

        public WebServiceClientController(WebServiceClientModel clientData)
        {
            wsClient = clientData;
        }

        public void RunQuery()
        {
            bool QueryOK = false;
            string resultVars = "";
            logger.Info("Iniciando llamada a WebService de CDmon");
            var stringResult = client.DownloadString(BuildQueryString(wsClient));

            var nose = WebServiceClientResponseController.ParseResultString(stringResult);
            
            foreach (var item in nose)
            {
                resultVars += $"{item.Code}={item.Value} || ";
                if (item.Value == "guardatok")
                    QueryOK = true;
            }
            if(QueryOK)
            {
                logger.Info("La IP se ha actualizado correctamente.");
            }
            else
            {
                logger.Error("No se ha podido actualizar correctamente los datos");
            }

            resultVars = resultVars.Remove(resultVars.Length - 4); //Elimina el último separador: ' || '
            logger.Debug($"Resultado llamada webservice: {resultVars}");

        }
        private string BuildQueryString(WebServiceClientModel clientData)
        {
            string QueryString = "";

            QueryString = clientData.URL + @"?";
            QueryString += $"enctype={clientData.Encryption}{(char)clientData.WebServiceResultSeparator}";
            QueryString += $"n={clientData.UserName}{(char)clientData.WebServiceResultSeparator}";
            QueryString += $"p={clientData.Password}";

            logger.Debug($"WebServiceClient.URL: {QueryString}");
            return QueryString;

        }
    }
}
