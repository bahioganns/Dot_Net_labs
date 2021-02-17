using System;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();

            list.push_back(123);
            Console.WriteLine(list);

            list.push_back(456);
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
