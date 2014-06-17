using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace picturefort
{
	public partial class color_designation : UserControl
	{
		public Color mycolor;
		string dig = "";
		string build = "";
		string place = "";
		string query = "";
		public string designation
		{
			get
			{
				return string.Format("{0}|{1}|{2}|{3}", dig, build, place, query);
			}
		}

		public Dictionary<string, string> designations_dig = new Dictionary<string, string>();
		public Dictionary<string, string> designations_build = new Dictionary<string, string>();
		public Dictionary<string, string> designations_place = new Dictionary<string, string>();
		public Dictionary<string, string> designations_query = new Dictionary<string, string>();

		public color_designation(Color c)
		{
			InitializeComponent();

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

			mycolor = c;
		}
		
		private void color_designation_Load(object sender, EventArgs e)
		{
			txtColor.BackColor = mycolor;
			txtColor.Text = pf.color_string(mycolor);
			txtColor.ReadOnly = true;

			AutoCompleteStringCollection source_dig = new AutoCompleteStringCollection();
			source_dig.Add("");
			source_dig.AddRange(designations_dig.Keys.ToArray<string>());
			cbModeDig.DataSource = source_dig;
			cbModeDig.AutoCompleteCustomSource = source_dig;

			AutoCompleteStringCollection source_build = new AutoCompleteStringCollection();
			source_build.Add("");
			source_build.AddRange(designations_build.Keys.ToArray<string>());
			cbModeBuild.DataSource = source_build;
			cbModeBuild.AutoCompleteCustomSource = source_build;

			AutoCompleteStringCollection source_place = new AutoCompleteStringCollection();
			source_place.Add("");
			source_place.AddRange(designations_place.Keys.ToArray<string>());
			cbModePlace.DataSource = source_place;
			cbModePlace.AutoCompleteCustomSource = source_place;

			AutoCompleteStringCollection source_query = new AutoCompleteStringCollection();
			source_query.Add("");
			source_query.AddRange(designations_query.Keys.ToArray<string>());
			cbModeQuery.DataSource = source_query;
			cbModeQuery.AutoCompleteCustomSource = source_query;

		}

		private void save_designations()
		{
			//Debug.Log("designation: " + designation);
			if (designation == "|||")
			{
				//if no designations are set, just wipe the setting
				pf.set_setting(pf.color_string(mycolor), "");
			}
			else
			{
				pf.set_setting(pf.color_string(mycolor), designation);
			}
			//Debug.Log("setting:" + pf.settings[pf.color_string(mycolor)]);
		}

		#region event handlers
		
		private void cbModeDig_SelectedIndexChanged(object sender, EventArgs e)
		{
			string key = cbModeDig.SelectedValue.ToString();
			if (key != "")
			{
				dig = designations_dig[key];
			}
			else
			{
				dig = "";
			}
			save_designations();
		}

		private void cbModeBuild_SelectedIndexChanged(object sender, EventArgs e)
		{
			string key = cbModeBuild.SelectedValue.ToString();
			if (key != "")
			{
				//if we're building something, default dig mode to Mine to clear space
				cbModeDig.SelectedIndex = 1; //mine
				build = designations_build[key];
			}
			else
			{
				if (build != "")
				{
					//if we're NOT building something, default dig mode back to nothing
					cbModeDig.SelectedIndex = 0; //nothing
					build = "";
				}
			}
			save_designations();
		}

		private void cbModePlace_SelectedIndexChanged(object sender, EventArgs e)
		{
			string key = cbModePlace.SelectedValue.ToString();
			if (key != "")
			{
				//if we're placing a stockpile, default dig mode to Mine to clear space
				cbModeDig.SelectedIndex = 1; //mine
				place = designations_place[key];
			}
			else
			{
				if (place != "")
				{
					//if we're NOT placing a stockpile, default dig mode back to nothing
					cbModeDig.SelectedIndex = 0; //nothing
					place = "";
				}
			}
			save_designations();
		}

		private void cbModeQuery_SelectedIndexChanged(object sender, EventArgs e)
		{
			string key = cbModeQuery.SelectedValue.ToString();
			if (key != "")
			{
				query = designations_query[key];
			}
			else
			{
				query = "";
			}
			save_designations();
		}

		#endregion event handlers

	}
}
