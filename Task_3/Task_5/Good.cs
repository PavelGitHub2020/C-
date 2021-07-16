using System;
using System.Collections.Generic;
using System.Text;

namespace Task_5
{
    //Создать класс Money для работы с денежными суммами в котором для рублей и
    //копеек предусмотрены независимые целочисленные данные.Реализовать метод вывода
    //суммы на экран.На основе класса Money создать класс Good для работы с товаром.
    //Предусмотреть метод, осуществляющий уменьшение цены на заданное число процентов.
    class Good : Money
    {
        private string name;
        private int percentR;

        private double price;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int PercentR
        {
            get { return percentR; }
            set
            {
                if (value < 0 || value > 100)
                {
                    Console.WriteLine("The value's percent must be in 0 to 100!");
                }
                else
                {
                    percentR = value;
                }
            }
        }


        public Good(string name, int ruble, int copeck, int percent) : base(ruble,copeck)
        {
            Name = name;
            PercentR = percent;
        }

        public void ShowPrice()
        {
            Console.WriteLine("Discount - " + PercentR + "%");
            Console.WriteLine($"{Name}:");
            this.price = (this.Ruble + (double)this.Kopeck / 100) - ((this.Ruble + (double)this.Kopeck / 100) * this.PercentR / 100);
            Console.WriteLine("price = {0}", this.price);
        }
    }
}
