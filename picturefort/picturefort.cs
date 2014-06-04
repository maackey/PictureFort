using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

namespace picturefort
{

	public enum setting
	{
		csv_path,
		image_batch_path,
		restore_directory,

	}


	static class picturefort
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}

	}

	public class pf
	{
		

		public const string settingsfilepath = "./picturefort.ini";
		public static Hashtable settings = new Hashtable();
		public static List<byte_image> loaded_images = new List<byte_image>();
		public static ProgressBar progress;

		public static List<Color> palette = new List<Color>();
		public static Dictionary<string, string> designations_dig = new Dictionary<string, string>();
		public static Dictionary<string, string> designations_build = new Dictionary<string, string>();
		public static Dictionary<string, string> designations_place = new Dictionary<string, string>();
		public static Dictionary<string, string> designations_query = new Dictionary<string, string>();

		public pf(ProgressBar p)
		{
			progress = p;

			/*
			 * dig     Designations menu (d)
			 * build   Build menu (b)
			 * place   Place stockpiles menu (p)
			 * query   Set building tasks/prefs menu (q)
			 * 
			 * */


			#region designations
			//designations
			designations_dig.Add("Mine", "d");
			designations_dig.Add("Channel", "h");
			designations_dig.Add("Remove Up Stairs/Ramps", "z");
			designations_dig.Add("Upward Stairway", "u");
			designations_dig.Add("Downward Stairway", "j");
			designations_dig.Add("Up/Down Stairway", "i");
			designations_dig.Add("Upward Ramp", "r");
			designations_dig.Add("Chop Down Trees", "t");
			designations_dig.Add("Gather Plants", "p");
			designations_dig.Add("Smooth Stone", "s");
			designations_dig.Add("Engrave Stone", "e");
			designations_dig.Add("Carve Fortifications", "a");
			designations_dig.Add("Carve Track", "T");
			designations_dig.Add("Toggle Engravings", "v");
			designations_dig.Add("Remove Designation", "x");
			designations_dig.Add("Remove Construction", "n");

			//bulk designations (b)
			designations_dig.Add("Reclaim Items/Buildings", "bc");
			designations_dig.Add("Forbid Items/Buildings", "bf");
			designations_dig.Add("Melt Items", "bm");
			designations_dig.Add("Remove Melt", "bM");
			designations_dig.Add("Dump Items", "bd");
			designations_dig.Add("Remove Dump", "bD");
			designations_dig.Add("Hide Items/Buildings", "bh");
			designations_dig.Add("Unhide Items/Buildings", "bH");

			//traffic areas (o)
			designations_dig.Add("High Traffic Area", "oh");
			designations_dig.Add("Normal Traffic Area", "on");
			designations_dig.Add("Low Traffic Area", "ol");
			designations_dig.Add("Restricted Traffic Area", "or");

			// /-+*: Move between type of areas to change with QqwW.
			// QqwW: Change cost by -5/-1/1/5.
			#endregion designations

			#region buildings
			//buildings
			designations_build.Add("Armor Stand", "a");
			designations_build.Add("Bed", "b");
			designations_build.Add("Seat", "c");
			designations_build.Add("Burial Receptacle", "n");
			designations_build.Add("Door", "d");
			designations_build.Add("Floodgate", "x");
			designations_build.Add("Floor Hatch", "H");
			designations_build.Add("Wall Grate", "W");
			designations_build.Add("Floor Grate", "G");
			designations_build.Add("Vertical Bars", "B");
			designations_build.Add("Floor Bars", "Alt + b");
			designations_build.Add("Cabinet", "f");
			designations_build.Add("Container", "h");
			designations_build.Add("Kennels", "k");
			designations_build.Add("Farm Plot", "p");
			designations_build.Add("Weapon Rack", "r");
			designations_build.Add("Statue", "s");
			designations_build.Add("Table", "t");
			designations_build.Add("Paved Road", "o");
			designations_build.Add("Dirt Road", "O");
			designations_build.Add("Bridge", "g");
			designations_build.Add("Well", "l");

			//Siege Engines (i)
			designations_build.Add("Ballista", "ib");
			designations_build.Add("Catapult", "ic");

			//Workshops (w)
			designations_build.Add("Leather works", "we");
			designations_build.Add("Quern", "wq");
			designations_build.Add("Millstone", "wM");
			designations_build.Add("Loom", "wo");
			designations_build.Add("Clothier's Shop", "wk");
			designations_build.Add("Bowyer's Workshop", "wb");
			designations_build.Add("Carpenter's Workshop", "wc");
			designations_build.Add("Metalsmith's Forge", "wf");
			designations_build.Add("Magma Forge", "wv");
			designations_build.Add("Jeweler's Workshop", "wj");
			designations_build.Add("Mason's Workshop", "wm");
			designations_build.Add("Butcher's Shop", "wu");
			designations_build.Add("Tanner's Shop", "wn");
			designations_build.Add("Craftsdwarf's Workshop", "wr");
			designations_build.Add("Siege Workshop", "ws");
			designations_build.Add("Mechanic's Workshop", "wt");
			designations_build.Add("Still", "wl");
			designations_build.Add("Farmer's Workshop", "ww");
			designations_build.Add("Kitchen", "wz");
			designations_build.Add("Fishery", "wh");
			designations_build.Add("Ashery", "wy");
			designations_build.Add("Dyer's Shop", "wd");
			designations_build.Add("Soap Maker's Workshop", "wS");

			//Furnaces (e)
			designations_build.Add("Wood Furnce", "ew");
			designations_build.Add("Smelter", "es");
			designations_build.Add("Glass Furnace", "eg");
			designations_build.Add("Kiln", "ek");
			designations_build.Add("Magma Smelter", "el");
			designations_build.Add("Magma Glass Furnace", "ea");
			designations_build.Add("Magma Kiln", "en");

			//buildings (cont.)
			designations_build.Add("Glass Window", "y");
			designations_build.Add("Gem Window", "Y");

			//Wall/Floor/Stairs (C)
			designations_build.Add("Wall", "Cw");
			designations_build.Add("Floor", "Cf");
			designations_build.Add("Ramp", "Cr");
			designations_build.Add("Up Stair", "Cu");
			designations_build.Add("Down Stair", "Cd");
			designations_build.Add("Up/Down Stair", "Cx");
			designations_build.Add("Fortification", "CF");

			//buildings (cont.)
			designations_build.Add("Trade Depot", "D");

			//Traps/Levers (T)
			designations_build.Add("Stone-Fall Trap", "Ts");
			designations_build.Add("Weapon Trap", "Tw");
			designations_build.Add("Lever", "Tl");
			designations_build.Add("Pressure Plate", "Tp");
			designations_build.Add("Cage Trap", "Tc");
			designations_build.Add("Upright Spear/Spike", "TS");

			//Machine Components (M)
			designations_build.Add("Screw Pump", "Ms");
			designations_build.Add("Water Wheel", "Mw");
			designations_build.Add("Windmill", "Mm");
			designations_build.Add("Gear Assembly", "Mg");
			designations_build.Add("Horizontal Axle", "Mh");
			designations_build.Add("Vertical Axle", "Mv");

			//buildings (cont.)
			designations_build.Add("Support", "S");
			designations_build.Add("Animal Trap", "m");
			designations_build.Add("Restraint", "v");
			designations_build.Add("Cage", "j");
			designations_build.Add("Archery Target", "A");
			designations_build.Add("Traction Bench", "R");
			#endregion buildings

			#region stockpiles
			//stockpiles
			designations_place.Add("Animal", "a");
			designations_place.Add("Food", "f");
			designations_place.Add("Furniture Storage", "u");
			designations_place.Add("Graveyard", "y");
			designations_place.Add("Refuse", "r");
			designations_place.Add("Stone", "s");
			designations_place.Add("Wood", "w");
			designations_place.Add("Gem", "e");
			designations_place.Add("Bar/Block", "b");
			designations_place.Add("Cloth", "h");
			designations_place.Add("Leather", "l");
			designations_place.Add("Ammo", "z");
			designations_place.Add("Coins", "n");
			designations_place.Add("Finished Goods", "g");
			designations_place.Add("Weapons", "p");
			designations_place.Add("Armor", "d");
			designations_place.Add("Customer Stockpile", "c");
			//designations_place.Add("Custom Settings", "t");
			//designations_place.Add("Remove Designation", "x");

			// /*: Reserved Barrels
			// -:+: Reserved Bins
			// Enter: Select
			#endregion stockpiles

			#region query
			//building tasks/preferences
			designations_query.Add("Make Room", "r+");

			#endregion query


		}


		#region settings io

		public bool read_settings()
		{
			settings.Clear();

			try
			{
				StreamReader f = new StreamReader(settingsfilepath);
				string line = "";

				while (line != null)
				{
					line = f.ReadLine();
					if (line == null) break;

					//support // comments
					if (line.Contains("//"))
					{
						int endpos = line.Length - line.IndexOf("//");
						line = line.Substring(0, endpos);
					}

					if (line.Trim().StartsWith("#"))
					{
						//check color designations
						load_colorsetting(line);
					}
					else
					{
						//check manual settings
						foreach (setting s in settings) load_setting(s, line);
					}

				}

				f.Close();
				f.Dispose();
				return true;
			}
			catch (FileNotFoundException e)
			{
				Console.WriteLine("File not found. Continue on." + e.Message);
				return false;
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception: " + e.Message);
				return false;
			}
		}

		public bool write_settings()
		{
			try
			{
				StreamWriter f = new StreamWriter(settingsfilepath);
				foreach (DictionaryEntry s in settings)
				{
					string padding = s.Key + ":";
					f.WriteLine(string.Format("{0, -20} {1}", padding, s.Value));
					Console.WriteLine(string.Format("write key:{0}- value:{1}-", s.Key, s.Value));
				}

				f.Close();
				f.Dispose();
				return true;
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception: " + e.Message);
				return false;
			}
		}

		public static void set_setting(object key, object value)
		{
			if (settings[key] == null) settings.Add(key, value);
			else settings[key] = value;
		}

		private bool load_setting(setting s, string line)
		{
			string key = s.ToString() + ":";
			if (line.Trim().StartsWith(key))
			{
				string value = line.Replace(key, "").Trim();
				set_setting(s, value);
				return true;
			}
			return false;
		}

		private bool load_colorsetting(string line)
		{
			Regex regcolor = new Regex("#[0-9a-fA-F]{8}:");
			if (regcolor.Match(line).Success)
			{
				string key = line.Substring(0, line.IndexOf(":")).ToUpper().Trim();
				string value = line.Substring(line.IndexOf(":") + 1).Trim();
				set_setting(key, value);
				return true;
			}
			return false;
		}

		#endregion


		public static string convert_color(Color c)
		{
			return string.Format("#{0}{1}{2}{3}", c.A.ToString("X2"), c.R.ToString("X2"), c.G.ToString("X2"), c.B.ToString("X2"));
		}

		public bool batch_csv(List<byte_image> images, string csv_path = "./csv", ProgressBar p = null)
		{
			foreach (byte_image image in images)
			{
				string filepath = csv_path.Trim('/').Trim('\\') + "/" + image.csv_file;
				single_csv(image, filepath, p, null);
			}
			return true;
		}

		public bool single_csv(byte_image image, string csv_filepath = null, ProgressBar progress = null, Button b = null)
		{
			List<byte_image> imagelist =  new List<byte_image>();
			imagelist.Add(image);
			return multi_csv(imagelist, csv_filepath, progress, b);
		}

		public bool multi_csv(List<byte_image> images, string csv_filepath = null, ProgressBar progress = null, Button b = null)
		{

			if (images == null || images.Count == 0) return false;

			string status;

			//check images to make sure they are the same size, prepare progressbar for multiple images
			status = "Preparing CSV";
			if (b != null)
			{
				b.Text = status;
				b.Refresh();
			}
			Console.WriteLine(status);
			int prediction = images[0].image.Width * images[0].image.Height;

			if (images.Count > 1)
			{
				byte_image previous = null;
				prediction = 0;

				if (progress != null)
				{
					progress.Maximum = images.Count;
					progress.Value = 0;
				}

				foreach (byte_image current in images)
				{
					if (progress != null)
					{
						progress.Value++;
						prediction += current.image.Width * current.image.Height;
						progress.Refresh();
					}

					if (previous == null)
					{
						previous = current;
						continue;
					}

					if (previous.image.Size != current.image.Size)
					{
						MessageBox.Show("Images must be the same size for multilevel templates");
						Console.WriteLine("images do not match dimensions");
						if (progress != null) progress.Value = 0;
						return false;
					}

				}
			}
			

			//generate csv -- use stringbuilder to create file contents before writing to file
			status = "Generating CSV";
			Console.WriteLine(status);

			if (progress != null)
			{
				progress.Maximum = prediction;
				progress.Value = 0;
			}

			StringBuilder csv_builder = new StringBuilder();
			//TODO: fix description
			csv_builder.Append("#dig blah blah blah\n");

			int image_index = 1;

			foreach (byte_image current in images)
			{

				if (b != null)
				{
					b.Text = string.Format("{0} level ({1}/{2})", status, image_index, images.Count);
					b.Refresh();
				}
				Queue<Color> color_queue = new Queue<Color>(current.image_array);

				for (int y = 0; y < current.image.Height; y++)
				{
					for (int x = 0; x < current.image.Width; x++)
					{
						if (progress != null)
						{
							progress.Value++;
							progress.Refresh();
						}

						string key = convert_color(color_queue.Dequeue());
						//handle unkown values by writing blanks, otherwise write the setting value of the color
						if (settings[key] == null || settings[key].ToString() == "") csv_builder.Append(" ,");
						else csv_builder.Append(string.Format("{0},", settings[key]));
					}
					//remove last ,
					csv_builder = csv_builder.Remove(csv_builder.Length - 1, 1);
					//append # to the end of the line
					csv_builder.Append("#\n");
				}

				
				if (image_index == images.Count)
				{
					//if this is the last image, fill bottom with #'s
					for (int x = 0; x < current.image.Width; x++)
					{
						csv_builder.Append("##");
					}
				}
				else
				{
					//otherwise fill bottom with #>##...# to indicate next level down
					csv_builder.Append("#>");
					for (int x = 1; x < current.image.Width; x++)
					{
						csv_builder.Append("##");
					}
					csv_builder.Append("\n");
				}

				image_index++;

			}

			//Console.WriteLine(csv_builder.ToString());

			//write file
			try
			{
				if (csv_filepath == null)
				{
					if (images[0].csv_filepath != null) csv_filepath = images[0].csv_filepath;
					else return false;
				}
				Console.WriteLine("Writing file: " + csv_filepath);
				StreamWriter f = new StreamWriter(csv_filepath);
				f.Write(csv_builder.ToString());
				f.Close();
				f.Dispose();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return false;
			}

			if (b != null)
			{
				b.Text = "CSV Generated";
				b.Refresh();
			}

			return true;
		}

		public class byte_image
		{

			public Bitmap image;
			public List<Color> palette = new List<Color>();
			public Queue<Color> image_array = new Queue<Color>();
			public string csv_filepath;
			public string csv_file;

			public byte_image(Image raw_image, string image_filepath, string csv_path = null, ProgressBar p = null)
			{
				int fstart = image_filepath.LastIndexOf("/");
				if (fstart == -1) fstart = image_filepath.LastIndexOf("\\");

				string image_file = image_filepath.Substring(fstart + 1);
				string image_extension = image_file.Substring(image_file.LastIndexOf("."));

				csv_file = image_file.Replace(image_extension, ".csv");

				if (csv_path == null || csv_path == "")
				{
					csv_filepath = image_filepath.Replace(image_file, csv_file);
				}
				else
				{
					if (!Directory.Exists(csv_path)) Directory.CreateDirectory(csv_path);
					csv_path = csv_path.TrimEnd('/').TrimEnd('\\');
					csv_filepath = string.Format("{0}/{1}", csv_path, csv_file);
				}

				//Console.WriteLine(string.Format("image file:{0}, csv file:{1}, image filepath:{2}", image_file, csv_file, image_filepath));
				Console.WriteLine(csv_filepath);

				image = new Bitmap(raw_image);
				get_pixel_data(p);
			}

			public bool get_pixel_data(ProgressBar progress = null)
			{

				if (progress != null)
				{
					progress.Maximum = image.Height * image.Width;
					progress.Value = 0;
				}

				Color pixelcolor = Color.FromArgb(0, 0, 0, 0);

				for (int y = 0; y < image.Height; y++)
				{
					for (int x = 0; x < image.Width; x++)
					{
						if (progress != null)
						{
							progress.Value++;
							progress.Refresh();
						}

						pixelcolor = image.GetPixel(x, y);
						image_array.Enqueue(pixelcolor);
						if (palette.Contains(pixelcolor)) continue;
						else palette.Add(pixelcolor);
					}
				}

				foreach (Color c in palette)
				{
					//generate list of designations
					//populate list with setting entries
				}

				return true;
			}

		}

	}

}
