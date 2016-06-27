using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using TBNMobile.DependencyServices;
using TBNMobile.Droid.DependencyServices;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidAudioPlayer))]
namespace TBNMobile.Droid.DependencyServices
{
    class AndroidAudioPlayer : IAudioPlayer
    {
        public void PlayStreamingAudio(string URL)
        {
            throw new NotImplementedException();
        }

        public void StopStreamingAudio()
        {
            throw new NotImplementedException();
        }
    }
}