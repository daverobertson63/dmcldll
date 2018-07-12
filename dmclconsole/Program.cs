#define DEBUG

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using dmcldll;


namespace dmclconsole
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int mypid;
            String map;
            String buffer;
            int docbases;
            string cmd;
            String result;
            string Docbase;
            int resint;
            char[] apibuff = new char[1024];
            IntPtr dctmPtr;
            DMCL newSession;

            /*
            dfcInterop dfc = new dfcInterop();
            dfc.connect();
             */

            //mypid = getpid();
            //Console.WriteLine("External Lib Hook - my Process ID {0}", mypid);


            newSession = new DMCL(); 

            Console.WriteLine("Current Directory : " + System.Environment.CurrentDirectory);
            
            Console.WriteLine("Documentum/C# Integrtation with MONO!");

            Console.WriteLine("Init Documentum system");
            resint = DMCL.dmAPIInit();

            map = DMCL.dmAPIGet("getdocbasemap,c");

            Console.WriteLine("Map ID {0}", map);

            cmd = String.Format("values,c,{0},r_docbase_name", map);

            buffer = DMCL.dmAPIGet (cmd);

            docbases = int.Parse(buffer);

            Console.WriteLine("Available Docbases ID {0}", docbases);

            Console.ReadKey();
            //
            for (int i = 0; i < docbases; i++)
            {
                cmd = String.Format("get,c,{0},r_docbase_name[{1:g}]", map, i);
                Console.WriteLine("cmdexec: {0}", cmd);
                Docbase = DMCL.dmAPIGet(cmd);

                //for (int j=0;j<Docbase.Length;j++)
                //      Console.WriteLine ("{0:g}",(int)Docbase[j]);

                //cmd = "getmessage,c";

                Console.WriteLine("Docbase: {0}", Docbase);            }

            Console.WriteLine("Completed Map");
            String session = DMCL.dmAPIGet("connect,EPAProd,dmadmin,");
            Console.WriteLine("Session Connect: {0}", session);
            Console.ReadKey();

            // Simple query
            String sSQL = "select count(*) from dm_document";
			//String sSQL = "select * from dm_document where folder ( '/Licence Applications',DESCEND)";

			Console.WriteLine( sSQL);

	        String sColID1 =  DMCL.dmAPIGet("readquery,c," +  sSQL);

            if (sColID1 == "")
            {
				Console.WriteLine("Cannot get a query ");
				Console.WriteLine(DMCL.dmAPIGet("getmessage,c"));
                System.Environment.Exit(10);
            }
			Console.WriteLine("Query comntinues - Hit key: " + sColID1);

			Console.ReadKey();

			/*	
			' Loop round to get the details - and see if we are waiting.
			While dmapiexec("next,c," + sColID1) > 0
			 * */
			int loopReturn = DMCL.dmAPIExec("next,c," + sColID1);
			Console.WriteLine(loopReturn);

			String theCount = DMCL.dmAPIGet("get,c," + sColID1 + ",count");

			Console.WriteLine(theCount);

			loopReturn = DMCL.dmAPIExec("next,c," + sColID1);
			Console.WriteLine(loopReturn);
			loopReturn = DMCL.dmAPIExec("next,c," + sColID1);
			Console.WriteLine(loopReturn);

			Console.Write("Hit Key ");
			Console.ReadKey();

			while (loopReturn >0 )
	        {
	            Console.Write("While statement ");
	            // Write the index to the screen.
	            Console.WriteLine(loopReturn);
	            // Increment the variable.
	            //loopReturn++;
	

		    String id = DMCL.dmAPIGet("get,c," + sColID1 + ",r_object_id");

		    String docname = DMCL.dmAPIGet("get,c," + id + ",object_name");

		    String folderID = DMCL.dmAPIGet("get,c," + id + ",i_folder_id");

		    Console.WriteLine(DMCL.dmAPIGet("getmessage,c"));

		    Console.WriteLine( "Folder ID " + folderID);
		
		    String folderPath = DMCL.dmAPIGet("get,c," + folderID + ",r_folder_path");
		
		    String r_start_date = DMCL.dmAPIGet("get,c," + sColID1 + ",r_start_date");
		    
		    String fileName = DMCL.dmAPIGet("getfile,c," + id  + ",data/" + id + ".pdf");

		
            }
		
	        int iRetval = DMCL.dmAPIExec("close,c," + sColID1);
	  
                
        
        }
    }
}

