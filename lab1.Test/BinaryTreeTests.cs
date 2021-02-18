using System;
using NUnit.Framework;

namespace lab1.Test
{
    public class BinaryTreeTests
    {
        BinaryTree.BinaryTree<int, int> tree;

        [SetUp]
        public void Setup()
        {
            tree = new BinaryTree.BinaryTree<int, int>();
        }

        [Test]
        public void TestInsertAndFind()
        {
            Assert.IsNull(tree.find(2));
            Assert.IsNull(tree.find(3));

            tree.insert(2, 123);

            Assert.AreEqual(tree.find(2).key, 2);
            Assert.AreEqual(tree.find(2).val, 123);

            tree.insert(2, 456);

            Assert.AreEqual(tree.find(2).key, 2);
            Assert.AreEqual(tree.find(2).val, 456);

            tree.insert(3, 456);

            Assert.AreEqual(tree.find(3).key, 3);
            Assert.AreEqual(tree.find(3).val, 456);
        }

        [Test]
        public void TestRemove()
        {
            tree.insert(2, 123);
            tree.insert(3, 456);
            tree.insert(1, 789);

            tree.remove(2);
            Assert.IsNull(tree.find(2));

            tree.remove(3);
            Assert.IsNull(tree.find(3));

            tree.remove(1);
            Assert.IsNull(tree.find(1));
        }
    }
}
