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
        public void Test1()
        {
            list.push_back(123);
            Assert.AreEqual(123, list.back());
        }
    }
}
