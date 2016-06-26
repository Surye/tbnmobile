using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TBNMobile.UserInterface
{
	public partial class LiveStreamPage : ContentPage
	{
        public string MainText
        {
            get { return "Live Stream here"; }
        }

        public LiveStreamPage ()
		{
			InitializeComponent ();
            BindingContext = this;
		}
	}
}
