using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalExpenses.Models
{
    public class UserIncome
    {
        private User user;

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        private Income income;

        public Income Income
        {
            get { return income; }
            set { income = value; }
        }

        private decimal amount;

        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public UserIncome(User user,Income income,decimal amount)
        {
            User = user;
            Income = income;
            Amount = amount;            
        }
    }
}
