using LSystem.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSystem.Multimedia.MCI
{

    public class Video : Media
    {
        private Size _size;
        private IntPtr _windowHandle;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediaName">A reference name for the media file.</param>
        /// <param name="filePath">The video file's path.</param>
        public Video(string mediaName, string filePath)
        {
            base.MediaName = mediaName;
            Open(filePath);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediaName">A reference name for the media file.</param>
        /// <param name="filePath">The video file's path.</param>
        /// <param name="size">A handle for a window to display the video.</param>
        /// <param name="size">The window size.</param>
        public Video(string mediaName, string filePath, IntPtr windowHandle, Size size)
        {
            this._size = size;
            this._windowHandle = windowHandle;
            base.MediaName = mediaName;
            Open(filePath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        internal override void Open(string filePath)
        {
            String command = String.Concat("open \"", filePath, "\" type mpegvideo alias MediaFile");

            if (_windowHandle != IntPtr.Zero)
            {
                command = String.Concat(command, " style child parent ", this._windowHandle);
                base.ExecuteMCICommand(command);
                Put();
            }
            else
                base.ExecuteMCICommand(command);
        }

        /// <summary>
        /// 
        /// </summary>
        private void Put()
        {
            String command = String.Concat("put MediaFile window at 0 0 ", _size.Width, " ", _size.Height);
            base.ExecuteMCICommand(command);
        }
    }
}
