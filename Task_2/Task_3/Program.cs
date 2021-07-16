using System;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Counter counter = new Counter();
            counter.DefaultValue = 10;
            Console.WriteLine("Default value - " + counter.DefaultValue);

            counter.Value = -4;
            Console.WriteLine(counter.getCurrentState);

            counter.IncreaseCounter();
            Console.WriteLine("After increase:");
            Console.WriteLine(counter.getCurrentState);

            counter.DecreaseCounter();
            Console.WriteLine("After decrease:");
            Console.WriteLine(counter.getCurrentState);

        }
    }
}
