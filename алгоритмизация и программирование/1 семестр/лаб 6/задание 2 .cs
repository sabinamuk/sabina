/**************************************************************************************
28.10.24 -  Массив двумерный обычный, необходимо определить в массиве точки минимакса 
**************************************************************************************/
using System;
class Program
{
    static void Main()
    {
        int n, m, maxindex2 = 0, maxindex = 0;
        Console.WriteLine("Введите размерность массива: ");
        n = int.Parse(Console.ReadLine());
        m = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите массив: ");
        int[,] array = new int[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int k = 0; k < m; k++)
            {
                array[i, k] = int.Parse(Console.ReadLine());
            }
        }
        int minimax = -10000000;
        for (int i = 0; i < n; i++)
        {
            int maxstrok = array[i, 0];
            for (int k = 1; k < m; k++)
            {
                if (array[i, k] > maxstrok)
                {
                    maxstrok = array[i, k];
                    maxindex = k;
                    maxindex2 = i;
                }
            }
            bool minstolb = true;
            for (int j = 0; j < n; j++)
            {
                if (array[j, maxindex] < maxstrok)
                {
                    minstolb = false;
                    break;
                }
            }
            if (minstolb)
            {
                maxindex2 = i;
                minimax = maxstrok;
                break;
            }
        }
        if (minimax > -10000000)
        {
            Console.WriteLine("Минимакс: " + minimax);
            Console.WriteLine("Строка(x): " + (maxindex2 + 1));
            Console.WriteLine("Столбец(y): " + (maxindex + 1));
        }
        else
        {
            Console.WriteLine("Минимакса нет");
        }
    }
}