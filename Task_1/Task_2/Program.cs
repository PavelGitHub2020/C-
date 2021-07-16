using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            SomeClass someClass = new SomeClass(3, 4);
            Console.WriteLine(someClass.ToString());
            Console.WriteLine(someClass.Sum());
            Console.WriteLine(someClass.Equal());

            someClass.ChangeTheValues(34, 78);
            Console.WriteLine(someClass.Sum());
            Console.WriteLine(someClass.ToString());
        }
    }
}
