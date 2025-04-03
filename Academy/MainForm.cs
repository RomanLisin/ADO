using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;
using System.Globalization;

namespace Academy
{
	public partial class MainForm : Form
	{
		Connector connector;

		Query[] queries = new Query[]
		{
			new Query("*", "Students"),
			new Query("group_id, group_name,COUNT(stud_id) AS students_count,direction_name", 
				"Students,Groups,Directions",
				"direction=direction_id AND [group] = group_id",
				"group_id, group_name, direction_name"
				),
			new Query("direction_name, [groups_count] = COUNT(DISTINCT group_id), [students_count] = COUNT(stud_id)  ",
				"Directions, Groups, Students",
				"[group] = group_id AND direction=direction_id",
				"direction_name"),
			new Query("*", "Disciplines"),
			new Query("*", "Teachers"),
		};

		DataGridView[] tables;
		string[] status_messages = new string[]
		{
			"Количество студентов: ",
			"Количество групп: ",
			"Количество направлений: ",
			"Количество дисциплин: ",
			"Количество преподавателей: ",
		};
		public MainForm()
		{
			InitializeComponent();
			tables = new DataGridView[]
			{
				dgvStudents,
				dgvGroups,
				dgvDirectors,
				dgvDisciplines,
				dgvTeachers
			};
			connector = new Connector(ConfigurationManager.ConnectionStrings["VPD_311_Import"].ConnectionString);
			dgvStudents.DataSource = connector.Select("*", "Students");
			statusStripCountLabel.Text = $"Количество студентов: {dgvStudents.RowCount - 1}";
		}

		private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			comboBoxGroupsDirection.SelectedItem = null;
			int i = tabControl.SelectedIndex;
			//Query query = queries[i];
			tables[i].DataSource = connector.Select(queries[i].Columns, queries[i].Tables, queries[i].Condition, queries[i].GroupBy);
			statusStripCountLabel.Text = $"{status_messages[i]}  {tables[i].RowCount - 1}";

			foreach (Control control in tabControl.TabPages[i].Controls)
			{
				if (control is ComboBox cb)
				{
					LoadComboBoxDirections(tabControl.TabPages[i].Name, "tabPageDirections", cb);
					//MessageBox.Show("Найден ComboBox: " + cb.Name);
					break;
				}
			}
		}

		private void LoadComboBoxDirections(string tabControlName, string tabControlNameSource, ComboBox cb)
		{
			int i = GetTabIndexByName(tabControlName);
			cb.Items.Clear();
				int j = GetTabIndexByName(tabControlNameSource);
			dgvDirectors.DataSource = connector.Select(queries[j].Columns, queries[j].Tables, queries[j].Condition, queries[j].GroupBy);
			
				foreach (DataGridViewRow row in dgvDirectors.Rows)
				{
					if (row.Cells["direction_name"].Value != null)
					{
						cb.Items.Add(row.Cells["direction_name"].Value.ToString());
					}
				}
				cb.Items.Add("All directions");
			
		}

		private void LoadComboBoxGroups()
		{ 
		}
		private void comboBoxGroupsDirection_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBoxGroupsDirection.SelectedItem == null) return;

			string directionName = comboBoxGroupsDirection.SelectedItem.ToString().Replace("'", "''"); // Предотвращение SQL-инъекций

			if (comboBoxGroupsDirection.SelectedItem.ToString() == "All directions")
			{
				tabControl_SelectedIndexChanged(tabControl, EventArgs.Empty);
			}
			else
			{
				dgvGroups.DataSource = connector.Select(
					"group_id, group_name, COUNT(stud_id) AS students_count, direction_name",
					"Students, Groups, Directions",
					$"direction=direction_id AND [group] = group_id AND direction_name = '{directionName}'",
					"group_id, group_name, direction_name"
				);
			}
		}

		int GetTabIndexByName(string tabName)
		{
			for (int i = 0; i < tabControl.TabPages.Count; i++)
			{
				if (tabControl.TabPages[i].Name == tabName)
				{
					return i; // возвращаем индекс, если имя совпадает
				}
			}
			return -1; // eсли вкладка не найдена
		}
	}
}
