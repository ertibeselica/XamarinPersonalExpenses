using PersonalExpenses.Models;
using PersonalExpenses.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace PersonalExpenses.ViewModels
{
    public class UserViewModel
    {
        public INavigation Navigation { get; set; }
        public ICommand GoToHomePageCommand { get; protected set; }
        LogInPage loginPage;
        HttpClient httpClient;
        User useri;
        private User user;

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public UserViewModel()
        {
            GoToHomePageCommand = new Command<User>(GoToHomeAsync);            
            
        }

        public virtual async void GoToHomeAsync(User user)
        {
            if (await ValidateAsync(user))
            {
                Application.Current.Properties["userId"] = user.UserId;                
                //await Navigation.PushAsync(new HomePage());
                App.Current.MainPage = new HomePage();
            }
        }
        protected virtual async Task<bool> ValidateAsync<T>(T data)
            where T : class
        {
            if (data is User)
            {
                return await ValidateLogin(data as User);
            }

            return true;
        }

        public virtual async Task<bool> ValidateLogin(User user)
        {    
            httpClient = new HttpClient();
            var uri = new Uri("");
            var response = await httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                useri = JsonConvert.DeserializeObject<User>(content);

            }

            if (user.Username==null || user.Username!=useri.Username)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Kredencialet nuk jane te sakta", "Cancel");
                return false;
            }
            else if (user.Password==null || user.Password!=useri.Password )
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Kredencialet nuk jane te sakta", "Cancel");
                return false;
            }
            return true;
        }

        

    }
}
