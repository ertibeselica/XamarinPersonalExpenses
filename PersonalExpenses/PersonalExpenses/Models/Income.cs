using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalExpenses.Models
{
    public class Income
    {
        private int incomeId;

        public int IncomeId
        {
            get { return incomeId; }
            set { incomeId = value; }
        }

        private string incomeName;

        public string IncomeName
        {
            get { return incomeName; }
            set { incomeName = value; }
        }


    }
}
