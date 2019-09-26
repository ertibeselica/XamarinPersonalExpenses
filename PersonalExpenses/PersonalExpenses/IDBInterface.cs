using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalExpenses
{
    public interface IDBInterface
    {
        SQLiteConnection GetConnection();
    }
}
