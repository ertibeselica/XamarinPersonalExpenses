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
using Xamarin.Essentials;

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

            if (shpenzimetPicker.SelectedItem != null)
            {
                UserExpenseVM userInc = new UserExpenseVM();
                userInc.UserId = (int)Application.Current.Properties["userId"];
                userInc.ExpenseId = shpenzimetPicker.SelectedIndex + 1;
                userInc.ExpenseValue = Convert.ToDecimal(shpenzimiEntry.Text);

                HttpClient httpClient = new HttpClient();
                var json = JsonConvert.SerializeObject(userInc);
                var uri = new Uri("https://personalexpensesapi.conveyor.cloud/api/usersexpens");
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    shpenzimiEntry.Text = null;
                    Vibration.Vibrate();                   
                    await DisplayAlert("Sukses", "Shpenzimi u shtua me sukses", "OK");
                    await Navigation.PopAsync();
                }

                else
                {
                    await DisplayAlert("DESHTOI", "Ka deshtuar " + json, "OK");
                }
            }
        }
    }
}