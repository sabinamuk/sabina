/******************************************************************************
28.10.24 -  Массив двумерный обычный, необходимо выдать пары номеров строк,
состоящих из одинаковых элементов
*******************************************************************************/
using System;
class HelloWorld
{
    static void Main()
    {
        int n, m;
        Console.WriteLine("Введите размерность массива: ");
        n = int.Parse(Console.ReadLine());
        m = int.Parse(Console.ReadLine());
        int[,] arr = new int[n, m];
        Console.WriteLine("Введите массив: ");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                arr[i, j] = int.Parse(Console.ReadLine());
            }
        }
        int[] sumarr = new int[n];
        int[] proizarr = new int[n];
        int[] nolarr = new int[n];
        for (int i = 0; i < n; i++)
        {
            int sum = 0;
            for (int j = 0; j < m; j++)
            {
                sum += arr[i, j];
            }
            sumarr[i] = sum;
        }
        for (int i = 0; i < n; i++)
        {
            int proiz = 1;
            for (int j = 0; j < m; j++)
            {
                if (arr[i, j] == 0)
                {
                    continue;
                }
                proiz *= arr[i, j];
            }
            proizarr[i] = proiz;
        }
        for (int i = 0; i < n; i++)
        {
            int nol = 0;
            for (int j = 0; j < m; j++)
            {
                if (arr[i, j] == 0)
                {
                    nol += 1;
                }
            }
            nolarr[i] = nol;
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (proizarr[i] == proizarr[j] && sumarr[i] == sumarr[j] && nolarr[i] == nolarr[j])
                {
                    Console.WriteLine("Строки " + (i + 1) + " и " + (j + 1) + " имеют одинаковые элементы");
                }
            }
        }
    }
}