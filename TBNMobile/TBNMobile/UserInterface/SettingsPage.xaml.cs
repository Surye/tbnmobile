using Xamarin.Forms;

namespace TBNMobile.UserInterface
{
	public partial class SettingsPage : ContentPage
	{
        public string MainText => "Settings Page here";

	    public SettingsPage ()
		{
			InitializeComponent ();
            BindingContext = this;
		}
	}
}
