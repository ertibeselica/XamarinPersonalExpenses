using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalExpenses.Models
{
    public class User
    {
        private int userId;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string surname;

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        private string username;

        public string Username
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

        private decimal balance;

        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }






    }
}
