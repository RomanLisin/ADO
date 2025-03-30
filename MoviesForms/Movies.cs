using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.IO;


namespace MoviesForms
{
	public partial class movies : Form
	{
		FormAddDirector formAddDirector;
		FormAddMovie formAddMovie;
		Connector connector = new Connector();
		string fields = "title + ' (' + CONVERT(varchar(10), release_date, 23) + ') - ' + first_name + ' ' + last_name AS DisplayText";
		// For CONVERT
		//Основные стили форматирования даты в SQL Server
		//Код стиля Формат  Пример
		//101	MM/DD/YYYY	12/31/2023
		//103	DD/MM/YYYY	31/12/2023
		//112	YYYYMMDD	20231231
		//120	YYYY-MM-DD HH:MI:SS	2023-12-31 23:59:59
		string conditions = "director_id=director";

		public movies()
		{
			InitializeComponent();

			formAddDirector = new FormAddDirector(this);  // инициализируем
			formAddMovie = new FormAddMovie(this);  // инициализируем
			dateTimePicker1.MinDate = new DateTime(1980, 1, 1);

			//Connector connector = new Connector();
			connector.Select(this.comboBoxMovies, fields, "Movies,Directors", conditions);
			connector.Select(this.comboBoxDirectors, "first_name + ' ' + last_name AS full_name", "Directors");

			// Create the connection.
			//using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connectionString))
			//{
			//	// Create a SqlCommand, and identify it as a stored procedure.
			//	using (SqlCommand sqlCommand = new SqlCommand("Sales.uspNewCustomer", connection))
			//	{
			//		sqlCommand.CommandType = CommandType.StoredProcedure;

			//		// Add input parameter for the stored procedure and specify what to use as its value.
			//		sqlCommand.Parameters.Add(new SqlParameter("@CustomerName", SqlDbType.NVarChar, 40));
			//		sqlCommand.Parameters["@CustomerName"].Value = txtCustomerName.Text;

			//		// Add the output parameter.
			//		sqlCommand.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.Int));
			//		sqlCommand.Parameters["@CustomerID"].Direction = ParameterDirection.Output;

			//		try
			//		{
			//			connection.Open();

			//			// Run the stored procedure.
			//			sqlCommand.ExecuteNonQuery();

			//			// Customer ID is an IDENTITY value from the database.
			//			this.parsedCustomerID = (int)sqlCommand.Parameters["@CustomerID"].Value;

			//			// Put the Customer ID value into the read-only text box.
			//			this.txtCustomerID.Text = Convert.ToString(parsedCustomerID);
			//		}
			//		catch
			//		{
			//			MessageBox.Show("Customer ID was not returned. Account could not be created.");
			//		}
			//		finally
			//		{
			//			connection.Close();
			//		}
			//	}

			//}
		}
			 public void ReloadMoviesComboBox()
			{
				//Connector connector = new Connector();
				connector.Select(this.comboBoxMovies, fields, "Movies,Directors", conditions);
			}
		public void ReloadDirectorCombobox()
		{
			//Connector connector = new Connector();
			connector.Select(this.comboBoxDirectors, "first_name + ' ' + last_name AS full_name", "Directors");
		}


		private void buttonExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void ToolStripMenuItemAddDirector_Click(object sender, EventArgs e)
		{
			formAddDirector.ShowDialog(this);
		}

