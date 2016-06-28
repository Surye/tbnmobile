using TBNMobile.DependencyServices;
using Xamarin.Forms;

namespace TBNMobile.UserInterface
{
	public partial class LiveStreamPage : ContentPage
	{
	    public string MainText => "Live Stream here";
	    public IAudioPlayer AudioPlayer { get; private set; }
	    private const string TBNLiveStream = "http://ice5.securenetsystems.net/THEBN";

	    public LiveStreamPage ()
		{
			InitializeComponent ();
            BindingContext = this;
            AudioPlayer = DependencyService.Get<IAudioPlayer>();

	        btnStartStreaming.GestureRecognizers.Add(new TapGestureRecognizer
	        {
	            Command = new Command(() => AudioPlayer.PlayStreamingAudio(TBNLiveStream, "Live Radio")),
                NumberOfTapsRequired = 1,
	        });
            btnPauseStreaming.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => AudioPlayer.PauseStreamingAudio()),
                NumberOfTapsRequired = 1,
            });
            btnStopStreaming.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => AudioPlayer.StopStreamingAudio()),
                NumberOfTapsRequired = 1,
            });
        }
    }
}
