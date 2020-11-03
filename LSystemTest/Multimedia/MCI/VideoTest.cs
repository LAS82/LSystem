using LSystem.Multimedia;
using LSystem.Multimedia.MCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSystemTest.Multimedia.MCI
{
    [TestClass]
    public class VideoTest
    {
        [TestMethod]
        public void Play()
        {
#warning REPLACE THE VIDEO_FILE_PATH LITERAL WITH A VALID FILE PATH
            Video video = new Video("MediaFile", @"VIDEO_FILE_PATH");

            Assert.AreEqual(PlayStatus.Stopped, video.MediaStatus);

            //Play file.
            video.Play(false);
            Assert.AreEqual(PlayStatus.Playing, video.MediaStatus);

            System.Threading.Thread.Sleep(15000);

            //Pause file.
            video.Pause();
            Assert.AreEqual(PlayStatus.Paused, video.MediaStatus);

            System.Threading.Thread.Sleep(2000);

            //Resume file.
            video.Resume();
            Assert.AreEqual(PlayStatus.Playing, video.MediaStatus);

            System.Threading.Thread.Sleep(15000);

            //Close file.
            video.Close();
        }

    }
}
