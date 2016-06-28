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
            Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
            masterPage.MainMenu.SelectedItem = null;
            IsPresented = false;
        }
    }
}
