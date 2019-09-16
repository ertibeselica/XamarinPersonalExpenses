using PersonalExpenses.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalExpenses.ViewModels
{
    public class UserViewModel
    {
        private User user;

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public UserViewModel()
        {
            user = new User();
        }

    }
}
