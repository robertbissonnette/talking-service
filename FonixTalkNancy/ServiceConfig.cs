using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonixTalkNancy
{
    static public class ServiceConfig
    {
        static public Uri[] GetUris()
        {
            var endpointsRaw = ConfigurationManager.AppSettings["endpointUris"];
            return endpointsRaw.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(e => new Uri(e)).ToArray();
        }

        static public string GetServiceName()
        {
            return ConfigurationManager.AppSettings["serviceName"];
        }

        static public string GetServiceDisplayName()
        {
            return ConfigurationManager.AppSettings["serviceDisplayName"];
        }
    }
}
