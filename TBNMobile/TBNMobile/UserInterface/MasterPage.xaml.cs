using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBNMobile.Models;
using Xamarin.Forms;

namespace TBNMobile.UserInterface
{
	public partial class MasterPage : ContentPage
	{
        public string SocialMediaHeader { get { return "Join us on the web!"; } }
        public string MainMenuHeader { get { return "The Brewing Network"; } }

        public ListView MainMenu { get { return mainMenu; } }

        public MasterPage ()
		{
			InitializeComponent ();
            BindingContext = this;

            var masterPageItems = new List<MasterPageItem>();
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Live Stream",
                IconSource = "live.png",
                TargetType = typeof(LiveStreamPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Show Archive",
                IconSource = "archive.png",
                TargetType = typeof(ShowArchivePage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Settings",
                IconSource = "settings.png",
                TargetType = typeof(SettingsPage)
            });

            mainMenu.ItemsSource = masterPageItems;

            var socialMediaItems = new List<SocialMediaItem>();
            socialMediaItems.Add(new SocialMediaItem
            {
                Title = "The Forums",
                IconSource = "archive.png",
                URL = "http://www.thebrewingnetwork.com/forum/"
            });
            socialMediaItems.Add(new SocialMediaItem
            {
                Title = "Facebook",
                IconSource = "archive.png",
                URL = "https://www.facebook.com/brewingnetwork/"
            });
            socialMediaItems.Add(new SocialMediaItem
            {
                Title = "Twitter",
                IconSource = "archive.png",
                URL = "https://twitter.com/brewingnetwork"
            });
            socialMediaItems.Add(new SocialMediaItem
            {
                Title = "Instagram",
                IconSource = "archive.png",
                URL = "https://www.instagram.com/brewingnetwork/"
            });
            socialMediaMenu.ItemsSource = socialMediaItems;

        }
    }
}
