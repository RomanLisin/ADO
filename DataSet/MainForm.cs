using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Configuration;
using Academy;


namespace AcademyDataSet
{
	public partial class MainForm : Form
	{
		Query query;
		readonly string CONNECTION_STRING = "";
		Cache GroupsRelatedData = null;

		//Query[] queries = new Query[]
		//{
		//	new Query("*", "Students JOIN Groups ON ([group] = group_id) JOIN Directions ON (direction=direction_id)"),
		//	new Query("group_id, group_name,COUNT(stud_id) AS students_count,direction_name",
		//		"Students,Groups,Directions",
		//		"direction=direction_id AND [group] = group_id",
		//		"group_id, group_name, direction_name"
		//		),
		//	new Query
		//	(
		//		@"direction_name, COUNT(DISTINCT group_id) AS N'Количество групп',COUNT (DISTINCT stud_id) AS N'Количество студентов'",
		//		@" Students JOIN Groups ON ([group] = group_id) RIGHT JOIN Directions ON (direction = direction_id)" ,
		//		"",  //WHERE
		//		"direction_name;"

		//		),
		//	new Query("*", "Disciplines"),
		//	new Query("*", "Teachers"),
		//};

		DataGridView[] tables;
		//string[] status_messages = new string[]
		//{
		//	"Количество студентов: ",
		//	"Количество групп: ",
		//	"Количество направлений: ",
		//	"Количество дисциплин: ",
		//	"Количество преподавателей: ",
		//};
		public MainForm()
		{
			InitializeComponent();
			CONNECTION_STRING = ConfigurationManager.ConnectionStrings["VPD_311_Import"].ConnectionString;
			
			AllocConsole();
            Console.WriteLine(CONNECTION_STRING);
			tables = new DataGridView[]
			{
				dgvStudents,
				dgvGroups,
				dgvDirections,
				dgvDisciplines,
				dgvTeachers
			};
			//1 Создаем DataSet
			GroupsRelatedData = new Cache(CONNECTION_STRING);
			GroupsRelatedData.AddTable("Directions", "direction_id:int,direction_name:string");
			GroupsRelatedData.AddTable("Groups", "group_id:int,group_name:string,direction:int");
			GroupsRelatedData.AddTable("Students", "stud_id:int,last_name:string,first_name:string,middle_name:string,birth_date:datatime,[group]:int");
			GroupsRelatedData.AddTable("Disciplines", "discipline_id,discipline_name,number_of_lessons");
			GroupsRelatedData.AddTable("Teachers", "teacher_id,last_name,first_name,middle_name,birth_date,work_since,rate");
			GroupsRelatedData.AddRelation("GroupsDirections", "Groups,direction", "Directions,direction_id");
			GroupsRelatedData.AddRelation("StudentsGroups", "Students,[group]", "Groups,group_id");
			dgvGroups.DataSource = GroupsRelatedData.Tables["Groups"];
			dgvDirections.DataSource = GroupsRelatedData.Tables["Directions"];
			dgvStudents.DataSource = GroupsRelatedData.Tables["Students"];
			dgvDisciplines.DataSource = GroupsRelatedData.Tables["Disciplines"];
			dgvTeachers.DataSource = GroupsRelatedData.Tables["Teachers"];
			cbStudentsDirections.DataSource = cbGroupsDirections.DataSource = GroupsRelatedData.Tables["Directions"];
															//.AsEnumerable()
															//.Select(t => t.Field<string>("direction_name"))
															//.ToList();
			cbStudentsDirections.DisplayMember = "direction_name";    // что отображать
			cbStudentsDirections.ValueMember = "direction_id";        // с чем работать

			GroupsRelatedData.Print("Groups");
			//LoadGroupRelatedData();
        }
		private void cbStudentsDirections_SelectedIndexChanged(object sender, EventArgs e)
		{

			if (cbStudentsDirections.SelectedValue == null)
			{
				MessageBox.Show("Not select direction");
				return;
			}
			cbStudentsGroups.DataSource = GroupsRelatedData.Tables["Groups"]   // link в синтаксисе методов
													.AsEnumerable()
													.Where(t => t.Field<int>("direction") == (int)cbStudentsDirections.SelectedValue)
													.Select(t => new
														{
															GroupName = t.Field<string>("group_name"),
															GroupId = t.Field<int>("group_id")
														})
													.ToList();

			//cbStudentsGroups.DataSource =		from t in GroupsRelatedData.Tables["Groups"].AsEnumerable()  // link в синтаксисе запросов
			//									where t.Field<int>("direction") == (int)cbStudentsDirections.SelectedValue
			//									select t.Field<string>("group_name").ToList();
			cbStudentsGroups.DisplayMember = "GroupName"; // что отображать
			cbStudentsGroups.ValueMember = "GroupID";   // c чем работать

			//Type columnType = GroupsRelatedData.Tables["Groups"].Columns["direction"].DataType;   // узнать тип колонки
			//MessageBox.Show($"Тип столбца 'direction': {columnType}");
			//Console.WriteLine(GroupsRelatedData.Tables["Groups"].Columns["direction"].DataType);
			var filteredRows = GroupsRelatedData.Tables["Students"]
														.AsEnumerable()
														.Where(t => t.Field<int?>("group") == (int?)cbStudentsGroups.SelectedItem);
			if (filteredRows.Any())
			{
				dgvStudents.DataSource = filteredRows.CopyToDataTable();
			}
			else
			{
				dgvStudents.DataSource = null;
			}
			dgvStudents.Refresh();
			
			Type columnType = cbStudentsGroups.SelectedValue.GetType();
			MessageBox.Show($"Type selectedItem: {columnType}");
			
		}

