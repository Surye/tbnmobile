using System.IO;

using SQLite.Net.Platform.XamarinAndroid;
using TBNMobile.DependencyServices;
using TBNMobile.Droid.DependencyServices;
using Xamarin.Forms;
using SQLite.Net;

[assembly: Dependency(typeof(AndroidSQLite))]
namespace TBNMobile.Droid.DependencyServices
{
    public class AndroidSQLite : ISQLite
    {
        public AndroidSQLite() { }
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "TBNMobile.db3";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            // Create the connection
            var conn = new SQLiteConnection(new SQLitePlatformAndroid(), path);
            // Return the database connection
            return conn;
        }
    }
}