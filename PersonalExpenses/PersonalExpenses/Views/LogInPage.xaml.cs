using Newtonsoft.Json;
using PersonalExpenses.Models;
using PersonalExpenses.ViewModels;
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
	public partial class LogInPage : ContentPage
	{
        HttpClient httpClient;
        User useri;
        public LogInPage ()
		{
			InitializeComponent ();
            //BindingContext = (UserViewModel)BindingContext;
            
		}

        private async void LoginBtn_Clicked(object sender, EventArgs e)
        {
            
            if (await ValidateLogin(usernameEntry.Text, passwordEntry.Text))
            {
                await Navigation.PushAsync(new HomePage());
                //App.Current.MainPage = new HomePage();
            }
        }

        private void RegisterBtn_Clicked(object sender, EventArgs e)
        {

        }

        public virtual async Task<bool> ValidateLogin(string username, string password)
        {
            httpClient = new HttpClient();
            var uri = new Uri($"https://personalexpensesapi.conveyor.cloud/api/users?username={username}&password={password}");
            var response = await httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                if(content==null)
                    await Application.Current.MainPage.DisplayAlert("Error", "Diqka Shkoi Gabim", "Cancel");
                useri = JsonConvert.DeserializeObject<User>(content);
                Application.Current.Properties["userId"] = useri.UserId;
                Application.Current.Properties["username"] = useri.Username;

            }

            if (username == null || username != useri.Username)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Username nuk eshte te sakta", "Cancel");
                return false;
            }
            else if (password == null || password != useri.Password)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Passwordi nuk eshte i sakta", "Cancel");
                return false;
            }
            return true;
        }
    }
}