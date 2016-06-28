using System.Collections.Generic;
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

            // For Debugging
            Conn.DropTable<Show>();
            Conn.DropTable<Episode>();

            // Create tables if needed.
            Conn.CreateTable<Show>();
            Conn.CreateTable<Episode>();

            SeedShows();
        }

        private void SeedShows()
        {
            Conn.InsertAll(new List<Show>
            {
                new Show()
                {
                    Name = "The Session",
                    ImageName = "TheSessionCover.png",
                    RssFeed = "http://thebrewingnetwork.com/sundayshow_test.xml",
                },
                new Show()
                {
                    Name = "The Sour Hour",
                    ImageName = "TheSourHourCover.png",
                    RssFeed = "http://www.thebrewingnetwork.com/feed/sour-hour/",
                },
                new Show()
                {
                    Name = "Dr. Homebrew",
                    ImageName = "DrHomebrewCover.png",
                    RssFeed = "http://www.thebrewingnetwork.com/feed/doctor-homebrew/",
                },
                new Show()
                {
                    Name = "Brew Strong",
                    ImageName = "BrewStrongCover.png",
                    RssFeed = "http://www.thebrewingnetwork.com/feed/brew-strong/",
                },
                new Show()
                {
                    Name = "Brewing With Style",
                    ImageName = "BrewingWithStyleCover.png",
                    RssFeed = "http://www.thebrewingnetwork.com/feed/bws/",
                },
                new Show()
                {
                    Name = "Can You Brew It",
                    ImageName = "CYBICover.png",
                    RssFeed = "http://www.thebrewingnetwork.com/feed/cybi/",
                },
                new Show()
                {
                    Name = "The Jamil Show",
                    ImageName = "JamilShowCover.png",
                    RssFeed = "http://www.thebrewingnetwork.com/feed/jamil-show/",
                },
//              // No RSS Feed, Defunct Show, maybe just hard code the existing few episodes? Created a hosted XML for them?
//              new Show()
//              {
//                  Name = "The Home Brewed Chef",
//                  ImageName = "HomeBrewedChefCover.png",
//                  RssFeed = "http://www.thebrewingnetwork.com/feed/brew-strong/",
//              },
            });
        }
    }
}
