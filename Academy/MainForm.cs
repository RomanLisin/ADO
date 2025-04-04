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
		Query query;

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
			tabControl_SelectedIndexChanged(tabControl, EventArgs.Empty);
		}

		private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
		{

			comboBoxGroupsDirection.SelectedItem = null;
			int i = tabControl.SelectedIndex;
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
			LoadComboBoxGroups();
			

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
			//int countGroups = Convert.ToInt32(connector.Select("COUNT(*) as group_count", "Groups", " group_id IN (SELECT DISTINCT [group] FROM Students"));
				
			//comboBoxStudentsGroups.SelectedItem = null;
			comboBoxStudentsGroups.DataSource = connector.Select(
				"group_name",
				"Students, Groups, Directions",
				$"direction=direction_id AND [group] = group_id",
				"group_id, group_name, direction_name"
				);
			comboBoxStudentsGroups.DisplayMember = "group_name";
		}
		private void comboBoxStudentsDirections_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBoxStudentsDirections.SelectedItem.ToString() == "All directions")
			{
				//Console.WriteLine("\nЗдесь должна быть ошибка\n");
				comboBoxStudentsGroups.DataSource = null;  // Отключаем привязку данных, без этого ошибка:
				//"Items collection cannot be modified when the DataSource property is set."
				//(Коллекция Items не может быть изменена, когда установлен DataSource.)
				//comboBoxStudentsGroups.Items.Clear();
				tabControl_SelectedIndexChanged(tabControl, EventArgs.Empty);

				//Console.WriteLine("если до сюда дошли, значит перепрыгнули Items.Clear()");
				//tabControl_SelectedIndexChanged(tabControl, EventArgs.Empty);
				//comboBoxStudentsGroups.DataSource = null;
				//comboBoxStudentsGroups.SelectedIndex = -1;
				//comboBoxStudentsGroups.Text = "";
				//tabControl_SelectedIndexChanged(tabControl, EventArgs.Empty);
				//comboBoxStudentsGroups.DataSource = null; // Отключаем DataSource
				//comboBoxStudentsGroups.Items.Clear(); // Очищаем элементы
				//comboBoxStudentsGroups.Text = ""; // Очищаем текст вручную
				LoadComboBoxGroups();
			}
			else
			{
				//string directionName = comboBoxGroupsDirection.SelectedItem.ToString().Replace("'", "''"); // Предотвращение SQL-инъекций
				comboBoxStudentsGroups.DataSource = connector.Select(
					"group_name",
					"Students, Groups, Directions",
					$"direction=direction_id AND [group] = group_id AND " +
					$"direction_name ='{comboBoxStudentsDirections.SelectedItem.ToString().Replace("'", "''")}'",
					"group_id, group_name, direction_name"
				);
					comboBoxStudentsGroups.DisplayMember = "group_name";
			}
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

		private void comboBoxStudentsGroups_SelectedIndexChanged(object sender, EventArgs e)
		{
			dgvStudents.DataSource = null;
			if (comboBoxStudentsGroups.SelectedItem is DataRowView rowView)
			{
				string comboBoxStudentsValue = rowView["group_name"].ToString().Trim(); // Извлекаем поле group_name
				Query subQuery = new Query("group_", "Groups", $"group_name = N'{comboBoxStudentsValue}'");
				query = new Query("stud_id, last_name, first_name, middle_name, birth_date, group_name",
					"Students, Groups",
				$"[group] = group_id AND group_name = N'{comboBoxStudentsValue}'" //N'{connector.Select(subQuery.Columns, subQuery.Tables, subQuery.Condition)}'"
				);
				dgvStudents.DataSource = connector.Select(query.Columns, query.Tables, query.Condition, query.GroupBy);
				tabPageStudents.Controls.Add(dgvStudents);
				dgvStudents.Visible = true;
				dgvStudents.Refresh();
				//tabControl_SelectedIndexChanged(tabControl, EventArgs.Empty);
			}
		
		}
	}
}
