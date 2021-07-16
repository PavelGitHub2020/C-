using System;

namespace QueueInTheStore
{
    class Program
    {
        static void Main(string[] args)
        {
            QueueInTheStore queueInTheStore = new QueueInTheStore(10);

            while (true)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    queueInTheStore.PlacingInAQueue();
                    queueInTheStore.LivingTheQueue();
                }
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }
    }
}
