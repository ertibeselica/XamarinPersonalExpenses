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

        //public UserViewModel()
        //{
        //    GoToHomePageCommand = new Command<User>(GoToHomeAsync);            
            
        //}

        //public virtual async void GoToHomeAsync()
        //{
        //    if (await ValidateLogin())
        //    {
        //        Application.Current.Properties["userId"] = user.UserId;                
        //        //await Navigation.PushAsync(new HomePage());
        //        App.Current.MainPage = new HomePage();
        //    }
        //}
        //protected virtual async Task<bool> ValidateAsync<T>(T data)
        //    where T : class
        //{
        //    if (data is User)
        //    {
        //        return await ValidateLogin(data as User);
        //    }

        //    return true;
        //}

        public virtual async Task<bool> ValidateLogin(string username,string password)
        {    
            httpClient = new HttpClient();
            var uri = "http://localhost:50562/api/users?username={username}&password={password}";
            var response = await httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                useri = JsonConvert.DeserializeObject<User>(content);

            }

            if (username==null || username!=useri.Username)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Username nuk eshte te sakta", "Cancel");
                return false;
            }
            else if (password == null || password!=useri.Password )
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Passwordi nuk eshte i sakta", "Cancel");
                return false;
            }
            return true;
        }

        

    }
}
