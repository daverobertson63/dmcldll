using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace DMCLService
{

	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.AutoDual)]
	public class DMCL
	{

		private static string m_cstrDMCLTraceCategory = "DMCL";
		private static TraceSwitch m_sts;
		private static bool m_fDMCLTrace = true;


		public double MultiplyNTimes(double number1, double number2, double timesToMultiply)
		{

			Init();
			double result = number1;
			for (double i = 0; i < timesToMultiply; i++)
			{
				result = result * number2;
			}
			return result;
		}

		public enum DescAccess
		{
			/// <summary> 
			/// Not accessible through any dmAPIxxx command 
			/// </summary> 
			daUnknown
			= -1,
			/// <summary> 
			/// Accessible through a dmAPIGet command 
			/// </summary> 
			daGet
			= 0,
			/// <summary> 
			/// Accessible through a dmAPISet command 
			/// </summary> 
			daSet
			= 1,
			/// <summary> 
			/// Accessible through a dmAPIExec command 
			/// </summary> 
			daExec
			= 2
		}

		public static void Init()
		{
			
			// Create a new switch class
			m_sts = new TraceSwitch(m_cstrDMCLTraceCategory, "DMCL Tracing switch");
			m_sts.Level = TraceLevel.Verbose;
			
			Trace.WriteLine("Trace Level : " + m_sts.Level.ToString());
			Trace.WriteLine("Trace Verbose : " + m_sts.TraceVerbose.ToString());
			Trace.WriteLine("Trace Error : " + m_sts.TraceError.ToString());
			Trace.WriteLine("Trace Warning : " + m_sts.TraceWarning.ToString());
			Trace.WriteLine("Trace Info : " + m_sts.TraceInfo.ToString());
			
dmAPIInit();
		}

		static DMCL()
		{
			try
			{
				Init();
			}
			catch (System.Exception e)
			{
				Trace.WriteLine(e);
				
			}
		}

		/// <summary> 
		/// Flag to enable or disable DMCL trace 
		/// </summary> 
		public static bool TraceDMCL
		{
			get { return /*m_fDMCLTrace;*/m_sts.TraceVerbose; }
			set
			{
				m_sts.Level = (true == value) ? TraceLevel.Verbose : TraceLevel.Off; m_fDMCLTrace = value;
			}
		}

		[DllImport("Kernel32", EntryPoint = "LoadLibrary")]
		private static extern uint LoadLibrary(string strFileName);
		[DllImport("Kernel32", EntryPoint = "GetLastError")]
		private static extern uint GetLastError();
		[DllImport("Kernel32", EntryPoint = "SetLastError")]
		private static extern void SetLastError(uint uError);

		private static void OutputError(System.Exception e)
		{
			//FileLogger logger = new FileLogger();
			//logger.Log(e.ToString());
			Trace.WriteLine("", m_cstrDMCLTraceCategory);
			Trace.Indent();
			Trace.WriteLine("Stack Trace error dumped :",
			m_cstrDMCLTraceCategory);
			uint uError = GetLastError();
			Trace.WriteLine(e.ToString(),
			m_cstrDMCLTraceCategory);
			// Retrieve ow the OS error 
			uError = GetLastError();
			if (0 != uError)
			{
				Trace.WriteLine("OS Error : " +
				uError.ToString(), m_cstrDMCLTraceCategory);
				SetLastError(0);
			}
			Trace.WriteLine(null, m_cstrDMCLTraceCategory);
			Trace.Unindent();
		}

		public int dmAPIINitVBA()
		{
			return dmAPIInit();
		}

		[DllImport("dmcl40.dll", EntryPoint = "dmAPIInit", CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
		private static extern int orig_dmAPIInit();
		public static int dmAPIInit()
		{
			int nRet = 0;
			try
			{
				Trace.WriteIf(TraceDMCL, "dmAPIInit () returned ");
				nRet = orig_dmAPIInit();
				Trace.WriteLineIf(TraceDMCL, nRet.ToString());
			}
			catch (System.Exception e)
			{
				OutputError(e);
				nRet = 0;
			}
			return nRet;
		}


		public int dmAPIDeInitVBA()
		{
			return dmAPIDeInit();
		}

		[DllImport("dmcl40.dll", EntryPoint = "dmAPIDeInit", CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
		private static extern int orig_dmAPIDeInit();
		public static int dmAPIDeInit()
		{
			int nRet = 0;
			try
			{
				Trace.WriteIf(TraceDMCL, "dmAPIDeInit () returned ");
				nRet = orig_dmAPIDeInit();
				Trace.WriteLineIf(TraceDMCL, nRet.ToString());
			}
			catch (System.Exception e)
			{
				OutputError(e);
				nRet = 0;
			}
			return nRet;
		}

		public DescAccess dmAPIDescVBA(string strCmd, int nVal1, ref int rnVal2, ref int rSession)
		{
			return dmAPIDesc(strCmd, nVal1, ref rnVal2, ref rSession);
		}

		[DllImport("dmcl40.dll", EntryPoint = "dmAPIDesc", CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
		private static extern System.IntPtr orig_dmAPIDesc([In] string strCmd, [In] int nVal1, ref int rnVal2, ref int rSession);

		public static DescAccess dmAPIDesc(string strCmd, int nVal1, ref int rnVal2, ref int rSession)
		{
			DescAccess da = DescAccess.daUnknown;
			string strRet = null;
			try
			{
				Trace.WriteIf(TraceDMCL, "dmAPIDesc (" + strCmd + ", " + nVal1.ToString() + ",...) returned ");
				System.IntPtr ptr = orig_dmAPIDesc(strCmd, nVal1, ref rnVal2, ref rSession);
				if (System.IntPtr.Zero != ptr)
					strRet = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(ptr);
				Trace.WriteLineIf(TraceDMCL, strRet);
				if (0 == strRet.CompareTo("0"))
					da = DescAccess.daGet;
				else if (0 == strRet.CompareTo("1"))
					da = DescAccess.daSet;
				else if (0 == strRet.CompareTo("2"))
					da = DescAccess.daExec;
			}
			catch (System.Exception e)
			{
				OutputError(e);
				strRet = null;
			}
			return da;
		}

		public int dmAPIExecVBA(string strExec)
		{
			return dmAPIExec(strExec);
		}



		[DllImport("dmcl40.dll", EntryPoint = "dmAPIExec", CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
		private static extern int orig_dmAPIExec([In] string strExec);
		public static int dmAPIExec(string strExec)
		{
			int nRet = 0;
			try
			{
				Trace.WriteIf(TraceDMCL, "dmAPIDeExec (" + strExec + ") returned ");
				nRet = orig_dmAPIExec(strExec);
				Trace.WriteLineIf(TraceDMCL, nRet.ToString());
			}
			catch (System.Exception e)
			{
				OutputError(e);
				nRet = 0;
			}
			return nRet;
		}

		public string dmAPIGetVBA(string strCmd)
		{
			return dmAPIGet(strCmd);
		}


		[DllImport("dmcl40.dll", EntryPoint = "dmAPIGet",
		CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
		private static extern System.IntPtr orig_dmAPIGet([In, MarshalAs(UnmanagedType.LPStr)] string strCmd);
		public static string dmAPIGet(string strCmd)
		{
			string strRet = null;
			try
			{
				System.IntPtr ptr;
				Trace.WriteIf(TraceDMCL, "dmAPIGet (" + strCmd + ") returned '");
				ptr = orig_dmAPIGet(strCmd);
				Console.WriteLine(strCmd);
				if (System.IntPtr.Zero != ptr)
				{
					Trace.WriteLineIf(TraceDMCL, "DLL Has returned a value");
					strRet = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(ptr);
				}
				else
				{
					Trace.WriteLineIf(TraceDMCL, "Null Pointer");

				}
				Trace.WriteLineIf(TraceDMCL, strRet + "'");
			}
			catch (System.Exception e)
			{
				OutputError(e);
				Console.WriteLine(e);
				strRet = null;
			}
			return strRet;
		}

		public int dmAPISetVBA(string strCmd, string strValue)
		{
			return dmAPISet(strCmd, strValue);
		}



		[DllImport("dmcl40.dll", EntryPoint = "dmAPISet", CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
		private static extern int orig_dmAPISet([In] string strCmd, [In] string strValue);
		public static int dmAPISet(string strCmd, string strValue)
		{
			int nRet = 0;
			try
			{
				Trace.WriteIf(TraceDMCL, "dmAPISet (" + strCmd + "," + strValue + ") returned ");
				nRet = orig_dmAPISet(strCmd, strValue);
				Trace.WriteLineIf(TraceDMCL, nRet.ToString
				());
			}
			catch (System.Exception e)
			{
				OutputError(e);
				nRet = 0;
			}
			return nRet;
		}

		public static string dmAPIEvalVBA(ref string strEval, ref string strArg)
		{
			return dmAPIEval(ref strEval, ref strArg);
		}


		[DllImport("dmcl40.dll", EntryPoint = "dmAPIEval", CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
		private static extern System.IntPtr orig_dmAPIEval(ref string strEval, ref string strArg);
		public static string dmAPIEval(ref string strEval, ref string strArg)
		{
			string strRet = null;
			try
			{
				System.IntPtr ptr;
				Trace.WriteIf(TraceDMCL, "dmAPIEval (" + strEval + ", " + strArg + ") returned ");
				ptr = orig_dmAPIEval(ref strEval, ref strArg);
				if (System.IntPtr.Zero != ptr)
					strRet = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(ptr);
				Trace.WriteLineIf(TraceDMCL, strRet);
			}
			catch (System.Exception e)
			{
				OutputError(e);
				strRet = null;
			}
			return strRet;
		}


		const string m_cstrAPISession = "apisession";
		/// <summary> 
		/// Returns the alias for the API session 
		/// </summary> 
		public static string APISessionID
		{
			get
			{
				return m_cstrAPISession;
			}
		}
	}


}
