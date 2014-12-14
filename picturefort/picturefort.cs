using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace picturefort
{

	public enum setting
	{
		output_path,
		file_format,
		clean,
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
			Application.Run(new MainWindow());
		}

	}

	public class pf
	{
		
		public const string settingsfilepath = "./picturefort.ini";
		public static Hashtable settings = new Hashtable();

		public List<byte_image> loaded_images = new List<byte_image>();

		public List<string> start_positions = new List<string>();

		public pf(ProgressBar p)
		{

			#region start positions

			start_positions.Add("Custom");
			start_positions.Add("Center");
			start_positions.Add("Top-Left");
			start_positions.Add("Top-Right");
			start_positions.Add("Bottom-Left");
			start_positions.Add("Bottom-Right");
			
			#endregion

		}

		#region helper functions

		/// <summary>
		/// Converts a given color to the string format used in the settings keys (#ARGB)
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		public static string color_string(Color c)
		{
			return string.Format("#{0}{1}{2}{3}", c.A.ToString("X2"), c.R.ToString("X2"), c.G.ToString("X2"), c.B.ToString("X2"));
		}

		/// <summary>
		/// Builds the output filename from a formatted string and image information
		/// </summary>
		/// <param name="image">Image</param>
		/// <param name="format">Format string -- defines order of variables and other static characters</param>
		/// <param name="mode">dig, build, place, query?</param>
		/// <param name="levels">how many images are being stiched together into one template</param>
		/// <param name="etc">anything else</param>
		/// <returns></returns>
		public static string csv_name_format(byte_image image, string format, string name = "", string mode="", string levels = "", string etc = "")
		{
			if (format == "") format = "[mode] - [name].csv";

			//sort in order from least likely to contain bad stuff to most likely to contain bad stuff
			format = format.Replace("[mode]", mode);
			format = format.Replace("[levels]", levels);
			format = format.Replace("[size]", string.Format("({0}x{1})", image.image.Width, image.image.Height));
			format = format.Replace("[name]", name);
			//format = format.Replace("etc", etc);

			return format;
		}

		/// <summary>
		/// creates an MD5 hash of the input string
		/// </summary>
		/// <param name="inputstring">input string to be hashed</param>
		/// <returns>hash of the input as a hexadecimal string</returns>
		static string createHash(string inputstring)
		{
			string hash = "";
			byte[] input = Encoding.UTF8.GetBytes(inputstring);
			byte[] data = MD5.Create().ComputeHash(input);

			//format byte as hexadecimal string
			foreach (byte b in data) hash += b.ToString("x2");

			return hash.ToUpper();
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
			//set defaults
			set_setting(setting.output_path, "");
			set_setting(setting.clean, "false");

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
					else if (line.Trim().ToLower().StartsWith("image"))
					{
						//check image settings
						load_imagesetting(line);
					}
					else
					{
						//check manual settings
						Array settinglist = Enum.GetValues(typeof(setting));
						foreach (setting s in settinglist) load_setting(s, line);
					}

				}

				f.Close();
				f.Dispose();
				return true;
			}
			catch (FileNotFoundException e)
			{
				Debug.Log("File not found. Coninue on.", e);
				return false;
			}
			catch (Exception e)
			{
				Debug.Log(e);
				return false;
			}
		}

		/// <summary>
		/// Writes the settings hashtable to the settings file
		/// </summary>
		/// <returns></returns>
		public bool write_settings()
		{
			Debug.Log("Writing settings");
			try
			{
				bool clean = settings[setting.clean].ToString().ToLower() == "true";
				if (!clean) settings[setting.clean] = "false";

				StreamWriter f = new StreamWriter(settingsfilepath);
				StringBuilder colors = new StringBuilder();
				StringBuilder images = new StringBuilder();
				StringBuilder manual = new StringBuilder();

				foreach (DictionaryEntry s in settings)
				{
					string key = s.Key.ToString();
					string value = s.Value.ToString();
					if (value != "" || !clean)
					{
						string writeline = "";
						if (key.StartsWith("#")) 
						{
							writeline = string.Format("{0}: {1}\n", key, value);
							colors.Append(writeline);
						}
							
						else if (key.Length == 32)
						{
							image_settings set = (image_settings)settings[key];
							string image_file = set.image_file;
							writeline = string.Format("image({2}) {0}:{1}\n", key, value, image_file);
							images.Append(writeline);
						}
						else
						{
							writeline = string.Format("{0, -20} {1}\n", key + ":", value);
							manual.Append(writeline);
						}

						//Debug.Log(string.Format("key:{0}- value:{1}-", key, value));
						//Debug.Log("writing:" + writeline.TrimEnd('\n'));
					}
				}

				f.Write("\n//General Settings\n\n");
				f.Write(manual.ToString());
				f.Write("\n//Color Designations\n\n");
				f.Write(colors.ToString());
				f.Write("\n//Image Specific Settings\n\n");
				f.Write(images.ToString());

				f.Close();
				f.Dispose();
				return true;
			}
			catch (Exception e)
			{
				Debug.Log(e);
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
		private bool load_setting(setting key, string line)
		{
			if (line.Trim().StartsWith(key + ":"))
			{
				string value = line.Replace(key + ":", "").Trim();
				set_setting(key, value);
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
			Regex regcolor = new Regex("#[0-9A-F]{8}:", RegexOptions.IgnoreCase);
			if (regcolor.Match(line).Success)
			{
				string key = line.Substring(0, line.IndexOf(":")).ToUpper().Trim();
				string value = line.Substring(line.IndexOf(":") + 1).Trim();
				set_setting(key, value);
				return true;
			}
			return false;
		}

		/// <summary>
		/// Checks if line has image settings. If so, it will set the image settings in memory
		/// </summary>
		/// <param name="line"></param>
		/// <returns></returns>
		private bool load_imagesetting(string line)
		{
			Regex hash = new Regex("image(.*) [0-9A-F]{32}:", RegexOptions.IgnoreCase);
			if (hash.Match(line).Success)
			{
				line = line.Substring(line.IndexOf(')') + 1).Trim();
				string key = line.Substring(0, 32).ToUpper(); //32 is length of hash string
				string description = line.Substring(line.IndexOf(":") + 1).Trim();
				image_settings value = new image_settings(key, description);
				set_setting(key, value);
				return true;
			}
			return false;
		}

		#endregion

		#region generate csv's

		public bool convert(List<byte_image> images, string outputpath, string filename_format, bool multilevel = false, image_settings settings = null, ProgressBar progress = null, Label status = null)
		{
			if (multilevel)
			{
				if (settings == null) return false;
				foreach (KeyValuePair<string, string> kvp in settings.modelist)
				{
					string mode = kvp.Key;
					string description = kvp.Value;
					build_csv(images, outputpath, filename_format, mode, description, progress, status);
				}
				return true;
			}
			else
			{
				//batch image mode. each image gets its own settings
				foreach (byte_image image in images)
				{
					List<byte_image> single_zlevel_list = new List<byte_image>() { image };
					pf.image_settings img_settings = (pf.image_settings)pf.settings[image.image_hash];
					foreach (KeyValuePair<string, string> kvp in img_settings.modelist)
					{
						string mode = kvp.Key;
						string description = kvp.Value;
						build_csv(single_zlevel_list, outputpath, filename_format, mode, description, progress, status);
					}
				}
				return true;
			}
		}

		/// <summary>
		/// Creates a multi-z-level template with the provided list of images.
		/// </summary>
		/// <param name="images">List of images -- one for each z-level. Must be the same dimensions</param>
		/// <param name="output_path">Output file path for the template</param>
		/// <param name="filename">name of desired output file.</param>
		/// <param name="mode">what kind of template which is being generated</param>
		/// <param name="description">Image settings which have deisgnation info</param>
		/// <param name="progress">ProgressBar object to track the function's progress</param>
		/// <param name="status">Label object to provide a visual indicator of the function's status</param>
		/// <returns></returns>
		public bool build_csv(List<byte_image> images, string output_path, string filename_format, string mode, string description, ProgressBar progress = null, Label status = null)
		{

			if (images == null || images.Count == 0) return false;

			StringBuilder csv_builder = new StringBuilder();
			int image_index = 1;
			int prediction = images[0].image.Width * images[0].image.Height;
			
			//check images to make sure they are the same size, prepare progressbar for multiple images
			#region if multiple images

			if (images.Count > 1)
			{
				byte_image first_image = null;
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

					if (first_image == null)
					{
						first_image = current;
						continue;
					}

					if (first_image.image.Size != current.image.Size)
					{
						MessageBox.Show("Images must be the same size for multilevel templates");
						Debug.Log("images do not match dimensions");
						if (progress != null) progress.Value = 0;
						return false;
					}

				}
			}

			#endregion

			#region generate csv

			//set progressbar estimate
			if (progress != null)
			{
				progress.Maximum = prediction;
				progress.Value = 0;
				progress.Refresh();
			}

			//generate csv -- use stringbuilder to create file contents before writing to file
			update_status(status, "Generating CSV");

			//write first line -> template type, start position, comments
			csv_builder.Append(string.Format("{0}\n", description));

			foreach (byte_image current in images)
			{

				update_status(status, string.Format("Creating level ({0}/{1})", image_index, images.Count));

				Queue<Color> color_queue = new Queue<Color>(current.image_array);

				for (int y = 0; y < current.image.Height; y++)
				{
					for (int x = 0; x < current.image.Width; x++)
					{
						if (progress != null)
						{
							try
							{
								progress.Value++;
								progress.Refresh();
							}
							catch (Exception ex)
							{
								Debug.Log(string.Format("wrong value for progressbar: {0}", progress.Value, ex));
							}
						}

						//write the setting value of the color based on the template type
						//handle unkown values by writing blanks
						string designation = " ";
						string key = color_string(color_queue.Dequeue());

						if (settings[key] != null && settings[key].ToString() != "")
						{
							string[] colorcodes = settings[key].ToString().Split('|');
							if (colorcodes.Length == 4)
							{
								switch (mode)
								{
									case "dig": designation = colorcodes[0]; break;
									case "build": designation = colorcodes[1]; break;
									case "place": designation = colorcodes[2]; break;
									case "query": designation = colorcodes[3]; break;
									default: break;
								}
							}
							else
							{
								//they have the wrong format, just grab the first string item
								designation = colorcodes[0];
							}
							if (designation == "") designation = " ";
						}

						csv_builder.Append(string.Format("{0},", designation));
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

			//Debug.log(csv_builder.ToString());

			#endregion generate csv

			#region write file

			//write file
			update_status(status, "Writing File");

			string filename = images[0].out_file;

			try
			{

				////if file is nothing, use the file name of the first image
				//if (string.IsNullOrEmpty(filename)) filename = images[0].csv_file;

				//if path is nothing, use the path of the first image
				if (string.IsNullOrEmpty(output_path)) output_path = images[0].out_path;
				
				//format filename
				filename = csv_name_format(images[0], filename_format, name: filename.Replace(byte_image.out_extension, ""), mode: mode, levels: images.Count.ToString());

				//save output path in settings
				set_setting(setting.output_path, output_path);

				string csv_filepath = string.Format("{0}/{1}", output_path, filename);
				//if user put / to make subfolders, set the path to subfolder
				output_path = csv_filepath.Substring(0, csv_filepath.LastIndexOf('/'));

				//if path doesn't exist, create it
				if (!Directory.Exists(output_path)) Directory.CreateDirectory(output_path);

				using (StreamWriter f = new StreamWriter(csv_filepath)) f.Write(csv_builder.ToString());

				update_status(status, "File Written");
				Debug.Log(string.Format("file written to: {0}", csv_filepath));
			}
			catch (Exception e)
			{
				string status_message = string.Format("Error. File:{0}/{1} could not be written", output_path, filename);
				update_status(status, status_message);
				MessageBox.Show(status_message);
				Debug.Log(e);
				return false;
			}

			#endregion write file

			return true;
		}

		private void update_status(Label status, string message)
		{
			if (status != null)
			{
				status.Text = message;
				status.Refresh();
			}
		}

		private void update_progress(ProgressBar progress, int value)
		{

		}

		#endregion

		public class byte_image
		{

			public Bitmap image;
			public List<Color> palette = new List<Color>();
			public Queue<Color> image_array = new Queue<Color>();
			public string image_hash;

			public string image_file;
			public string image_path;
			public string image_filepath
			{
				get
				{
					return string.Format("{0}/{1}", image_path, image_file);
				}
			}
			public string image_extension;

			public string out_file;
			public string out_path;
			public string out_filepath
			{
				get
				{
					return string.Format("{0}/{1}", out_path, out_file);
				}
			}
			public static string out_extension = ".csv";
			
			/// <summary>
			/// Creates an image object which contains the image, a color palette, the image as an list of colors
			/// and a default path & filename for any csv created with the image.
			/// </summary>
			/// <param name="raw_image"></param>
			/// <param name="img_filepath"></param>
			/// <param name="path"></param>
			/// <param name="p"></param>
			/// <param name="l"></param>
			public byte_image(Image raw_image, string img_filepath, string path = null, ProgressBar p = null, Label status = null)
			{
				//get input image location info
				//----------------------------------------------
				int fstart = img_filepath.LastIndexOf("/");
				if (fstart == -1) fstart = img_filepath.LastIndexOf("\\");

				image_file = img_filepath.Substring(fstart + 1);
				image_path = img_filepath.Replace(image_file, "").TrimEnd('/').TrimEnd('\\');

				image_extension = image_file.Substring(image_file.LastIndexOf("."));

				//get initial output location info
				//----------------------------------------------

				//set csv name to image name
				out_file = image_file.Replace(image_extension, out_extension);

				//if provided path is null, csv_file will be created in same directory as image
				out_path = string.IsNullOrEmpty(path) ? image_path : path.TrimEnd('/').TrimEnd('\\');

				//get and create necessary image data
				//----------------------------------------------

				image = new Bitmap(raw_image);
				load_pixel_data(p);

				//build unique identifier string for the image
				status.Text = "Creating Image Hash";
				status.Refresh();

				StringBuilder colors = new StringBuilder();
				foreach (Color c in image_array) colors.Append(color_string(c).Replace("#", ""));
				image_hash = createHash(string.Format("({0}x{1})-{2}", image.Width, image.Height, colors));
				Debug.Log(string.Format("Image Loaded:{0}; path:{1}; hash:{2}", image_filepath, path, image_hash));
			}

			public bool load_pixel_data(ProgressBar progress = null)
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

		public class image_settings
		{
			//copy of byte_image data
			public string image_filepath;
			public string image_file;
			public string image_extension;
			public string csv_filepath;
			public string csv_file;
			
			//write to file
			public string image_hash;
			public int StartPosIndex;
			public string StartString;
			public bool dig;
			public bool build;
			public bool place;
			public bool query;
			public string digComment;
			public string buildComment;
			public string placeComment;
			public string queryComment;

			public Dictionary<string, string> modelist = new Dictionary<string, string>();

			public image_settings(string hash, string description)
			{
				image_hash = hash;
				string[] modes = description.Split('|');
				StartPosIndex = int.Parse(modes[0]);
				StartString = util.decode(modes[1]);
				foreach (string mode in modes)
				{
					if (mode.Contains("#dig"))
					{
						digComment = util.decode(mode.Replace("#dig", "")).Trim();
						dig = true;
						modelist.Add("dig", digDescription());
					}
					else if (mode.Contains("#build"))
					{
						buildComment = util.decode(mode.Replace("#build", "")).Trim();
						build = true;
						modelist.Add("build", buildDescription());
					}
					else if (mode.Contains("#place"))
					{
						placeComment = util.decode(mode.Replace("#place", "")).Trim();
						place = true;
						modelist.Add("place", placeDescription());
					}
					else if (mode.Contains("#query"))
					{
						queryComment = util.decode(mode.Replace("#query", "")).Trim();
						query = true;
						modelist.Add("query", queryDescription());
					}
				}
			}

			public void load_image_data(byte_image img)
			{
				this.image_filepath = img.image_filepath;
				this.image_file = img.image_file;
				this.image_extension = img.image_extension;
				this.csv_filepath = img.out_filepath;
				this.csv_file = img.out_file;
			}

			private string digDescription()
			{
				return string.Format("#dig {0} {1}", StartString, digComment);
			}
			private string buildDescription()
			{
				return string.Format("#build {0} {1}", StartString, buildComment);
			}
			private string placeDescription()
			{
				return string.Format("#place {0} {1}", StartString, placeComment);
			}
			private string queryDescription()
			{
				return string.Format("#query {0} {1}", StartString, queryComment);
			}

			public override string ToString()
			{
				StringBuilder description = new StringBuilder();
				description.Append(string.Format("{0}|{1}|", StartPosIndex, util.encode(StartString)));
				if (dig) description.Append(string.Format("#dig {0}|", util.encode(digComment)));
				if (build) description.Append(string.Format("#build {0}|", util.encode(buildComment)));
				if (place) description.Append(string.Format("#place {0}|", util.encode(placeComment)));
				if (query) description.Append(string.Format("#query {0}|", util.encode(queryComment)));

				return description.ToString().TrimEnd('|');
			}

			public override bool Equals(object obj)
			{
				if (obj.GetType() == this.GetType())
				{
					image_settings s = (image_settings)obj;
					if (s.image_hash == image_hash) return true;
				}
				else if (obj.ToString() == image_hash) return true;
				
				return false;
			}

			public override int GetHashCode()
			{
				return int.Parse(image_hash); //TODO: test this? for curiosity if nothing else
			}
		}

	}

}
