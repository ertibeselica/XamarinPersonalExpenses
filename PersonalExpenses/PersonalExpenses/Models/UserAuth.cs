using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalExpenses.Models
{
    public class UserAuth
    {
        private string username;

        public string UserName
        {
            get { return username; }
            set { username = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }





    }
}
