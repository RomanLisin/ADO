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

namespace MoviesForms
{
	public partial class Movies : Form
	{
		FormAddDirector formAddDirector;
		FormAddMovie formAddMovie;
		public Movies()
		{
			InitializeComponent();

			formAddDirector = new FormAddDirector();  // инициализируем
			formAddMovie = new FormAddMovie();  // инициализируем
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
	}
}
