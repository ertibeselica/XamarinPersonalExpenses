using Newtonsoft.Json;
using PersonalExpenses.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalExpenses.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserExpensesPage : ContentPage
	{
         HttpClient client;
        ObservableCollection<UserExpense> listUserExpenses;

        public UserExpensesPage ()
		{
			InitializeComponent ();
            listUserExpenses = new ObservableCollection<UserExpense>();
            Task.Run(async () =>
            {

                var listuserExpenses = await GetUserExpenses((int)Application.Current.Properties["userId"]);
                if (listuserExpenses != null)
                    foreach (var item in listuserExpenses)
                        listUserExpenses.Add(item);



            });
            ListUserExpenses.ItemsSource = listUserExpenses;
        }

        public async Task<ObservableCollection<UserExpense>> GetUserExpenses(int userId)
        {
            ObservableCollection<UserExpense> listUserExpenses = new ObservableCollection<UserExpense>();
            try
            {
                client = new HttpClient();

                var uri = $"https://personalexpensesapi.conveyor.cloud/api/usersexpens/{userId}";


                HttpResponseMessage response = await client.GetAsync(uri);


                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    listUserExpenses = JsonConvert.DeserializeObject<ObservableCollection<UserExpense>>(result);
                    if (listUserExpenses != null)
                    {
                        return listUserExpenses;
                    }
                }
            }
            catch (Exception e)
            {

                e.ToString();
            }

            return listUserExpenses;
        }
    }
}