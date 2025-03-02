/****************************************
лаб 4 - (28.02.25) -задача 2 - список
****************************************/
using System;
using System.Collections.Generic;

namespace listcounted
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lst = new List<int>();
            Console.WriteLine("Введите количество элементов списка:");
            int amount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите элементы списка:");
            for (int i = 0; i < amount; i++)
            {
                int var = Convert.ToInt32(Console.ReadLine());
                lst.Add(var);
            }
            // 1
            HashSet<int> elements = new HashSet<int>(lst);
            Console.WriteLine("Список состоит из элементов: ");
            foreach (int elem in elements)
            {
                Console.Write(elem + " ");
            }
            // 2
            Dictionary<int, int> chastota = new Dictionary<int, int>();
            foreach (int elem in lst)
            {
                if (chastota.ContainsKey(elem))
                {
                    chastota[elem]++;
                }
                else
                {
                    chastota.Add(elem, 1);
                }
            }
            Console.WriteLine("\nЧастота появления каждого элемента: ");
            foreach (var pair in chastota)
            {
                Console.WriteLine($"Элемент {pair.Key}: {pair.Value}");
            }
        }
    }
}
