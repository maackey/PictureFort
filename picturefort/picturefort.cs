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

		public List<byte_image> loaded_images = new List<byte_image>();
		public List<Color> palette = new List<Color>();

		public List<string> start_positions = new List<string>();

		public Dictionary<string, string> designations_dig = new Dictionary<string, string>();
		public Dictionary<string, string> designations_build = new Dictionary<string, string>();
		public Dictionary<string, string> designations_place = new Dictionary<string, string>();
		public Dictionary<string, string> designations_query = new Dictionary<string, string>();

		public pf(ProgressBar p)
		{

			/*
			 * dig     Designations menu (d)
			 * build   Build menu (b)
			 * place   Place stockpiles menu (p)
			 * query   Set building tasks/prefs menu (q)
			 * 
			 * */

			#region start positions

			start_positions.Add("Custom");
			start_positions.Add("Center");
			start_positions.Add("Top-Left");
			start_positions.Add("Top-Right");
			start_positions.Add("Bottom-Left");
			start_positions.Add("Bottom-Right");
			
			#endregion

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

		#region helper functions

		/// <summary>
		/// Converts a given color to the string format used in the settings keys (#ARGB)
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		public static string convert_color(Color c)
		{
			return string.Format("#{0}{1}{2}{3}", c.A.ToString("X2"), c.R.ToString("X2"), c.G.ToString("X2"), c.B.ToString("X2"));
		}

		/// <summary>
		/// //TODO: lat user's choose format for the name of the autogenerated csv files. 
		/// </summary>
		/// <param name="format"></param>
		/// <returns></returns>
		public static string csv_name_format(string format)
		{

			string formatted_name = format;
			//type: dig/build/place/query
			//image: filename
			//level count
			//orientation
			//image dimensions
			//colors?
			//etc.


			return formatted_name;
		}

		#endregion

		#region settings io

		/// <summary>
		/// Loads the settings hashtable from the settings file
		/// </summary>
		/// <returns></returns>
		public bool read_settings()
		{
			settings.Clear();
			set_setting(setting.csv_path, "");

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

		/// <summary>
		/// Writes the settings hashtable to the settings file
		/// </summary>
		/// <returns></returns>
		public bool write_settings()
		{
			try
			{
				StreamWriter f = new StreamWriter(settingsfilepath);
				Console.WriteLine("Writing settings");
				foreach (DictionaryEntry s in settings)
				{
					string key = s.Key + ": ";
					if (key.StartsWith("#")) f.WriteLine(key + s.Value);
					else f.WriteLine(string.Format("{0, -20} {1}", key, s.Value));
					Console.WriteLine(string.Format("key:{0}- value:{1}-", s.Key, s.Value));
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

		/// <summary>
		/// Creates an entry for a setting if the key doesn't exist.
		/// Updates an existing entry otherwise.
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		public static void set_setting(object key, object value)
		{
			if (settings[key] == null) settings.Add(key, value);
			else settings[key] = value;
		}

		/// <summary>
		/// Checks if line is the provided setting. If so, it will set the setting in memory
		/// </summary>
		/// <param name="s"></param>
		/// <param name="line"></param>
		/// <returns></returns>
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

		/// <summary>
		/// Checks if line is a color designation. If so, it will set the setting in memory
		/// </summary>
		/// <param name="line"></param>
		/// <returns></returns>
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

		#region generate csv's

		/// <summary>
		/// Creates a template for each image in the list, in the designated directory. 
		/// </summary>
		/// <param name="images">List of images to be converted</param>
		/// <param name="csv_path">Path where the generated files will be placed</param>
		/// <param name="progress">ProgressBar object to track the function's progress</param>
		/// <param name="status">Label object to provide a visual indicator of the function's status</param>
		/// <returns></returns>
		public bool batch_csv(List<byte_image> images, string csv_path, string description, ProgressBar progress = null, Label status = null)
		{
			try
			{
				//if path doesn't exist, use the path of the first image
				if (csv_path == "") csv_path = images[0].csv_filepath.Replace(images[0].csv_file, "");
				//create the directory if it doesn't exist
				if (!Directory.Exists(csv_path)) Directory.CreateDirectory(csv_path);

				foreach (byte_image image in images)
				{
					string filepath = string.Format("{0}/{1}", csv_path.Trim('/').Trim('\\'), image.csv_file);
					single_csv(image, filepath, description, progress, status);
				}
				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show("Error in batch_csv using path: " + csv_path);
				Console.WriteLine(e.Message);
				return false;
			}
		}

		/// <summary>
		/// Creates a template for a single image.
		/// </summary>
		/// <param name="image"></param>
		/// <param name="csv_filepath"></param>
		/// <param name="progress"></param>
		/// <param name="label"></param>
		/// <returns></returns>
		public bool single_csv(byte_image image, string csv_filepath, string description, ProgressBar progress = null, Label label = null)
		{
			List<byte_image> imagelist =  new List<byte_image>();
			imagelist.Add(image);
			return build_csv(imagelist, csv_filepath, image.csv_file, description, progress, label);
		}

		/// <summary>
		/// Creates a multi-z-level template with the provided list of images.
		/// </summary>
		/// <param name="images">List of images -- one for each z-level. Must be the same dimensions</param>
		/// <param name="csv_path">Output file path for the template</param>
		/// <param name="progress">ProgressBar object to track the function's progress</param>
		/// <param name="status">Label object to provide a visual indicator of the function's status</param>
		/// <returns></returns>
		public bool build_csv(List<byte_image> images, string csv_path, string filename, string description, ProgressBar progress = null, Label status = null)
		{

			if (images == null || images.Count == 0) return false;

			string status_message;
			int prediction = images[0].image.Width * images[0].image.Height;
			string template_type = description.Substring(0, description.IndexOf(" ")).Replace("#", "") + "-";

			//check images to make sure they are the same size, prepare progressbar for multiple images
			#region if multiple images

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

			#endregion

			#region generate csv

			//generate csv -- use stringbuilder to create file contents before writing to file
			status_message = "Generating CSV";
			Console.WriteLine(status_message);

			if (progress != null)
			{
				progress.Maximum = prediction;
				progress.Value = 0;
			}

			StringBuilder csv_builder = new StringBuilder();

			csv_builder.Append(string.Format("{0}\n", description));

			int image_index = 1;

			foreach (byte_image current in images)
			{

				if (status != null)
				{
					status.Text = string.Format("Creating level ({0}/{1})", image_index, images.Count);
					status.Refresh();
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

				
				if (image_index < images.Count)
				{
					//if there are other images, write #> to indicate the start of the next level down
					csv_builder.Append("#>\n");
				}
				else
				{
					//if this is the last image, write # to indicate end of csv
					csv_builder.Append("#");
				}

				image_index++;

			}

			//Console.WriteLine(csv_builder.ToString());

			#endregion generate csv

			#region write file

			//write file
			status_message = "Writing File";
			if (status != null)
			{
				status.Text = status_message;
				status.Refresh();
			}

			try
			{

				if (csv_path == "") csv_path = ".";
				csv_path = csv_path.TrimEnd('/').TrimEnd('\\');

				if (!Directory.Exists(csv_path)) Directory.CreateDirectory(csv_path);

				if (filename == "") filename = images[0].csv_file;

				//to prevent dig/build/place/query templates from overwriting eachother
				if (filename.StartsWith(template_type)) filename.Replace(template_type, "");
				filename = string.Format("{0}{1}", template_type, filename);
				images[0].csv_file = filename.Replace(template_type, "");
				string csv_filepath = string.Format("{0}/{1}", csv_path, filename);

				Console.WriteLine(status_message + ": " + csv_filepath);
				StreamWriter f = new StreamWriter(csv_filepath);
				f.Write(csv_builder.ToString());
				f.Close();
				f.Dispose();
			}
			catch (Exception e)
			{
				MessageBox.Show(string.Format("File:{0}/{1} could not be written", csv_path, filename));
				Console.WriteLine(e.Message);
				return false;
			}

			#endregion write file

			return true;
		}

		#endregion

		public class byte_image
		{

			public Bitmap image;
			public List<Color> palette = new List<Color>();
			public Queue<Color> image_array = new Queue<Color>();
			public string csv_filepath;
			public string csv_file;


			/// <summary>
			/// Creates an image object which contains the image, a color palette, the image as an list of colors
			/// and a default path & filename for any csv created with the image.
			/// </summary>
			/// <param name="raw_image"></param>
			/// <param name="image_filepath"></param>
			/// <param name="csv_path"></param>
			/// <param name="p"></param>
			/// <param name="l"></param>
			public byte_image(Image raw_image, string image_filepath, string csv_path = null, ProgressBar p = null, Label l = null)
			{
				int fstart = image_filepath.LastIndexOf("/");
				if (fstart == -1) fstart = image_filepath.LastIndexOf("\\");

				string image_file = image_filepath.Substring(fstart + 1);
				string image_extension = image_file.Substring(image_file.LastIndexOf("."));

				csv_file = image_file.Replace(image_extension, ".csv");

				if (csv_path == null || csv_path == "")
				{
					//if provided path is null, csv_file will be created in same directory as image
					csv_filepath = image_filepath.Replace(image_file, csv_file);
				}
				else
				{
					//otherwise, create the new directory and create the csv_file in the provided directory
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

				return true;
			}

		}

	}

}
