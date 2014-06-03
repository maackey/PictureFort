namespace picturefort_multiplatform
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
			this.btnImageChooser = new System.Windows.Forms.Button();
			this.btnConvertImage = new System.Windows.Forms.Button();
			this.progress_bar = new System.Windows.Forms.ProgressBar();
			this.tabPanel = new System.Windows.Forms.TabControl();
			this.tabImagePreview = new System.Windows.Forms.TabPage();
			this.preview = new System.Windows.Forms.PictureBox();
			this.tabColorDesignations = new System.Windows.Forms.TabPage();
			this.listColorDesignations = new System.Windows.Forms.FlowLayoutPanel();
			this.tabAdvancedSettings = new System.Windows.Forms.TabPage();
			this.grid.SuspendLayout();
			this.tabPanel.SuspendLayout();
			this.tabImagePreview.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.preview)).BeginInit();
			this.tabColorDesignations.SuspendLayout();
			this.SuspendLayout();
			// 
			// grid
			// 
			this.grid.ColumnCount = 3;
			this.grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
			this.grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
			this.grid.Controls.Add(this.btnImageChooser, 0, 1);
			this.grid.Controls.Add(this.btnConvertImage, 2, 1);
			this.grid.Controls.Add(this.progress_bar, 1, 1);
			this.grid.Controls.Add(this.tabPanel, 0, 0);
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.Location = new System.Drawing.Point(0, 0);
			this.grid.Margin = new System.Windows.Forms.Padding(0);
			this.grid.Name = "grid";
			this.grid.RowCount = 1;
			this.grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.grid.Size = new System.Drawing.Size(776, 461);
			this.grid.TabIndex = 0;
			// 
			// btnImageChooser
			// 
			this.btnImageChooser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnImageChooser.Location = new System.Drawing.Point(0, 429);
			this.btnImageChooser.Margin = new System.Windows.Forms.Padding(0);
			this.btnImageChooser.Name = "btnImageChooser";
			this.btnImageChooser.Size = new System.Drawing.Size(150, 32);
			this.btnImageChooser.TabIndex = 1;
			this.btnImageChooser.Text = "Choose Image";
			this.btnImageChooser.UseVisualStyleBackColor = true;
			this.btnImageChooser.Click += new System.EventHandler(this.btnImageChooser_Click);
			// 
			// btnConvertImage
			// 
			this.btnConvertImage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnConvertImage.Enabled = false;
			this.btnConvertImage.Location = new System.Drawing.Point(626, 429);
			this.btnConvertImage.Margin = new System.Windows.Forms.Padding(0);
			this.btnConvertImage.Name = "btnConvertImage";
			this.btnConvertImage.Size = new System.Drawing.Size(150, 32);
			this.btnConvertImage.TabIndex = 2;
			this.btnConvertImage.Text = "Convert Image";
			this.btnConvertImage.UseVisualStyleBackColor = true;
			this.btnConvertImage.Click += new System.EventHandler(this.btnConvertImage_Click);
			// 
			// progress_bar
			// 
			this.progress_bar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.progress_bar.Location = new System.Drawing.Point(150, 429);
			this.progress_bar.Margin = new System.Windows.Forms.Padding(0);
			this.progress_bar.Name = "progress_bar";
			this.progress_bar.Size = new System.Drawing.Size(476, 32);
			this.progress_bar.TabIndex = 3;
			// 
			// tabPanel
			// 
			this.grid.SetColumnSpan(this.tabPanel, 3);
			this.tabPanel.Controls.Add(this.tabImagePreview);
			this.tabPanel.Controls.Add(this.tabColorDesignations);
			this.tabPanel.Controls.Add(this.tabAdvancedSettings);
			this.tabPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabPanel.Location = new System.Drawing.Point(0, 0);
			this.tabPanel.Margin = new System.Windows.Forms.Padding(0);
			this.tabPanel.Name = "tabPanel";
			this.tabPanel.SelectedIndex = 0;
			this.tabPanel.Size = new System.Drawing.Size(776, 429);
			this.tabPanel.TabIndex = 5;
			// 
			// tabImagePreview
			// 
			this.tabImagePreview.Controls.Add(this.preview);
			this.tabImagePreview.Location = new System.Drawing.Point(4, 22);
			this.tabImagePreview.Name = "tabImagePreview";
			this.tabImagePreview.Padding = new System.Windows.Forms.Padding(3);
			this.tabImagePreview.Size = new System.Drawing.Size(768, 403);
			this.tabImagePreview.TabIndex = 0;
			this.tabImagePreview.Text = "Image Preview";
			this.tabImagePreview.UseVisualStyleBackColor = true;
			// 
			// preview
			// 
			this.preview.BackColor = System.Drawing.Color.Gray;
			this.preview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.preview.Location = new System.Drawing.Point(3, 3);
			this.preview.Margin = new System.Windows.Forms.Padding(0);
			this.preview.Name = "preview";
			this.preview.Size = new System.Drawing.Size(762, 397);
			this.preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.preview.TabIndex = 0;
			this.preview.TabStop = false;
			// 
			// tabColorDesignations
			// 
			this.tabColorDesignations.Controls.Add(this.listColorDesignations);
			this.tabColorDesignations.Location = new System.Drawing.Point(4, 22);
			this.tabColorDesignations.Name = "tabColorDesignations";
			this.tabColorDesignations.Padding = new System.Windows.Forms.Padding(3);
			this.tabColorDesignations.Size = new System.Drawing.Size(768, 403);
			this.tabColorDesignations.TabIndex = 1;
			this.tabColorDesignations.Text = "Color Designations";
			this.tabColorDesignations.UseVisualStyleBackColor = true;
			// 
			// listColorDesignations
			// 
			this.listColorDesignations.BackColor = System.Drawing.Color.Transparent;
			this.listColorDesignations.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.listColorDesignations.Location = new System.Drawing.Point(3, 3);
			this.listColorDesignations.Margin = new System.Windows.Forms.Padding(0);
			this.listColorDesignations.Name = "listColorDesignations";
			this.listColorDesignations.Size = new System.Drawing.Size(762, 397);
			this.listColorDesignations.TabIndex = 5;
			// 
			// tabAdvancedSettings
			// 
			this.tabAdvancedSettings.Location = new System.Drawing.Point(4, 22);
			this.tabAdvancedSettings.Name = "tabAdvancedSettings";
			this.tabAdvancedSettings.Size = new System.Drawing.Size(768, 403);
			this.tabAdvancedSettings.TabIndex = 2;
			this.tabAdvancedSettings.Text = "Advanced";
			this.tabAdvancedSettings.UseVisualStyleBackColor = true;
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
			this.tabPanel.ResumeLayout(false);
			this.tabImagePreview.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.preview)).EndInit();
			this.tabColorDesignations.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel grid;
		private System.Windows.Forms.Button btnImageChooser;
		private System.Windows.Forms.Button btnConvertImage;
		private System.Windows.Forms.ProgressBar progress_bar;
		private System.Windows.Forms.TabControl tabPanel;
		private System.Windows.Forms.TabPage tabImagePreview;
		private System.Windows.Forms.PictureBox preview;
		private System.Windows.Forms.TabPage tabColorDesignations;
		private System.Windows.Forms.FlowLayoutPanel listColorDesignations;
		private System.Windows.Forms.TabPage tabAdvancedSettings;

	}
}

