using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalExpenses.Models
{
    public class UserExpense
    {
        private User user;

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        private Expense expense;

        public Expense Expense
        {
            get { return expense; }
            set { expense = value; }
        }

        private decimal expenseValue;

        public decimal ExpenseValue
        {
            get { return expenseValue; }
            set { expenseValue = value; }
        }
    }
}
