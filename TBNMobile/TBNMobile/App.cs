using TBNMobile.Database;
using TBNMobile.Database.Models;
using TBNMobile.Podcast;
using Xamarin.Forms;

namespace TBNMobile
{
	public class App : Application
	{
	    public static TBNDatabase Database;

        public App ()
		{
            // Initalize Database
            Database = new TBNDatabase();

            RefreshRSS();

            var mainPage = new UserInterface.MasterDetail();
            // The root page of your application
            MainPage = mainPage;
        }

        async protected void RefreshRSS()
        {
            var shows = Database.Conn.Table<Show>().Where(s => s.RssFeed != null);
            foreach (var show in shows)
            {
                var feed = new Feed(show);
                await feed.DownloadAndProcessAsync(); // Await to ensure we're only doing one at a time, but don't block on the process. Probably better to just synchronize on db writes.
            }
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
