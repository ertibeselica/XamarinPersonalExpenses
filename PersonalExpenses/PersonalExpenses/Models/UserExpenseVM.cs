using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalExpenses.Models
{
    public class UserExpenseVM
    {
        public int UserId { get; set; }
        public int ExpenseId { get; set; }
        public decimal ExpenseValue { get; set; }
    }
}
