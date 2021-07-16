using System;
using System.Collections.Generic;
using System.Text;

namespace QueueInTheStore
{
    class Queue
    {
        private int maxSize;
        private long[] queArray;
        private int front;
        private int rear;
        private int nItems;

        public Queue(int s)
        {
            maxSize = s;
            queArray = new long[maxSize];
            front = 0;
            rear = -1;
            nItems = 0;
        }

        public void Display()//+++++
        {
            if (nItems == 0)
            {
                Console.WriteLine("The list is empty!");
            }
            if (rear == maxSize - 1)
            {
                for (int i = 0; i < queArray.Length; i++)
                {
                    Console.WriteLine(queArray[i]);
                }
            }
            else
            {
                for (int i = 0; i < nItems; i++)
                {
                    Console.WriteLine(queArray[i]);
                }
            }
        }
        public void insert(long j) // Вставка элемента в конец очереди
        {
            if (rear == maxSize - 1) // Циклический перенос
                rear = -1;
            queArray[++rear] = j; // Увеличение rear и вставка
            nItems++; // Увеличение количества элементов
        }

        public long remove() // Извлечение элемента в начале очереди
        {
            long temp = queArray[front++]; // Выборка и увеличение front
            if (front == maxSize) // Циклический перенос
                front = 0;
            nItems--; // Уменьшение количества элементов
            return temp;
        }

        public long peekFront() // Чтение элемента в начале очереди
        {
            return queArray[front];
        }
        public bool isEmpty() // true, если очередь пуста
        {
            return (nItems == 0);
        }

        public bool isFull()
        {
            return (nItems == maxSize);
        }

        public int size() // Количество элементов в очереди
        {
            return nItems;
        }
    }
}

