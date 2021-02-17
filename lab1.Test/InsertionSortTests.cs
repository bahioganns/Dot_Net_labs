using System;
using NUnit.Framework;

namespace lab1.Test
{
    public class InsertionSortTests
    {
        [Test]
        public void TestSort()
        {
            int[] arr = { 2, 7, 3, 11, 6 };

            int[] sortedArr = (int[]) arr.Clone();
            Array.Sort(sortedArr);

            int[] mySortedArr = (int[]) arr.Clone();
            MySort.InsertionSort(mySortedArr);

            Assert.AreEqual(sortedArr, mySortedArr);
        }
    }
}
