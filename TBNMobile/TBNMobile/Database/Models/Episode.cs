using System;
using SQLite.Net.Attributes;

namespace TBNMobile.Database.Models
{
    public class Episode
    {
        [PrimaryKey]
        public string ID { get; set; }

        public string Title { get; set; }
        public string Subtitle { get; set; }
        
        public int ShowId { get; set; }

        public string Description { get; set; }

        public DateTime AirTime { get; set; }

        public string Url { get; set; }

        public int Size { get; set; }

        public int Duration { get; set; }

        // Local State
        [Default(true, 0)]
        public int Position { get; set; }

        [Default(true, false)]
        public bool Downloaded { get; set; }

        [Default(true, false)]
        public bool Played { get; set; }

        public string LocalName { get; set; }

    }
}
