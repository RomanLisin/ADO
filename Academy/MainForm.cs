﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;
using System.Collections;
using System.Data.Common;
using System.Data.SqlClient;

namespace Academy
{
	public partial class MainForm : Form
	{
		Connector connector;

		Query[] queries = new Query[]
		{
			new Query("*", "Students JOIN Groups ON ([group] = group_id) JOIN Directions ON (direction=direction_id)"),
			new Query("group_id, group_name,COUNT(stud_id) AS students_count,direction_name",
				"Students,Groups,Directions",
				"direction=direction_id AND [group] = group_id",
				"group_id, group_name, direction_name"
				),
			//new Query("direction_name, [groups_count] = COUNT(DISTINCT group_id), [students_count] = COUNT(stud_id)  ",    // домашка начало от 30.03.2025
			//	"Directions, Groups, Students",
			//	"[group] = group_id AND direction=direction_id",
			//	"direction_name"),
			new Query
			(
				@"direction_name, COUNT(DISTINCT group_id) AS N'Количество групп',COUNT (DISTINCT stud_id) AS N'Количество студентов'",
				@" Students JOIN Groups ON ([group] = group_id) RIGHT JOIN Directions ON (direction = direction_id)" ,
				"",  //WHERE
				"direction_name;"

				),
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

		/// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// <summary>
		// TODO: Apply encapsulation:
		//public Dictionary<string, int> d_groups{get; private set;};
		public Dictionary<string, int> d_directions { get; private set; }
		public  Dictionary<string, int> d_groups { get; private set; }

		//public Dictionary<string, int> d_group { get; private set; }
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

			d_directions = connector.GetDictionary("Directions");
			d_groups = connector.GetDictionary("Groups");
			cbStudentsGroup.Items.AddRange(d_groups.Select(g => g.Key.ToString()).ToArray());
			cbStudentsDirection.Items.AddRange(d_directions.Select(d => d.Key.ToString()).ToArray());  // LINQ
			cbGroupsDirection.Items.AddRange(d_directions.Select(d => d.Key.ToString()).ToArray());   // LINQ
		}
		void LoadTab(Query query = null)
		{
			int i = tabControl.SelectedIndex;
			if (query == null) query = queries[i];
			tables[i].DataSource = connector.Select(query.Columns, query.Tables, query.Condition, query.GroupBy);
			statusStripCountLabel.Text = $"{status_messages[i]}  {tables[i].RowCount - 1}";

		}
		private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			//int i = tabControl.SelectedIndex;
			//Query query = queries[i];
			LoadTab();
		}

		private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			int i = tabControl.SelectedIndex;
			Query query = new Query(queries[i]);
			Console.WriteLine(query.Condition);
			string tab_name = (sender as ComboBox).Name;
			string field_name = tab_name.Substring(Array.FindLastIndex<char>(tab_name.ToCharArray(), Char.IsUpper));
            Console.WriteLine(field_name);
			string member_name = $"d_{field_name.ToLower()}s";
			Dictionary<string, int> source = this.GetType().GetProperty(member_name).GetValue(this) as Dictionary<string, int>;  // это код получает доступ к полю текущего класса по имени, которое хранится в переменной member_name, извлекает значение этого поля, пытается интерпретировать это значение, как словарь
			if (query.Condition != "") query.Condition += " AND";

			string SelectItem = (sender as ComboBox).SelectedItem.ToString();

			query.Condition += $" [{field_name.ToLower()}] = {source[SelectItem]}";
			LoadTab(query);
			if (member_name == "d_directions")
			{
				d_groups.Clear();
				//d_groups = SelectDict(d_directions, d_groups, SelectItem);
				d_groups = connector.GetRefDictionary(source[SelectItem]);
			}
			cbStudentsGroup.Items.Clear();
			cbStudentsGroup.Items.AddRange(d_groups.Select(g => g.Key.ToString()).ToArray());
			cbStudentsGroup.Refresh();
			Console.WriteLine((sender as ComboBox).Name);
            Console.WriteLine(e);
        }



	
		private Dictionary<string, int> SelectDict(Dictionary<string, int> d_groups, Dictionary<string, int> d_directions, string direction)
		{
			Dictionary<string, int> d_result = new Dictionary<string, int>();
			//string direction = cbStudentsDirection.Text;
			if (d_directions.TryGetValue(direction, out int direction_id))
			{
				// Ищем все группы с таким номером:
				d_result = d_groups
				.Where(kv => kv.Value == direction_id)
				.ToDictionary(kv => kv.Key, kv => kv.Value);
			}
			return d_result;
		}
	}
}
