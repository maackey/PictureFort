namespace picturefort
{
	partial class color_designation
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtColor = new System.Windows.Forms.TextBox();
			this.cbModeDig = new System.Windows.Forms.ComboBox();
			this.cbModeBuild = new System.Windows.Forms.ComboBox();
			this.cbModePlace = new System.Windows.Forms.ComboBox();
			this.cbModeQuery = new System.Windows.Forms.ComboBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtColor
			// 
			this.txtColor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtColor.Location = new System.Drawing.Point(3, 3);
			this.txtColor.Name = "txtColor";
			this.txtColor.Size = new System.Drawing.Size(103, 20);
			this.txtColor.TabIndex = 4;
			// 
			// cbModeDig
			// 
			this.cbModeDig.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbModeDig.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.cbModeDig.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbModeDig.DropDownWidth = 150;
			this.cbModeDig.FormattingEnabled = true;
			this.cbModeDig.Location = new System.Drawing.Point(112, 3);
			this.cbModeDig.Name = "cbModeDig";
			this.cbModeDig.Size = new System.Drawing.Size(103, 21);
			this.cbModeDig.TabIndex = 5;
			this.cbModeDig.SelectedIndexChanged += new System.EventHandler(this.cbModeDig_SelectedIndexChanged);
			// 
			// cbModeBuild
			// 
			this.cbModeBuild.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbModeBuild.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.cbModeBuild.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbModeBuild.DropDownWidth = 150;
			this.cbModeBuild.FormattingEnabled = true;
			this.cbModeBuild.Location = new System.Drawing.Point(221, 3);
			this.cbModeBuild.Name = "cbModeBuild";
			this.cbModeBuild.Size = new System.Drawing.Size(103, 21);
			this.cbModeBuild.TabIndex = 6;
			this.cbModeBuild.SelectedIndexChanged += new System.EventHandler(this.cbModeBuild_SelectedIndexChanged);
			// 
			// cbModePlace
			// 
			this.cbModePlace.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbModePlace.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.cbModePlace.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbModePlace.DropDownWidth = 150;
			this.cbModePlace.FormattingEnabled = true;
			this.cbModePlace.Location = new System.Drawing.Point(330, 3);
			this.cbModePlace.Name = "cbModePlace";
			this.cbModePlace.Size = new System.Drawing.Size(103, 21);
			this.cbModePlace.TabIndex = 7;
			this.cbModePlace.SelectedIndexChanged += new System.EventHandler(this.cbModePlace_SelectedIndexChanged);
			// 
			// cbModeQuery
			// 
			this.cbModeQuery.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbModeQuery.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.cbModeQuery.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbModeQuery.DropDownWidth = 150;
			this.cbModeQuery.FormattingEnabled = true;
			this.cbModeQuery.Location = new System.Drawing.Point(439, 3);
			this.cbModeQuery.Name = "cbModeQuery";
			this.cbModeQuery.Size = new System.Drawing.Size(103, 21);
			this.cbModeQuery.TabIndex = 8;
			this.cbModeQuery.SelectedIndexChanged += new System.EventHandler(this.cbModeQuery_SelectedIndexChanged);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
			this.tableLayoutPanel1.ColumnCount = 5;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.Controls.Add(this.cbModeQuery, 4, 0);
			this.tableLayoutPanel1.Controls.Add(this.cbModePlace, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.cbModeBuild, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.cbModeDig, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.txtColor, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(545, 28);
			this.tableLayoutPanel1.TabIndex = 9;
			// 
			// color_designation
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.MinimumSize = new System.Drawing.Size(545, 28);
			this.Name = "color_designation";
			this.Size = new System.Drawing.Size(545, 28);
			this.Load += new System.EventHandler(this.color_designation_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox txtColor;
		private System.Windows.Forms.ComboBox cbModeDig;
		private System.Windows.Forms.ComboBox cbModeBuild;
		private System.Windows.Forms.ComboBox cbModePlace;
		private System.Windows.Forms.ComboBox cbModeQuery;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	}
}