		private void ToolStripMenuItemAddMovie_Click(object sender, EventArgs e)
		{
			formAddMovie.ShowDialog(this);
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (comboBoxDirectors.SelectedItem == null)
			{
				MessageBox.Show("Select director for delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			//Connector connector = new Connector();
			connector.DeleteDirector(comboBoxDirectors.SelectedItem.ToString());
			comboBoxDirectors.Items.Clear();
			comboBoxDirectors.Text = "";
			connector.Select(this.comboBoxDirectors, "first_name + ' ' + last_name AS full_name", "Directors");

		}

		private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (comboBoxMovies.SelectedItem == null)
			{
				MessageBox.Show("Select movie for delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			//Connector connector = new Connector();
			connector.DeleteMovie(comboBoxMovies.SelectedItem.ToString());
            //Console.WriteLine(comboBoxMovies.SelectedItem.ToString());
			comboBoxMovies.Items.Clear();
			comboBoxMovies.Text = "";
			//comboBoxMovies.SelectedItem = null;
			connector.Select(this.comboBoxMovies, fields, "Movies,Directors", conditions);
			
		}

		private void buttonFilter_Click(object sender, EventArgs e)
		{
			
			//Connector connector = new Connector();
			comboBoxDirectors.Text = "";
			dateTimePicker1.Value = dateTimePicker1.MinDate;
			dateTimePicker2.Value = DateTime.Today;
			//UpdateMovieList();
			//if (comboBoxDirectors.SelectedItem == null)
			//{
			//	conditions = $"director_id = director AND release_date BETWEEN N'{this.dateTimePicker1.Value.Date.ToString("yyyy-MM-dd")}' " +
			//		$"AND N'{this.dateTimePicker2.Value.Date.ToString("yyyy-MM-dd")}' ";
			//}
			//else
			//{
			//	// Разделяем имя режиссера на части (если нужно)
			//	string[] directorParts = this.comboBoxDirectors.SelectedItem.ToString().Split(' ');
			//	string firstName = directorParts[0];
			//	string lastName = directorParts.Length > 1 ? directorParts[1] : "";
			//	conditions = $"director_id = director AND release_date BETWEEN N'{this.dateTimePicker1.Value.Date.ToString("yyyy-MM-dd")}' " +
			//		$"AND N'{this.dateTimePicker2.Value.Date.ToString("yyyy-MM-dd")}' " +
			//		$"AND first_name = N'{firstName}' AND last_name = N'{lastName}'";
			//}

			conditions = "director_id = director";
			connector.Select(this.comboBoxMovies, fields, "Movies,Directors", conditions);
		}

		private void comboBoxDirectors_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBoxDirectors.SelectedItem == null)
			{
				conditions = $"director_id = director AND release_date BETWEEN N'{this.dateTimePicker1.Value.Date.ToString("yyyy-MM-dd")}' " +
					$"AND N'{this.dateTimePicker2.Value.Date.ToString("yyyy-MM-dd")}' ";
			}
			else
			{
				// Разделяем имя режиссера на части (если нужно)
				string[] directorParts = this.comboBoxDirectors.SelectedItem.ToString().Split(' ');
				string firstName = directorParts[0];
				string lastName = directorParts.Length > 1 ? directorParts[1] : "";
				conditions = $"director_id = director AND release_date BETWEEN N'{this.dateTimePicker1.Value.Date.ToString("yyyy-MM-dd")}' " +
					$"AND N'{this.dateTimePicker2.Value.Date.ToString("yyyy-MM-dd")}' " +
					$"AND first_name = N'{firstName}' AND last_name = N'{lastName}'";
			}
			connector.Select(this.comboBoxMovies, fields, "Movies,Directors", conditions);
			//UpdateMovieList();
		}

		private void UpdateMovieList()
		{
			string startDate = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");
			string endDate = dateTimePicker2.Value.Date.ToString("yyyy-MM-dd");

			if (comboBoxDirectors.SelectedItem == null)
			{
				conditions = $"director_id = director AND release_date BETWEEN N'{startDate}' AND N'{endDate}'";
			}
			else
			{
				string[] directorParts = comboBoxDirectors.SelectedItem.ToString().Split(' ');
				string firstName = directorParts[0];
				string lastName = directorParts.Length > 1 ? directorParts[1] : "";

				conditions = $"director_id = director AND release_date BETWEEN N'{startDate}' AND N'{endDate}' " +
							 $"AND first_name = N'{firstName}' AND last_name = N'{lastName}'";
			}

			connector.Select(comboBoxMovies, fields, "Movies,Directors", conditions);
		}

	}
	
}
