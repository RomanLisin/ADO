using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Academy;

namespace AcademyDataSet
{
	//2. вынести DataSet и весь его функционал в класс Cache;
	internal class Cache : DataSet
	{
		readonly string CONNECTION_STRING;
		Connector connection;
		public Cache(string connectionString)
		{
			CONNECTION_STRING = connectionString;
			connection = new Connector(CONNECTION_STRING);
		}
		public void AddTable(string table, string columns)
		{
			//2.1)Добавляем таблицу в DataSet
			this.Tables.Add(table);

			//2.2) Добавляем поля (столбики) в таблицу:
			string[] a_columns = columns.Split(',');
			//for (int i = 0; i < a_columns.Length; i++)
			//{
			foreach(var col in a_columns)
			{ 
				//Поддержка синтаксиса: "columnName:type"
				string[] parts = col.Split(':');
				string columnName = parts[0];
				Type columnType = typeof(string); // по умолчанию
				if(parts.Length > 1)
				{
					string typeName = parts[1].ToLower();
					switch (typeName)
					{
						case "int":
						case "int32":
							columnType = typeof(int);
							break;
						case "string":
							columnType = typeof(string);
							break;
						case "datatime":
							columnType = typeof(DateTime);
							break;
						case "bool":
							columnType = typeof(bool);
							break;
					}
				}

				this.Tables[table].Columns.Add(columnName,columnType);
			}
			// 2.3) Определяем, какое поле будет первичным ключом:
			this.Tables[table].PrimaryKey =
				new DataColumn[] { this.Tables[table].Columns[0] };

			string cmd = $"SELECT {string.Join(",",a_columns.Select(c => c.Split(':')[0]))} FROM {table}";
			SqlDataAdapter adapter = new SqlDataAdapter(cmd, connection.GetConnection());
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
