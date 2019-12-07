using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSystem.Multimedia.MCI
{
    public class Audio : Media
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediaName">A reference name for the media file.</param>
        /// <param name="filePath">The audio file's path.</param>
        public Audio(string mediaName, string filePath)
        {
            base.MediaName = mediaName;
            base.MediaStatus = PlayStatus.Closed;

            Open(filePath);
        }

        /// <summary>
        /// Cleans up.
        /// </summary>
        public override void Dispose()
        {
            base.TryClose();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Opens the audio file.
        /// </summary>
        /// <param name="filePath">the audio file's path</param>
        internal override void Open(string filePath)
        {
            String command = String.Concat("Open \"", filePath, "\" alias ", base.MediaName);

            base.ExecuteMCICommand(command);

            base.MediaStatus = PlayStatus.Opened;
        }

        /// <summary>
        /// Finalize method. Called internally by the GC.
        /// </summary>
        ~Audio()
        {
            Dispose();
        }
    }
}
