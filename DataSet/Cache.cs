using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyDataSet
{
	//2. вынести DataSet и весь его функционал в класс Cache;
	internal class Cache : DataSet
	{
		string CONNECTION_STRING;
		SqlConnection connection = null;
		public Cache(string CONNECTION_STRING)
		{
			connection = new SqlConnection(CONNECTION_STRING);
		}
		public void AddTable(string table, string columns)
		{
			//2.1)Добавляем таблицу в DataSet
			this.Tables.Add(table);

			//2.2) Добавляем поля (столбики) в таблицу:
			string[] a_columns = columns.Split(',');
			for (int i = 0; i < a_columns.Length; i++)
			{
				this.Tables[table].Columns.Add(a_columns[i]);
			}
			// 2.3) Определяем, какое поле будет первичным ключом:
			this.Tables[table].PrimaryKey =
				new DataColumn[] { this.Tables[table].Columns[0] };

			string cmd = $"SELECT {columns} FROM {table}";
			SqlDataAdapter adapter = new SqlDataAdapter(cmd, connection);
			adapter.Fill(this.Tables[table]);
			Print(table);
		}
		public void AddRelation(string relation_name, string child, string parent)
		{
			this.Relations.Add
				(
					relation_name,
					this.Tables[parent.Split(',')[0]].Columns[parent.Split(',')[1]],
					this.Tables[child.Split(',')[0]].Columns[child.Split(',')[1]]
				);
		}
		public void Print(string table)
		{
			Console.WriteLine(table);
			Console.WriteLine("\n========================================================\n");
			for (int i = 0; i < this.Tables[table].Columns.Count; i++)
			{
				Console.Write(this.Tables[table].Columns[i].Caption + "\t");
			}
			Console.WriteLine("\n--------------------------------------------------------\n");

			for (int i = 0; i < this.Tables[table].Rows.Count; i++)
			{
				//Console.WriteLine(GroupsRelatedData.Tables[table].Rows[i] + ":\t");
				for (int j = 0; j < this.Tables[table].Columns.Count; j++)
				{
					Console.Write(this.Tables[table].Rows[i][j] + "\t\t");
				}
				Console.WriteLine();
			}
			Console.WriteLine("\n========================================================\n");
			for (int i = 0; i < this.Tables[table].Columns.Count; i++)
			{
				string parentColumn = GetParentColumnName(this.Tables[table].Columns[i]);
				Console.Write(this.Tables[table].Columns[i].Caption + "\t");
				if (parentColumn != null) Console.Write(parentColumn); else Console.Write("No parent column");
				Console.WriteLine();
			}
			Console.WriteLine("\n--------------------------------------------------------\n");
		}

		public string GetParentColumnName(DataColumn childColumn)
		{
			foreach (DataRelation relation in childColumn.Table.ParentRelations)
			{
				for (int i = 0; i < relation.ChildColumns.Length; i++)
				{
					if (relation.ChildColumns[i] == childColumn)
					{
						return relation.ParentColumns[i].ColumnName;
					}
				}
			}
			return null; // если не найдено
		}
	}
}
