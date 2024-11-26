using MyClasses;
using System.Text;

namespace FindAndReplaceWords
{
	public partial class Form1 : Form
	{
		private TextFile textFile = new TextFile();
		private DictionaryFile dictFile = new DictionaryFile();

		private int shortenLength = 50;
		private enum filterType
		{
			txt = 1,
			csv = 2,
			any = 3
		}
		private string filters = "Text files (*.txt)|*.txt|Csv files|*.csv|All files (*.*)|*.*";

		public string AppName => "Find and Replace Words";//Application.ProductName;

		private string _openedFile = "";
		public string OpenedFile
		{
			get => _openedFile;
			set
			{
				var ret = new FunctionReturn();
				ret = FileMan.FileExit(value);
				if (ret.Flag)
				{
					_openedFile = ret.Text;
					lblOpenedFile.Text = FileMan.PathShorten(_openedFile, shortenLength);
					toolTip1.SetToolTip(lblOpenedFile, ret.Text);
					btnShowText.Enabled = true;
					btnCreateDict.Enabled = true;
					btnReplace.Enabled = _openedFile != "" && _dictFile != "";
				}
			}
		}
		private string _dictFile = "";
		public string DictFile
		{
			get => _dictFile;
			set
			{
				var ret = new FunctionReturn();
				ret = FileMan.FileExit(value);
				if (ret.Flag)
				{
					_dictFile = ret.Text;
					lblDictFile.Text = FileMan.PathShorten(_dictFile, shortenLength);
					toolTip1.SetToolTip(lblDictFile, ret.Text);
					btnShowDict.Enabled = true;
					btnReplace.Enabled = _openedFile != "" && _dictFile != "";
				}
			}
		}

