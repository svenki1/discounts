using Newtonsoft.Json;
using System;
using System.IO;

namespace Zadatak_Sven_Jakabfi_Components.Logger
{
	public class FileLogger
	{

		public void Debug(string message)
		{
#if DEBUG
			Log(message, LogLevel.Debug);
#endif
		}

		public void Info(object message)
		{
			Log(JsonConvert.SerializeObject(message), LogLevel.Info);
		}

		public void Warning(string message)
		{
			Log(message, LogLevel.Warning);
		}

		public void Error(Exception ex)
		{
			Log(JsonConvert.SerializeObject(ex), LogLevel.Error);
		}

		public void FatalError(string message)
		{
			Log(message, LogLevel.FatalError);
		}

		private void Log(string message, LogLevel logLevel)
		{
			string path = "..\\..\\..\\Log\\log.txt";

			if (!File.Exists(path))
			{
				// Create a file to write to.
				using (StreamWriter writer = File.CreateText(path))
				{
					writer.WriteLine("LogFile");
				}
			}

			LogModel logData = new LogModel
			{
				DateCreated = DateTime.Now,
				LogLevel = logLevel.ToString(),
				Message = message
			};

			string data = JsonConvert.SerializeObject(logData);
			using (StreamWriter writer = File.AppendText(path))
			{
				writer.WriteLine(data);
			}
		}
	}
	[Serializable]
	public class LogModel
	{
		public DateTime DateCreated { get; set; }
		public string LogLevel { get; set; }
		public string Message { get; set; }
	}
}
