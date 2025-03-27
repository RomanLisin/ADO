using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.SqlClient;
using System.Configuration;

namespace MoviesForms
{
	internal class Connector
	{
		// строка подключения к базе данных
		readonly string CONNECTION_STRING;
		// объект подключения к базе даннныч SQL Server
		readonly SqlConnection connection;

		// конструктор по умолчанию, использует строку подключения из конфигурационного файла
		public Connector() : this(ConfigurationManager.ConnectionStrings["Movies_VPD_311"].ConnectionString)
		{
			//CONNECTION_STRING =
			//	ConfigurationManager.ConnectionStrings["Movies_VPD_311"].ConnectionString;
			//this.connection = new SqlConnection(CONNECTION_STRING);
		}

		// Конструктор с параметром, принимает строку подключения
		public Connector(string connection_string)
		{
			this.CONNECTION_STRING = connection_string; // Сохраняем строку подключения
			this.connection = new SqlConnection(CONNECTION_STRING); // Создаем подключение к SQL Server
			Console.WriteLine(CONNECTION_STRING);  // Выводим строку подключения в консоль для отладки
		}
		public void InsertDirector(string first_name, string last_name)
		{
			string condition = $"last_name = N'{last_name}' AND first_name= N'{first_name}'";

			string query = $"INSERT Directors(first_name, last_name) VALUES (N'{first_name}', N'{last_name}')";
			string cmd = $"IF NOT EXISTS (SELECT director_id FROM Directors WHERE {condition}) BEGIN {query} END";
			// Создаем SQL-команду
			SqlCommand command = new SqlCommand(cmd, connection);

			// Открываем соединение с базой данных
			connection.Open();
			command.ExecuteNonQuery();  // Выполняем SQL-запрос
			connection.Close();  // Закрываем соединение
		}
	}
}