		public Form1()
		{
			InitializeComponent();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			this.Text = AppName + " v." + Application.ProductVersion;
			lblOpenedFile.Text = "";
			lblDictFile.Text = "";
			btnShowText.Enabled = false;
			btnShowDict.Enabled = false;
			btnCreateDict.Enabled = false;
			btnReplace.Enabled = false;
			btnSave.Enabled = false;
			initTooltips();
		}
		private void Form1_Closing(object sender, FormClosingEventArgs e)
		{
			dictFile.Clear();
			textFile.Clear();
		}
		private void Form1_Closed(object sender, FormClosedEventArgs e)
		{

		}
		private string openFileDialog(string path = "", filterType filter_Type = filterType.txt)
		{
			var ret = new FunctionReturn();
			ret.CheckNullOrEmptyWithTrim(path);

			if (ret.IsTextEmpty) path = Environment.CurrentDirectory;

			string selectedFilePath = "";

			OpenFileDialog ofd = new OpenFileDialog();
			ofd.InitialDirectory = Path.GetDirectoryName(path);

			ofd.Filter = filters;
			ofd.FilterIndex = (int)filter_Type;

			if (ofd.FilterIndex == 1)
				ofd.DefaultExt = "txt";
			else if (ofd.FilterIndex == 2)
				ofd.DefaultExt = "csv";
			else
				ofd.DefaultExt = "txt";

			// openFileDialog.Title = title;

			ofd.CheckFileExists = true;
			ofd.CheckPathExists = true;

			ofd.RestoreDirectory = true;

			if (ofd.ShowDialog() == DialogResult.OK)
				selectedFilePath = ofd.FileName;

			return selectedFilePath;
		}
		private string saveFileDialog(string path = "", filterType filter_Type = filterType.txt)
		{
			var ret = new FunctionReturn();
			ret.CheckNullOrEmptyWithTrim(path);

			if (ret.IsTextEmpty) path = Environment.CurrentDirectory;

			string selectedFilePath = "";

			SaveFileDialog sfd = new SaveFileDialog();
			sfd.InitialDirectory = Path.GetDirectoryName(path);

			sfd.Filter = filters;
			sfd.FilterIndex = (int)filter_Type;

			if (sfd.FilterIndex == 1)
				sfd.DefaultExt = "txt";
			else if (sfd.FilterIndex == 2)
				sfd.DefaultExt = "csv";
			else
				sfd.DefaultExt = "txt";

			//sfd.Title = "Save File";

			//sfd.CheckFileExists = true;
			sfd.CheckPathExists = true;

			sfd.RestoreDirectory = true;

			if (sfd.ShowDialog() == DialogResult.OK)
				selectedFilePath = sfd.FileName;

			return selectedFilePath;
		}
		private string getNow() => DateTime.Now.ToString("d-MMM-yy HH:mm:ss");
		private void showData(string filePath)
		{
			var ret = new FunctionReturn();
			ret = FileMan.FileExit(filePath);
			if (ret.Flag)
			{
				txtContent.Clear();

				do
				{
					try
					{
						txtContent.Text = File.ReadAllText(filePath);
						btnSave.Enabled = true;
						ret.Flag = false;
					}
					catch (Exception ex)
					{
						string msg = $"'{filePath}'\nunable to be read.\n\n{ex.Message}\n\n" + getNow();
						string title = AppName + " - Read File";
						var ans = MessageBox.Show(msg, title, MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
						
						if (ans == DialogResult.Cancel) ret.Flag = false;
					}
				} while (ret.Flag);
			}
			else
			{
				string msg = $"'{filePath}'\nfile not found.\n\n" + getNow();
				string title = AppName + " - Show the Text Content";
				MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		private void btnClear_Click(object sender, EventArgs e)
		{
			txtContent.Clear();
			btnSave.Enabled = false;
		}
		private void initTooltips()
		{
			toolTip1.SetToolTip(lblOpenedFile, "the text file that be opened.");
			toolTip1.SetToolTip(lblDictFile, "the mapping word file for replacement.");
			toolTip1.SetToolTip(btnBrowseText, "select a text to be replaced.");
			toolTip1.SetToolTip(btnBrowseDict, "select a mapping word file to be used for replacement.");
			toolTip1.SetToolTip(btnShowText, "show the content of the selected text file.");
			toolTip1.SetToolTip(btnShowDict, "show the content of the selected mapping word file.");
			toolTip1.SetToolTip(btnCreateDict, "create the mapping word file from the selected text file.");
			toolTip1.SetToolTip(btnReplace, "replace.");
			toolTip1.SetToolTip(btnSave, "save the content to file.");
			toolTip1.SetToolTip(btnClear, "clear the content.");
			toolTip1.SetToolTip(txtContent, "file content.");
		}
		private void btnShowText_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(OpenedFile))
			{
				string msg = "you must select a text file first\nby pressing the Browse button.\n\n" + getNow();
				string title = AppName + " - Show the Text File";
				MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
				showData(OpenedFile);
		}
		private void btnShowDict_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(DictFile))
			{
				string msg = "you must select the mapping file first\nby pressing the Browse button.\n\n" + getNow();
				string title = AppName + " - Show the Mapping File";
				MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
				showData(DictFile);
		}
		private void btnBrowseText_Click(object sender, EventArgs e)
		{
			string s = openFileDialog(OpenedFile, 0);
			if (!string.IsNullOrEmpty(s))
			{
				OpenedFile = s;
				textFile.Read(OpenedFile);

				showData(OpenedFile);
			}
		}
		private void btnBrowseDict_Click(object sender, EventArgs e)
		{
			string s = openFileDialog(DictFile, filterType.csv);
			if (!string.IsNullOrEmpty(s))
			{
				DictFile = s;
				dictFile.Read(DictFile);

				showData(DictFile);
			}
		}
		private void btnCreateDict_Click(object sender, EventArgs e)
		{
			if (!textFile.ContainsData)
			{
				string msg = "you must select a text file first\nby pressing the Browse button.\n\n" + getNow();
				string title = AppName + " - Create the Mapping File";
				MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			string s = saveFileDialog("", filterType.csv);
			if (!string.IsNullOrEmpty(s))
			{
				var dict = textFile.CreateWordMapping(100);

				int method = 1;
				string header = "Column_01,Column_02";

				if (method == 1)
				{
					using (StreamWriter sw = new StreamWriter(s))
					{
						sw.WriteLine(header);

						int i = 0;

						foreach (var kvp in dict)
						{
							i++;
							sw.WriteLine(kvp.Key + "," + kvp.Value);
						}

						sw.Close();
					}
				}
				else
				{
					StringBuilder sb = new StringBuilder();
					sb.Clear();

					sb.AppendLine(header);

					foreach (var kvp in dict)
						sb.AppendLine(kvp.Key + "," + kvp.Value);

					dictFile.Write(s, sb.ToString());

					sb.Clear();
				}

				showData(s);
			}
		}
		private void btnReplace_Click(object sender, EventArgs e)
		{
			if (_openedFile == "" || _dictFile == "")
			{
				string msg = "both text file and mapping file must be loaded first.\n\n" + getNow();
				string title = AppName + " - Replacing";
				MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			if (textFile.ContainsData && dictFile.ContainsData)
			{
				string s = "";
				var wc = textFile.WordCount();

				foreach (var w in wc)
				{
					s = dictFile.GetValueByKey(w.Item1);

					if (!string.IsNullOrEmpty(s.Trim()))
					{
						// replace word by index
						var words_indexes = textFile.GetAllWordIndexesByText(w.Item1);

						foreach (var wi in words_indexes)
						{
							textFile.Words[wi.Item2].TextOnly = s;
						}
					}
				}

				txtContent.Clear();
				txtContent.Text = textFile.WordMerge();
				btnSave.Enabled = true;
			}
			else
			{

			}

		}
		private void btnSave_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtContent.Text.Trim()))
			{
				string msg = "nothing to be saved.\n\n" + getNow();
				string title = AppName + " - Save the Result";
				MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			string s = saveFileDialog("", filterType.any);
			if (!string.IsNullOrEmpty(s))
			{
				File.WriteAllText(s, txtContent.Text.Trim());
			}
		}
	}
}
