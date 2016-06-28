using System.Collections.Generic;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace TBNMobile.Database.Models
{
    class Show
    {
        [AutoIncrement, PrimaryKey]
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }
        public string RssFeed { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Episode> Episodes { get; set; }
    }
}
