namespace LSystem.Multimedia
{
    /// <summary>
    /// Indicates wether the media file is in execution or paused or stopped.
    /// </summary>
    public enum PlayStatus
    {
        Stopped = 0,
        Playing = 1,
        Paused = 2
    }

    /// <summary>
    /// Contains the original representations of the MCI's media status.
    /// </summary>
    internal static class MCIPlayStatus
    {
        internal const string STOPPED = "stopped";
        internal const string PLAYING = "playing";
        internal const string PAUSED = "paused";
    }
}
