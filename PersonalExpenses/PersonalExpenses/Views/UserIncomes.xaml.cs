using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Connectivity;

namespace PersonalExpenses.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserIncomes : ContentPage
    {
        public UserIncomes userIncomes { get; set; }
        ObservableCollection<UserIncomes> listUserIncomes;
        HttpClient client;
        public UserIncomes()
        {
            InitializeComponent();
            Task.Run(async () =>
            {
                //if (CrossConnectivity.Current.IsConnected)
                //{
                //    var listRoutes = await GetInformationAsync((int)Application.Current.Properties["userId"]);
                //    if (listRoutes != null)
                //        foreach (var item in listRoutes)
                //            listUserIncomes.Add(item);


                //}

            });

            ListUserIncomes.ItemsSource = listUserIncomes;
        }

        public async Task<ObservableCollection<UserIncomes>> GetInformationAsync(int userId)
        {
            ObservableCollection<UserIncomes> userIncomes = new ObservableCollection<UserIncomes>();
            try
            {
                client = new HttpClient();

                var uri = $"";


                HttpResponseMessage response = await client.GetAsync(uri);


                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    userIncomes = JsonConvert.DeserializeObject<ObservableCollection<UserIncomes>>(result);
                    if (userIncomes != null)
                    {
                        return userIncomes;
                    }
                }
            }
            catch (Exception e)
            {

                e.ToString();
            }

            return userIncomes;
        }
    }
}