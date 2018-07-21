using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMCLService
{
	

	public class DMCLModules : NancyModule
	{

		
		public DMCLModules(SessionCache sc)
		{

			Get["/v1/disconnect"] = parameters =>
			{
				
				//DMCL newSession;
				string session = this.Request.Query["session"];
				Console.WriteLine("Route Disconnect: " + session);

			int ret = sc.dmcl.dmAPIExecVBA("disconnect," + session );
				//string session = "s0";

				sc.list.Add(session);
				sc.dateTimes.Add(new DateTime());
				//string myString = ret.ToString();

				var status = new string[] { ret.ToString() };
				return Response.AsJson(status);
			};



			Get["/v1/connect"] = parameters =>
			{

				Console.WriteLine("Connect Docbase Route: ");

				string username = this.Request.Query["username"];
				string password = this.Request.Query["password"];
				string docbase = this.Request.Query["docbase"];

				Console.WriteLine(username);

				Console.WriteLine(password);

				Console.WriteLine(docbase);

				string session = sc.dmcl.dmAPIGetVBA("connect," + docbase + "," + username + "," + password);

				sc.list.Add(session);
				sc.dateTimes.Add(new DateTime());

				var status = new string[] { session };

				
				return Response.AsJson(status);
			};

			/* Get["consumptions/{granularity}"] = x =>
			{
				var feeds = new string[] { "foo", "bar};
				var granularity = x.granularity;
				var from = this.Request.Query["from"];
				var to = this.Request.Query["to"];
				return Response.AsJson(feeds);
			};
			*/
			Get["/v1/getapi"] = parameters =>
			{

				Console.WriteLine("Route getapi: ");

				string session = this.Request.Query["session"];
				string command = this.Request.Query["getapi"];
				string args = this.Request.Query["args"];

				if (session.Equals("") || command.Equals(""))
				{
					return new string[] { "" };
				}

				Console.WriteLine(session);

				Console.WriteLine(command);

				Console.WriteLine(args);

				string result = sc.dmcl.dmAPIGetVBA(command + "," + session + "," + args );

				if (result == null)
					result = "";


				var status = new string[] { result };
				return Response.AsJson(status);
			};

			Get["/v1/get"] = parameters =>
			{

				Console.WriteLine("Route raw get: ");

				string args = this.Request.Query["args"];
				
				if (args.Equals(""))
				{
					return new string[] { "" };
				}

				Console.WriteLine(args);
				
				string result = sc.dmcl.dmAPIGetVBA(args);

				if (result == null)
					result = "";

				Console.WriteLine(result);

				var status = new string[] { result };
				return Response.AsJson(status);
			};

			Get["/v1/set"] = parameters =>
			{

				Console.WriteLine("Route raw  get: ");

				string args = this.Request.Query["args"];
				string setdata = this.Request.Query["data"];

				if (args.Equals("") || setdata.Equals(""))
				{
					return new string[] { "0" };
				}

				Console.WriteLine(args);

				Console.WriteLine(setdata);
				
				
				int nret = sc.dmcl.dmAPISetVBA(args,setdata);

				var status = new string[] { nret.ToString() };
				return Response.AsJson(status);
			};

			Get["/v1/exec"] = parameters =>
			{

				Console.WriteLine("Route raw  exec: ");

				string args = this.Request.Query["args"];
				

				if (args.Equals("") )
				{
					return new string[] { "0" };
				}

				Console.WriteLine(args);
				

				int nret = sc.dmcl.dmAPIExecVBA(args);

				var status = new string[] { nret.ToString() };
				return Response.AsJson(status);
			};

		}
	}


}
