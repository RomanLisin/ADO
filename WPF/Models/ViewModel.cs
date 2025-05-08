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
using Caching;




namespace WPF//.Models
{
	public class ViewModel : INotifyPropertyChanged
	{
		private readonly string CONNECTION_STRING;
		private Cache groupsRelatedData;

		public event PropertyChangedEventHandler PropertyChanged;
	public ViewModel()
	{
		CONNECTION_STRING = ConfigurationManager.ConnectionStrings["VPD_311_Import"].ConnectionString;
		// Initialize data
		groupsRelatedData = new Cache(CONNECTION_STRING);
		groupsRelatedData.AddTable("Directions", "direction_id:int,direction_name:string");
		
	}
	}

}
