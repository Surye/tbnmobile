using System.Collections.Generic;
using SQLite.Net;
using TBNMobile.Database.Models;
using TBNMobile.DependencyServices;
using Xamarin.Forms;

namespace TBNMobile.Database
{
    public class TBNDatabase
    {
        public SQLiteConnection Conn { get; set; }

        public TBNDatabase()
        {
            Conn = DependencyService.Get<ISQLite>().GetConnection();

            // For Debugging
            //Conn.DropTable<Show>();
            //Conn.DropTable<Episode>();

            // Create tables if needed.
            Conn.CreateTable<Show>();
            Conn.CreateTable<Episode>();
            
            //SeedShows();
        }

        private void SeedShows()
        {
            Conn.InsertAll(new List<Show>
            {
                new Show()
                {
                    Name = "The Session",
                    ImageName = "TheSessionCover.png",
                    RssFeed = "http://www.thebrewingnetwork.com/sundayshow.xml",
                },
                new Show()
                {
                    Name = "The Sour Hour",
                    ImageName = "TheSourHourCover.png",
                    RssFeed = "http://www.thebrewingnetwork.com/sourhour.xml",
                },
                new Show()
                {
                    Name = "Dr. Homebrew",
                    ImageName = "DrHomebrewCover.png",
                    RssFeed = "http://www.thebrewingnetwork.com/drhomebrew.xml",
                },
                new Show()
                {
                    Name = "Brew Strong",
                    ImageName = "BrewStrongCover.png",
                    RssFeed = "http://www.thebrewingnetwork.com/brewstrong.xml",
                },
                new Show()
                {
                    Name = "The Jamil Show",
                    ImageName = "JamilShowCover.png",
                    RssFeed = "http://www.thebrewingnetwork.com/jamilshow.xml",
                },
                new Show()
                {
                    Name = "The Home Brewed Chef",
                    ImageName = "HomeBrewedChefCover.png",
                    RssFeed = "http://www.thebrewingnetwork.com/homebrewedchef.xml",
                },
            });
        }
    }
}
