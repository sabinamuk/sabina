/******************************************************************************
практика - 4 (16.10.24) - упаковки молока
*******************************************************************************/
using System;
class HelloWorld
{
    static void Main()
    {
        int N = Convert.ToInt32(Console.ReadLine());
        double[] prices = new double[N];

        for (int i = 0; i < N; i++)
        {
            int[] cont1 = new int[3];
            int[] cont2 = new int[3];
            for (int j = 0; j < 3; j++)
            {
                Console.Write("Введите размеры упаковки 1: ");
                cont1[j] = Convert.ToInt32(Console.ReadLine());
            }
            for (int j = 0; j < 3; j++)
            {
                Console.Write("Введите размеры упаковки 2: ");
                cont2[j] = Convert.ToInt32(Console.ReadLine());
            }
            Console.Write("Введите стоимость упаковки 1: ");
            double c1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите стоимость упаковки 2: ");
            double c2 = Convert.ToDouble(Console.ReadLine());

            double v1 = (double)(cont1[0] * cont1[1] * cont1[2]) / 1000;
            double v2 = (double)(cont2[0] * cont2[1] * cont2[2]) / 1000;
            int s1 = 2 * (cont1[0] * cont1[1] + cont1[0] * cont1[2] + cont1[1] * cont1[2]);
            int s2 = 2 * (cont2[0] * cont2[1] + cont2[0] * cont2[2] + cont2[1] * cont2[2]);

            double literPrice = Math.Round((c1 - s1 * ((c2 * v1 - c1 * v2) / (s2 * v1 - s1 * v2))) / v1, 2);
            prices[i] = literPrice;
        }
        double minPrice = prices[0];
        int t = 1;
        for (int n = 1; n < N; n++)
        {
            if (prices[n] < minPrice)
            {
                minPrice = prices[n];
                t = n + 1;
            }
        }
        Console.WriteLine("{0} {1:f2}", t, minPrice);
    }
}