/******************************************************************************
30.09.24-Определить в последовательности минимальный размер 
подпоследовательности состоящей из 0
*******************************************************************************/
using System;
class HelloWorld
{
    static void Main()
    {
     int c = 0, min = -1, n, num;
     n = Convert.ToInt32(Console.ReadLine());
     for (int i = 0; i < n; i++)
        {
         num = Convert.ToInt32(Console.ReadLine());
         if (num == 0)
           {
               c++;
           }
           else
            {
              if (c > 0 && (min == -1 || c < min))
              {
                 min = c;
               }
               c = 0;
            }
        }
        if (c > 0 && (min == -1 || c < min))
        {
            min = c;
        }
        Console.WriteLine(min); 
    }
}