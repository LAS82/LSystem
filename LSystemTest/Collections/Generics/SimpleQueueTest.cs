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
    public class SimpleQueueTest
    {
        [TestMethod]
        public void EmptyConstructor()
        {
            SimpleQueue<int> integers = new SimpleQueue<int>();

            Assert.IsInstanceOfType(integers, typeof(SimpleQueue<int>));
        }

        [TestMethod]
        public void ConstructorWithItems()
        {
            IEnumerable<string> strings = new List<string> { "Hello", "World", "With", "Data", "Structures" };

            SimpleQueue<string> stringQueue = new SimpleQueue<string>(strings);

            Assert.IsInstanceOfType(stringQueue, typeof(SimpleQueue<string>));
            Assert.AreEqual(strings.Count(), stringQueue.Count);
        }

        [TestMethod]
        public void TestQueueBehavior()
        {
            List<char> chars = new List<char> { 'a', 'b', 'c' };

            SimpleQueue<char> charQueue = new SimpleQueue<char>(chars);

            chars.Add('d');
            chars.Add('e');
            chars.Add('f');

            charQueue.Enqueue('d');
            charQueue.Enqueue('e');
            charQueue.Enqueue('f');

            int index = 0;

            while (!charQueue.IsEmpty())
            {
                Assert.AreEqual(chars[index++], charQueue.Dequeue());
            }

            Assert.AreEqual(0, charQueue.Count);

        }

        [TestMethod]
        public void TestClearBehavior()
        {
            List<char> chars = new List<char> { 'a', 'b', 'c' };

            SimpleQueue<char> charQueue = new SimpleQueue<char>(chars);

            charQueue.Clear();

            Assert.AreEqual(0, charQueue.Count);
            Assert.AreEqual(true, charQueue.IsEmpty());
        }

        [TestMethod]
        public void TestCheckFrontItem()
        {
            List<char> chars = new List<char> { 'a', 'b', 'c' };

            SimpleQueue<char> charQueue = new SimpleQueue<char>(chars);

            Assert.AreEqual(chars[0], charQueue.Front());
        }

    }
}
