using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalExpenses.Models
{
    public class UserExpense
    {        
        public string Username { get; set; }
        public int UserId { get; set; }
        public int ExpenseId { get; set; }
        public string ExpenseName { get; set; }
        public Nullable<decimal> ExpenseValue { get; set; }

        public virtual Income Income { get; set; }
        public virtual User User { get; set; }
    }
}
