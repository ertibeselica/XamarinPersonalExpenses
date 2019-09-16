using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalExpenses.Models
{
    public class Expense
    {
        private string expenseId;

        public string ExpenseId
        {
            get { return expenseId; }
            set { expenseId = value; }
        }

        private string expenseName;

        public string ExpenseName
        {
            get { return expenseName; }
            set { expenseName = value; }
        }
    }
}
