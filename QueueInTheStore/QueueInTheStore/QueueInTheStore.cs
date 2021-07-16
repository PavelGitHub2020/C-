using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace QueueInTheStore
{
    class QueueInTheStore
    {
        //Очереди часто используются для моделирования потока людей, машин, 
        //самолетов, банковских операций и т.д.Напишите программу, моделирующую
        //очередь покупателей в кассы в магазине, на базе класса Queue
        //Программа должна отображать содержимое сразу нескольких
        //очередей; воспользуйтесь методом display() из класса Queue Новый покупатель помещается
        //в очередь нажатием клавиши.Вы должны самостоятельно определить, каким
        //образом он будет выбирать очередь. Обслуживание каждого покупателя имеет
        //случайную продолжительность (в зависимости от количества товаров в корзине). 
        //Обслуженные покупатели удаляются из очереди.Для простоты течение времени
        //можно моделировать нажатиями клавиш — например, каждое нажатие клавиши
        //соответствует одной минуте.
       
            private Queue[] queues;

            private int[] numberOfProducts;

            private int numberOfQueue;

            private int numberOfQueues;

            char userName;

            private Random random;


            public QueueInTheStore(int number)
            {
                numberOfQueues = number;

                queues = new Queue[numberOfQueues];
                numberOfProducts = new int[numberOfQueues];

                for (int i = 0; i < numberOfQueues; i++)
                {
                    random = new Random();
                    numberOfProducts[i] = random.Next(1, 10);

                    queues[i] = new Queue(numberOfProducts[i]);
                }
            }

            public void PlacingInAQueue()
            {
                random = new Random();
                numberOfQueue = random.Next(0, queues.Length);

                random = new Random();
                userName = (char)random.Next('A', 'Z' + 1);

                for (int i = 0; i < numberOfProducts[numberOfQueue]; i++)
                {
                    queues[numberOfQueue].insert(i);
                }

                Console.WriteLine($"{userName} in {numberOfQueue} queue has {numberOfProducts[numberOfQueue]} products:");
                queues[numberOfQueue].Display();
            }

            public void LivingTheQueue()
            {
                while (!queues[numberOfQueue].isEmpty())
                {
                    queues[numberOfQueue].remove();
                }

                int serviceDuration = numberOfProducts[numberOfQueue] * 1000;
                Thread.Sleep(serviceDuration);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{userName} served and leaved the queue!\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Beep();
            }
        }
    }

