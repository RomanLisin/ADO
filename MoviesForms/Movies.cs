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


namespace MoviesForms
{
	public partial class movies : Form
	{
		FormAddDirector formAddDirector;
		FormAddMovie formAddMovie;
		public movies()
		{
			InitializeComponent();

			formAddDirector = new FormAddDirector(this);  // инициализируем
			formAddMovie = new FormAddMovie(this);  // инициализируем
			dateTimePicker1.MinDate = new DateTime(1970, 1, 1);

			Connector connector = new Connector();
			connector.Select(this.comboBoxMovies, "title + ' (' + CONVERT(varchar(10), release_date, 101) + ') - ' + first_name + ' ' + last_name AS DisplayText", "Movies,Directors","director_id=director");
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
				Connector connector = new Connector();
				connector.Select(this.comboBoxMovies, "title + ' (' + CONVERT(varchar(10), release_date, 101) + ') - ' + first_name + ' ' + last_name AS DisplayText", "Movies,Directors", "director_id=director");
			}
		public void ReloadDirectorCombobox()
		{
			Connector connector = new Connector();
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
			Connector connector = new Connector();
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
			Connector connector = new Connector();
			connector.DeleteMovie(comboBoxMovies.SelectedItem.ToString());
            //Console.WriteLine(comboBoxMovies.SelectedItem.ToString());
			comboBoxMovies.Items.Clear();
			comboBoxMovies.Text = "";
			connector.Select(this.comboBoxMovies, "title + ' (' + CONVERT(varchar(10), release_date, 101) + ') - ' + first_name + ' ' + last_name AS DisplayText", "Movies,Directors", "director_id=director");
		}

		private void buttonFilter_Click(object sender, EventArgs e)
		{
			comboBoxDirectors.Text = "";
			dateTimePicker1.Value = dateTimePicker1.MinDate;
			dateTimePicker2.Value = DateTime.Today;
		}
	}
	
}
