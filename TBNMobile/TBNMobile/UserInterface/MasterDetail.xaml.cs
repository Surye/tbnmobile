using System;
using TBNMobile.UserInterface.Models;
using Xamarin.Forms;

namespace TBNMobile.UserInterface
{
	public partial class MasterDetail : MasterDetailPage
    {
		public MasterDetail()
        {
            InitializeComponent();
            masterPage.MainMenu.ItemSelected += OnItemSelected;
        }


        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item == null) return;
            var page = Activator.CreateInstance(item.TargetType) as ContentPage;
            Detail = new NavigationPage(page);
            masterPage.MainMenu.SelectedItem = null;
            IsPresented = false;
        }
    }
}