		void LoadGroupRelatedData()
		{
			//GroupsRelatedData = new DataSet();
			//1 Создаем DataSet

			//2)Добавляем таблицы в DataSet
			const string dsTable_Directions = "Directions";
			const string dst_col_direction_id = "direction_id";
			const string dst_col_direction_name = "direction_name";
			//2.1)Добавляем таблицу в DataSet
			GroupsRelatedData.Tables.Add(dsTable_Directions);
			//2.2)Добавляем поля (столбики) в таблицу:
			GroupsRelatedData.Tables[dsTable_Directions].Columns.Add(dst_col_direction_id, typeof(byte));
			GroupsRelatedData.Tables[dsTable_Directions].Columns.Add(dst_col_direction_name, typeof(string));
			//2.3)Определяем, какое поле будет первичным ключом:
			GroupsRelatedData.Tables[dsTable_Directions].PrimaryKey =
				new DataColumn[] { GroupsRelatedData.Tables[dsTable_Directions].Columns[dst_col_direction_id] };

			const string dsTable_Groups = "Groups";
			const string dst_Groups_col_group_id = "group_id";
			const string dst_Groups_col_group_name = "group_name";
			const string dst_Groups_col_group_direction = "diretion";
			GroupsRelatedData.Tables.Add(dsTable_Groups);
			GroupsRelatedData.Tables[dsTable_Groups].Columns.Add(dst_Groups_col_group_id, typeof(int));
			GroupsRelatedData.Tables[dsTable_Groups].Columns.Add(dst_Groups_col_group_name, typeof(string));
			GroupsRelatedData.Tables[dsTable_Groups].Columns.Add(dst_Groups_col_group_direction, typeof(byte));
			GroupsRelatedData.Tables[dsTable_Groups].PrimaryKey =
				new DataColumn[] { GroupsRelatedData.Tables[dsTable_Groups].Columns[0] };

			//3 Строим связи между таблицами
			GroupsRelatedData.Relations.Add
				(
					"GroupsDirections",
					GroupsRelatedData.Tables[dsTable_Directions].Columns[dst_col_direction_id], // Parent field - первичный ключ в другой таблице
					GroupsRelatedData.Tables[dsTable_Groups].Columns[dst_Groups_col_group_direction] // Child field - внешний ключ
				);
			//4 Загрузка данных в DataSet
			string directionsCmd = "SELECT * FROM Directions";
			string groupsCmd = "SELECT * FROM Groups";
			//SqlDataAdapter directionsAdapter = new SqlDataAdapter(directionsCmd, connection);
			//SqlDataAdapter groupsAdapter = new SqlDataAdapter(groupsCmd, connection);

			//directionsAdapter.Fill(GroupsRelatedData.Tables[dsTable_Directions]);
			//groupsAdapter.Fill(GroupsRelatedData.Tables[dsTable_Groups]);

			//Print("Directions");
			//Print("Groups");
		}
		//1.Функция Print() должна самостоятельно определять, есть ли у столбца 
		//родитель, и если он есть, то нужно вывести соответствующее поле из
		//родительской таблицы

		//void LoadTab(Query query = null)
		//{
		//	int i = tabControl.SelectedIndex;
		//	if (query == null) query = queries[i];
		//	//tables[i].DataSource = GroupsRelatedData.connection.Select(query.Columns, query.Tables, query.Condition, query.GroupBy);
		//	//statusStripCountLabel.Text = $"{status_messages[i]}  {tables[i].RowCount - 1}";

		//}
		void PrintGroups()
		{
			Console.WriteLine("\n========================================================\n");
			string table = "Groups";
			for (int i = 0; i < GroupsRelatedData.Tables[table].Rows.Count; i++)
			{
				for(int j=0; j < GroupsRelatedData.Tables[table].Columns.Count; j++)
				{
					Console.Write(GroupsRelatedData.Tables[table].Rows[i][j] + "\t") ;
                }
				Console.WriteLine(GroupsRelatedData.Tables[table].Rows[i].GetParentRow("GroupsDirections")["direction_name"]);
                Console.WriteLine();
            }
            Console.WriteLine("\n========================================================\n");
        }
		
		//*ChildColumn -> ParentColumn*/ находим родительскую колонку в другой таблице по дочерней колонке в таблице, которую передаем в качестве первого параметра
		

		[DllImport("kernel32.dll")]
		public static extern bool AllocConsole();
		[DllImport("kernel32.dll")]
		public static extern bool FreeConsole();

	}
}
