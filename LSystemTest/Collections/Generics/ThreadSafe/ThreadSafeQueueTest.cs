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
    public class ThreadSafeQueueTest
    {
        [TestMethod]
        public void TestAsyncEnqueue()
        {
            ThreadSafeQueue<int> integers = new ThreadSafeQueue<int>();

            Task t1 = Task.Run(
                () => {
                    for (int i = 0; i < 1000000; ++i)
                    {
                        integers.Enqueue(i);
                    }
                }
            );

            Task t2 = Task.Run(
                () => {
                    for (int i = 0; i < 1000000; ++i)
                    {
                        integers.Enqueue(i);
                    }
                }
            );

            Task.WaitAll(t1, t2);

            Assert.AreEqual(2000000, integers.Count);
        }

        [TestMethod]
        public void TestAsyncEnqueueList()
        {
            ThreadSafeQueue<int> integers = new ThreadSafeQueue<int>();

            Task t1 = Task.Run(
                () => {
                    List<int> data = new List<int>(500);
                    for (int i = 0; i < 1000; i+=2)
                    {
                        System.Threading.Thread.Sleep(10);
                        data.Add(i);
                    }

                    integers.Enqueue(data);
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

                    integers.Enqueue(data);
                }
            );

            Task.WaitAll(t1, t2);

            Assert.AreEqual(1000, integers.Count);
        }

        [TestMethod]
        public void TestAsyncDequeue()
        {
            ThreadSafeQueue<int> integers = new ThreadSafeQueue<int>();

            for (int i = 3; i < 1000000; ++i)
            {
                integers.Enqueue(i);
            }

            Task t1 = Task.Run(
                () => {
                    while(!integers.IsEmpty())
                    {

                        integers.Dequeue();
                    }
                }
            );

            Task t2 = Task.Run(
                () => {
                    while(!integers.IsEmpty())
                    {
                        integers.Dequeue();
                    }
                }
            );

            Task.WaitAll(t1, t2);

            Assert.AreEqual(0, integers.Count);
        }

    }
}
