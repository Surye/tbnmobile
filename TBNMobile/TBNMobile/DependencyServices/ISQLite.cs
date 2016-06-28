using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net;

namespace TBNMobile.DependencyServices
{
    interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
