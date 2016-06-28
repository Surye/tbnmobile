using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net;
using TBNMobile.Database.Models;
using TBNMobile.DependencyServices;
using Xamarin.Forms;

namespace TBNMobile.Database
{
    public class TBNDatabase
    {
        private SQLiteConnection Conn { get; set; }

        public TBNDatabase()
        {
            Conn = DependencyService.Get<ISQLite>().GetConnection();

            Conn.CreateTable<Show>();
            Conn.CreateTable<Episode>();
        }
    }
}
