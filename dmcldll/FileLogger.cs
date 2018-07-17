using System.IO;

namespace dmcldll
{
	public abstract class LogBase
	{
		public abstract void Log(string message);
	}

	public class FileLogger : LogBase
	{
		public string filePath = @"c:\windows\temp\dmcllog.txt";
        public override void Log(string message)
		{
			using (StreamWriter streamWriter = new StreamWriter(filePath))
			{
				streamWriter.WriteLine(message);
				streamWriter.Close();
			}
		}
	}
	}
