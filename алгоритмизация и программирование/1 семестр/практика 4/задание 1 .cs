/******************************************************************************
практика - 4 (16.10.24) - Даны три массива, размерностью m,n,p. 
В каждом массиве определить 
1)сумму элементов кратных трем
2)произведение нечетных элементов
3)кол-во нулевых элементов
*******************************************************************************/
using System;
internal class Program
{
    static int Nul(int[] array)
    {
        int count = 0;
        foreach (int num in array)
        {
            if (num == 0)
            {
                count++;
            }
        }
        return count;
    }
    static int Nech(int[] array)
    {
        int proizv = 1;
        foreach (int num in array)
        {
            if (num % 2 != 0)
            {
                proizv *= num;
            }
        }
        return proizv > 1 ? proizv : 0;
    }

    static int Krat(int[] array)
    {
        int sum = 0;
        foreach (int num in array)
        {
            if (num % 3 == 0)
            {
                sum += num;
            }
        }
        return sum;
    }
    static int[] Zapoln(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }
        return array;
    }
    static void Main()
    {
        int m = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());

        int[] array1 = new int[m];
        int[] array2 = new int[n];
        int[] array3 = new int[p];

        array1 = Zapoln(array1);
        array2 = Zapoln(array2);
        array3 = Zapoln(array3);

        Console.WriteLine("Сумма кратных трём в первом массиве : " + Krat(array1));
        Console.WriteLine("Сумма кратных трём во втором массиве : " + Krat(array2));
        Console.WriteLine("Сумма кратных трём в третьем массиве : " + Krat(array3));
        Console.WriteLine("Произведение нечётных элементов в первом массиве : " + Nech(array1));
        Console.WriteLine("Произведение нечётных элементов во втором массиве : " + Nech(array2));
        Console.WriteLine("Произведение нечётных элементов в третьем массиве : " + Nech(array3));
        Console.WriteLine("Количество нулей в первом массиве : " + Nul(array1));
        Console.WriteLine("Количество нулей во втором массиве : " + Nul(array2));
        Console.WriteLine("Количество нулей в третьем массиве : " + Nul(array3));

        Console.ReadKey();
    }
}
