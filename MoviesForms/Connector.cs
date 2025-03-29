using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace MoviesForms
{
	internal class Connector
	{
		static readonly int PADDING = 5;
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

		public void DeleteMovie(string  name)
		{
			string title = name.Split('(')[0].Trim();
			string condition = $"title = N'{title}'";
			string query = $"DELETE FROM Movies WHERE {condition}";
			string cmd = $"IF EXISTS (SELECT title FROM Movies WHERE {condition}) BEGIN {query} END";

			// создаем SQL - комманду
			SqlCommand command = new SqlCommand(cmd, connection);

			// открываем соединение с базой данных
			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
		}
		public void DeleteDirector(string director)
		{
			// Разделяем имя режиссера на части (если нужно)
			string[] directorParts = director.Split(' ');
			string firstName = directorParts[0];
			string lastName = directorParts.Length > 1 ? directorParts[1] : "";
			string condition = $"last_name = N'{lastName}' AND first_name = N'{firstName}'";
			string query = $"DELETE FROM Directors WHERE N'{lastName}' = last_name";
			string cmd = $"IF NOT EXISTS (SELECT director FROM Movies,Directors WHERE {condition} AND director = director_id) BEGIN {query} END";
			// Создаем SQL-команду
			SqlCommand command = new SqlCommand(cmd, connection);

			// Открываем соединение с базой данных
			connection.Open();
			command.ExecuteNonQuery();  // Выполняем SQL-запрос
			connection.Close();  // Закрываем соединение
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

		//public void InsertMovie(string title, string director, DateTimePicker dateRelease)
		//{
		//	string condition = $"release_date = N'{dateRelease.Value}' AND  director = (SELECT director_id FROM Directors WHERE N'{director.Split(' ')[0]}' = first_name)";
		//	string subQuery = $"SELECT director_id FROM Directors WHERE first_name = N'{director.Split(' ')[0]}";
		//	string query = $"INSERT Movies(title, release_date, director) VALUES (N'{title}', N'{dateRelease.Value}', N'{subQuery}' )";
		//	string cmd = $"IF NOT EXISTS (SELECT movie_id FROM Movies WHERE N'{condition}') BEGIN N'{query}' END";
		//	// Создаем SQL-команду
		//	SqlCommand command = new SqlCommand(cmd, connection);

		//	// Открываем соединение с базой данных
		//	connection.Open();
		//	command.ExecuteNonQuery();  // Выполняем SQL-запрос
		//	connection.Close();  // Закрываем соединение
		//}

		public void InsertMovie(string title, string director, DateTimePicker dateRelease)
		{
			// Разделяем имя режиссера на части (если нужно)
			string[] directorParts = director.Split(' ');
			string firstName = directorParts[0];
			string lastName = directorParts.Length > 1 ? directorParts[1] : "";

			// Формируем запрос с параметрами для защиты от SQL-инъекций
			string query = @"
        DECLARE @directorId INT
        
        -- Находим ID режиссера
        SELECT @directorId = director_id 
        FROM Directors 
        WHERE first_name = @firstName AND last_name = @lastName
        
        -- Если режиссер не найден, можно добавить обработку этого случая
        -- или вставить нового режиссера
        
        -- Вставляем фильм, если он еще не существует
        IF NOT EXISTS (
            SELECT 1 
            FROM Movies 
            WHERE title = @title 
            AND release_date = @releaseDate
            AND director = @directorId
        )
        BEGIN
            INSERT INTO Movies(title, release_date, director) 
            VALUES (@title, @releaseDate, @directorId)
        END";

			// Создаем SQL-команду с параметрами
			SqlCommand cmd = new SqlCommand(query, connection);

			// Добавляем параметры
			cmd.Parameters.AddWithValue("@title", title);
			cmd.Parameters.AddWithValue("@releaseDate", dateRelease.Value);
			cmd.Parameters.AddWithValue("@firstName", firstName);
			cmd.Parameters.AddWithValue("@lastName", lastName);

			try
			{
				connection.Open();
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				// Обработка ошибок
				MessageBox.Show($"Ошибка при добавлении фильма: {ex.Message}");
			}
			finally
			{
				connection.Close();
			}
		}
		public void Select(Control control, string fields, string tables, string condition = "" ) // cmd)
		{
			int width = 0;

			if (control is ComboBox comboBox) comboBox.Items.Clear();
			else if (control is ListBox listBox) listBox.Items.Clear();
			else if (control is TextBox textBox) textBox.Text = "";

			// 1) Создаем подключение к базе
			//SqlConnection connection = new SqlConnection(CONNECTION_STRING);

			// 2) Создаем команду, которую хотим выполнить на Сервере:
			//string cmd = "SELECT * FROM Movies";
			// Формируем SQL-запрос
			string cmd = $"SELECT {fields} FROM {tables}";
			if (condition != "") cmd += $" WHERE {condition}";

			// создаем SQL-команду
			SqlCommand command = new SqlCommand(cmd, connection);

			// 3) получаем результаты запроса с Сервера:
			connection.Open();
			// выполняем команду и получаем объект SqlDataReader для чтения данных
			SqlDataReader reader = command.ExecuteReader();

			// 4) Обрабатываем результаты запроса:
			if (reader.HasRows)
			{
				//// выводим заголовки столбцов
				//for (int i = 0; i < reader.FieldCount; i++)
				//	Console.Write(reader.GetName(i).ToString().PadRight(PADDING));
				//Console.WriteLine();
				// читаем и выводим строки результата
				while (reader.Read())
				{
					//Console.WriteLine($"{reader[0]}\t{reader[1]}\t{reader[2]}\t");
					for (int i = 0; i < reader.FieldCount; i++)
					{
						string value = reader[i].ToString().PadRight(PADDING);
						
						if (control is ComboBox cb) cb.Items.Add(value);
						else if (control is ListBox lb) lb.Items.Add(value);
						else if (control is TextBox tb) tb.Text += value + Environment.NewLine;
						//Console.Write(reader[i].ToString().PadRight(PADDING));
					}
					//Console.WriteLine();
				}
			}

			//5) Закрываем поток и соединение с Сервером
			reader.Close();
			connection.Close();
		}
	}
}