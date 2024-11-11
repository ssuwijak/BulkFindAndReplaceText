using MyClasses;
using System.Text;

namespace FindAndReplaceWords
{
	public class TextFile : IDisposable
	{
		private List<Word> words = new List<Word>();
		public List<Word> Words { get => words; }
		public bool ContainsData => words.Count > 0;

		private bool disposedValue = false;

		public TextFile()
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

				words.Clear();

				disposedValue = true;
			}
		}

		// // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
		// ~TextFile()
		// {
		//     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		//     Dispose(disposing: false);
		// }

		public void Dispose()
		{
			// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		#endregion
		public void Clear()
		{
			words.Clear();
		}
		public FunctionReturn Read(string filePath)
		{
			var ret = new FunctionReturn();
			ret = FileMan.FileExit(filePath);
			if (!ret.Flag) return ret;

			Clear();

			using (StreamReader sr = new StreamReader(filePath))
			{
				var wp = new WordProcessor();
				int lineNo = 0;
				string line;

				while ((line = sr.ReadLine()) != null)
				{
					lineNo++;

					if (!string.IsNullOrEmpty(line))
					{
						string[] ss = line.Split(" ");
						foreach (string s in ss)
						{
							var word = new Word();

							wp.Text = s;
							wp.AssignTo(word);

							words.Add(word);
						}
						words.Add(new Word() { EndText = "\r\n" });
					}
				}
				sr.Close();
			}
			return ret;
		}
		public List<Tuple<string, int>> WordCount()
		{
			if (!ContainsData) return null;

			//var groupedWords = words
			//						.GroupBy(w => w.TextOnly)
			//						.Select(g => new WordCounter { Text = g.Key, Count = g.Count() })
			//						.OrderByDescending(g => g.Count)
			//						.ToList();

			var groupedWords2 = words
									.GroupBy(w => w.TextOnly)
									.Select(g => Tuple.Create<string, int>(g.Key, g.Count()))
									.OrderByDescending(t => t.Item2)
									.ToList();

			return groupedWords2;
		}
		public List<Tuple<string, int>> WordCountRandom(int randomNo = 1)
		{
			if (!ContainsData) return null;

			var wordCount = WordCount();

			int totalWords = wordCount.Count;
			int randomNo_Max;

			if (totalWords < 100)
				randomNo_Max = (int)(.7 * totalWords);
			else if (totalWords < 500)
				randomNo_Max = (int)(.5 * totalWords);
			else
				randomNo_Max = (int)(.2 * totalWords);

			if (randomNo < 1 || randomNo > randomNo_Max) randomNo = (int)(.5 * randomNo_Max);

			Random random = new Random();
			return wordCount.OrderBy(t => random.Next()).Take(randomNo).ToList();
		}
		public List<Tuple<string, int>> GetAllWordIndexesByText(string searchingText)
		{
			if (!ContainsData) return null;

			//var foundItems = words
			//					.Select((item, index) => new { Item = item, Index = index })
			//					.Where(x => x.Item.TextOnly == name)
			//					.Select(x => new WordCounter { Text = x.Item.TextOnly, Count = x.Index })
			//					.ToList();

			var foundItems = words
							  .Select((item, index) => new Tuple<string, int>(item.TextOnly, index))
							  .Where(t => t.Item1 == searchingText)
							  .OrderBy(t => t.Item2)
							  .ToList();

			return foundItems;
		}
		public string WordMerge()
		{
			return string.Join(" ", words.Select(w => w.Merge()));
		}
		public Dictionary<string, string> CreateWordMapping(int number)
		{
			if (!ContainsData) return null;

			var findingWords = WordCountRandom(number);
			var replacedWords = generateUniqueStrings(findingWords.Count);

			if (findingWords.Count != replacedWords.Count) return null;

			return findingWords
						.Zip(replacedWords, (wc, id) => new { Key = wc.Item1, Value = id })
						.ToDictionary(item => item.Key, item => item.Value);
		}
		private List<string> generateUniqueStrings(int number)
		{
			Random random = new Random();
			List<string> generatedStrings = new List<string>();

			while (generatedStrings.Count < number)
			{
				char randomLetter = (char)('A' + random.Next(26));
				int randomNumber = random.Next(10000);
				string newString = randomLetter.ToString() + randomNumber.ToString("D4");

				if (!generatedStrings.Contains(newString))
				{
					generatedStrings.Add(newString);
				}
			}

			return generatedStrings;
		}


	}


}
