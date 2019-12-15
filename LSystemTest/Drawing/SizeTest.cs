using LSystem.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSystemTest.Drawing
{
    [TestClass]
    public class SizeTest
    {

        [TestMethod]
        public void SizeTests()
        {
            Size s1 = new Size();
            s1.Width = 10;
            s1.Height = 20;

            Size s2 = new Size(10, 20);

            Assert.AreEqual(true, s1.Equals(s2));
            Assert.AreEqual(true, s1.Equals(s2 as Object));

            Assert.AreEqual(true, s1.GetHashCode() == s2.GetHashCode());

            s2.Height = 10;

            Assert.AreEqual(false, s1.Equals(s2));
            Assert.AreEqual(false, s1.Equals(s2 as Object));

            Assert.AreEqual(false, s1.GetHashCode() == s2.GetHashCode());

            Assert.AreEqual("Width: 10, Height: 20", s1.ToString());
            Assert.AreEqual("Width: 10, Height: 10", s2.ToString());
        }
    }
}
