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
	public partial class AddIncome : ContentPage
	{
        HttpClient httpClient;
        public int UserId { get; set; }
        
        public AddIncome ()
		{
			InitializeComponent ();
		}

        private async void ShtoShpenzim_Clicked(object sender, EventArgs e)
        {
            if (ShpenzimetPicker.SelectedItem!=null)
            {
                httpClient = new HttpClient();                

                UserId = (int)Application.Current.Properties["userId"];
                httpClient = new HttpClient();
                var uri = new Uri($"http://localhost:50562/api/usersincomes?userid{UserId}&incomename={(ShpenzimetPicker.SelectedItem as Income).IncomeName}&amount={Convert.ToDecimal(shumaEntry.Text)}");
                var userIncome = new UserIncome(UserId,(ShpenzimetPicker.SelectedItem as Income).IncomeName, Convert.ToDecimal(shumaEntry.Text));
                var content = JsonConvert.SerializeObject(userIncome);
                await httpClient.PostAsync(uri, new StringContent(content));
                shumaEntry.Text = null;               
                
                //User useri = new User((int)Application.Current.Properties["userId"]);
                //Income income =  
                //UserIncome userIncome = new UserIncome(useri,)
            }
        }
    }
}