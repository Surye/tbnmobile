﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBNMobile.UserInterface.Models;
using Xamarin.Forms;

namespace TBNMobile.UserInterface
{
	public partial class MasterPage : ContentPage
	{
        public string SocialMediaHeader => "Join us on the web!";
	    public string MainMenuHeader => "The Brewing Network";

	    public ListView MainMenu => mainMenu;
        public ListView SocialMediaMenu => socialMediaMenu;

        public MasterPage ()
		{
			InitializeComponent ();
            BindingContext = this;

            var masterPageItems = new List<MasterPageItem>
            {
                new MasterPageItem
                {
                    Title = "Live Stream",
                    IconSource = "live.png",
                    TargetType = typeof(LiveStreamPage)
                },
                new MasterPageItem
                {
                    Title = "Show Archive",
                    IconSource = "archive.png",
                    TargetType = typeof(ShowArchivePage)
                },
                new MasterPageItem
                {
                    Title = "Settings",
                    IconSource = "settings.png",
                    TargetType = typeof(SettingsPage)
                }
            };

            mainMenu.ItemsSource = masterPageItems;

            var socialMediaItems = new List<SocialMediaItem>
            {
                new SocialMediaItem
                {
                    Title = "The Forums",
                    IconSource = "archive.png",
                    URL = "http://www.thebrewingnetwork.com/forum/"
                },
                new SocialMediaItem
                {
                    Title = "Facebook",
                    IconSource = "archive.png",
                    URL = "https://www.facebook.com/brewingnetwork/"
                },
                new SocialMediaItem
                {
                    Title = "Twitter",
                    IconSource = "archive.png",
                    URL = "https://twitter.com/brewingnetwork"
                },
                new SocialMediaItem
                {
                    Title = "Instagram",
                    IconSource = "archive.png",
                    URL = "https://www.instagram.com/brewingnetwork/"
                }
            };
            socialMediaMenu.ItemsSource = socialMediaItems;

        }
    }
}
