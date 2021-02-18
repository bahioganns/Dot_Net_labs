using NUnit.Framework;

namespace Lab1.Test
{
    public class SortingTest
    {
        Lab1.Sorting elem;
        int[] testArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int[] notSortedArray = { 1, 0, 3, 9, 2, 6, 4, 5, 7, 8 };
        [SetUp]
        public void Setup()
        {
            elem = new Lab1.Sorting();
            int[] testArray = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            int[] notSortedArray = {1, 0, 3, 9, 2, 6, 4, 5, 7, 8};
        }

        [Test]
        public void Sorting()
        {
            elem.InsertionSort(notSortedArray);

            Assert.AreEqual(notSortedArray, testArray);
        }

        

    }
}
