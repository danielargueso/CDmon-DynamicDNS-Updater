using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDmonDynamicDNSUpdater.Models
{
    public class WebServiceClientResponseModel
    {
        public string Code { get; set; }
        public string Value { get; set; }
        public string Message
        {
            get
            {
                if (Code == @"resultat")
                {
                    switch (Value)
                    {
                        case "guardatok":
                            return "Los datos se han almacenado correctamente";
                        
                        case "customok":
                            return "La IP especificada manualmente se ha almacenado correctamente";
                        case "badip":
                            return "La IP proporcionada no es correcta";
                        case "errorlogin":
                            return "La autenticación no ha sido correcta";
                        case "novaversio":
                            return "El servidor API ha sufrido una actualización, debe ponerse en contacto con el servicio técnico de CDmon para obtener la nueva URL.";
                        default:
                            return $"No hay descripción conocida para el código: {Value}";
                    }
                }
                else
                {
                    switch (Code)
                    {
                        case "newip":
                            return "IP Actual detectada por el servidor";
                        case "temps":
                            return $"Los datos se han actualizado correctamente y se aplicarán en: {ConvertMsInHumanRedableTime(Value)}";
                        default:
                            return $"No hay descripción conocida para el código: {Code}";
                    }
                }
            }
        }
        private string ConvertMsInHumanRedableTime(string str)
        {
            TimeSpan t = TimeSpan.FromMilliseconds(Convert.ToDouble(str));
            return string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                                    t.Hours,
                                    t.Minutes,
                                    t.Seconds,
                                    t.Milliseconds);
        }
    }
}
