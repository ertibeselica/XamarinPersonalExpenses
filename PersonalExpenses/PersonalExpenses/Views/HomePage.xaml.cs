using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using SQLitePCL;
using PersonalExpenses.Models;

namespace PersonalExpenses.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private SQLiteConnection _sqlconnection;


        public HomePage()
        {

            InitializeComponent();
            _sqlconnection = DependencyService.Get<IDBInterface>().GetConnection();
            _sqlconnection.CreateTable<About>();
            
        }

        private async void GoToAddIncome_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new AddIncomePage()));
        }

        private async void ShowIncomes_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserIncomesPage());
        }

        private async void ShowShpenzimet_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserExpensesPage());
        }

        private async void GoToAddExpense_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddExpensePage());
        }

        private void Logoutbtn_Clicked(object sender, EventArgs e)
        {
            Application.Current.Properties["userId"] = null;
            Application.Current.Properties["username"] = null;
            Application.Current.MainPage = new LogInPage();
        }        
    }
}