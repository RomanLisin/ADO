using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace MoviesForms
{
	public partial class FormAddDirector : Form
	{
		private movies parentForm;  // Ссылка на главную форму
		public FormAddDirector(movies parent)
		{
			InitializeComponent();
			parentForm = parent;  // Сохраняем ссылку на главную форму
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			Connector connector = new Connector();
			connector.InsertDirector(textBoxFirstName.Text, textBoxLastName.Text);
			// Обновляем список режиссёров в главной форме
			parentForm.ReloadDirectorCombobox();
		}
	}
}
