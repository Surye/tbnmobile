using System;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace TBNMobile.Database.Models
{
    class Episode
    {
        [PrimaryKey]
        public string Guid { get; set; }

        public string Title { get; set; }
        public string Subtitle { get; set; }

        [ForeignKey(typeof(Show))]
        public int ShowId { get; set; }
        [ManyToOne]
        public Show Show { get; set; }

        public string Description { get; set; }

        public DateTime AirTime { get; set; }

        public string Url { get; set; }

        public int Size { get; set; }

        public int Duration { get; set; }

        public bool Played { get; set; }

        public bool LocalName { get; set; }

    }
}
