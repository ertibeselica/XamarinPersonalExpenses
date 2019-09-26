using Newtonsoft.Json;
using PersonalExpenses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace PersonalExpenses.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddIncomePage : ContentPage
    {
        HttpClient httpClient;
        public int UserId { get; set; }

        public AddIncomePage()
        {
            InitializeComponent();
        }

        private async void ShtoHyjre_Clicked(object sender, EventArgs e)
        {
            int userId = (int)Application.Current.Properties["userId"];
            int incomeId = teHyratPicker.SelectedIndex+1;
            decimal amount = Convert.ToDecimal(shumaEntry.Text);

            UserIncomeVM userInc = new UserIncomeVM();
            userInc.UserId = userId;
            userInc.IncomeId = incomeId;
            userInc.Amount = amount;



            if (teHyratPicker.SelectedItem != null)
            {

                httpClient = new HttpClient();
                var json = JsonConvert.SerializeObject(userInc);
                var uri = new Uri("https://personalexpensesapi.conveyor.cloud/api/usersincomes");
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    shumaEntry.Text = null;
                    Vibration.Vibrate();
                    await Flashlight.TurnOnAsync();
                    await DisplayAlert("Sukses", "E hyra u shtua me sukses", "OK");
                    await Task.Delay(1000);
                    await Flashlight.TurnOffAsync();
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

