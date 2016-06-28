using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TBNMobile.DependencyServices
{
    interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
