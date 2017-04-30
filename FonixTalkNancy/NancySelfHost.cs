using Nancy.Hosting.Self;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonixTalkNancy
{
    public class NancySelfHost
    {
        private NancyHost m_nancyHost;

        public void Start()
        {
            m_nancyHost = new NancyHost(ServiceConfig.GetUris());
            m_nancyHost.Start();

        }

        public void Stop()
        {
            m_nancyHost.Stop();
            Console.WriteLine("Stopped. Good bye!");
        }
    }
}
