using System;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Linked List Example
            LinkedList<int> list = new LinkedList<int>();

            list.push_back(123);
            list.push_back(456);
            list.push_back(789);

            int i = 1;
            foreach (int val in list)
            {
                Console.WriteLine($"{i}: {val}");
                i += 1;
            }

            Console.WriteLine(list);

            list.pop_back();
            Console.WriteLine(list);

            list.pop_back();
            Console.WriteLine(list);

            list.pop_back();
            Console.WriteLine(list);


            // Binary Tree Example
            BinaryTree.BinaryTree<int, int> tree = new BinaryTree.BinaryTree<int, int>();

            tree.insert(2, 123);
            tree.insert(1, 456);
            tree.insert(3, 789);

            tree.remove(2);

            tree.find(2);
            tree.find(1);
            tree.find(3);


            // Insertion Sort Example
            int[] arr = { 2, 7, 3, 11, 6 };

            MySort.InsertionSort(arr);
        }
    }
}
