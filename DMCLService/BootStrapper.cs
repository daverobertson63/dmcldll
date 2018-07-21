using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DMCLService
{
	public class Bootstrapper : Nancy.DefaultNancyBootstrapper
	{
		private SessionCache sc;// Specify what you want to happen when the Elapsed event is raised.

		private static void OnTimedEvent(object source, ElapsedEventArgs e)
		{
			Console.WriteLine("Timer check - sessions!");
		}




		protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
		{

			sc = new SessionCache();
			sc.InitDMCL();
			
			System.Timers.Timer aTimer = new System.Timers.Timer();
			aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
			aTimer.Interval = 5000;
			aTimer.Enabled = false;
			base.ApplicationStartup(container, pipelines);
			//var myXmlCacheInstance = ... // read your xml file and create an object to hold it
			container.Register<SessionCache>(sc);
		}



	}

}
