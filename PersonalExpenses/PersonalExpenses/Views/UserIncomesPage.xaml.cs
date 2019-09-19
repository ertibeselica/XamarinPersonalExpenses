using Newtonsoft.Json;
using PersonalExpenses.Models;
using Plugin.Connectivity;
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
	public partial class UserIncomesPage : ContentPage
	{
        ObservableCollection<UserIncome> listUserIncomes;
        HttpClient client;
        public UserIncomesPage ()
		{
			InitializeComponent ();
            listUserIncomes = new ObservableCollection<UserIncome>();
            Task.Run(async () =>
            {
                
                    var listuserIncomes = await GetInformationAsync((int)Application.Current.Properties["userId"]);
                    if (listuserIncomes != null)
                        foreach (var item in listuserIncomes)
                            listUserIncomes.Add(item);

                

            });
            ListUserIncomes.ItemsSource = listUserIncomes;
        }

        public async Task<ObservableCollection<UserIncome>> GetInformationAsync(int userId)
        {
            ObservableCollection<UserIncome> listUserIncomes = new ObservableCollection<UserIncome>();
            try
            {
                client = new HttpClient();

                var uri = $"https://personalexpensesapi.conveyor.cloud/api/usersincomes/{userId}";


                HttpResponseMessage response = await client.GetAsync(uri);


                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    listUserIncomes = JsonConvert.DeserializeObject<ObservableCollection<UserIncome>>(result);
                    if (listUserIncomes != null)
                    {
                        return listUserIncomes;
                    }
                }
            }
            catch (Exception e)
            {

                e.ToString();
            }

            return listUserIncomes;
        }
    }
}