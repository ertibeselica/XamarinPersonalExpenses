using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PersonalExpenses.Droid;
using Xamarin.Forms;
using SQLitePCL;
using SQLite;
using System.IO;

[assembly: Dependency(typeof(DatabaseService))]
namespace PersonalExpenses.Droid
{

    public class DatabaseService : IDBInterface
    {
        public SQLiteConnection GetConnection()
        {
            var dbase = "about.db3";
            var dbpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(dbpath, dbase);
            var connection = new SQLiteConnection(path);
            return connection;
        }
    }
}