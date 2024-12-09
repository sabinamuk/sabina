/******************************************************************************
08.11.24 - Определить номера строк, элементы в которых образуют равномерно 
убывающую последовательность
*******************************************************************************/
using System;
class HelloWorld
{
    static int[][] Zapoln(int[][] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int m = int.Parse(Console.ReadLine());
            array[i] = new int[m];
            for (int j = 0; j < m; j++)
            {
                array[i][j] = int.Parse(Console.ReadLine());
            }
        }
        return array;
    }
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[][] array = new int[n][];
        array = Zapoln(array);
        int t = 0;
        for (int i = 0; i < n; i++)
        {
            int num = array[i].Length;
            int c = 0;
            for (int j = 0; j < num; j++)
            {
                if (j != 0 && array[i][j] < array[i][j - 1])
                {
                    c++;
                }
                if (c + 1 == num)
                {
                    Console.WriteLine("строка: " + (i + 1));
                }
            }
        }
    }
}