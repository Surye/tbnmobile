using System;
using System.Collections.Generic;
using System.Text;

namespace TBNMobile.DependencyServices
{
    public interface IAudioPlayer
    {
        void Init();
        void PlayStreamingAudio(string URL);
        void PauseStreamingAudio();
        void StopStreamingAudio();
    }
}
