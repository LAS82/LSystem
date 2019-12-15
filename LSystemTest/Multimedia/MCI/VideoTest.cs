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
            Video video = new Video("MediaFile", @"E:\HDD_General\Videos\Clipes e Shows\GoGo's - Head Over Heels.mpg");

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
