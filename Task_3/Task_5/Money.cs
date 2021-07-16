using System;
using System.Collections.Generic;
using System.Text;

namespace Task_5
{
    //Создать класс Money для работы с денежными суммами в котором для рублей и
    //копеек предусмотрены независимые целочисленные данные.Реализовать метод вывода
    //суммы на экран.На основе класса Money создать класс Good для работы с товаром.
    //Предусмотреть метод, осуществляющий уменьшение цены на заданное число процентов.
    class Money
    {
        private int ruble;
        private int kopeck;
        public int Ruble
        {
            get { return ruble; }
            set { ruble = value; }
        }
        public int Kopeck
        {
            get
            {
                return kopeck;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    Console.WriteLine("Kopeck must be in 0 to 100 value!");
                }
                else
                {
                    kopeck = value;
                }
               
            }
        }

        public Money(int rub, int kop)
        {
            Ruble = rub;
            Kopeck = kop;
        }
        public void ShowSum()
        {
            Console.WriteLine(this.Ruble + (double)this.Kopeck / 100);
        }

    }
}
