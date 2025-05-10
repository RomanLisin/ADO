using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Windows;
using CacheLibrary;




namespace WPF//.Models
{
	public class ViewModel : INotifyPropertyChanged
	{

		private readonly string CONNECTION_STRING;
		private Cache cache;
		public Cache dataSet { get => cache; }

		public event PropertyChangedEventHandler PropertyChanged;
	public ViewModel()
	{
		CONNECTION_STRING = ConfigurationManager.ConnectionStrings["VPD_311_Import"].ConnectionString;
		// Initialize data
		cache = new Cache(CONNECTION_STRING);

			cache.AddTable("Students", "stud_id,last_name,first_name,middle_name,group");
			cache.AddTable("Directions", "direction_id,direction_name");
			cache.AddTable("Groups", "group_id,group_name,direction");

		}
	}

}
