using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;      // ADO.NET classes

namespace ADO.NET
{
	internal class Program
	{
		static void Main(string[] args)
		{
            Console.WriteLine("Hello, ADO");
			const int PADDING = 33;

			const string CONNECTION_STRING = "Data Source=(localdb)" +
				"\\ProjectModels;Initial Catalog=Movies_VPD_311;Integrated Security=True;" +
				"Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;Application" +
				"Intent=ReadWrite;MultiSubnetFailover=False";
            Console.WriteLine(CONNECTION_STRING);

			// 1) Создаем подключение к базе
			SqlConnection connection = new SqlConnection(CONNECTION_STRING);

			// 2) Создаем команду, которую хотим выполнить на Сервере:
			string cmd = "SELECT * FROM Movies";
			SqlCommand command = new SqlCommand(cmd, connection);

			// 3) Получаем результаты запроса с Сервера:
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();

			// 4) Обрабатываем результаты запроса:
			if(reader.HasRows)
			{
				for(int i=0; i<reader.FieldCount;i++)
                    Console.Write(reader.GetName(i).ToString().PadRight(PADDING));
                Console.WriteLine();
                while (reader.Read())
				{
					//Console.WriteLine($"{reader[0]}\t{reader[1]}\t{reader[2]}\t");
					for(int i = 0; i<reader.FieldCount; i++)
					{
						Console.Write(reader[i].ToString().PadRight(PADDING));
                    }
                    Console.WriteLine();
                }
			}

			//5) Закрываем поток и соединение с Сервером
			reader.Close();
			connection.Close();

        }
	}
}
