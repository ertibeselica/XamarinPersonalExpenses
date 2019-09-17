using PersonalExpenses.ViewModels;
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
	public partial class LogInPage : ContentPage
	{
		public LogInPage ()
		{
			InitializeComponent ();
            BindingContext = (UserViewModel)BindingContext;
            
		}
	}
}