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
    public class SimpleStackTest
    {
        [TestMethod]
        public void EmptyConstructor()
        {
            SimpleStack<int> integers = new SimpleStack<int>();

            Assert.IsInstanceOfType(integers, typeof(SimpleStack<int>));
        }

        [TestMethod]
        public void ConstructorWithItems()
        {
            IEnumerable<string> strings = new List<string> { "Hello", "World", "With", "Data", "Structures" };

            SimpleStack<string> stringStack = new SimpleStack<string>(strings);

            Assert.IsInstanceOfType(stringStack, typeof(SimpleStack<string>));
            Assert.AreEqual(strings.Count(), stringStack.Count);
        }

        [TestMethod]
        public void TestStackBehavior()
        {
            List<char> chars = new List<char> { 'a', 'b', 'c' };

            SimpleStack<char> charStack = new SimpleStack<char>(chars);

            chars.Add('d');
            chars.Add('e');
            chars.Add('f');

            charStack.Push('d');
            charStack.Push('e');
            charStack.Push('f');

            while (!charStack.IsEmpty())
            {
                Assert.AreEqual(chars[chars.Count-1], charStack.Pop());
                chars.RemoveAt(chars.Count - 1);
            }

            Assert.AreEqual(0, charStack.Count);

        }

        [TestMethod]
        public void TestClearBehavior()
        {
            List<char> chars = new List<char> { 'a', 'b', 'c' };

            SimpleStack<char> charStack = new SimpleStack<char>(chars);

            charStack.Clear();

            Assert.AreEqual(0, charStack.Count);
            Assert.AreEqual(true, charStack.IsEmpty());
        }

        [TestMethod]
        public void TestCheckTopItem()
        {
            List<char> chars = new List<char> { 'a', 'b', 'c' };

            SimpleStack<char> charStack = new SimpleStack<char>(chars);

            Assert.AreEqual(chars[chars.Count-1], charStack.Top());
        }

    }
}
