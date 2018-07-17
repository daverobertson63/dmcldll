using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMCLService
{
	
		public class DMCLModules : NancyModule
	{

		public DMCLModules()
		{

			

			Get["/v1/init"] = parameters =>
			{

				DMCL newSession;
				newSession = new DMCL();
				int ret = newSession.dmAPIINitVBA();
				string myString = ret.ToString();

				var feeds = new string[] { "foo", "bar" ,myString};
				return Response.AsJson(feeds);
			};

			Get["consumptions/{granularity}"] = x =>
			{
				var feeds = new string[] { "foo", "bar", myString };
				var granularity = x.granularity;
				var from = this.Request.Query["from"];
				var to = this.Request.Query["to"];
				return Response.AsJson(feeds);
			};

			Get["/v1/get"] = parameters =>
			{
							Get["/v1/init"] = parameters =>
			{

				DMCL newSession;
				newSession = new DMCL();
				int ret = newSession.dmAPIINitVBA();
				string myString = ret.ToString();

				var feeds = new string[] { "foo", "bar" ,myString};
				return Response.AsJson(feeds);
			};

				DMCL newSession;
				newSession = new DMCL();
				int ret = newSession.dmAPIINitVBA();
				string myString = ret.ToString();

				var feeds = new string[] { "foo", "bar", myString };
				return Response.AsJson(feeds);
			};


		}
	}


}
