using System;
using Topshelf;

namespace FonixTalkNancy
{
    public class Program
    {
        public static void Main()
        {
            HostFactory.Run(x =>
            {
                x.Service<NancySelfHost>(s =>
                {
                    s.ConstructUsing(name => new NancySelfHost());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalSystem();
                x.SetDescription("Nancy-SelfHost service for FonixTalk");
                x.SetDisplayName(ServiceConfig.GetServiceDisplayName());
                x.SetServiceName(ServiceConfig.GetServiceName());
            });
        }
    }
}