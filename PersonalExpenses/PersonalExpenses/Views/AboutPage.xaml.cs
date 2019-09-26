using PersonalExpenses.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalExpenses.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AboutPage : ContentPage
	{
        private SQLiteConnection conn;
        public string AppDetails { get; set; }
        public AboutPage ()
		{
			InitializeComponent ();
            conn = DependencyService.Get<IDBInterface>().GetConnection();
            conn.CreateTable<About>();
            DisplayDetails();
		}

        public void DisplayDetails()
        {
            var details = conn.Table<About>().FirstOrDefault();
            AppDetails = details.AboutDescription;
            detailsLbl.Text = AppDetails;

        }
    }
}