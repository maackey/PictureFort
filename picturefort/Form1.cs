using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;

//TODO
/*
 ------------------------------* Completed
 ---------------------* default color designations (dropdown comboboxes)
 * custom output filenames
 * image/csv rotation
 */

namespace picturefort
{
	public partial class Form1 : Form
	{
		public const int scrollbar_width = 24;
		pf p;
		public static pf.byte_image selected_image;

		#region loading

		public Form1()
		{
			InitializeComponent();
		}

		void Form1_Load(object sender, EventArgs e)
		{
			p = new pf(progress_bar);
			p.read_settings();
			txtOutPath.Text = pf.settings[setting.output_path].ToString();

			cbRecursive.Enabled = false;
			cbRecursive.Visible = false;
		}

		/// <summary>
		/// Creates a file chooser dialog, loads necessary data from each image (byte_image.get_pixel_data), and displays the top image in the preview window
		/// </summary>
		/// <returns></returns>
		void load_images()
		{
			//clear controls & open dialog for user to select images
			side_previews.Controls.Clear();
			selected_image = null;
			OpenFileDialog d = new OpenFileDialog();
			d.Multiselect = true;
			//TODO: remove "All files", provide more extensive list of supported image types
			d.Filter = "Images|*.png;*.bmp;*.jpg;|All files|*";

			if (d.ShowDialog() == DialogResult.OK)
			{
				int loading_number = 1;
				p.loaded_images.Clear();

				//load all images into a list containing image data & metadata
				foreach (string image_filepath in d.FileNames)
				{
					status.Text = string.Format("Loading Pixel Data ({0}/{1})", loading_number, d.FileNames.Count());
					status.Refresh();

					pf.byte_image temp = new pf.byte_image(
						Image.FromFile(image_filepath),
						image_filepath,
						(string)pf.settings[setting.output_path],
						progress_bar,
						status);

					p.loaded_images.Add(temp);

					loading_number++;
				}

				//display images in preview window(s)
				if (p.loaded_images.Count > 0)
				{
					status.Text = "Images Loaded";
					status.Refresh();

					//hide side panel if only one image is loaded
					if (p.loaded_images.Count <= 1) tableImagePreview.ColumnStyles[0].Width = 0;
					else tableImagePreview.ColumnStyles[0].Width = 200;

					for (int i = 0; i < p.loaded_images.Count; i++)
					{
						//display the first image in the main preview area
						if (i == 0)
						{
							display_image(p.loaded_images[i].image, preview);
							selected_image = p.loaded_images[i];
						}
						//display all loaded images in the side panel
						if (p.loaded_images.Count > 1)
						{
							PictureBox temp = new PictureBox();
							temp.Tag = p.loaded_images[i];
							temp.Click += side_preview_Click;
							temp.Width = side_previews.Width - scrollbar_width;
							temp.Height = side_previews.Width - scrollbar_width;

							side_previews.Controls.Add(temp);
							display_image(p.loaded_images[i].image, temp);
						}
					}

					load_palettes();
					create_start_positions();
					foreach (pf.byte_image image in p.loaded_images) load_image_settings(image);
				}
			}
		}

		/// <summary>
		/// Displays provided image into preview window, scaling it up as appropriate.
		/// </summary>
		/// <param name="image">Image to be displayed</param>
		/// <param name="p">PictureBox image will be displayed in</param>
		void display_image(Image image, PictureBox p)
		{
			Bitmap bmp = new Bitmap(p.Width, p.Height);
			using (Graphics g = Graphics.FromImage(bmp))
			{
				g.InterpolationMode = InterpolationMode.NearestNeighbor;
				g.PixelOffsetMode = PixelOffsetMode.Half;
				g.DrawImage(image, new Rectangle(Point.Empty, bmp.Size));
			}
			p.Image = bmp;
		}

