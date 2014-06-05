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
		pf p;

		public color_designation(pf f)
		{
			InitializeComponent();
			p = f;
		}

		public color_designation(Color c)
		{
			mycolor = c;
		}

		private void color_designation_Load(object sender, EventArgs e)
		{
			txtColor.BackColor = mycolor;
			txtColor.Text = pf.convert_color(mycolor);
			txtColor.ReadOnly = true;

			AutoCompleteStringCollection source_dig = new AutoCompleteStringCollection();
			source_dig.Add("");
			source_dig.AddRange(p.designations_dig.Keys.ToArray<string>());
			cbModeDig.DataSource = source_dig;
			cbModeDig.AutoCompleteCustomSource = source_dig;

			AutoCompleteStringCollection source_build = new AutoCompleteStringCollection();
			source_build.Add("");
			source_build.AddRange(p.designations_build.Keys.ToArray<string>());
			cbModeBuild.DataSource = source_build;
			cbModeBuild.AutoCompleteCustomSource = source_build;

			AutoCompleteStringCollection source_place = new AutoCompleteStringCollection();
			source_place.Add("");
			source_place.AddRange(p.designations_place.Keys.ToArray<string>());
			cbModePlace.DataSource = source_place;
			cbModePlace.AutoCompleteCustomSource = source_place;

			AutoCompleteStringCollection source_query = new AutoCompleteStringCollection();
			source_query.Add("");
			source_query.AddRange(p.designations_query.Keys.ToArray<string>());
			cbModeQuery.DataSource = source_query;
			cbModeQuery.AutoCompleteCustomSource = source_query;

		}


	}
}
