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
		public FormAddMovie()
		{
			InitializeComponent();
			Connector connector = new Connector();
			connector.Select(this.comboBoxDirector, "first_name + ' ' + last_name AS full_name", "Directors");
		}

	}
}
