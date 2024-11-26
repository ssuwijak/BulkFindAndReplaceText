namespace FindAndReplaceWords
{
	public class Word
	{
		public string Text { get; set; } = "";
		public string TextOnly { get; set; } = "";
		public string StartText { get; set; } = "";
		public string EndText { get; set; } = "";
		public string Merge()
		{
			return StartText + TextOnly + EndText;
		}
	}
}
