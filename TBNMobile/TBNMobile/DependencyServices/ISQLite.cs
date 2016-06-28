using SQLite.Net;

namespace TBNMobile.DependencyServices
{
    interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
