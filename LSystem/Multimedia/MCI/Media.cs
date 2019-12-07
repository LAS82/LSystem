using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LSystem.Multimedia.MCI
{
    /// <summary>
    /// An abstract class that serves as a base class to concrete media classes.
    /// </summary>
    public abstract class Media
    {

        /// <summary>
        /// A reference name for the media.
        /// </summary>
        internal string MediaName { get; set; }

        /// <summary>
        /// The current media file status.
        /// </summary>
        public PlayStatus MediaStatus {
            get
            {
                StringBuilder data = new StringBuilder(128);
                ExecuteMCICommand($"status {MediaName} mode", data);

                switch (data.ToString())
                {
                    case MCIPlayStatus.PLAYING:
                        return PlayStatus.Playing;
                    case MCIPlayStatus.PAUSED:
                        return PlayStatus.Paused;
                    default:
                        return PlayStatus.Stopped;
                }
            }
        }

        /// <summary>
        /// Sends a specified command to the MCI Device.
        /// </summary>
        /// <param name="strCommand">Command</param>
        /// <param name="strReturn">Return data.</param>
        /// <param name="iReturnLength">Return data size.</param>
        /// <param name="oCallback">Callback window handle.</param>
        /// <returns>Indicates whether the execution was successful or if any errors occurred.</returns>
        [DllImport("winmm.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        private static extern int mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr oCallback);

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command to be executed in the format 'command {0} command' where {0} will be replaced by the MediaName property.</param>
        /// <exception cref="MCIException">Throws this exception if any problem occurs during the mciSendString execution.</exception>
        private protected void ExecuteMCICommand(string command)
        {
            ExecuteMCICommand(command, null);
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command to be executed in the format 'command {0} command' where {0} will be replaced by the MediaName property.</param>
        /// <exception cref="MCIException">Throws this exception if any problem occurs during the mciSendString execution.</exception>
        private protected void ExecuteMCICommand(string command, StringBuilder mciData)
        {
            int returnLength = mciData == null ? 0 : mciData.Capacity;
            int errorCode = mciSendString(command, mciData, returnLength, IntPtr.Zero);

            if (errorCode != 0)
                throw new MCIException(errorCode);
        }

        /// <summary>
        /// Starts the media execution.
        /// </summary>
        public void Play(bool repeat)
        {
            string repeatCommand = repeat ? "REPEAT" : String.Empty;

            ExecuteMCICommand($"play {MediaName} {repeatCommand}");  
        }

        /// <summary>
        /// Pauses the media execution
        /// </summary>
        public void Pause()
        {
            ExecuteMCICommand($"pause {MediaName}");
        }

        /// <summary>
        /// Resumes the media execution
        /// </summary>
        public void Resume()
        {
            ExecuteMCICommand($"resume {MediaName}");
        }

        /// <summary>
        /// Stops the media execution.
        /// </summary>
        public void Stop()
        {
            ExecuteMCICommand($"stop {MediaName}");
        }

        /// <summary>
        /// Closes the media.
        /// </summary>
        public void Close()
        {
            ExecuteMCICommand($"close {MediaName}");
        }

        /// <summary>
        /// Returns the current play time.
        /// </summary>
        /// <returns>The current play time.</returns>
        public String RetrieveCurrentTime()
        {
            StringBuilder mciData = new StringBuilder(128);
            ExecuteMCICommand($"status {MediaName} position", mciData);

            return mciData.ToString();
        }

        /// <summary>
        /// Returns the song length.
        /// </summary>
        /// <returns>The total play time.</returns>
        public String RetrieveSongLength()
        {
            StringBuilder mciData = new StringBuilder(128);
            ExecuteMCICommand($"status {MediaName} length", mciData);

            return mciData.ToString();
        }

        /// <summary>
        /// The open method must be implemented because it depends 
        /// of the media type.
        /// </summary>
        /// <param name="filePath">The file's full path.</param>
        internal abstract void Open(string filePath);
    }
}
