using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MoviesForms
{
	public partial class FormAddMovie : Form
	{
		private movies parentForm;
		public FormAddMovie(movies parent)
		{
			InitializeComponent();
			Connector connector = new Connector();
			connector.Select(this.comboBoxDirector, "first_name + ' ' + last_name AS full_name", "Directors");
			parentForm = parent;
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			if (comboBoxDirector.SelectedItem == null)
			{
				MessageBox.Show("Select director to add!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (textBoxTitle.Text == "")
			{
				MessageBox.Show("Select movie to add!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			Connector connector = new Connector();
			connector.InsertMovie(this.textBoxTitle.Text, this.comboBoxDirector.Text, this.dateTimePickerRelease);
			this.textBoxTitle.Text = "";
			this.comboBoxDirector.SelectedIndex = -1;
			this.dateTimePickerRelease.Value = DateTime.Today;
			parentForm.ReloadMoviesComboBox();
		}
	}
}