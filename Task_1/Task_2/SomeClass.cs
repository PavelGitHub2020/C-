using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2
{
    //Создать класс с двумя переменными.Добавить функцию вывода на экран и функцию изменения этих переменных.
    //Добавить функцию, которая находит сумму значений этих переменных,
    //и функцию которая находит наибольшее значение из этих двух переменных.
    class SomeClass
    {
        private int number1;
        private int number2;

        public SomeClass(int x, int y)
        {
            this.number1 = x;
            this.number2 = y;
        }

        public override string ToString()
        {
            return $"number1 - {number1} \n number2 - {number2}";
        }

        public void ChangeTheValues(int x, int y)
        {
            this.number1 = x;
            this.number2 = y;
        }

        public int Sum()
        {
            Console.WriteLine("Sum of two elements:");
            return number1 + number2;
        }

        public string Equal()
        {
            if (number1 > number2)
                return $"number1 > number2";

            return $"number2 > number1";
        }
    }
}
