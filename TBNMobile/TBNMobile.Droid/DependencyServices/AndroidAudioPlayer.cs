using System;
using Android.App;
using Android.Content;
using Android.OS;
using TBNMobile.DependencyServices;
using TBNMobile.Droid.DependencyServices;
using Android.Media;
using Android.Net.Wifi;
using Android.Net;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidAudioPlayer))]
namespace TBNMobile.Droid.DependencyServices
{

    [Service]
    [IntentFilter(new[] { ActionPlay, ActionPause, ActionStop })]
    public class StreamingBackgroundService : Service, AudioManager.IOnAudioFocusChangeListener
    {
        //Actions
        public const string ActionPlay = "net.datamachine.surye.tbnmobile.action.PLAY";
        public const string ActionPause = "net.datamachine.surye.tbnmobile.PAUSE";
        public const string ActionStop = "net.datamachine.surye.tbnmobile.STOP";
        
        private MediaPlayer player;
        private AudioManager audioManager;
        private WifiManager wifiManager;
        private WifiManager.WifiLock wifiLock;
        private bool paused;

        private const int NotificationId = 1;

        public string MediaSource { get; private set; }
        public string MediaTitle { get; private set; }

        /// <summary>
        /// On create simply detect some of our managers
        /// </summary>
        public override void OnCreate()
        {
            base.OnCreate();
            //Find our audio and notificaton managers
            audioManager = (AudioManager)GetSystemService(AudioService);
            wifiManager = (WifiManager)GetSystemService(WifiService);
        }

        /// <summary>
        /// Don't do anything on bind
        /// </summary>
        /// <param name="intent"></param>
        /// <returns></returns>
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            MediaSource = intent.Extras?.GetString("uri");
            MediaTitle = intent.Extras?.GetString("title");

            switch (intent.Action)
            {
                case ActionPlay: Play(); break;
                case ActionStop: Stop(); break;
                case ActionPause: Pause(); break;
            }

            //Set sticky as we are a long running operation
            return StartCommandResult.Sticky;
        }

        private void IntializePlayer()
        {
            player = new MediaPlayer();

            //Tell our player to sream music
            player.SetAudioStreamType(Stream.Music);

            //Wake mode will be partial to keep the CPU still running under lock screen
            player.SetWakeMode(ApplicationContext, WakeLockFlags.Partial);

            //When we have prepared the song start playback
            player.Prepared += (sender, args) => player.Start();

            //When we have reached the end of the song stop ourselves, however you could signal next track here.
            player.Completion += (sender, args) => Stop();

            player.Error += (sender, args) =>
            {
                //playback error
                Console.WriteLine("Error in playback resetting: " + args.What);
                Stop();//this will clean up and reset properly.
            };
        }


        /// <summary>
        /// When we start on the foreground we will present a notification to the user
        /// When they press the notification it will take them to the main page so they can control the music
        /// </summary>
        private void StartForeground()
        {

            var pendingIntent = PendingIntent.GetActivity(ApplicationContext, 0,
                            new Intent(ApplicationContext, typeof(MainActivity)),
                            PendingIntentFlags.UpdateCurrent);


            // Instantiate the builder and set notification elements:
            var builder = new Notification.Builder(this)
                .SetContentTitle("The Brewing Network")
                .SetContentText(MediaTitle)
                .SetSmallIcon(Resource.Drawable.hopgrenade);

            // Build the notification:
            var notification = builder.Build();

            // Get the notification manager:
            var notificationManager =
                GetSystemService(Context.NotificationService) as NotificationManager;

            notificationManager?.Notify(NotificationId, notification);
            StartForeground(NotificationId, notification);
        }