		/// <summary>
		/// Loads various UI elements with last saved image values.
		/// </summary>
		/// <param name="selected">selected image</param>
		void load_image_settings(pf.byte_image selected)
		{
			if (selected == null) return;
			Debug.Log("Loading image settings...");

			//load up UI elements with settings
			lblSelectedPicture.Text = selected.image_file;

			string key = selected.image_hash;
			if(pf.settings[key] == null) return;

			pf.image_settings s = new pf.image_settings(key, pf.settings[key].ToString());

			//save image metadata to settings in memory
			s.load_image_data(selected);
			pf.set_setting(key, s);

			cbStartPos.SelectedIndex = s.StartPosIndex;
			txtStartPos.Text = s.StartString;

			cbDig.Checked = s.dig;
			cbBuild.Checked = s.build;
			cbPlace.Checked = s.place;
			cbQuery.Checked = s.query;

			txtCommentDig.Text = s.digComment;
			txtCommentBuild.Text = s.buildComment;
			txtCommentPlace.Text = s.placeComment;
			txtCommentQuery.Text = s.queryComment;

			txtOutFilePath.Text = selected.csv_file;
			txtOutPath.Text = selected.csv_filepath.Replace(selected.csv_file, "");
		}

		/// <summary>
		/// Generates a list of all the different colors for all the currently loaded images
		/// </summary>
		/// <returns></returns>
		void load_palettes()
		{
			List<Color> palette = new List<Color>();
			if (p.loaded_images != null && p.loaded_images.Count > 0)
			{
				foreach (pf.byte_image image in p.loaded_images)
				{
					foreach (Color c in image.palette)
					{
						if (!palette.Contains(c)) palette.Add(c);
					}
				}
			}
			create_designations(palette);
		}

		/// <summary>
		/// Creates the possible color designations for all the currently loaded images
		/// </summary>
		/// <returns></returns>
		void create_designations(List<Color> palette)
		{
			color_designation temp;
			int color_max = 32;
			int color_count = 0;

			if (palette.Count >= color_max)
			{
				string message = string.Format("You've loaded an image with lots of unique colors ({1}). It could severely impact the performance of the program. Do you want to cap the total number of colors at {0}?", color_max, palette.Count);
				DialogResult result = MessageBox.Show(message, "You've delved too greedily and too deep.", MessageBoxButtons.YesNoCancel);

				if (result == DialogResult.No)
				{
					color_max = palette.Count;
				}
				else if (result == DialogResult.Cancel)
				{
					return;
				}
			}

			progress_bar.Value = 0;
			progress_bar.Maximum = color_max;

			listDesignations.Controls.Clear();

			foreach (Color c in palette)
			{
				if (progress_bar.Value < color_max)
				{

					if (c.A != 255) continue; //skip transparent colors (will throw off count)

					temp = new color_designation(c);
					
					listDesignations.Controls.Add(temp);

					status.Text = string.Format("Loading designation {0}/{1}", ++color_count, color_max);
					status.Refresh();

					progress_bar.Value += 1;
				}

			}

			progress_bar.Value = progress_bar.Maximum;
			status.Text = "Images Loaded";
			status.Refresh();

			Debug.Log("test: ");
			Debug.Log("total colors loaded: " + progress_bar.Value);
		}

		/// <summary>
		/// Creates some pre-defined starting positions for the preview image
		/// </summary>
		/// <returns></returns>
		void create_start_positions()
		{

			AutoCompleteStringCollection source_startpos = new AutoCompleteStringCollection();
			source_startpos.AddRange(p.start_positions.ToArray<string>());
			cbStartPos.DataSource = p.start_positions;
			cbStartPos.AutoCompleteCustomSource = source_startpos;
			cbStartPos.SelectedIndex = 1;
			update_start_positions();
			
		}

		/// <summary>
		/// Sets & fills start position combobox & text with appropriate values
		/// </summary>
		void update_start_positions()
		{
			if (selected_image == null) return;

			if (cbStartPos.SelectedIndex == 0) txtStartPos.Enabled = true;
			else txtStartPos.Enabled = false;

			Image img = selected_image.image;
			switch (cbStartPos.SelectedValue.ToString())
			{
				case "Custom": break;
				case "Center": txtStartPos.Text = String.Format("start({0};{1}; Start: Center)", Math.Ceiling((double)img.Width / 2), Math.Ceiling((double)img.Height / 2)); break;
				case "Top-Left": txtStartPos.Text = String.Format("start({0};{1}; Start: Top-Left)", 0, 0); break;
				case "Top-Right": txtStartPos.Text = String.Format("start({0};{1}; Start: Top-Right)", img.Width, 0); break;
				case "Bottom-Left": txtStartPos.Text = String.Format("start({0};{1}; Start: Bottom-Left)", 0, img.Height); break;
				case "Bottom-Right": txtStartPos.Text = String.Format("start({0};{1}; Start: Bottom-Right)", img.Width, img.Height); break;
				default: break;
			}
		}

