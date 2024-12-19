/**************************************************************************************
практика - 5 (28.10.24) - Массив трех массивов , своя размерность 
Необходимо определить кол-во нечетных  элементов в каждой строке ступенчатого массива
**************************************************************************************/
using System;
class HelloWorld
{
    static int Nech(int[] array, int count = 0)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int t = array[i];
            if (t % 2 != 0)
            {
                count += 1;
            }
        }
        return count;
    }
    static void Main()
    {
        int count = 0, firstl, secl, thl, nechcount = 0, a = 0, b = 0, c = 0;
        firstl = int.Parse(Console.ReadLine());
        secl = int.Parse(Console.ReadLine());
        thl = int.Parse(Console.ReadLine());
        int[][] arr = new int[3][];
        arr[0] = new int[firstl];
        arr[1] = new int[secl];
        arr[2] = new int[thl];
        for (int i = 0; i < firstl; i++)
        {
            arr[0][i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < secl; i++)
        {
            arr[1][i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < thl; i++)
        {
            arr[2][i] = int.Parse(Console.ReadLine());
        }
        a = Nech(arr[0]);
        b = Nech(arr[1]);
        c = Nech(arr[2]);
        nechcount = a + b + c;
        Console.WriteLine("Количество нечётных в первой строке: " + a);
        Console.WriteLine("Количество нечётных во второй строке: " + b);
        Console.WriteLine("Количество нечётных в третьей строке: " + c);
        Console.WriteLine("Всего нечётных: " + nechcount);
    }
}