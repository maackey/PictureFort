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
 --* multi image previews (side panel with smaller images)
 --* per-image persistent descriptions
 * image/csv rotation
 */

namespace picturefort
{
	public partial class Form1 : Form
	{
		pf p;

		public Form1()
		{
			InitializeComponent();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			p = new pf(progress_bar);
			p.read_settings();
			txtOutPath.Text = pf.settings[setting.csv_path].ToString();


			cbRecursive.Enabled = false;
		}

		/// <summary>
		/// Generates a list of all the different colors for all the currently loaded images
		/// </summary>
		/// <returns></returns>
		public bool load_palettes()
		{
			p.palette.Clear();
			listColorDesignations.Controls.Clear();
			if (p.loaded_images != null && p.loaded_images.Count > 0)
			{
				foreach (pf.byte_image image in p.loaded_images)
				{
					foreach (Color c in image.palette)
					{
						if (!p.palette.Contains(c)) p.palette.Add(c);
					}
				}
			}
			return true;
		}

		/// <summary>
		/// Writes each color designation key and value to the settings hashtable
		/// </summary>
		/// <returns></returns>
		public void save_palette()
		{

			foreach (TextBox txt in listColorDesignations.Controls)
			{
				string key = pf.convert_color(txt.BackColor);
				string value = txt.Text;
				pf.set_setting(key, value);
			}
		}

		public void save_settings()
		{
			save_palette();
			pf.set_setting(setting.csv_path, txtOutPath.Text);
			p.write_settings();
		}

		/// <summary>
		/// Creates a file chooser dialog, loads necessary data from each image (byte_image.get_pixel_data), and displays the top image in the preview window
		/// </summary>
		/// <returns></returns>
		public bool load_images()
		{
			OpenFileDialog d = new OpenFileDialog();

			d.Multiselect = true;
			//TODO: remove all files, provide more extensive list of image types
			d.Filter = "Images|*.png;*.bmp;*.jpg;|All files|*";

			if (d.ShowDialog() == DialogResult.OK)
			{
				int loading_number = 1;
				p.loaded_images.Clear();

				foreach (string image_filepath in d.FileNames)
				{
					pf.byte_image temp = new pf.byte_image(
						Image.FromFile(image_filepath),
						image_filepath,
						(string)pf.settings[setting.csv_path],
						progress_bar);

					p.loaded_images.Add(temp);

					status.Text = string.Format("Loading Pixel Data ({0}/{1})", loading_number, d.FileNames.Count());
					status.Refresh();

					loading_number++;
				}

				if (p.loaded_images.Count > 0) display_image(p.loaded_images[0].image, preview);

			}

			return true;
		}

		/// <summary>
		/// Creates the possible color designations for all the currently loaded images
		/// </summary>
		/// <returns></returns>
		public bool create_designations()
		{
			foreach (Color c in p.palette)
			{
				if (c.A != 255) continue; //skip transparent colors

				TextBox temp = new TextBox();
				temp.BackColor = c;
				if (c.R < 32 || c.G < 32 || c.B < 32) temp.ForeColor = Color.White;
				if (pf.settings[pf.convert_color(c)] != null)
					temp.Text = pf.settings[pf.convert_color(c)].ToString();

				listColorDesignations.Controls.Add(temp);
			}
			Console.WriteLine("controls: " + listColorDesignations.Controls.Count);
			return true;
		}

		/// <summary>
		/// Creates some pre-defined starting positions for the preview image
		/// </summary>
		/// <returns></returns>
		public bool create_start_positions()
		{

			AutoCompleteStringCollection source_startpos = new AutoCompleteStringCollection();
			source_startpos.AddRange(p.start_positions.ToArray<string>());
			cbStartPos.DataSource = p.start_positions;
			cbStartPos.AutoCompleteCustomSource = source_startpos;
			cbStartPos.SelectedIndex = 1;
			
			return true;
		}

		/// <summary>
		/// Displays provided image into preview window, scaling it up as appropriate.
		/// </summary>
		/// <param name="image">Image to be displayed</param>
		/// <param name="p">PictureBox image will be displayed in</param>
		private void display_image(Image image, PictureBox p)
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

		#region Event Handlers

		private void btnImageChooser_Click(object sender, EventArgs e)
		{
			load_images();
			load_palettes();
			create_designations();
			create_start_positions();

			txtOutFilePath.Text = "";
			txtOutPath.Text = pf.settings[setting.csv_path].ToString();
		}

