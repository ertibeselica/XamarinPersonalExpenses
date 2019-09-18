using PersonalExpenses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalExpenses.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddIncome : ContentPage
	{
		public AddIncome ()
		{
			InitializeComponent ();
		}

        private void ShtoShpenzim_Clicked(object sender, EventArgs e)
        {
            if (ShpenzimetPicker.SelectedItem!=null)
            {
                User useri = new User((int)Application.Current.Properties["userId"]);
                Income income =  
                UserIncome userIncome = new UserIncome(useri,)
            }
        }
    }
}