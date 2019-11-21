using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LSystem.Multimedia.MCI
{
    /// <summary>
    /// Class used for all MCI exceptions.
    /// </summary>
    public class MCIException : Exception
    {
        /// <summary>
        /// Recovers a MCI error message.
        /// </summary>
        /// <param name="fdwError">The error code.</param>
        /// <param name="lpszErrorText">The StringBuilder that will receive the error message.</param>
        /// <param name="cchErrorText">The StringBuilder capacity size.</param>
        /// <returns></returns>
        [DllImport("winmm.dll")]
        private static extern bool mciGetErrorString(int fdwError, StringBuilder lpszErrorText, int cchErrorText);

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="HResult">Error code.</param>
        public MCIException(int HResult) : base()
        {
            base.HResult = HResult;
        }

        /// <summary>
        /// Returns the error message.
        /// </summary>
        public override string Message
        {
            get
            {
                StringBuilder errorMessage = new StringBuilder(128);

                mciGetErrorString(base.HResult, errorMessage, errorMessage.Capacity);

                return errorMessage.ToString();
            }
        }
    }
}
