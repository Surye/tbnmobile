using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBNMobile.DependencyServices;
using Xamarin.Forms;

namespace TBNMobile.UserInterface
{
	public partial class LiveStreamPage : ContentPage
	{
        public string TBNLiveStream { get { return "http://ice5.securenetsystems.net/THEBN";  } }

        public string MainText
        {
            get { return "Live Stream here"; }
        }

        public LiveStreamPage ()
		{
			InitializeComponent ();
            BindingContext = this;

            btnStartStreaming.Clicked += BtnStartStreaming_Clicked;

        }

        private void BtnStartStreaming_Clicked(object sender, EventArgs e)
        {
            var audioPlayer = DependencyService.Get<IAudioPlayer>();
        }
    }
}
