using System;
using NUnit.Framework;

namespace lab1.Test
{
    public class LinkedListTests
    {
        private LinkedList<int> list;

        [SetUp]
        public void Setup()
        {
            list = new LinkedList<int>();
        }

        [Test]
        public void TestEmpty()
        {
            Assert.Throws<Exception>(() => list.back());
        }

        [Test]
        public void TestPushBack()
        {
            list.push_back(1);
            Assert.AreEqual(1, list.back());

            list.push_back(2);
            Assert.AreEqual(2, list.back());

            list.push_back(3);
            Assert.AreEqual(3, list.back());
        }

        [Test]
        public void TestPopBack()
        {
            list.push_back(1);
            list.push_back(2);
            list.push_back(3);

            list.pop_back();
            Assert.AreEqual(2, list.back());

            list.pop_back();
            Assert.AreEqual(1, list.back());

            list.pop_back();
            Assert.Throws<Exception>(() => list.back());
        }

        [Test]
        public void TestRemoveByIndex()
        {
            list.push_back(1);
            list.push_back(2);
            list.push_back(3);

            list.remove_by_index(1);

            Assert.AreEqual(3, list.back());
            list.pop_back();
            Assert.AreEqual(1, list.back());
            list.pop_back();
            Assert.Throws<Exception>(() => list.back());
        }

        [Test]
        public void TestRemoveByIndexFromHeadOrTail()
        {
            list.push_back(1);

            list.remove_by_index(0);

            Assert.Throws<Exception>(() => list.back());
        }

        [Test]
        public void TestReverse()
        {
            list.push_back(1);
            list.push_back(2);
            list.push_back(3);

            list.reverse();

            Assert.AreEqual(1, list.back());
            list.pop_back();

            Assert.AreEqual(2, list.back());
            list.pop_back();

            Assert.AreEqual(3, list.back());
            list.pop_back();

            Assert.Throws<Exception>(() => list.back());
        }

        [Test]
        public void TestIEnumerable()
        {
            list.push_back(1);
            list.push_back(2);
            list.push_back(3);

            int i = 1;
            foreach (int val in list)
            {
                Assert.AreEqual(i, val);
                i += 1;
            }
            Assert.AreEqual(i, 4);
        }
    }
}
