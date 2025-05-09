/**************************************************************************************
Лаб 9 - 04.04.25 -  задача 2 - необходимо выдать слова, которые начинаются на букву а
***************************************************************************************/
using System;
using System.Collections.Generic;
namespace AWord
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите количество слов");
            int count = int.Parse(Console.ReadLine());

            var words = new List<string>();
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Введите слово {i}");
                words.Add(Console.ReadLine());
            }
            var wordsWithA = words.FindAll(word =>
                word.Length > 0 && (word[0] == 'А' || word[0] == 'а'));

            Console.WriteLine("\nСлова на 'A' или 'a':");
            wordsWithA.ForEach(word => Console.WriteLine(word));
        }
    }
}