		#endregion loading

		#region saving
		
		/// <summary>
		/// saves last output path to the settings hashfile, then writes all settings to a file
		/// </summary>
		void save_settings()
		{
			pf.set_setting(setting.output_path, txtOutPath.Text);
			p.write_settings();
		}

		/// <summary>
		/// saves per-image settings to the settings hashtable
		/// </summary>
		/// <param name="i"></param>
		void save_image_settings(pf.byte_image i)
		{
			StringBuilder description = new StringBuilder();
			description.Append(string.Format("{0}|{1}|", cbStartPos.SelectedIndex, util.encode(txtStartPos.Text)));
			if (cbDig.Checked) description.Append(string.Format("#dig {0}|", util.encode(txtCommentDig.Text)));
			if (cbBuild.Checked) description.Append(string.Format("#build {0}|", util.encode(txtCommentBuild.Text)));
			if (cbPlace.Checked) description.Append(string.Format("#place {0}|", util.encode(txtCommentPlace.Text)));
			if (cbQuery.Checked) description.Append(string.Format("#query {0}|", util.encode(txtCommentQuery.Text)));

			//save image metadata to settings in memory
			pf.image_settings value = new pf.image_settings(i.image_hash, description.ToString());
			value.load_image_data(i);
			pf.set_setting(i.image_hash, value);
		}

		#endregion saving

		#region event handlers

		private void btnImageChooser_Click(object sender, EventArgs e)
		{
			load_images();
			load_image_settings(selected_image);

			txtOutFilePath.Text = "";
			txtOutPath.Text = pf.settings[setting.output_path].ToString();
		}

		private void btnSingleCSV_Click(object sender, EventArgs e)
		{
			if (p.loaded_images.Count == 0) return;

			//save any last changes made before clicking
			save_image_settings(selected_image);

			pf.image_settings img_settings = (pf.image_settings)pf.settings[selected_image.image_hash];
			foreach (KeyValuePair<string, string> kvp in img_settings.modelist)
			{
				string mode = kvp.Key;
				string description = kvp.Value;
				p.build_csv(p.loaded_images, txtOutPath.Text, selected_image.csv_file, mode, description, progress_bar, status);
			}

			//txtOutFilePath.Text = "#mode-" + selected_image.csv_file;

			save_settings();
		}

		private void btnMultiCSV_Click(object sender, EventArgs e)
		{
			if (p.loaded_images.Count == 0) return;

			//save any last changes made before clicking
			save_image_settings(selected_image);

			p.batch_csv(p.loaded_images, txtOutPath.Text, progress_bar, status);

			//txtOutPath.Text = pf.settings[setting.output_path].ToString();

			save_settings();
		}

		private void side_preview_Click(object sender, EventArgs e)
		{
			save_image_settings(selected_image);
			PictureBox p = (PictureBox)sender;
			pf.byte_image selected = (pf.byte_image)p.Tag;
			selected_image = selected;
			display_image(selected.image, preview);
			Debug.Log(selected.image_path + " selected. hash: " + selected.image_hash);
			update_start_positions();
			load_image_settings(selected_image);
		}

		private void cbStartPos_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (p.loaded_images.Count == 0) return;
			update_start_positions();
		}
		
		private void txtOutFilePath_DoubleClick(object sender, EventArgs e)
		{
			OpenFileDialog d = new OpenFileDialog();
			if (d.ShowDialog() == DialogResult.OK) txtOutPath.Text = d.SafeFileName;
		}

		private void txtOutPath_DoubleClick(object sender, EventArgs e)
		{
			//TODO: open directory
			FolderBrowserDialog d = new FolderBrowserDialog();
			if (d.ShowDialog() == DialogResult.OK) txtOutPath.Text = d.SelectedPath;
		}

		private void txtStartPos_TextChanged(object sender, EventArgs e)
		{
			//TODO: validate text
		}

		private void listColorDesignations_SizeChanged(object sender, EventArgs e)
		{
			//FlowLayoutPanel f = (FlowLayoutPanel)sender;

			//foreach (color_designation c in f.Controls)
			//{
			//	c.Width = f.Width;
			//}
		}

		private void btnTest_Click(object sender, EventArgs e)
		{
			load_images();
			tabPanel.SelectedIndex = 1; //switch to color designation tab
		}

		#endregion event handlers

	}
}
