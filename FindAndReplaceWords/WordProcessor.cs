using MyClasses;
using System.Text.RegularExpressions;

namespace FindAndReplaceWords
{
	public class WordProcessor
	{
		protected string _text = "";
		public string Text
		{
			get => _text;
			set
			{
				var ret = new FunctionReturn();
				ret.CheckNullOrEmptyWithTrim(value);
				if (ret.IsTextEmpty) value = " ";

				_text = value;

				Length = _text.Length;

				if (Length == 1)
				{
					TextOnly = _text;
					ContainsSpecialCharacters = false;
				}
				else if (Length > 1)
				{
					if (StartsOrEndsWithSpecialCharacter(_text))
					{
						int i, j, k;
						string s = "";
						bool chk = true;
						k = _text.Length;
						j = k - 1;
						i = 0;

						while (chk && i < k)
						{
							s = _text.Substring(i, 1);
							chk = StartsWithSpecialCharacter(s);
							if (!chk) i--;
							i++;
						}

						if (i < j)
						{
							chk = true;

							while (chk && j > i)
							{
								s = _text.Substring(j, 1);
								chk = EndsWithSpecialCharacter(s);
								if (!chk) j++;
								j--;
							}
						}

						StartText = i <= 0 ? "" : _text.Substring(0, i);
						EndText = j >= k - 1 ? "" : _text.Substring(j + 1);
						TextOnly = _text.Substring(i, j - i + 1);
					}
					else
					{
						StartText = "";
						EndText = "";
						TextOnly = _text;
					}
				}
			}
		}
		public int Length { get; private set; }
		public bool ContainsSpecialCharacters { get; private set; }
		public string TextOnly { set; get; } = "";
		public string StartText { get; private set; } = "";
		public string EndText { get; private set; } = "";
		public string TextTransformed { get => StartText + TextOnly + EndText; }

		public WordProcessor()
		{
		}
		public WordProcessor(string text)
		{
			Text = text;
		}

		bool StartsWithSpecialCharacter(string str)
		{
			string pattern = @"^[^a-zA-Z\d\s]";
			Regex regex = new Regex(pattern);
			return regex.IsMatch(str);
		}
		bool EndsWithSpecialCharacter(string str)
		{
			string pattern = @"[^a-zA-Z\d\s]$";
			Regex regex = new Regex(pattern);
			return regex.IsMatch(str);
		}
		bool StartsOrEndsWithSpecialCharacter(string str)
		{
			string pattern = @"^[^a-zA-Z\d\s]|[^a-zA-Z\d\s]$";
			Regex regex = new Regex(pattern);
			return regex.IsMatch(str);
		}
		public void AssignTo(Word wordModel)
		{
			if (wordModel != null)
			{
				wordModel.Text = _text;
				wordModel.StartText = StartText;
				wordModel.EndText = EndText;
				wordModel.TextOnly = TextOnly;
			}
		}
	}
}
