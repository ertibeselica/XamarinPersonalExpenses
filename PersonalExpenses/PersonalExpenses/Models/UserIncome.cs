using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalExpenses.Models
{
    public class UserIncome
    {
        public int UserId { get; set; }
        public string IncomeName { get; set; }
        public decimal? Amount { get; set; }

        public UserIncome(int userId, string incomename,decimal amount)
        {
            UserId = userId;
            IncomeName = incomename;
            Amount = amount;
        }
    }
}
