using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TBNMobile
{
	public class App : Application
	{
		public App ()
		{
            var mainPage = new UserInterface.MasterDetail();
            //var mainPage = new UserInterface.LiveStreamPage();
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