        private async void Play()
        {

            if (paused && player != null)
            {
                paused = false;
                //We are simply paused so just start again
                player.Start();
                StartForeground();
                return;
            }

            if (player == null)
            {
                IntializePlayer();
            }

            if (player.IsPlaying)
                return;

            try
            {
                await player.SetDataSourceAsync(ApplicationContext, Android.Net.Uri.Parse(MediaSource));
                
                var focusResult = audioManager.RequestAudioFocus(this, Stream.Music, AudioFocus.Gain);
                if (focusResult != AudioFocusRequest.Granted)
                {
                    //could not get audio focus
                    Console.WriteLine("Could not get audio focus");
                }

                player.PrepareAsync();
                AquireWifiLock();
                StartForeground();
            }
            catch (Exception ex)
            {
                //unable to start playback log error
                Console.WriteLine("Unable to start playback: " + ex);
            }
        }

        private void Pause()
        {
            if (player == null)
                return;

            if (player.IsPlaying)
                player.Pause();

            StopForeground(true);
            paused = true;
        }

        private void Stop()
        {
            if (player == null)
                return;

            if (player.IsPlaying)
                player.Stop();

            player.Reset();
            paused = false;
            StopForeground(true);
            ReleaseWifiLock();
        }


        /// <summary>
        /// Lock the wifi so we can still stream under lock screen
        /// </summary>
        private void AquireWifiLock()
        {
            if (wifiLock == null)
            {
                wifiLock = wifiManager.CreateWifiLock(WifiMode.Full, "xamarin_wifi_lock");
            }
            wifiLock.Acquire();
        }

        /// <summary>
        /// This will release the wifi lock if it is no longer needed
        /// </summary>
        private void ReleaseWifiLock()
        {
            wifiLock?.Release();
            wifiLock = null;
        }

        /// <summary>
        /// Properly cleanup of your player by releasing resources
        /// </summary>
        public override void OnDestroy()
        {
            base.OnDestroy();
            player?.Release();
            player = null;
        }

        /// <summary>
        /// For a good user experience we should account for when audio focus has changed.
        /// There is only 1 audio output there may be several media services trying to use it so
        /// we should act correctly based on this.  "duck" to be quiet and when we gain go full.
        /// All applications are encouraged to follow this, but are not enforced.
        /// </summary>
        /// <param name="focusChange"></param>
        public void OnAudioFocusChange(AudioFocus focusChange)
        {
            switch (focusChange)
            {
                case AudioFocus.Gain:
                    if (player == null)
                        IntializePlayer();

                    if (!player.IsPlaying)
                    {
                        player.Start();
                        paused = false;
                    }

                    player.SetVolume(1.0f, 1.0f);//Turn it up!
                    break;
                case AudioFocus.Loss:
                    //We have lost focus stop!
                    Stop();
                    break;
                case AudioFocus.LossTransient:
                    //We have lost focus for a short time, but likely to resume so pause
                    Pause();
                    break;
                case AudioFocus.LossTransientCanDuck:
                    //We have lost focus but should till play at a muted 10% volume
                    if (player.IsPlaying)
                        player.SetVolume(.1f, .1f);//turn it down!
                    break;

            }
        }
    }


    internal class AndroidAudioPlayer : IAudioPlayer
    {

        public void Init()
        {
            // Noop in Android
        }

        public void PlayStreamingAudio(string uri, string title)
        {
            var valuesForActivity = new Bundle();
            valuesForActivity.PutString("uri", uri);
            valuesForActivity.PutString("title", title);

            var intent = new Intent(StreamingBackgroundService.ActionPlay);
            intent.PutExtras(valuesForActivity);
            intent.SetPackage(Application.Context.PackageName);
            Application.Context.StartService(intent);
        }

        public void PauseStreamingAudio()
        {
            var intent = new Intent(StreamingBackgroundService.ActionPause);
            intent.SetPackage(Application.Context.PackageName);
            Application.Context.StartService(intent);
        }

 

        public void StopStreamingAudio()
        {
            var intent = new Intent(StreamingBackgroundService.ActionStop);
            intent.SetPackage(Application.Context.PackageName);
            Application.Context.StartService(intent);
        }
    }
}