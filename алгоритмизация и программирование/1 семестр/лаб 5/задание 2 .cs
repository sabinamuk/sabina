/******************************************************************************
14.10.24 -  Есть массив из n элементов, состоящий из переменных целого типа,
определить кол-во элементов, значение которых оканчиваются на тройку
*******************************************************************************/
using System;
class HelloWorld
{
    static void Main()
    {
        int n, a, b = 0;
        n = Convert.ToInt32(Console.ReadLine());
        int[] array = new int[n];
        for (a = 0; a < n; a++)
        {
            array[a] = Convert.ToInt32(Console.ReadLine());
        }
        for (a = 0; a < n; a++)
        {
            if ((array[a] % 10 == 3) || (Math.Abs(array[a])) % 10 == 3)
            {
                b++;
            }
        }
        Console.WriteLine(b);
    }
}