using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ListView
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void btbAdd_Click(object sender, RoutedEventArgs e)
		{
			if (lvEtries.Items.Contains(txtEntry.Text)) return;
			lvEtries.Items.Add(txtEntry.Text);
        }

		private void btnDelete_Click(object sender, RoutedEventArgs e)
		{
			if (lvEtries.SelectedIndex == -1) return;
			lvEtries.Items.RemoveAt(lvEtries.SelectedIndex);
		}

		private void btnClear_Click(object sender, RoutedEventArgs e)
		{
			lvEtries.Items.Clear();
		}
	}
}
