using System;
using System.Collections.Generic;
using System.Text;

namespace TBNMobile.DependencyServices
{
    public interface IAudioPlayer
    {
        void PlayStreamingAudio(string URL);
        void StopStreamingAudio();
    }
}
