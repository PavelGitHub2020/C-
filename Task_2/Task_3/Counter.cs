using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3
{
    //Описать класс, реализующий десятичный счетчик,
    //который может увеличивать или уменьшать свое значение на единицу в заданном диапазоне.
    //Предусмотреть инициализацию счетчика значениями по умолчанию и произвольными значениями.
    //Счетчик имеет два метода: увеличения и уменьшения, — и свойство, позволяющее получить его текущее состояние.
    //Написать программу, демонстрирующую все возможности класса.
    class Counter
    {
        private int values;
        public int Value
        {
            set
            {
                if (value > 100)
                    Console.WriteLine("The counter value can't be more than 100!");
                else if (value < - 10)
                    Console.WriteLine("The counter value can't be more less!");
                else
                    values = value;
            }
            get { return values; }
        }
        public string getCurrentState
        {
            get
            {
                return $"The current state of counter - {Value}";
            }
        }
        public int DefaultValue
        {
            get { return values; }
            set { Value = value; }
        }

        public int IncreaseCounter()
        {
            return Value++;
        }

        public int DecreaseCounter()
        {
            return Value--;
        }
    }
}
