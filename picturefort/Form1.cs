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
 ------------------------------* progressbar / status info
 -------------------------* persistent settings
 ---------------------* default color designations
 ---------------------* custom folder for csv files
 ------------------------------* batch image processing
 ------------------------------* multiple z-level designations
 * per-image persistent descriptions
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
			btnSingleCSV.Enabled = false;
			btnMultiCSV.Enabled = false;
			cbStartPos.SelectedIndex = 1;
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			p = new pf(progress_bar);
			p.read_settings();
		}

		/// <summary>
		/// Generates a list of all the different colors for all the currently loaded images
		/// </summary>
		/// <returns></returns>
		public bool load_palettes()
		{
			pf.palette.Clear();
			listColorDesignations.Controls.Clear();
			if (pf.loaded_images != null && pf.loaded_images.Count > 0)
			{
				foreach (pf.byte_image image in pf.loaded_images)
				{
					foreach (Color c in image.palette)
					{
						if (!pf.palette.Contains(c)) pf.palette.Add(c);
					}
				}
			}
			create_designations();
			return true;
		}

		/// <summary>
		/// Writes each color designation key and value to the settings hashtable
		/// </summary>
		/// <returns></returns>
		public bool save_palette()
		{

			foreach (TextBox txt in listColorDesignations.Controls)
			{
				string key = pf.convert_color(txt.BackColor);
				string value = txt.Text;
				pf.set_setting(key, value);
			}
			p.write_settings();
			return true;
		}

		/// <summary>
		/// Creates a file chooser dialog, loads necessary data from each image (byte_image.get_pixel_data), and displays the top image in the preview window
		/// </summary>
		/// <returns></returns>
		public bool load_images()
		{
			OpenFileDialog d = new OpenFileDialog();

			pf.settings[setting.restore_directory] = d.RestoreDirectory;
			d.Multiselect = true;
			//TODO: remove all files, provide more extensive list of image types
			d.Filter = "Images|*.png;*.bmp;*.jpg;|All files|*";

			if (d.ShowDialog() == DialogResult.OK)
			{
				int loading_number = 1;
				pf.loaded_images.Clear();

				foreach (string image_filepath in d.FileNames)
				{
					pf.byte_image temp = new pf.byte_image(
						Image.FromFile(image_filepath),
						image_filepath,
						(string)pf.settings[setting.csv_path],
						progress_bar);

					pf.loaded_images.Add(temp);

					status.Text = string.Format("Loading Pixel Data ({0}/{1})", loading_number, d.FileNames.Count());
					status.Refresh();

					loading_number++;
				}

				if (pf.loaded_images.Count > 0) display_image(pf.loaded_images[0].image, preview);

			}

			return true;
		}

		/// <summary>
		/// Creates the possible color designations for all the currently loaded images
		/// </summary>
		/// <returns></returns>
		public bool create_designations()
		{
			foreach (Color c in pf.palette)
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

			btnSingleCSV.Enabled = true;
			btnMultiCSV.Enabled = true;
		}

		private void btnSingleCSV_Click(object sender, EventArgs e)
		{
			save_palette();
			btnSingleCSV.Enabled = false;
			
			p.multi_csv(pf.loaded_images, "./test.csv", progress_bar, status);
		}

		private void btnMultiCSV_Click(object sender, EventArgs e)
		{
			save_palette();
			btnMultiCSV.Enabled = false;

			p.batch_csv(pf.loaded_images, "./test/", progress_bar, status);
		}
		private void cbStartPos_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbStartPos.SelectedIndex == 0) txtStartPos.Enabled = true;
			else txtStartPos.Enabled = false;
			//TODO: update text box with coordinates when index changes
		}
		
		private void txtOutFilePath_DoubleClick(object sender, EventArgs e)
		{
			//TODO: open directory
		}

		private void txtOutPath_DoubleClick(object sender, EventArgs e)
		{
			//TODO: open directory
		}



		#endregion Event Handlers
	}
}
