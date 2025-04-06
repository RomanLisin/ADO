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

using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Runtime.InteropServices;
//using System.IO;

namespace Academy
{
	public partial class AddGroup : Form
	{
		Connector connector;
		Query directionNameQuery;
		DataTable dtDirections;
		private MainForm parentForm;
		public AddGroup(MainForm parentForm)
		{
			InitializeComponent();
			connector = new Connector(ConfigurationManager.ConnectionStrings["VPD_311_Import"].ConnectionString);
			dtDirections = new DataTable();
			LoadComboBoxSelectDirections(comboBoxSelectDirection);
			this.parentForm = parentForm;
		}
		private void LoadComboBoxSelectDirections(ComboBox cb)
		{
			directionNameQuery = new Query("direction_name", "Directions");
			dtDirections = connector.Select(directionNameQuery.Columns, directionNameQuery.Tables);
			cb.Items.Clear();
			foreach (DataRow row in dtDirections.Rows)
			{
				if (row["direction_name"] != DBNull.Value)  //именно так в DataTable представлено "null" значение, сравнивать с null напрямую нельзя
				{
					cb.Items.Add(row["direction_name"].ToString());
				}
			}
		}
		private void buttonGroupAdd_Click(object sender, EventArgs e)
		{
			if (comboBoxSelectDirection.SelectedItem == null)
			{
				MessageBox.Show("Select direction to add!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (textBoxName.Text == "")
			{
				MessageBox.Show("Input name group to add!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			connector.InsertGroup(textBoxName.Text, comboBoxSelectDirection.SelectedItem.ToString());
			parentForm.RefreshGroups();
			this.Close();
		}
	}
}
