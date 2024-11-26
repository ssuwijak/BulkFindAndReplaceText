using MyClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAndReplaceWords
{
	public class DictionaryFile : IDisposable
	{
		private Dictionary<string, string> dict = new Dictionary<string, string>();
		public Dictionary<string, string> Data { get => dict; }
		public string KeyName { get; private set; } = "";
		public string ValueName { get; private set; } = "";
		public bool ContainsData => dict.Count > 0;
		public int Length => dict.Count;

		private bool disposedValue;

		public DictionaryFile()
		{

		}
		#region Dispose Implementation
		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: dispose managed state (managed objects)
				}

				// TODO: free unmanaged resources (unmanaged objects) and override finalizer
				// TODO: set large fields to null
				Clear();
				disposedValue = true;
			}
		}

		// // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
		// ~DictionaryFile()
		// {
		//     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		//     Dispose(disposing: false);
		// }

		public void Dispose()
		{
			// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
		#endregion

		public void Clear()
		{
			KeyName = "";
			ValueName = "";
			dict.Clear();
		}
		public FunctionReturn Read(string filePath)
		{
			var ret = new FunctionReturn();
			ret = FileMan.FileExit(filePath);
			if (!ret.Flag) return ret;

			Clear();

			using (StreamReader sr = new StreamReader(filePath))
			{
				int lineNo = 0;
				string line;
				int headerLine = 1;

				while ((line = sr.ReadLine()) != null)
				{
					lineNo++;

					if (!string.IsNullOrEmpty(line.Trim()))
					{
						string[] ss = line.Split(",");

						if (lineNo == headerLine)
						{
							if (KeyName == "" && ValueName == "")
								if (ss.Length < 2)
									headerLine++;
								else if (ss[0] == "" || ss[1] == "")
									headerLine++;
								else
								{
									KeyName = ss[0];
									ValueName = ss[1];
								}
						}
						else if (lineNo > headerLine)
						{
							if (ss.Length >= 2)
								if (!dict.Keys.Contains(ss[0]))
									dict.Add(ss[0], ss[1]);
						}
						else
						{

						}
					}
				}
				sr.Close();
			}
			return ret;
		}
		public FunctionReturn Write(string filePath, string content)
		{
			var ret = new FunctionReturn();
			ret = FileMan.FileExit(filePath);
			if (!ret.Flag)
			{
				ret = FileMan.PathExists(filePath);

			}
			if (ret.Flag)
				try
				{
					File.WriteAllText(filePath, content);
					ret.SetValues(true, $"'{filePath}' was written completely.");
				}
				catch (Exception ex)
				{
					ret.SetValues(false, ex.Message);
				}

			return ret;
		}
		public string GetValueByKey(string key)
		{
			if (dict.ContainsKey(key))
				return dict[key];
			else
				return "";
		}
	}
}
