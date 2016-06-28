using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TBNMobile.DependencyServices;
using TBNMobile.Droid.DependencyServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidSQLite))]
namespace TBNMobile.Droid.DependencyServices
{
    public class AndroidSQLite : ISQLite
    {
        public AndroidSQLite() { }
        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFilename = "TBNMobile.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            // Create the connection
            var conn = new SQLite.SQLiteConnection(path);
            // Return the database connection
            return conn;
        }
    }
}