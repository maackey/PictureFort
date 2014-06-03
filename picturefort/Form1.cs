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
 ---------------------* persistent settings
 --------* default color designations
 -------------* custom folder for csv files
 -------------* batch image processing
 ------------------------------* multiple z-level designations
 * per-image descriptions
 * image/csv rotation
 */

namespace picturefort_multiplatform
{
	public partial class Form1 : Form
	{
		pf p;

		public Form1()
		{
			InitializeComponent();
			btnConvertImage.Enabled = false;
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			p = new pf(progress_bar);
			p.read_settings();
		}


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
			}


			return true;
		}

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

		public bool load_images()
		{
			OpenFileDialog d = new OpenFileDialog();

			pf.settings[setting.restore_directory] = d.RestoreDirectory;
			d.Multiselect = true;
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

					btnConvertImage.Text = string.Format("Loading Pixel Data ({0}/{1})", loading_number, d.FileNames.Count());
					btnConvertImage.Refresh();

					loading_number++;
				}

				btnConvertImage.Text = "Convert Image";
				btnConvertImage.Enabled = true;
				btnConvertImage.Refresh();

				if (pf.loaded_images.Count > 0) display_image(pf.loaded_images[0].image, preview);

			}

			return true;
		}

		private void btnImageChooser_Click(object sender, EventArgs e)
		{
			load_images();
			load_palettes();
		}

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

		private void btnConvertImage_Click(object sender, EventArgs e)
		{
			btnConvertImage.Text = "Generating CSV File";
			btnConvertImage.Enabled = false;
			btnConvertImage.Refresh();

			save_palette();

			p.build_csv(pf.loaded_images, null, progress_bar, btnConvertImage);

		}

	}
}
