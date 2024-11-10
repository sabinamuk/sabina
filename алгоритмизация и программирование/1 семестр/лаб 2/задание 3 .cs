/******************************************************************************
определить кол-во элементов, являющихся локальными минимумами 
*******************************************************************************/
using System;
class HelloWorld
{
    static void Main()
    {
        int num = Convert.ToInt32(Console.ReadLine());
        int x = 0;
        int a = Convert.ToInt32(Console.ReadLine());
        int b = Convert.ToInt32(Console.ReadLine());
        for (int i = 2; i < num; i++)
        {
            int c = Convert.ToInt32(Console.ReadLine());
            if (b < a && b < c)
            {
                x++;
            }
            a = b;
            b = c;
        }
        Console.WriteLine(x);
    }
}