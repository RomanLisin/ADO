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
		public AddGroup()
		{
			InitializeComponent();
			connector = new Connector(ConfigurationManager.ConnectionStrings["VPD_311_Import"].ConnectionString);
			DataTable dtDirections = new DataTable();
			LoadComboBoxSelectDirections(comboBoxSelectDirection);
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
			connector.InsertGroup(textBoxName.Text, comboBoxSelectDirection.SelectedItem.ToString());
		}
	}
}
