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
	    public string MainText
        {
            get { return "Live Stream here"; }
        }
        public IAudioPlayer AudioPlayer { get; private set; }

        public LiveStreamPage ()
		{
			InitializeComponent ();
            BindingContext = this;
            AudioPlayer = DependencyService.Get<IAudioPlayer>();
            //AudioPlayer.Init();

            btnStartStreaming.Clicked += (sender, args) => AudioPlayer.PlayStreamingAudio();
            btnPauseStreaming.Clicked += (sender, args) => AudioPlayer.PauseStreamingAudio();
            btnStopStreaming.Clicked  += (sender, args) => AudioPlayer.StopStreamingAudio();
        }
    }
}
