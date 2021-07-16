using System;

namespace Task_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Good good = new Good("Pasta", 321,94,95);
            good.ShowSum();
            good.ShowPrice();
        }
    }
}
