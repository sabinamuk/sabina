/******************************************************************************
14.10.24 -  Есть массив из n элементов, состоящий из переменных целого типа,
определить среднее арифметическое четных цифр
*******************************************************************************/
using System;
class HelloWorld
{
    static void Main()
    {
        int n, a, b = 0, c = 0, d = 0, s = 0;
        n = Convert.ToInt32(Console.ReadLine());
        int[] array = new int[n];
        for (a = 0; a < n; a++)
        {
            array[a] = Convert.ToInt32(Console.ReadLine());
        }
        for (a = 0; a < n; a++)
        {
            c = array[a];
            if (c % 2 == 0)
            {
                b++;
                d += c;
            }
        }
        s = d / b;
        Console.WriteLine(s);
    }
}