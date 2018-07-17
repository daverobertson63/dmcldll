using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace DMCLService
{
	class Program
	{
		static void Main(string[] args)
		{

			//log4net.Config.XmlConfigurator.Configure();

			HostFactory.Run(x =>
			{
				//x.UseLinuxIfAvailable();
				x.Service<NancySelfHost>(s =>
				{
					s.ConstructUsing(name => new NancySelfHost());
					s.WhenStarted(tc => tc.Start());
					s.WhenStopped(tc => tc.Stop());
				});

				x.RunAsLocalSystem();
				x.SetDescription("Nancy-SelfHost DMCL Service");
				x.SetDisplayName("Nancy-SelfHost DMCL Service");
				x.SetServiceName("Nancy-SelfHost-DMCL");
			});
		}

	}
	
}
