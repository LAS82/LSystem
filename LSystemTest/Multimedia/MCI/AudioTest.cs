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
    public class AudioTest
    {
        [TestMethod]
        public void Play()
        {
            //Open file.
            Audio audio = new Audio("Song", @"E:\HDD_General\Músicas\Baba Cósmica - Gororoba\09 - Uma Pedra No Meu Caminho.mp3");
            Assert.AreEqual(PlayStatus.Opened, audio.MediaStatus);

            //Play file.
            audio.Play(false);
            Assert.AreEqual(PlayStatus.Playing, audio.MediaStatus);

            System.Threading.Thread.Sleep(10000);

            //Pause file.
            audio.Pause();
            Assert.AreEqual(PlayStatus.Paused, audio.MediaStatus);

            System.Threading.Thread.Sleep(2000);

            //Resume file.
            audio.Resume();
            Assert.AreEqual(PlayStatus.Playing, audio.MediaStatus);

            System.Threading.Thread.Sleep(10000);

            //Close file.
            audio.Close();
            Assert.AreEqual(PlayStatus.Closed, audio.MediaStatus);
        }
    }
}
