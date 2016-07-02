using SQLite.Net.Attributes;

namespace TBNMobile.Database.Models
{
    public class Show
    {
        [AutoIncrement, PrimaryKey]
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }
        public string RssFeed { get; set; }
    }
}
