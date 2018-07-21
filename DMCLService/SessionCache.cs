using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMCLService
{
	public class SessionCache
	{
		public DMCL dmcl=null;
		DateTime[] daenow = new DateTime[100];
		public List<string> list = new List<string>();
		public List<DateTime> dateTimes = new List<DateTime>();
		//string[] sessions = new string[100];
		
		public SessionCache()
		{
		}

		public  int addSession(string session)
		{

			return 0;
		}

		public int InitDMCL()
		{

			//DMCL newSession;
			dmcl = new DMCL();
			int ret = dmcl.dmAPIINitVBA();
			string myString = ret.ToString();
			return ret;

		}


	}
}
