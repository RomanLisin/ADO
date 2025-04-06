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
		AddGroup addGroup;
		GroupDelete groupDelete;

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
			comboBoxStudentsGroups_SelectedIndexChanged(comboBoxStudentsGroups.SelectedItem, EventArgs.Empty);
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
			string directionName = comboBoxStudentsDirections.SelectedItem.ToString().Replace("'", "''");
			if (directionName == "All directions")
			{
				comboBoxStudentsGroups.DataSource = null;  // Отключаем привязку данных, без этого ошибка:
				comboBoxStudentsGroups.SelectedItem = null;
				//"Items collection cannot be modified when the DataSource property is set."
				//(Коллекция Items не может быть изменена, когда установлен DataSource.)
				tabControl_SelectedIndexChanged(tabControl, EventArgs.Empty);
			}
			else
			{
				comboBoxStudentsGroups.DataSource = connector.Select(
					"group_name",
					"Students, Groups, Directions",
					$"direction=direction_id AND [group] = group_id AND " +
					$"direction_name ='{directionName}'",
					"group_id, group_name, direction_name"
				);
				comboBoxStudentsGroups.DisplayMember = "group_name";
				comboBoxStudentsGroups.SelectedItem = null;
				dgvStudents.DataSource = connector.Select(
					"stud_id, last_name, first_name, middle_name, birth_date, group_name",
					"Students, Groups, Directions",
					$"direction=direction_id AND [group] = group_id AND direction_name = '{directionName}'" //,
					//"group_id, group_name, direction_name"
				);
				//tabControl_SelectedIndexChanged(tabControl, EventArgs.Empty);
				}
				//// Получаем название направления
				//string directionName = comboBoxStudentsDirections.SelectedItem.ToString().Replace("'", "''");

				//// Проверка на "Все направления"
				//if (directionName == "All directions")
				//{
				//	comboBoxStudentsGroups.DataSource = null;
				//	comboBoxStudentsGroups.SelectedItem = null;
				//	dgvStudents.DataSource = null; // очищаем студентов тоже
				//	tabControl_SelectedIndexChanged(tabControl, EventArgs.Empty);
				//	return;
				//}

				//// Получаем группы по выбранному направлению
				//DataTable groups = connector.Select(
				//	"group_id, group_name, direction_name",
				//	"Groups INNER JOIN Directions ON Groups.direction = Directions.direction_id",
				//	$"Directions.direction_name = '{directionName}'",
				//	"Groups.group_id, Groups.group_name, Directions.direction_name"
				//);

				//// Привязываем к ComboBox
				//comboBoxStudentsGroups.DataSource = groups;
				//comboBoxStudentsGroups.DisplayMember = "group_name";
				//comboBoxStudentsGroups.ValueMember = "group_id";
				//comboBoxStudentsGroups.SelectedItem = null;

				//// Собираем список group_id для фильтрации студентов
				//List<string> groupIds = new List<string>();
				//foreach (DataRow row in groups.Rows)
				//{
				//	groupIds.Add(row["group_id"].ToString());
				//}

				//// Если группы есть — подгружаем студентов
				//if (groupIds.Count > 0)
				//{
				//	string groupIdFilter = string.Join(", ", groupIds);

				//	dgvStudents.DataSource = connector.Select(
				//		"Groups.group_id, group_name, COUNT(stud_id) AS students_count, direction_name",
				//		"Students, Groups, Directions",
				//		$"direction = direction_id AND [group] = group_id AND group_id IN ({groupIdFilter})",
				//		"group_id, group_name, direction_name"
				//	);
				//}
				//else
				//{
				//	dgvStudents.DataSource = null;
				//}

				//tabControl_SelectedIndexChanged(tabControl, EventArgs.Empty);
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
			if (comboBoxStudentsGroups.SelectedItem is DataRowView rowView)
			{

				string comboBoxStudentsValue = rowView["group_name"].ToString().Trim(); // Извлекаем поле group_name
				Query subQuery = new Query("group_", "Groups", $"group_name = N'{comboBoxStudentsValue}'");
				query = new Query("stud_id, last_name, first_name, middle_name, birth_date, group_name",
					"Students, Groups",
				$"[group] = group_id AND group_name = N'{comboBoxStudentsValue}'" //N'{connector.Select(subQuery.Columns, subQuery.Tables, subQuery.Condition)}'"
				);
				dgvStudents.DataSource = connector.Select(query.Columns, query.Tables, query.Condition, query.GroupBy);
			}

		}

		private void checkBoxEmptyDirections_CheckedChanged(object sender, EventArgs e)
		{
			
			Query queryDirection = new Query("d.direction_name,\r\n    ISNULL(g.groups_count, 0) AS groups_count,\r\n    ISNULL(s.students_count, 0) AS students_count",
												"Directions d LEFT JOIN (SELECT direction, COUNT(*) AS groups_count FROM Groups GROUP BY direction) g ON d.direction_id = g.direction " +
												"LEFT JOIN(SELECT g.direction, COUNT(s.stud_id) AS students_count FROM Groups g JOIN Students s ON g.group_id = s.[group] GROUP BY g.direction) s ON d.direction_id = s.direction; ");
			if (checkBoxEmptyDirections.Checked)
			{
				dgvDirectors.DataSource = null;
				dgvDirectors.DataSource = connector.Select(queryDirection.Columns, queryDirection.Tables, queryDirection.Condition, queryDirection.GroupBy);
			}
			else tabControl_SelectedIndexChanged(tabControl, EventArgs.Empty);
		}

		public void checkBoxEmptyGroups_CheckedChanged(object sender, EventArgs e)
		{
			Query queryDirection = new Query("g.group_id, g.group_name, ISNULL(s.students_count, 0) AS students_count, d.direction_name",
											" Groups g LEFT JOIN (SELECT [group], COUNT(stud_id) AS students_count FROM Students GROUP BY [group]) s ON g.group_id = s.[group] LEFT JOIN Directions d ON g.direction = d.direction_id",
											"",
											"g.group_id, g.group_name, s.students_count, d.direction_name;");
			if (checkBoxEmptyGroups.Checked)
			{
				dgvGroups.DataSource = null;
				dgvGroups.DataSource = connector.Select(queryDirection.Columns, queryDirection.Tables, queryDirection.Condition, queryDirection.GroupBy);
			}
			else tabControl_SelectedIndexChanged(tabControl, EventArgs.Empty);
		}

		private void addGroupToolStripMenuItem_Click(object sender, EventArgs e)
		{
			addGroup = new AddGroup(this);
			addGroup.Show(this);
		}

		public void RefreshGroups()
		{
			checkBoxEmptyGroups_CheckedChanged(checkBoxEmptyGroups, EventArgs.Empty);
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			groupDelete = new GroupDelete();
			groupDelete.Show(this);
		}
	}
}
