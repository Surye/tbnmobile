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
        public ListView ListView { get { return listView; } }

        public MasterPage ()
		{
			InitializeComponent ();

            var masterPageItems = new List<MasterPageItem>();
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Live Stream",
                IconSource = "settings.png",
                TargetType = typeof(LiveStreamPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Show Archive",
                IconSource = "settings.png",
                TargetType = typeof(ShowArchivePage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Settings",
                IconSource = "settings.png",
                TargetType = typeof(SettingsPage)
            });

            listView.ItemsSource = masterPageItems;

        }
    }
}
