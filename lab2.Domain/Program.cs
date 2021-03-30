using System;

namespace lab2.Domain
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User{ Id=123 };
            Note note = new Note{ Id=123, User=user};

            Console.WriteLine(user);
            Console.WriteLine(note);
        }
    }
}

