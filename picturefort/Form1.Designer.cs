namespace picturefort
{
	partial class MainWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			this.tableImagePreview = new System.Windows.Forms.TableLayoutPanel();
			this.listDesignations = new System.Windows.Forms.FlowLayoutPanel();
			this.side_previews = new System.Windows.Forms.FlowLayoutPanel();
			this.preview = new System.Windows.Forms.PictureBox();
			this.panelInput = new System.Windows.Forms.Panel();
			this.buttonConvert = new System.Windows.Forms.Button();
			this.btnTest = new System.Windows.Forms.Button();
			this.panelMultiImageMode = new System.Windows.Forms.Panel();
			this.radioMultiLevel = new System.Windows.Forms.RadioButton();
			this.radioBatch = new System.Windows.Forms.RadioButton();
			this.panelCustomFileString = new System.Windows.Forms.Panel();
			this.txtKeywords = new System.Windows.Forms.TextBox();
			this.txtOutputFormat = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label7 = new System.Windows.Forms.Label();
			this.txtOutPath = new System.Windows.Forms.TextBox();
			this.panelTemplateType = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cbDig = new System.Windows.Forms.CheckBox();
			this.cbBuild = new System.Windows.Forms.CheckBox();
			this.cbPlace = new System.Windows.Forms.CheckBox();
			this.cbQuery = new System.Windows.Forms.CheckBox();
			this.txtCommentQuery = new System.Windows.Forms.TextBox();
			this.txtCommentPlace = new System.Windows.Forms.TextBox();
			this.txtCommentBuild = new System.Windows.Forms.TextBox();
			this.txtCommentDig = new System.Windows.Forms.TextBox();
			this.panelStartPos = new System.Windows.Forms.Panel();
			this.txtStartPos = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cbStartPos = new System.Windows.Forms.ComboBox();
			this.lblSelectedPicture = new System.Windows.Forms.Label();
			this.btnImageChooser = new System.Windows.Forms.Button();
			this.panelStatus = new System.Windows.Forms.Panel();
			this.status = new System.Windows.Forms.Label();
			this.progress_bar = new System.Windows.Forms.ProgressBar();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.tableImagePreview.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.preview)).BeginInit();
			this.panelInput.SuspendLayout();
			this.panelMultiImageMode.SuspendLayout();
			this.panelCustomFileString.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panelTemplateType.SuspendLayout();
			this.panelStartPos.SuspendLayout();
			this.panelStatus.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableImagePreview
			// 
			this.tableImagePreview.BackColor = System.Drawing.Color.Black;
			this.tableImagePreview.ColumnCount = 2;
			this.tableImagePreview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
			this.tableImagePreview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableImagePreview.Controls.Add(this.listDesignations, 0, 1);
			this.tableImagePreview.Controls.Add(this.side_previews, 0, 0);
			this.tableImagePreview.Controls.Add(this.preview, 1, 0);
			this.tableImagePreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableImagePreview.Location = new System.Drawing.Point(0, 0);
			this.tableImagePreview.Margin = new System.Windows.Forms.Padding(0);
			this.tableImagePreview.Name = "tableImagePreview";
			this.tableImagePreview.RowCount = 2;
			this.tableImagePreview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.tableImagePreview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tableImagePreview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableImagePreview.Size = new System.Drawing.Size(567, 747);
			this.tableImagePreview.TabIndex = 1;
			// 
			// listDesignations
			// 
			this.listDesignations.AutoScroll = true;
			this.tableImagePreview.SetColumnSpan(this.listDesignations, 2);
			this.listDesignations.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listDesignations.Location = new System.Drawing.Point(3, 525);
			this.listDesignations.Name = "listDesignations";
			this.listDesignations.Size = new System.Drawing.Size(561, 219);
			this.listDesignations.TabIndex = 0;
			// 
			// side_previews
			// 
			this.side_previews.AutoScroll = true;
			this.side_previews.AutoSize = true;
			this.side_previews.BackColor = System.Drawing.Color.Gray;
			this.side_previews.Dock = System.Windows.Forms.DockStyle.Fill;
			this.side_previews.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.side_previews.Location = new System.Drawing.Point(0, 0);
			this.side_previews.Margin = new System.Windows.Forms.Padding(0);
			this.side_previews.Name = "side_previews";
			this.side_previews.Size = new System.Drawing.Size(200, 522);
			this.side_previews.TabIndex = 13;
			this.side_previews.WrapContents = false;
			// 
			// preview
			// 
			this.preview.BackColor = System.Drawing.Color.Gray;
			this.preview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.preview.Location = new System.Drawing.Point(200, 0);
			this.preview.Margin = new System.Windows.Forms.Padding(0);
			this.preview.Name = "preview";
			this.preview.Size = new System.Drawing.Size(367, 522);
			this.preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.preview.TabIndex = 0;
			this.preview.TabStop = false;
			this.preview.MouseClick += new System.Windows.Forms.MouseEventHandler(this.preview_MouseClick);
			// 
			// panelInput
			// 
			this.panelInput.Controls.Add(this.buttonConvert);
			this.panelInput.Controls.Add(this.panelMultiImageMode);
			this.panelInput.Controls.Add(this.panelCustomFileString);
			this.panelInput.Controls.Add(this.panel3);
			this.panelInput.Controls.Add(this.panelTemplateType);
			this.panelInput.Controls.Add(this.panelStartPos);
			this.panelInput.Controls.Add(this.lblSelectedPicture);
			this.panelInput.Controls.Add(this.btnImageChooser);
			this.panelInput.Controls.Add(this.btnTest);
			this.panelInput.Dock = System.Windows.Forms.DockStyle.Right;
			this.panelInput.Location = new System.Drawing.Point(567, 0);
			this.panelInput.Margin = new System.Windows.Forms.Padding(0);
			this.panelInput.Name = "panelInput";
			this.panelInput.Size = new System.Drawing.Size(217, 747);
			this.panelInput.TabIndex = 1;
			// 
			// buttonConvert
			// 
			this.buttonConvert.Dock = System.Windows.Forms.DockStyle.Top;
			this.buttonConvert.Location = new System.Drawing.Point(0, 626);
			this.buttonConvert.Name = "buttonConvert";
			this.buttonConvert.Size = new System.Drawing.Size(217, 23);
			this.buttonConvert.TabIndex = 19;
			this.buttonConvert.Text = "Convert";
			this.buttonConvert.UseVisualStyleBackColor = true;
			this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
			// 
			// btnTest
			// 
			this.btnTest.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnTest.Location = new System.Drawing.Point(0, 0);
			this.btnTest.Name = "btnTest";
			this.btnTest.Size = new System.Drawing.Size(217, 30);
			this.btnTest.TabIndex = 14;
			this.btnTest.Text = "TEST";
			this.btnTest.UseVisualStyleBackColor = true;
			this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
			// 
			// panelMultiImageMode
			// 
			this.panelMultiImageMode.Controls.Add(this.textBox1);
			this.panelMultiImageMode.Controls.Add(this.radioMultiLevel);
			this.panelMultiImageMode.Controls.Add(this.radioBatch);
			this.panelMultiImageMode.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelMultiImageMode.Location = new System.Drawing.Point(0, 510);
			this.panelMultiImageMode.Name = "panelMultiImageMode";
			this.panelMultiImageMode.Size = new System.Drawing.Size(217, 116);
			this.panelMultiImageMode.TabIndex = 17;
			// 
			// radioMultiLevel
			// 
			this.radioMultiLevel.AutoSize = true;
			this.radioMultiLevel.Checked = true;
			this.radioMultiLevel.Location = new System.Drawing.Point(62, 3);
			this.radioMultiLevel.Name = "radioMultiLevel";
			this.radioMultiLevel.Size = new System.Drawing.Size(126, 17);
			this.radioMultiLevel.TabIndex = 1;
			this.radioMultiLevel.TabStop = true;
			this.radioMultiLevel.Text = "Multiple Level Design";
			this.radioMultiLevel.UseVisualStyleBackColor = true;
			// 
			// radioBatch
			// 
			this.radioBatch.AutoSize = true;
			this.radioBatch.Location = new System.Drawing.Point(3, 3);
			this.radioBatch.Name = "radioBatch";
			this.radioBatch.Size = new System.Drawing.Size(53, 17);
			this.radioBatch.TabIndex = 0;
			this.radioBatch.Text = "Batch";
			this.radioBatch.UseVisualStyleBackColor = true;
			// 
			// panelCustomFileString
			// 
			this.panelCustomFileString.Controls.Add(this.txtKeywords);
			this.panelCustomFileString.Controls.Add(this.txtOutputFormat);
			this.panelCustomFileString.Controls.Add(this.label6);
			this.panelCustomFileString.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelCustomFileString.Location = new System.Drawing.Point(0, 319);
			this.panelCustomFileString.Name = "panelCustomFileString";
			this.panelCustomFileString.Size = new System.Drawing.Size(217, 191);
			this.panelCustomFileString.TabIndex = 16;
			// 
			// txtKeywords
			// 
			this.txtKeywords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtKeywords.Location = new System.Drawing.Point(3, 45);
			this.txtKeywords.Multiline = true;
			this.txtKeywords.Name = "txtKeywords";
			this.txtKeywords.ReadOnly = true;
			this.txtKeywords.Size = new System.Drawing.Size(211, 140);
			this.txtKeywords.TabIndex = 2;
			this.txtKeywords.Text = resources.GetString("txtKeywords.Text");
			// 
			// txtOutputFormat
			// 
			this.txtOutputFormat.Location = new System.Drawing.Point(3, 19);
			this.txtOutputFormat.Name = "txtOutputFormat";
			this.txtOutputFormat.Size = new System.Drawing.Size(211, 20);
			this.txtOutputFormat.TabIndex = 1;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(3, 3);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(119, 13);
			this.label6.TabIndex = 0;
			this.label6.Text = "Output Filename Format";
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.label7);
			this.panel3.Controls.Add(this.txtOutPath);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 267);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(217, 52);
			this.panel3.TabIndex = 18;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(3, 3);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(96, 13);
			this.label7.TabIndex = 10;
			this.label7.Text = "Output Folder Path";
			// 
			// txtOutPath
			// 
			this.txtOutPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOutPath.Location = new System.Drawing.Point(3, 26);
			this.txtOutPath.Margin = new System.Windows.Forms.Padding(0);
			this.txtOutPath.Name = "txtOutPath";
			this.txtOutPath.Size = new System.Drawing.Size(211, 20);
			this.txtOutPath.TabIndex = 9;
			this.txtOutPath.DoubleClick += new System.EventHandler(this.txtOutPath_DoubleClick);
			// 
			// panelTemplateType
			// 
			this.panelTemplateType.Controls.Add(this.label5);
			this.panelTemplateType.Controls.Add(this.label4);
			this.panelTemplateType.Controls.Add(this.cbDig);
			this.panelTemplateType.Controls.Add(this.cbBuild);
			this.panelTemplateType.Controls.Add(this.cbPlace);
			this.panelTemplateType.Controls.Add(this.cbQuery);
			this.panelTemplateType.Controls.Add(this.txtCommentQuery);
			this.panelTemplateType.Controls.Add(this.txtCommentPlace);
			this.panelTemplateType.Controls.Add(this.txtCommentBuild);
			this.panelTemplateType.Controls.Add(this.txtCommentDig);
			this.panelTemplateType.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTemplateType.Location = new System.Drawing.Point(0, 144);
			this.panelTemplateType.Name = "panelTemplateType";
			this.panelTemplateType.Size = new System.Drawing.Size(217, 123);
			this.panelTemplateType.TabIndex = 12;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(54, 3);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(51, 13);
			this.label5.TabIndex = 13;
			this.label5.Text = "Comment";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 3);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(34, 13);
			this.label4.TabIndex = 12;
			this.label4.Text = "Mode";
			// 
			// cbDig
			// 
			this.cbDig.AutoSize = true;
			this.cbDig.Checked = true;
			this.cbDig.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbDig.Location = new System.Drawing.Point(3, 26);
			this.cbDig.Margin = new System.Windows.Forms.Padding(0);
			this.cbDig.Name = "cbDig";
			this.cbDig.Size = new System.Drawing.Size(42, 17);
			this.cbDig.TabIndex = 2;
			this.cbDig.Text = "Dig";
			this.cbDig.UseVisualStyleBackColor = true;
			// 
			// cbBuild
			// 
			this.cbBuild.AutoSize = true;
			this.cbBuild.Location = new System.Drawing.Point(3, 49);
			this.cbBuild.Margin = new System.Windows.Forms.Padding(0);
			this.cbBuild.Name = "cbBuild";
			this.cbBuild.Size = new System.Drawing.Size(49, 17);
			this.cbBuild.TabIndex = 3;
			this.cbBuild.Text = "Build";
			this.cbBuild.UseVisualStyleBackColor = true;
			// 
			// cbPlace
			// 
			this.cbPlace.AutoSize = true;
			this.cbPlace.Location = new System.Drawing.Point(3, 72);
			this.cbPlace.Margin = new System.Windows.Forms.Padding(0);
			this.cbPlace.Name = "cbPlace";
			this.cbPlace.Size = new System.Drawing.Size(53, 17);
			this.cbPlace.TabIndex = 4;
			this.cbPlace.Text = "Place";
			this.cbPlace.UseVisualStyleBackColor = true;
			// 
			// cbQuery
			// 
			this.cbQuery.AutoSize = true;
			this.cbQuery.Location = new System.Drawing.Point(3, 96);
			this.cbQuery.Margin = new System.Windows.Forms.Padding(0);
			this.cbQuery.Name = "cbQuery";
			this.cbQuery.Size = new System.Drawing.Size(54, 17);
			this.cbQuery.TabIndex = 5;
			this.cbQuery.Text = "Query";
			this.cbQuery.UseVisualStyleBackColor = true;
			// 
			// txtCommentQuery
			// 
			this.txtCommentQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCommentQuery.Location = new System.Drawing.Point(57, 94);
			this.txtCommentQuery.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
			this.txtCommentQuery.Name = "txtCommentQuery";
			this.txtCommentQuery.Size = new System.Drawing.Size(157, 20);
			this.txtCommentQuery.TabIndex = 11;
			// 
			// txtCommentPlace
			// 
			this.txtCommentPlace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCommentPlace.Location = new System.Drawing.Point(57, 70);
			this.txtCommentPlace.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
			this.txtCommentPlace.Name = "txtCommentPlace";
			this.txtCommentPlace.Size = new System.Drawing.Size(157, 20);
			this.txtCommentPlace.TabIndex = 10;
			// 
			// txtCommentBuild
			// 
			this.txtCommentBuild.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCommentBuild.Location = new System.Drawing.Point(57, 47);
			this.txtCommentBuild.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
			this.txtCommentBuild.Name = "txtCommentBuild";
			this.txtCommentBuild.Size = new System.Drawing.Size(157, 20);
			this.txtCommentBuild.TabIndex = 9;
			// 
			// txtCommentDig
			// 
			this.txtCommentDig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCommentDig.Location = new System.Drawing.Point(57, 24);
			this.txtCommentDig.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
			this.txtCommentDig.Name = "txtCommentDig";
			this.txtCommentDig.Size = new System.Drawing.Size(157, 20);
			this.txtCommentDig.TabIndex = 8;
			// 
			// panelStartPos
			// 
			this.panelStartPos.Controls.Add(this.txtStartPos);
			this.panelStartPos.Controls.Add(this.label3);
			this.panelStartPos.Controls.Add(this.cbStartPos);
			this.panelStartPos.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelStartPos.Location = new System.Drawing.Point(0, 69);
			this.panelStartPos.Name = "panelStartPos";
			this.panelStartPos.Size = new System.Drawing.Size(217, 75);
			this.panelStartPos.TabIndex = 7;
			// 
			// txtStartPos
			// 
			this.txtStartPos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtStartPos.Location = new System.Drawing.Point(3, 49);
			this.txtStartPos.Name = "txtStartPos";
			this.txtStartPos.Size = new System.Drawing.Size(211, 20);
			this.txtStartPos.TabIndex = 8;
			this.txtStartPos.TextChanged += new System.EventHandler(this.txtStartPos_TextChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 5);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Start Point";
			// 
			// cbStartPos
			// 
			this.cbStartPos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbStartPos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbStartPos.FormattingEnabled = true;
			this.cbStartPos.Location = new System.Drawing.Point(3, 22);
			this.cbStartPos.Name = "cbStartPos";
			this.cbStartPos.Size = new System.Drawing.Size(211, 21);
			this.cbStartPos.TabIndex = 6;
			this.cbStartPos.SelectedIndexChanged += new System.EventHandler(this.cbStartPos_SelectedIndexChanged);
			// 
			// lblSelectedPicture
			// 
			this.lblSelectedPicture.AutoSize = true;
			this.lblSelectedPicture.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblSelectedPicture.Location = new System.Drawing.Point(0, 50);
			this.lblSelectedPicture.Margin = new System.Windows.Forms.Padding(10);
			this.lblSelectedPicture.Name = "lblSelectedPicture";
			this.lblSelectedPicture.Padding = new System.Windows.Forms.Padding(3);
			this.lblSelectedPicture.Size = new System.Drawing.Size(102, 19);
			this.lblSelectedPicture.TabIndex = 15;
			this.lblSelectedPicture.Text = "No Picture Loaded";
			this.lblSelectedPicture.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnImageChooser
			// 
			this.btnImageChooser.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnImageChooser.Location = new System.Drawing.Point(0, 30);
			this.btnImageChooser.Margin = new System.Windows.Forms.Padding(0);
			this.btnImageChooser.Name = "btnImageChooser";
			this.btnImageChooser.Size = new System.Drawing.Size(217, 20);
			this.btnImageChooser.TabIndex = 1;
			this.btnImageChooser.Text = "Load Image(s)";
			this.btnImageChooser.UseVisualStyleBackColor = true;
			this.btnImageChooser.Click += new System.EventHandler(this.btnImageChooser_Click);
			// 
			// panelStatus
			// 
			this.panelStatus.BackColor = System.Drawing.Color.Transparent;
			this.panelStatus.Controls.Add(this.status);
			this.panelStatus.Controls.Add(this.progress_bar);
			this.panelStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelStatus.Location = new System.Drawing.Point(0, 747);
			this.panelStatus.Name = "panelStatus";
			this.panelStatus.Size = new System.Drawing.Size(784, 30);
			this.panelStatus.TabIndex = 13;
			// 
			// status
			// 
			this.status.BackColor = System.Drawing.Color.Transparent;
			this.status.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.status.Location = new System.Drawing.Point(0, 0);
			this.status.Margin = new System.Windows.Forms.Padding(0);
			this.status.Name = "status";
			this.status.Size = new System.Drawing.Size(784, 15);
			this.status.TabIndex = 7;
			this.status.Text = "Ready";
			this.status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// progress_bar
			// 
			this.progress_bar.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.progress_bar.Location = new System.Drawing.Point(0, 15);
			this.progress_bar.Margin = new System.Windows.Forms.Padding(0);
			this.progress_bar.Name = "progress_bar";
			this.progress_bar.Size = new System.Drawing.Size(784, 15);
			this.progress_bar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progress_bar.TabIndex = 3;
			this.progress_bar.Value = 100;
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(3, 23);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(211, 87);
			this.textBox1.TabIndex = 3;
			this.textBox1.Text = resources.GetString("textBox1.Text");
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 777);
			this.Controls.Add(this.tableImagePreview);
			this.Controls.Add(this.panelInput);
			this.Controls.Add(this.panelStatus);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainWindow";
			this.Text = "PictureFort";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.tableImagePreview.ResumeLayout(false);
			this.tableImagePreview.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.preview)).EndInit();
			this.panelInput.ResumeLayout(false);
			this.panelInput.PerformLayout();
			this.panelMultiImageMode.ResumeLayout(false);
			this.panelMultiImageMode.PerformLayout();
			this.panelCustomFileString.ResumeLayout(false);
			this.panelCustomFileString.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panelTemplateType.ResumeLayout(false);
			this.panelTemplateType.PerformLayout();
			this.panelStartPos.ResumeLayout(false);
			this.panelStartPos.PerformLayout();
			this.panelStatus.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnImageChooser;
		private System.Windows.Forms.ProgressBar progress_bar;
		private System.Windows.Forms.PictureBox preview;
		private System.Windows.Forms.Panel panelInput;
		private System.Windows.Forms.Label status;
		private System.Windows.Forms.TextBox txtOutPath;
		private System.Windows.Forms.Panel panelStartPos;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbStartPos;
		private System.Windows.Forms.CheckBox cbQuery;
		private System.Windows.Forms.CheckBox cbPlace;
		private System.Windows.Forms.CheckBox cbBuild;
		private System.Windows.Forms.CheckBox cbDig;
		private System.Windows.Forms.TextBox txtStartPos;
		private System.Windows.Forms.TextBox txtCommentQuery;
		private System.Windows.Forms.TextBox txtCommentPlace;
		private System.Windows.Forms.TextBox txtCommentBuild;
		private System.Windows.Forms.TextBox txtCommentDig;
		private System.Windows.Forms.Panel panelTemplateType;
		private System.Windows.Forms.TableLayoutPanel tableImagePreview;
		private System.Windows.Forms.FlowLayoutPanel side_previews;
		private System.Windows.Forms.Button btnTest;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblSelectedPicture;
		private System.Windows.Forms.FlowLayoutPanel listDesignations;
		private System.Windows.Forms.Panel panelCustomFileString;
		private System.Windows.Forms.TextBox txtOutputFormat;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtKeywords;
		private System.Windows.Forms.Panel panelMultiImageMode;
		private System.Windows.Forms.RadioButton radioMultiLevel;
		private System.Windows.Forms.RadioButton radioBatch;
		private System.Windows.Forms.Panel panelStatus;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button buttonConvert;
		private System.Windows.Forms.TextBox textBox1;

	}
}

