using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBNMobile.Models;
using Xamarin.Forms;

namespace TBNMobile.UserInterface
{
	public partial class MasterDetail : MasterDetailPage
    {
		public MasterDetail()
        {
            InitializeComponent();
            Detail = new NavigationPage(new LiveStreamPage());
            masterPage.ListView.ItemSelected += OnItemSelected;
        }


        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
