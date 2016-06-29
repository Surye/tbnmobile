using SQLite.Net;
using System.IO;
using SQLite.Net.Platform.WinRT;
using TBNMobile.DependencyServices;
using Windows.Storage;
using Xamarin.Forms;
// ...
[assembly: Dependency(typeof(UWPSQLite))]
// ...
public class UWPSQLite : ISQLite
{
    public UWPSQLite() { }
    public SQLiteConnection GetConnection()
    {
        var sqliteFilename = "TBNMobile.db3";
        string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
        var conn = new SQLiteConnection(new SQLitePlatformWinRT(), path);
        return conn;
    }
}