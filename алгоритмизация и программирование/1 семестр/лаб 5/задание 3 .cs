/******************************************************************************
14.10.24 -  Есть массив из n элементов, состоящий из переменных целого типа,
для каждого элемента найти сумму цифр
*******************************************************************************/
using System;
class HelloWorld
{
    static void Main()
    {
        int n, a, b = 0, c;
        n = Convert.ToInt32(Console.ReadLine());
        int[] array = new int[n];
        for (a = 0; a < n; a++)
        {
            array[a] = Convert.ToInt32(Console.ReadLine());
        }
        for (a = 0; a < n; a++)
        {
            c = array[a];
            while (c > 0)
            {
                b += c % 10;
                c/= 10;
            }
            Console.WriteLine(b);
            b = 0;
        }
    }
}