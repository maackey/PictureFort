namespace picturefort
{
	partial class Form1
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.grid = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnTest = new System.Windows.Forms.Button();
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
			this.btnImageChooser = new System.Windows.Forms.Button();
			this.btnMultiCSV = new System.Windows.Forms.Button();
			this.btnSingleCSV = new System.Windows.Forms.Button();
			this.progress_bar = new System.Windows.Forms.ProgressBar();
			this.tabPanel = new System.Windows.Forms.TabControl();
			this.tabImagePreview = new System.Windows.Forms.TabPage();
			this.tableImagePreview = new System.Windows.Forms.TableLayoutPanel();
			this.side_previews = new System.Windows.Forms.FlowLayoutPanel();
			this.preview = new System.Windows.Forms.PictureBox();
			this.tabColorDesignations = new System.Windows.Forms.TabPage();
			this.status = new System.Windows.Forms.Label();
			this.txtOutFilePath = new System.Windows.Forms.TextBox();
			this.txtOutPath = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cbRecursive = new System.Windows.Forms.CheckBox();
			this.lblSelectedPicture = new System.Windows.Forms.Label();
			this.listDesignations = new System.Windows.Forms.ListBox();
			this.grid.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panelTemplateType.SuspendLayout();
			this.panelStartPos.SuspendLayout();
			this.tabPanel.SuspendLayout();
			this.tabImagePreview.SuspendLayout();
			this.tableImagePreview.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.preview)).BeginInit();
			this.tabColorDesignations.SuspendLayout();
			this.SuspendLayout();
			// 
			// grid
			// 
			this.grid.BackColor = System.Drawing.Color.Transparent;
			this.grid.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.grid.ColumnCount = 3;
			this.grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
			this.grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 213F));
			this.grid.Controls.Add(this.panel1, 2, 0);
			this.grid.Controls.Add(this.btnMultiCSV, 2, 2);
			this.grid.Controls.Add(this.btnSingleCSV, 2, 1);
			this.grid.Controls.Add(this.progress_bar, 1, 3);
			this.grid.Controls.Add(this.tabPanel, 0, 0);
			this.grid.Controls.Add(this.status, 2, 3);
			this.grid.Controls.Add(this.txtOutFilePath, 1, 1);
			this.grid.Controls.Add(this.txtOutPath, 1, 2);
			this.grid.Controls.Add(this.label1, 0, 1);
			this.grid.Controls.Add(this.label2, 0, 2);
			this.grid.Controls.Add(this.cbRecursive, 0, 3);
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.Location = new System.Drawing.Point(0, 0);
			this.grid.Margin = new System.Windows.Forms.Padding(0);
			this.grid.Name = "grid";
			this.grid.RowCount = 4;
			this.grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.grid.Size = new System.Drawing.Size(776, 461);
			this.grid.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnTest);
			this.panel1.Controls.Add(this.panelTemplateType);
			this.panel1.Controls.Add(this.panelStartPos);
			this.panel1.Controls.Add(this.lblSelectedPicture);
			this.panel1.Controls.Add(this.btnImageChooser);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(562, 1);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(213, 396);
			this.panel1.TabIndex = 1;
			// 
			// btnTest
			// 
			this.btnTest.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnTest.Location = new System.Drawing.Point(0, 237);
			this.btnTest.Name = "btnTest";
			this.btnTest.Size = new System.Drawing.Size(213, 61);
			this.btnTest.TabIndex = 14;
			this.btnTest.Text = "TEST";
			this.btnTest.UseVisualStyleBackColor = true;
			this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
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
			this.panelTemplateType.Location = new System.Drawing.Point(0, 114);
			this.panelTemplateType.Name = "panelTemplateType";
			this.panelTemplateType.Size = new System.Drawing.Size(213, 123);
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
			this.txtCommentQuery.Location = new System.Drawing.Point(57, 94);
			this.txtCommentQuery.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
			this.txtCommentQuery.Name = "txtCommentQuery";
			this.txtCommentQuery.Size = new System.Drawing.Size(152, 20);
			this.txtCommentQuery.TabIndex = 11;
			// 
			// txtCommentPlace
			// 
			this.txtCommentPlace.Location = new System.Drawing.Point(57, 70);
			this.txtCommentPlace.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
			this.txtCommentPlace.Name = "txtCommentPlace";
			this.txtCommentPlace.Size = new System.Drawing.Size(152, 20);
			this.txtCommentPlace.TabIndex = 10;
			// 
			// txtCommentBuild
			// 
			this.txtCommentBuild.Location = new System.Drawing.Point(57, 47);
			this.txtCommentBuild.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
			this.txtCommentBuild.Name = "txtCommentBuild";
			this.txtCommentBuild.Size = new System.Drawing.Size(152, 20);
			this.txtCommentBuild.TabIndex = 9;
			// 
			// txtCommentDig
			// 
			this.txtCommentDig.Location = new System.Drawing.Point(57, 24);
			this.txtCommentDig.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
			this.txtCommentDig.Name = "txtCommentDig";
			this.txtCommentDig.Size = new System.Drawing.Size(152, 20);
			this.txtCommentDig.TabIndex = 8;
			// 
			// panelStartPos
			// 
			this.panelStartPos.Controls.Add(this.txtStartPos);
			this.panelStartPos.Controls.Add(this.label3);
			this.panelStartPos.Controls.Add(this.cbStartPos);
			this.panelStartPos.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelStartPos.Location = new System.Drawing.Point(0, 39);
			this.panelStartPos.Name = "panelStartPos";
			this.panelStartPos.Size = new System.Drawing.Size(213, 75);
			this.panelStartPos.TabIndex = 7;
			// 
			// txtStartPos
			// 
			this.txtStartPos.Location = new System.Drawing.Point(3, 49);
			this.txtStartPos.Name = "txtStartPos";
			this.txtStartPos.Size = new System.Drawing.Size(206, 20);
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
			this.cbStartPos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbStartPos.FormattingEnabled = true;
			this.cbStartPos.Location = new System.Drawing.Point(3, 22);
			this.cbStartPos.Name = "cbStartPos";
			this.cbStartPos.Size = new System.Drawing.Size(206, 21);
			this.cbStartPos.TabIndex = 6;
			this.cbStartPos.SelectedIndexChanged += new System.EventHandler(this.cbStartPos_SelectedIndexChanged);
			// 
			// btnImageChooser
			// 
			this.btnImageChooser.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnImageChooser.Location = new System.Drawing.Point(0, 0);
			this.btnImageChooser.Margin = new System.Windows.Forms.Padding(0);
			this.btnImageChooser.Name = "btnImageChooser";
			this.btnImageChooser.Size = new System.Drawing.Size(213, 20);
			this.btnImageChooser.TabIndex = 1;
			this.btnImageChooser.Text = "Load Image(s)";
			this.btnImageChooser.UseVisualStyleBackColor = true;
			this.btnImageChooser.Click += new System.EventHandler(this.btnImageChooser_Click);
			// 
			// btnMultiCSV
			// 
			this.btnMultiCSV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnMultiCSV.Location = new System.Drawing.Point(562, 419);
			this.btnMultiCSV.Margin = new System.Windows.Forms.Padding(0);
			this.btnMultiCSV.Name = "btnMultiCSV";
			this.btnMultiCSV.Size = new System.Drawing.Size(213, 20);
			this.btnMultiCSV.TabIndex = 6;
			this.btnMultiCSV.Text = "Batch Templates";
			this.btnMultiCSV.UseVisualStyleBackColor = true;
			this.btnMultiCSV.Click += new System.EventHandler(this.btnMultiCSV_Click);
			// 
			// btnSingleCSV
			// 
			this.btnSingleCSV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnSingleCSV.Location = new System.Drawing.Point(562, 398);
			this.btnSingleCSV.Margin = new System.Windows.Forms.Padding(0);
			this.btnSingleCSV.Name = "btnSingleCSV";
			this.btnSingleCSV.Size = new System.Drawing.Size(213, 20);
			this.btnSingleCSV.TabIndex = 2;
			this.btnSingleCSV.Text = "Single Template";
			this.btnSingleCSV.UseVisualStyleBackColor = true;
			this.btnSingleCSV.Click += new System.EventHandler(this.btnSingleCSV_Click);
			// 
			// progress_bar
			// 
			this.progress_bar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.progress_bar.Location = new System.Drawing.Point(152, 440);
			this.progress_bar.Margin = new System.Windows.Forms.Padding(0);
			this.progress_bar.Name = "progress_bar";
			this.progress_bar.Size = new System.Drawing.Size(409, 20);
			this.progress_bar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progress_bar.TabIndex = 3;
			this.progress_bar.Value = 100;
			// 
			// tabPanel
			// 
			this.grid.SetColumnSpan(this.tabPanel, 2);
			this.tabPanel.Controls.Add(this.tabImagePreview);
			this.tabPanel.Controls.Add(this.tabColorDesignations);
			this.tabPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabPanel.Location = new System.Drawing.Point(1, 1);
			this.tabPanel.Margin = new System.Windows.Forms.Padding(0);
			this.tabPanel.Name = "tabPanel";
			this.tabPanel.SelectedIndex = 0;
			this.tabPanel.Size = new System.Drawing.Size(560, 396);
			this.tabPanel.TabIndex = 5;
			// 
			// tabImagePreview
			// 
			this.tabImagePreview.Controls.Add(this.tableImagePreview);
			this.tabImagePreview.Location = new System.Drawing.Point(4, 22);
			this.tabImagePreview.Margin = new System.Windows.Forms.Padding(0);
			this.tabImagePreview.Name = "tabImagePreview";
			this.tabImagePreview.Size = new System.Drawing.Size(552, 370);
			this.tabImagePreview.TabIndex = 0;
			this.tabImagePreview.Text = "Image Preview";
			this.tabImagePreview.UseVisualStyleBackColor = true;
			// 
			// tableImagePreview
			// 
			this.tableImagePreview.ColumnCount = 2;
			this.tableImagePreview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
			this.tableImagePreview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableImagePreview.Controls.Add(this.side_previews, 0, 0);
			this.tableImagePreview.Controls.Add(this.preview, 1, 0);
			this.tableImagePreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableImagePreview.Location = new System.Drawing.Point(0, 0);
			this.tableImagePreview.Margin = new System.Windows.Forms.Padding(0);
			this.tableImagePreview.Name = "tableImagePreview";
			this.tableImagePreview.RowCount = 1;
			this.tableImagePreview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableImagePreview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 364F));
			this.tableImagePreview.Size = new System.Drawing.Size(552, 370);
			this.tableImagePreview.TabIndex = 1;
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
			this.side_previews.Size = new System.Drawing.Size(200, 370);
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
			this.preview.Size = new System.Drawing.Size(352, 370);
			this.preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.preview.TabIndex = 0;
			this.preview.TabStop = false;
			// 
			// tabColorDesignations
			// 
			this.tabColorDesignations.Controls.Add(this.listDesignations);
			this.tabColorDesignations.Location = new System.Drawing.Point(4, 22);
			this.tabColorDesignations.Margin = new System.Windows.Forms.Padding(0);
			this.tabColorDesignations.Name = "tabColorDesignations";
			this.tabColorDesignations.Size = new System.Drawing.Size(552, 370);
			this.tabColorDesignations.TabIndex = 1;
			this.tabColorDesignations.Text = "Color Designations";
			this.tabColorDesignations.UseVisualStyleBackColor = true;
			// 
			// status
			// 
			this.status.AutoSize = true;
			this.status.Dock = System.Windows.Forms.DockStyle.Fill;
			this.status.Location = new System.Drawing.Point(565, 440);
			this.status.Name = "status";
			this.status.Size = new System.Drawing.Size(207, 20);
			this.status.TabIndex = 7;
			this.status.Text = "Ready";
			this.status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtOutFilePath
			// 
			this.txtOutFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtOutFilePath.Location = new System.Drawing.Point(152, 398);
			this.txtOutFilePath.Margin = new System.Windows.Forms.Padding(0);
			this.txtOutFilePath.Name = "txtOutFilePath";
			this.txtOutFilePath.Size = new System.Drawing.Size(409, 20);
			this.txtOutFilePath.TabIndex = 8;
			this.txtOutFilePath.DoubleClick += new System.EventHandler(this.txtOutFilePath_DoubleClick);
			// 
			// txtOutPath
			// 
			this.txtOutPath.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtOutPath.Location = new System.Drawing.Point(152, 419);
			this.txtOutPath.Margin = new System.Windows.Forms.Padding(0);
			this.txtOutPath.Name = "txtOutPath";
			this.txtOutPath.Size = new System.Drawing.Size(409, 20);
			this.txtOutPath.TabIndex = 9;
			this.txtOutPath.DoubleClick += new System.EventHandler(this.txtOutPath_DoubleClick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Location = new System.Drawing.Point(4, 398);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 20);
			this.label1.TabIndex = 10;
			this.label1.Text = "Ouput File";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Location = new System.Drawing.Point(4, 419);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(144, 20);
			this.label2.TabIndex = 11;
			this.label2.Text = "Output Path";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbRecursive
			// 
			this.cbRecursive.AutoSize = true;
			this.cbRecursive.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbRecursive.Location = new System.Drawing.Point(6, 440);
			this.cbRecursive.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
			this.cbRecursive.Name = "cbRecursive";
			this.cbRecursive.Size = new System.Drawing.Size(145, 20);
			this.cbRecursive.TabIndex = 12;
			this.cbRecursive.Text = "Recursive Directories?";
			this.cbRecursive.UseVisualStyleBackColor = true;
			// 
			// lblSelectedPicture
			// 
			this.lblSelectedPicture.AutoSize = true;
			this.lblSelectedPicture.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblSelectedPicture.Location = new System.Drawing.Point(0, 20);
			this.lblSelectedPicture.Margin = new System.Windows.Forms.Padding(10);
			this.lblSelectedPicture.Name = "lblSelectedPicture";
			this.lblSelectedPicture.Padding = new System.Windows.Forms.Padding(3);
			this.lblSelectedPicture.Size = new System.Drawing.Size(102, 19);
			this.lblSelectedPicture.TabIndex = 15;
			this.lblSelectedPicture.Text = "No Picture Loaded";
			this.lblSelectedPicture.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// listDesignations
			// 
			this.listDesignations.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listDesignations.FormattingEnabled = true;
			this.listDesignations.Location = new System.Drawing.Point(0, 0);
			this.listDesignations.Name = "listDesignations";
			this.listDesignations.Size = new System.Drawing.Size(552, 370);
			this.listDesignations.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(776, 461);
			this.Controls.Add(this.grid);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "PictureFort";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.grid.ResumeLayout(false);
			this.grid.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panelTemplateType.ResumeLayout(false);
			this.panelTemplateType.PerformLayout();
			this.panelStartPos.ResumeLayout(false);
			this.panelStartPos.PerformLayout();
			this.tabPanel.ResumeLayout(false);
			this.tabImagePreview.ResumeLayout(false);
			this.tableImagePreview.ResumeLayout(false);
			this.tableImagePreview.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.preview)).EndInit();
			this.tabColorDesignations.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel grid;
		private System.Windows.Forms.Button btnImageChooser;
		private System.Windows.Forms.Button btnSingleCSV;
		private System.Windows.Forms.ProgressBar progress_bar;
		private System.Windows.Forms.TabControl tabPanel;
		private System.Windows.Forms.TabPage tabImagePreview;
		private System.Windows.Forms.PictureBox preview;
		private System.Windows.Forms.TabPage tabColorDesignations;
		private System.Windows.Forms.Button btnMultiCSV;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label status;
		private System.Windows.Forms.TextBox txtOutFilePath;
		private System.Windows.Forms.TextBox txtOutPath;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
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
		private System.Windows.Forms.CheckBox cbRecursive;
		private System.Windows.Forms.Panel panelTemplateType;
		private System.Windows.Forms.TableLayoutPanel tableImagePreview;
		private System.Windows.Forms.FlowLayoutPanel side_previews;
		private System.Windows.Forms.Button btnTest;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblSelectedPicture;
		private System.Windows.Forms.ListBox listDesignations;

	}
}

