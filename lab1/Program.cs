using System;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
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
        }
    }
}
