namespace TBNMobile.DependencyServices
{
    public interface IAudioPlayer
    {
        void Init();
        void PlayStreamingAudio(string uri, string title = "");
        void PauseStreamingAudio();
        void StopStreamingAudio();
    }
}
