﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;  // Для того, чтобы подключить консоль

using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Academy
{
	internal class Connector
	{
		readonly string CONNECTION_STRING;
		SqlConnection connection;
		public Connector(string connection_string)
		{
			CONNECTION_STRING = connection_string ;
			connection = new SqlConnection(CONNECTION_STRING);
			AllocConsole();
            Console.WriteLine(CONNECTION_STRING);

        }
		public DataTable Select(string columns, string tables, string condition = "", string group_by = "")
		{
			DataTable table = null;
			string cmd = $"SELECT {columns} FROM {tables}";
			if (condition != "") cmd += $" WHERE {condition}";
			if (group_by != "") cmd += $" GROUP BY {group_by}";

			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();

			SqlDataReader reader = command.ExecuteReader();
			if (reader.HasRows)
			{
				//1)Создаем таблицу
				table = new DataTable();

				//2) Определяем набор полей таблицы (добавляем столбики в таблицу):
				for (int i = 0; i < reader.FieldCount; i++)
					table.Columns.Add(reader.GetName(i));

				//3) Добавляем строки в таблицу
				while (reader.Read())
				{
					// 4) создаем строку
					DataRow row = table.NewRow(); // строка создается через нашу таблицу,  поскольку у нее должен  ??
					//5) Загружаем данные в строку:
					for (int i = 0; i < reader.FieldCount; i++)
						row[i] = reader[i];
					//6) добавляем строку в таблицу
					table.Rows.Add(row);
				}

			}
			reader.Close();
			connection.Close();
			return table;
		}

		[DllImport("kernel32.dll")]
		public static extern bool AllocConsole();
		[DllImport("kernel32.dll")]
		public static extern bool FreeConsole();
	}
}
