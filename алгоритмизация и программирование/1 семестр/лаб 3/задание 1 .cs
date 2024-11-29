/******************************************************************************
30.09.24-Определить в последовательности максимальный размер подпоследовательности
состоящей из одинаковых элементов
*******************************************************************************/
using System;
class HelloWorld
{
    static void Main()
    {
        int n, c = 0, t, y = 1, max = 0;
        n = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            t = Convert.ToInt32(Console.ReadLine());
            if (i != 0 & c == t)
            {
                y++;
            }
            if (y > max)
            {
                max = y;
            }
            else
            {
                y = 1;
            }
            c = t;
        }
        Console.WriteLine(max);
    }
}