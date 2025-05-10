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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Data;


namespace WPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			ViewModel viewModel = new ViewModel();
			studentsDataGrid.ItemsSource = viewModel.dataSet.Set.Tables["Students"].DefaultView;
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{

		}
		private void btnStart_Click(object sender, RoutedEventArgs e)
		{
		
		}
	}
}
