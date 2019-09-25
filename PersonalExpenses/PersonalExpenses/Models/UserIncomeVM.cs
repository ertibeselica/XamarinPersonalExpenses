using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalExpenses.Models
{
    public class UserIncomeVM
    {
        public int UserId { get; set; }
        public int IncomeId { get; set; }
        public decimal Amount { get; set; }
    }
}
