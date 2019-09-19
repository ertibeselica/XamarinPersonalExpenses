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
    public partial class HomePage : ContentPage
    {

        public HomePage()
        {

            InitializeComponent();
        }

        private async void GoToAddIncome_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new AddIncome()));
        }

        private async void ShowIncomes_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserIncomesPage());
        }

        private async void ShowShpenzimet_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserExpensesPage());
        }
    }
}