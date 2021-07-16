using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Tamagochic
{
    class Program
    {
        static void Main(string[] args)
        {
            Tamagochi.Images();
            Tamagochi.PrintImages();
            Tamagochi tamagochi = new Tamagochi();
            tamagochi.LifeCycle();
        }

    }
}
