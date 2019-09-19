using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalExpenses.Models
{
    public class UserIncome
    {
        public int IncomeUserId { get; set; }
        public string Username { get; set; }
        public int UserId { get; set; }
        public int IncomeId { get; set; }
        public string IncomeName { get; set; }
        public Nullable<decimal> Amount { get; set; }

        public virtual Income Income { get; set; }
        public virtual User User { get; set; }
    }
}
