﻿using TBNMobile.Database;
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
            

            var mainPage = new UserInterface.MasterDetail();
            // The root page of your application
            MainPage = mainPage;
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
