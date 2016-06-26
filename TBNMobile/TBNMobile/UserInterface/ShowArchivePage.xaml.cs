using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
