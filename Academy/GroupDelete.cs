using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academy
{
	public partial class GroupDelete : Form
	{
		Connector connector;
		Query directionNameQuery;
		//DataTable dtDirections;
		private MainForm parentForm;
		public GroupDelete()
		{
			InitializeComponent();
			connector = new Connector(ConfigurationManager.ConnectionStrings["VPD_311_Import"].ConnectionString);

		}


		private void buttonDeleteGroupOk_Click(object sender, EventArgs e)
		{
			if (comboBoxSelectDirection.SelectedItem == null)
			{
				MessageBox.Show("Select direction to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (comboBoxSelectGroup.SelectedItem == null)
			{
				MessageBox.Show("Input name group to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

		}
	}
}
