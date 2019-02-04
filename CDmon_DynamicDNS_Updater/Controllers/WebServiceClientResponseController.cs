using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDmonDynamicDNSUpdater.Models;

namespace CDmonDynamicDNSUpdater.Controllers
{
    public static class WebServiceClientResponseController
    {
        public static List<WebServiceClientResponseModel> ParseResultString(string str)
        {
            return ConvertArrayOfVarsToListOfResponses(
                SplitInVars(
                    RemoveDelimitators(str)
                    )
                );
        }
        private static string RemoveDelimitators(string str)
        {
            if (str.ElementAt(0) == (char)GlobalVars.MAIN_CONFIG.WebServiceResultSeparator)
                str = str.Remove(0, 1);

            if (str.ElementAt(str.Length - 1) == (char)GlobalVars.MAIN_CONFIG.WebServiceResultSeparator)
                str = str.Remove(str.Length - 1, 1);

            return str;
        }
        private static string[] SplitInVars(string str)
        {
            return str.Split(((char)GlobalVars.MAIN_CONFIG.WebServiceResultSeparator));

        }
        private static List<WebServiceClientResponseModel> ConvertArrayOfVarsToListOfResponses(string[] varsArray)
        {
            List<WebServiceClientResponseModel> resultList = new List<WebServiceClientResponseModel>();
            WebServiceClientResponseModel response;
            string[] subArrayItem;

            foreach (var arrayItem in varsArray)
            {
                subArrayItem = arrayItem.Split('=');
                response = new WebServiceClientResponseModel()
                {
                    Code = subArrayItem[0],
                    Value = subArrayItem[1]
                };
                resultList.Add(response);
            }

            return resultList;
        }
    }
}