		private void btnSingleCSV_Click(object sender, EventArgs e)
		{

			save_palette();

			if (p.loaded_images.Count == 0) return;

			string filename = txtOutFilePath.Text.Replace("#mode-", "");

			if (cbDig.Checked)
			{
				string description = string.Format("{0} {1} {2}", "#dig", txtStartPos.Text, txtCommentDig.Text);
				p.build_csv(p.loaded_images, txtOutPath.Text, filename, description, progress_bar, status);
			}
			if (cbBuild.Checked)
			{
				string description = string.Format("{0} {1} {2}", "#build", txtStartPos.Text, txtCommentBuild.Text);
				p.build_csv(p.loaded_images, txtOutPath.Text, filename, description, progress_bar, status);
			}
			if (cbPlace.Checked)
			{
				string description = string.Format("{0} {1} {2}", "#place", txtStartPos.Text, txtCommentPlace.Text);
				p.build_csv(p.loaded_images, txtOutPath.Text, filename, description, progress_bar, status);
			}
			if (cbQuery.Checked)
			{
				string description = string.Format("{0} {1} {2}", "#query", txtStartPos.Text, txtCommentQuery.Text);
				p.build_csv(p.loaded_images, txtOutPath.Text, filename, description, progress_bar, status);
			}

			filename = p.loaded_images[0].csv_file;
			txtOutFilePath.Text = "#mode-" + filename;

			save_settings();
		}

		private void btnMultiCSV_Click(object sender, EventArgs e)
		{
			//TODO: per image descriptions -- pass in array of descriptions

			save_palette();

			if (p.loaded_images.Count == 0) return;

			if (cbDig.Checked)
			{
				string description = string.Format("{0} {1} {2}", "#dig", "", "");
				p.batch_csv(p.loaded_images, txtOutPath.Text, description, progress_bar, status);
			}
			if (cbBuild.Checked)
			{
				string description = string.Format("{0} {1} {2}", "#build", "", "");
				p.batch_csv(p.loaded_images, txtOutPath.Text, description, progress_bar, status);
			}
			if (cbPlace.Checked)
			{
				string description = string.Format("{0} {1} {2}", "#place", "", "");
				p.batch_csv(p.loaded_images, txtOutPath.Text, description, progress_bar, status);
			}
			if (cbQuery.Checked)
			{
				string description = string.Format("{0} {1} {2}", "#query", "", "");
				p.batch_csv(p.loaded_images, txtOutPath.Text, description, progress_bar, status);
			}

			txtOutPath.Text = pf.settings[setting.csv_path].ToString();

			save_settings();
		}

		private void cbStartPos_SelectedIndexChanged(object sender, EventArgs e)
		{

			if (p.loaded_images.Count == 0) return;

			if (cbStartPos.SelectedIndex == 0) txtStartPos.Enabled = true;
			else txtStartPos.Enabled = false;
			
			Image img = p.loaded_images[0].image;
			switch (cbStartPos.SelectedValue.ToString())
			{
				case "Custom": break;
				case "Center": txtStartPos.Text = String.Format("start({0};{1}; Start: Center)", Math.Ceiling((double) img.Width/2), Math.Ceiling((double) img.Height/2)); break;
				case "Top-Left": txtStartPos.Text = String.Format("start({0};{1}; Start: Top-Left)", 0, 0); break;
				case "Top-Right": txtStartPos.Text = String.Format("start({0};{1}; Start: Top-Right)", img.Width, 0); break;
				case "Bottom-Left": txtStartPos.Text = String.Format("start({0};{1}; Start: Bottom-Left)", 0, img.Height); break;
				case "Bottom-Right": txtStartPos.Text = String.Format("start({0};{1}; Start: Bottom-Right)", img.Width, img.Height); break;
				default: break;
			}
		}
		
		private void txtOutFilePath_DoubleClick(object sender, EventArgs e)
		{
			//TODO: open directory
			OpenFileDialog d = new OpenFileDialog();
			if (d.ShowDialog() == DialogResult.OK) txtOutPath.Text = d.SafeFileName;
		}

		private void txtOutPath_DoubleClick(object sender, EventArgs e)
		{
			//TODO: open directory
			FolderBrowserDialog d = new FolderBrowserDialog();
			if (d.ShowDialog() == DialogResult.OK) txtOutPath.Text = d.SelectedPath;
		}



		#endregion Event Handlers

		private void txtStartPos_TextChanged(object sender, EventArgs e)
		{
			//TODO: validate text
		}
	}
}
