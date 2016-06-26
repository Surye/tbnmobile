using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TBNMobile.UserInterface
{
	public partial class SettingsPage : ContentPage
	{
        public string MainText
        {
            get { return "Settings Page here"; }
        }

        public SettingsPage ()
		{
			InitializeComponent ();
            BindingContext = this;
		}
	}
}
