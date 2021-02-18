using NUnit.Framework;

namespace Lab1.Test
{
    public class Tests
    {
        Lab1.DoubleLinkedList<int> testList;

        [SetUp]
        public void Setup()
        {
            testList = new Lab1.DoubleLinkedList<int>();
        }

        [Test]
        public void TestInsertBack()
        {
            testList.InsertLast(1);

            Assert.AreEqual(testList.GetLastNode().data, 1);
            Assert.AreEqual(testList.head, testList.GetLastNode());
        }

        [Test]
        public void TestReverseList()
        {
            Lab1.DoubleLinkedList<int> testList1 = new Lab1.DoubleLinkedList<int>();

            for (int i = 0; i < 10; i++)
            {
                testList.InsertLast(i);
                testList1.InsertLast(9 - i);
            }

            testList.ReverseList();

            Node<int> test = testList.head;
            Node<int> test1= testList1.head;

            for(int i = 0; i < 10; i++)
            {
                Assert.AreEqual(test1.data, test.data);
                test = test.next;
                test1 = test1.next;
            }
        }

        [Test]
        public void TestDeleteFirstByKey()
        {
            for (int i = 0; i < 10; i++)
            {
                testList.InsertLast(i);
            }

            testList.DeleteFirstByKey(0);

            Assert.IsFalse(testList.Contains(0));

            testList.InsertLast(1);
            testList.DeleteFirstByKey(1);

            Assert.IsTrue(testList.Contains(1));
        }

        [Test]
        public void TestDeleteAllByKey()
        {
            for (int i = 0; i < 10; i++)
            {
                testList.InsertLast(i);
            }
            testList.InsertLast(1);
            testList.InsertLast(1);

            testList.DeleteAllByKey(1);

            Assert.IsFalse(testList.Contains(1));
        }
        
    }
}