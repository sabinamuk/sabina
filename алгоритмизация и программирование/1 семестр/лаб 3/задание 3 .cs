/******************************************************************************
30.09.24-Определить в последовательности максимальную сумму 
подпоследовательности из четных чисел 
*******************************************************************************/
using System;
class HelloWorld
{
    static void Main()
    {
        int c = 0, n, max = 0, num;
        n = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            num = Convert.ToInt32(Console.ReadLine());
            if (num % 2 == 0)
            {
                c += num;
                if (c > max)
                {
                    max = c;

                }
            }
            else
            {
                c = 0;
            }
        }
        Console.WriteLine(max);
    }

}