/******************************************************************************
определить среди элементов второй максимальный элемент
*******************************************************************************/
using System;
class HelloWorld
{
    static void Main()
    {
        int n, c = 0, num, max1 = 0, max2 = 0;
        n = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            num = Convert.ToInt32(Console.ReadLine());
            if (num > max1)
            {
                max2 = max1;
                max1 = num;
            }
            else if (max2 < num && num <= max1)
            {
                max2 = num;
            }
        }
        Console.WriteLine(max2);
    }
}