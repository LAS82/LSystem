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
            Assert.AreEqual(15, integers.Capacity);
            Assert.AreEqual(0, integers.Count);

            SimpleList<string> strings = new SimpleList<string>(20);
            Assert.AreEqual(20, strings.Capacity);
            Assert.AreEqual(0, strings.Count);

            Assert.ThrowsException<ArgumentException>(() => { new SimpleList<StringBuilder>(0); } );
            Assert.ThrowsException<ArgumentException>(() => { new SimpleList<StringBuilder>(-1); });
        }

        [TestMethod]
        public void ConstructorWithCapacityAndResizable()
        {
            //Resizable
            SimpleList<string> strings = new SimpleList<string>(2, true);
            Assert.AreEqual(2, strings.Capacity);
            Assert.AreEqual(0, strings.Count);

            strings.Add("Trying to ");
            Assert.AreEqual(1, strings.Count);

            strings.Add(" add three ");
            Assert.AreEqual(2, strings.Count);

            strings.Add(" strings.");
            Assert.AreEqual(3, strings.Count);


            //Not Resizable
            strings = new SimpleList<string>(2, false);
            strings.Add("Trying to ");
            Assert.AreEqual(1, strings.Count);

            strings.Add(" add three ");
            Assert.AreEqual(2, strings.Count);

            Assert.ThrowsException<InvalidOperationException>(() => strings.Add(" could not be added."));
        }

        [TestMethod]
        public void ConstructorWithItems()
        {
            IEnumerable<int> items = new List<int>(new int [] { 1, 2, 3, 4 });

            SimpleList<int> integers = new SimpleList<int>(items);

            Assert.AreEqual(2, integers[1]);
            Assert.AreEqual(3, integers[2]);
            Assert.AreEqual(4, integers.Capacity);
            Assert.AreEqual(4, integers.Count);

            
            Assert.ThrowsException<ArgumentNullException>(() => {

                items = null;
                integers = new SimpleList<int>(items);
                
            });

        }

        [TestMethod]
        public void PropertyIndex()
        {
            SimpleList<decimal> list = new SimpleList<decimal>(5);
            list.Add(100M);

            Assert.AreEqual(100M, list[0]);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { decimal value = list[-1]; });
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { decimal value = list[1]; });
        }

        [TestMethod]
        public void Clear()
        {
            SimpleList<DateTime> dates = new SimpleList<DateTime>(new DateTime[] { new DateTime(), DateTime.Now });

            Assert.AreEqual(2, dates.Count);
            dates.Clear();
            Assert.AreEqual(0, dates.Count);
            Assert.AreEqual(2, dates.Capacity);
        }

        [TestMethod]
        public void CopyTo()
        {
            SimpleList<string> strings = new SimpleList<string>(3);
            strings.Add("Hello ");
            strings.Add("world!");

            string[] stringsArr = new string[2];

            strings.CopyTo(stringsArr, 0);

            Assert.AreEqual("Hello ", stringsArr[0]);
            Assert.AreEqual("world!", stringsArr[1]);
            Assert.AreEqual(2, strings.Count);
            Assert.AreEqual(2, stringsArr.Length);

            Assert.ThrowsException<ArgumentNullException>(() => 
            {
                strings.CopyTo(null, 0);
            });

            Assert.ThrowsException<ArgumentException>(() =>
            {
                stringsArr = new string[0];
                strings.CopyTo(stringsArr, 0);
            });
            
        }

        [TestMethod]
        public void GetEnumerator()
        {
            SimpleList<decimal> decs = new SimpleList<decimal>(10);

            decs.Add(10.00M);
            decs.Add(11.01M);
            decs.Add(12.02M);
            decs.Add(13.03M);
            decs.Add(14.04M);

            IEnumerator<decimal> decimalEnumerator = decs.GetEnumerator();

            int index = 0;
            while (decimalEnumerator.MoveNext())
            {
                Assert.AreEqual(decs[index], decimalEnumerator.Current);
                index++;
            }

            decimalEnumerator.MoveNext();
            Assert.AreEqual(10.00M, decimalEnumerator.Current);

            decimalEnumerator.MoveNext();
            Assert.AreEqual(11.01M, decimalEnumerator.Current);

            decimalEnumerator.Reset();
            decimalEnumerator.MoveNext();
            Assert.AreEqual(10.00M, decimalEnumerator.Current);

            decimalEnumerator.Reset();
            Assert.AreEqual(Decimal.Zero, decimalEnumerator.Current);

        }

        [TestMethod]
        public void Contains()
        {
            SimpleList<StringBuilder> builders = new SimpleList<StringBuilder>(2);

            StringBuilder firstBuilder = new StringBuilder();
            StringBuilder secondBuilder = new StringBuilder();

            builders.Add(firstBuilder);
            builders.Add(secondBuilder);

            Assert.AreEqual(true, builders.Contains(firstBuilder));
            Assert.AreEqual(false, builders.Contains(new StringBuilder()));

            SimpleList<int> numbers = new SimpleList<int>(new int[] { 1, 2, 3 });
            Assert.AreEqual(true, numbers.Contains(3));
            Assert.AreEqual(false, numbers.Contains(4));

            SimpleList<string> nulls = new SimpleList<string>(new string[] { null, null, null });
            Assert.ThrowsException<NullReferenceException>(() => nulls.Contains(null));
        }
    }
}
