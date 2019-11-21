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
    public class MCIExceptionTest
    {
        [TestMethod]
        public void GetErrorMessage()
        {
            MCIException exc = new MCIException(300);
            Assert.AreNotEqual("", exc.Message);

            exc = new MCIException(264);
            Assert.AreNotEqual("", exc.Message);

            exc = new MCIException(346);
            Assert.AreNotEqual("", exc.Message);
        }
    }
}
