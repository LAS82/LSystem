using LSystem.Collections.Generics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LSystemTest.Collections.Generics
{

    [TestClass]
    public class SimpleListTest
    {
        [TestMethod]
        public void ConstructorWithCapacity()
        {
            SimpleList<int> integers = new SimpleList<int>(15);
            Assert.AreEqual(integers.Capacity, 15);
            Assert.AreEqual(integers.Count, 0);

            SimpleList<string> strings = new SimpleList<string>(20);
            Assert.AreEqual(strings.Capacity, 20);
            Assert.AreEqual(strings.Count, 0);

            Assert.ThrowsException<ArgumentException>(() => { new SimpleList<StringBuilder>(0); } );
            Assert.ThrowsException<ArgumentException>(() => { new SimpleList<StringBuilder>(-1); });
        }

        [TestMethod]
        public void ConstructorWithCapacityAndResizable()
        {
            //Resizable
            SimpleList<string> strings = new SimpleList<string>(2, true);
            Assert.AreEqual(strings.Capacity, 2);
            Assert.AreEqual(strings.Count, 0);

            strings.Add("Trying to ");
            Assert.AreEqual(strings.Count, 1);

            strings.Add(" add three ");
            Assert.AreEqual(strings.Count, 2);

            strings.Add(" strings.");
            Assert.AreEqual(strings.Count, 3);


            //Not Resizable
            strings = new SimpleList<string>(2, false);
            strings.Add("Trying to ");
            Assert.AreEqual(strings.Count, 1);

            strings.Add(" add three ");
            Assert.AreEqual(strings.Count, 2);

            Assert.ThrowsException<InvalidOperationException>(() => { strings.Add(" could not be added."); });
        }
    }
}
