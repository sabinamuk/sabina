/******************************************************************************
28.10.24 -  Массив двумерный обычный, необходимо переставить строку с 
минимальным элементом со строкой с максимальным элементов(меняем местами) 
минимум и максимум только один 
*******************************************************************************/
using System;
class HelloWorld {
  static void Main() {
    int n,m, min = 100000, max = -10000000, numbermin = 0, numbermax = 0, numbermax2 = 0, numbermin2 = 0;
    n = int.Parse(Console.ReadLine());
    m = int.Parse(Console.ReadLine());
    int[,] array = new int[n,m];
    for (int i = 0; i < n; i++)
    {
        for(int k = 0; k < m; k++)
        {
            array[i,k] = int.Parse(Console.ReadLine());
        }
    }
    for (int i = 0;i < n; i++)
    {
        for(int k = 0; k < m;  k++)
        {
            if (array[i,k] < min)
            {
                min = array[i,k];
                numbermin = i;
                numbermin2 = k;
            }
        }
    }
    for (int i = 0;i < n; i++)
    {
        for(int k = 0; k < m;  k++)
        {
            if (array[i,k] > max)
            {
                max = array[i,k];
                numbermax = i;
                numbermax2 = k;
            }
        }
    }
    for (int i=0;i<m;i++)
    {
        var t = array[numbermin,i];
        array[numbermin,i] = array[numbermax,i];
        array[numbermax,i] = t;
    }
    for(int i = 0; i < n; i++)
    {
        for(int k = 0; k < m; k++)
        {
            Console.Write(array[i,k]);
        }
        Console.WriteLine();
    }
  }
}