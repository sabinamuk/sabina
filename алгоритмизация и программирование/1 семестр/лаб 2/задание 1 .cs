/******************************************************************************
определить кол-во элементов меньших нуля
*******************************************************************************/
using System;
class HelloWorld
{
    static void Main()
    {
        int n, c = 0, num;
        n = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            num = Convert.ToInt32(Console.ReadLine());
            if (num < 0)
            {
                c++;
            }
        }
        Console.WriteLine(c);
    }
}