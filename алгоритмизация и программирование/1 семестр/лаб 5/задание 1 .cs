/******************************************************************************
14.10.24 -  Есть массив из n элементов, состоящий из переменных целого типа,
определить все ли элементы расположены в порядке возрастания — да или нет
*******************************************************************************/
using System;
class HelloWorld
{
    static void Main()
    {
        int n, a, b = 0;
        n = Convert.ToInt32(Console.ReadLine());
        int[] array = new int[n];
        for (a = 0; a < n; a++)
        {
            array[a] = Convert.ToInt32(Console.ReadLine());
        }
        for (a = 0; a < n; a++)
        {
            if (a != 0 && (array[a - 1] < array[a]))
            {
                b++;
            }
        }
        if (b == (n - 1))
        {
            Console.WriteLine("да");
        }
        else
        {
            Console.WriteLine("нет");
        }
    }
}