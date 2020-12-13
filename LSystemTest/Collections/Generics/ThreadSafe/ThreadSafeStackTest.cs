using LSystem.Collections.Generics.ThreadSafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSystemTest.Collections.Generics.ThreadSafe
{
    [TestClass]
    public class ThreadSafeStackTest
    {
        [TestMethod]
        public void TestAsyncPush()
        {
            ThreadSafeStack<int> integers = new ThreadSafeStack<int>();

            Task t1 = Task.Run(
                () => {
                    for (int i = 0; i < 1000000; ++i)
                    {
                        integers.Push(i);
                    }
                }
            );

            Task t2 = Task.Run(
                () => {
                    for (int i = 0; i < 1000000; ++i)
                    {
                        integers.Push(i);
                    }
                }
            );

            Task.WaitAll(t1, t2);

            Assert.AreEqual(2000000, integers.Count);
        }

        [TestMethod]
        public void TestAsyncPushList()
        {
            ThreadSafeStack<int> integers = new ThreadSafeStack<int>();

            Task t1 = Task.Run(
                () => {
                    List<int> data = new List<int>(500);
                    for (int i = 0; i < 1000; i+=2)
                    {
                        System.Threading.Thread.Sleep(10);
                        data.Add(i);
                    }

                    integers.Push(data);
                }
            );

            Task t2 = Task.Run(
                () => {
                    List<int> data = new List<int>(500);
                    for (int i = 1; i < 1000; i += 2)
                    {
                        System.Threading.Thread.Sleep(10);
                        data.Add(i);
                    }

                    integers.Push(data);
                }
            );

            Task.WaitAll(t1, t2);

            Assert.AreEqual(1000, integers.Count);
        }

        [TestMethod]
        public void TestAsyncPop()
        {
            ThreadSafeStack<int> integers = new ThreadSafeStack<int>();

            for (int i = 3; i < 1000000; ++i)
            {
                integers.Push(i);
            }

            Task t1 = Task.Run(
                () => {
                    while(!integers.IsEmpty())
                    {

                        integers.Pop();
                    }
                }
            );

            Task t2 = Task.Run(
                () => {
                    while(!integers.IsEmpty())
                    {
                        integers.Pop();
                    }
                }
            );

            Task.WaitAll(t1, t2);

            Assert.AreEqual(0, integers.Count);
        }

    }
}
