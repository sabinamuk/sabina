/******************************************************************************
Лаб 7 ( 08.11.24) - На вход подается зубчатый массив.
С помощью функции организовать ввод каждой строки массива.
Определить номера строк, элементы в которых образуют равномерно убывающую последовательность.
*******************************************************************************/
using System;
using System.Runtime.ExceptionServices;
using static System.Runtime.InteropServices.JavaScript.JSType;
class Program
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int[][] array = new int[N][];
        for (int i = 0; i < N; i++)
        {
            Console.Write($"Размерность массива {i + 1}: ");
            int length = int.Parse(Console.ReadLine());
            array[i] = new int[length];
            Console.WriteLine($"Введите {length} элементов для массива {i + 1}:");
            for (int j = 0; j < length; j++)
            {
                array[i][j] = int.Parse(Console.ReadLine());
            }
        }
        for (int i = 0; i < array.Length; i++) 
        {
            int count = 0;
            int razn = 0;
            for (int k = 0; k < array[i].Length; k++) 
            {
                int elfirst = array[i][0];
                if (array[i].Length > 1)
                {
                    razn = elfirst - array[i][1];
                    for (int j = 1; j < array[i].Length; j++) 
                    {
                        if ((array[i][j - 1] - array[i][j]) == razn)
                        {
                            count += 1;
                        }
                    }
                    if (count == array[i].Length - 1)
                        Console.WriteLine(i);
                }
            }
        }
    }
}