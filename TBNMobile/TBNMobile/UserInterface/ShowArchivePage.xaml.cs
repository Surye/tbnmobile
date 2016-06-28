using Xamarin.Forms;

namespace TBNMobile.UserInterface
{
	public partial class ShowArchivePage : ContentPage
	{
        public string MainText
        {
            get { return "Show Archive here"; }
        }

        public ShowArchivePage ()
		{
			InitializeComponent ();
            BindingContext = this;
		}
	}
}
