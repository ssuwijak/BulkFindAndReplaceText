namespace FindAndReplaceWords
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			txtContent = new TextBox();
			groupBox1 = new GroupBox();
			btnShowDict = new Button();
			btnBrowseDict = new Button();
			lblDictFile = new Label();
			label1 = new Label();
			btnCreateDict = new Button();
			groupBox2 = new GroupBox();
			btnShowText = new Button();
			lblOpenedFile = new Label();
			label3 = new Label();
			btnBrowseText = new Button();
			groupBox3 = new GroupBox();
			btnClear = new Button();
			btnSave = new Button();
			btnReplace = new Button();
			toolTip1 = new ToolTip(components);
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox3.SuspendLayout();
			SuspendLayout();
			// 
			// txtContent
			// 
			txtContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			txtContent.BorderStyle = BorderStyle.FixedSingle;
			txtContent.Location = new Point(7, 172);
			txtContent.Multiline = true;
			txtContent.Name = "txtContent";
			txtContent.ScrollBars = ScrollBars.Both;
			txtContent.Size = new Size(507, 217);
			txtContent.TabIndex = 0;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(btnShowDict);
			groupBox1.Controls.Add(btnBrowseDict);
			groupBox1.Controls.Add(lblDictFile);
			groupBox1.Controls.Add(label1);
			groupBox1.Location = new Point(7, 59);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(507, 46);
			groupBox1.TabIndex = 1;
			groupBox1.TabStop = false;
			groupBox1.Text = "2) Mapping file for word replacement";
			// 
			// btnShowDict
			// 
			btnShowDict.Location = new Point(426, 15);
			btnShowDict.Name = "btnShowDict";
			btnShowDict.Size = new Size(75, 23);
			btnShowDict.TabIndex = 3;
			btnShowDict.Text = "Show";
			btnShowDict.UseVisualStyleBackColor = true;
			btnShowDict.Click += btnShowDict_Click;
			// 
			// btnBrowseDict
			// 
			btnBrowseDict.Location = new Point(345, 15);
			btnBrowseDict.Name = "btnBrowseDict";
			btnBrowseDict.Size = new Size(75, 23);
			btnBrowseDict.TabIndex = 2;
			btnBrowseDict.Text = "Browse";
			btnBrowseDict.UseVisualStyleBackColor = true;
			btnBrowseDict.Click += btnBrowseDict_Click;
			// 
			// lblDictFile
			// 
			lblDictFile.AutoSize = true;
			lblDictFile.Location = new Point(64, 22);
			lblDictFile.Name = "lblDictFile";
			lblDictFile.Size = new Size(38, 15);
			lblDictFile.TabIndex = 1;
			lblDictFile.Text = "label2";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(6, 22);
			label1.Name = "label1";
			label1.Size = new Size(58, 15);
			label1.TabIndex = 0;
			label1.Text = "File Path :";
			// 
			// btnCreateDict
			// 
			btnCreateDict.Location = new Point(6, 21);
			btnCreateDict.Name = "btnCreateDict";
			btnCreateDict.Size = new Size(216, 23);
			btnCreateDict.TabIndex = 3;
			btnCreateDict.Text = "Create Mapping File from the Text File";
			btnCreateDict.UseVisualStyleBackColor = true;
			btnCreateDict.Click += btnCreateDict_Click;
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(btnShowText);
			groupBox2.Controls.Add(lblOpenedFile);
			groupBox2.Controls.Add(label3);
			groupBox2.Controls.Add(btnBrowseText);
			groupBox2.Location = new Point(7, 8);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(507, 45);
			groupBox2.TabIndex = 2;
			groupBox2.TabStop = false;
			groupBox2.Text = "1) Text file to be replaced";
			// 
			// btnShowText
			// 
			btnShowText.Location = new Point(426, 14);
			btnShowText.Name = "btnShowText";
			btnShowText.Size = new Size(75, 23);
			btnShowText.TabIndex = 3;
			btnShowText.Text = "Show";
			btnShowText.UseVisualStyleBackColor = true;
			btnShowText.Click += btnShowText_Click;
			// 
			// lblOpenedFile
			// 
			lblOpenedFile.AutoSize = true;
			lblOpenedFile.Location = new Point(64, 21);
			lblOpenedFile.Name = "lblOpenedFile";
			lblOpenedFile.Size = new Size(38, 15);
			lblOpenedFile.TabIndex = 2;
			lblOpenedFile.Text = "label4";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(6, 21);
			label3.Name = "label3";
			label3.Size = new Size(58, 15);
			label3.TabIndex = 1;
			label3.Text = "File Path :";
			// 
			// btnBrowseText
			// 
			btnBrowseText.Location = new Point(345, 14);
			btnBrowseText.Name = "btnBrowseText";
			btnBrowseText.Size = new Size(75, 23);
			btnBrowseText.TabIndex = 0;
			btnBrowseText.Text = "Browse";
			btnBrowseText.UseVisualStyleBackColor = true;
			btnBrowseText.Click += btnBrowseText_Click;
			// 
			// groupBox3
			// 
			groupBox3.Controls.Add(btnClear);
			groupBox3.Controls.Add(btnSave);
			groupBox3.Controls.Add(btnReplace);
			groupBox3.Controls.Add(btnCreateDict);
			groupBox3.Location = new Point(7, 111);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new Size(507, 55);
			groupBox3.TabIndex = 4;
			groupBox3.TabStop = false;
			groupBox3.Text = "3) Commands";
			// 
			// btnClear
			// 
			btnClear.Location = new Point(409, 21);
			btnClear.Name = "btnClear";
			btnClear.Size = new Size(92, 23);
			btnClear.TabIndex = 4;
			btnClear.Text = "Clear Content";
			btnClear.UseVisualStyleBackColor = true;
			btnClear.Click += btnClear_Click;
			// 
			// btnSave
			// 
			btnSave.Location = new Point(320, 21);
			btnSave.Name = "btnSave";
			btnSave.Size = new Size(85, 23);
			btnSave.TabIndex = 4;
			btnSave.Text = "Save Content";
			btnSave.UseVisualStyleBackColor = true;
			btnSave.Click += btnSave_Click;
			// 
			// btnReplace
			// 
			btnReplace.Location = new Point(244, 21);
			btnReplace.Name = "btnReplace";
			btnReplace.Size = new Size(72, 23);
			btnReplace.TabIndex = 4;
			btnReplace.Text = "Replace";
			btnReplace.UseVisualStyleBackColor = true;
			btnReplace.Click += btnReplace_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(532, 397);
			Controls.Add(groupBox3);
			Controls.Add(groupBox2);
			Controls.Add(groupBox1);
			Controls.Add(txtContent);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "Form1";
			Text = "Form1";
			FormClosing += Form1_Closing;
			FormClosed += Form1_Closed;
			Load += Form1_Load;
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			groupBox3.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox txtContent;
		private GroupBox groupBox1;
		private Button btnCreateDict;
		private Button btnBrowseDict;
		private Label lblDictFile;
		private Label label1;
		private GroupBox groupBox2;
		private Button btnShowText;
		private Label lblOpenedFile;
		private Label label3;
		private Button btnBrowseText;
		private Button btnShowDict;
		private GroupBox groupBox3;
		private Button btnReplace;
		private Button btnClear;
		private Button btnSave;
		private ToolTip toolTip1;
	}
}
