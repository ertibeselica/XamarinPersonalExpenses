using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PersonalExpenses.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalExpenses.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddExpensePage : ContentPage
    {
        public AddExpensePage()
        {
            InitializeComponent();
        }

        private async void ShtoShpenzim_Clicked(object sender, EventArgs e)
        {
            int userId = (int)Application.Current.Properties["userId"];
            int expenseId = shpenzimetPicker.SelectedIndex + 1;
            decimal expenseValue = Convert.ToDecimal(shpenzimiEntry.Text);

            UserExpenseVM userInc = new UserExpenseVM();
            userInc.UserId = userId;
            userInc.ExpenseId = expenseId;
            userInc.ExpenseValue = expenseValue;



            if (shpenzimetPicker.SelectedItem != null)
            {

                HttpClient httpClient = new HttpClient();
                var json = JsonConvert.SerializeObject(userInc);
                var uri = new Uri("https://personalexpensesapi.conveyor.cloud/api/usersexpens");
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    shpenzimiEntry.Text = null;
                    await DisplayAlert("Sukses", "Shpenzimi u shtua me sukses", "OK");
                    await Navigation.PopAsync();
                }

                else
                {
                    await DisplayAlert("Failed", "My Json " + json, "OK");
                }
            }
        }
    }
}