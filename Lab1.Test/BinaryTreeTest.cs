using NUnit.Framework;

namespace Lab1.Test
{
    public class BinaryTreeTest
    {
        Lab1.BinaryTree testTree;

        [SetUp]
        public void Setup()
        {
            testTree = new BinaryTree();
        }
        

        [Test]
        public void AddTest()
        {
            Assert.Null(testTree.root);

            testTree.Add(5);
            Assert.AreEqual(testTree.root.data, 5);

            testTree.Add(1);
            Assert.AreEqual(testTree.root.data, 5);

            Assert.NotNull(testTree.Find(1));
        }

        [Test]
        public void RemoveTest()
        {
            for (int i =0; i < 10; i++)
            {
                testTree.Add(i);
            }

            testTree.Remove(5);
            Assert.Null(testTree.Find(5));

            testTree.Remove(0);
            Assert.NotNull(testTree.root);

            BinaryTree treeTest1 = new BinaryTree();
            treeTest1.Add(2);
            treeTest1.Add(3);
            treeTest1.Add(1);
            treeTest1.Remove(1);
            Assert.Null(treeTest1.Find(1));
        }

    }
}
