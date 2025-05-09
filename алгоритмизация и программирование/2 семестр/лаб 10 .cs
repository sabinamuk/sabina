/******************************************************************************
Лаб 10 - 11.04.25 - добавление данных в массив, удаление из массива по индексу 
и получение из массива по индексу
*******************************************************************************/
using System;
namespace Array
{
    class GenArr<T>
    {
        private T[] arr;
        private int end;
        public int Count => end; 
        public GenArr()
        {
            arr = new T[1];
            end = 0;
        }
        public void Add(T newEntry)
        {
            if (end >= arr.Length)
                Array.Resize(ref arr, end + 1);
            arr[end++] = newEntry;
        }
        public void Del(int ind)
        {
            if (ind < 0 || ind >= end)
            {
                Console.WriteLine("Индекс выходит за пределы");
                return;
            }
            for (int i = ind; i < end - 1; i++)
                arr[i] = arr[i + 1];
            end--;
            Array.Resize(ref arr, end);
        }
        public T Find(int ind)
        {
            if (ind < 0 || ind >= end)
            {
                Console.WriteLine("Индекс выходит за пределы");
                return default;
            }

            return arr[ind];
        }
        public void Print()
        {
            Console.WriteLine("Текущий массив:");
            for (int i = 0; i < end; i++)
            {
                Console.WriteLine($"[{i}] {arr[i]}");
            }
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            GenArr<int> arr = new GenArr<int>();

            Console.WriteLine("Добавляем элементы 1, 2, 3:");
            arr.Add(1);
            arr.Add(2);
            arr.Add(3);
            arr.Print();

            Console.WriteLine("Удаляем элемент с индексом 1:");
            arr.Del(1);
            arr.Print();

            Console.WriteLine("Пытаемся получить элемент с индексом 5:");
            var value = arr.Find(5); 

            Console.WriteLine("Добавляем элементы 10, 20, 30:");
            arr.Add(10);
            arr.Add(20);
            arr.Add(30);
            arr.Print();

            Console.WriteLine("Удаляем элемент с индексом 4:");
            arr.Del(4);
            arr.Print();
        }
    }
}