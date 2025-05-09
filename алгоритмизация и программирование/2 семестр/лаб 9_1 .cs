/******************************************************************************
Лаб 9 - 04.04.25 -  задача 1 - вычислить сумму, произведение, разность
и деление между двумя переменными
*******************************************************************************/
using System;
namespace lambda_expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            var sum = (int x, int y) => x + y;
            var difference = (int x, int y) => x - y;
            var multiply = (int x, int y) => x * y;
            var divide = (int x, int y) =>
            {
                if (y == 0)
                {
                    Console.WriteLine("Ошибка: деление на ноль");
                    return 0;
                }
                return x / y;
            };
            Console.WriteLine("Введите два числа:");
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            Console.WriteLine($"Сумма: {sum(x, y)}");
            Console.WriteLine($"Разность: {difference(x, y)}");
            Console.WriteLine($"Произведение: {multiply(x, y)}");

            int result = divide(x, y);
            if (y != 0)
            {
                Console.WriteLine($"Деление: {result}");
            }
        }
    }
}