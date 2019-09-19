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
            string incomeName = teHyratPicker.Items[teHyratPicker.SelectedIndex];
            decimal amount = Convert.ToDecimal(shumaEntry.Text);

            UserIncome userInc = new UserIncome();
            userInc.UserId = userId;
            userInc.IncomeName = incomeName;
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
                    await DisplayAlert("Sukses", "E hyra u shtua me sukses", "OK");
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

