using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LSystem.Multimedia.MCI
{
    /// <summary>
    /// An abstract class that serves as a base class to concrete media classes.
    /// </summary>
    public abstract class Media
    {

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

    }
}
