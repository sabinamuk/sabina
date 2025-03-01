/****************************************
лаб 4 - (28.02.25) -задача 1 - польская
****************************************/
using System;
using System.Collections.Generic;

namespace PolishPostfix
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите выражение в постфиксной записи:");
            string date = Console.ReadLine();
            if (date == "" || date == null)
            {
                Console.WriteLine("Ошибка: Пустое выражение.");
                return;
            }
            string[] symbols = date.Split(' ');
            Stack<int> st = new Stack<int>();
            HashSet<string> oper = new HashSet<string> { "+", "-", "*", "/" };
            foreach (string symbol in symbols)
            {
                if (symbol == "") 
                {
                    continue;
                }
                bool isnumber = int.TryParse(symbol, out int number);
                if (isnumber)
                {
                    st.Push(number);
                }
                else if (oper.Contains(symbol))
                {
                    if (st.Count < 2)
                    {
                        Console.WriteLine("Ошибка: Неверная запись.");
                        return;
                    }
                    int b = st.Pop();
                    int a = st.Pop();
                    int result = 0;
                    switch (symbol)
                    {
                        case "+":
                            result = a + b;
                            break;
                        case "-":
                            result = a - b;
                            break;
                        case "*":
                            result = a * b;
                            break;
                        case "/":
                            if (b == 0)
                            {
                                Console.WriteLine("Ошибка: Деление на ноль.");
                                return;
                            }
                            result = a / b;
                            break;
                    }
                    st.Push(result);
                }
                else
                {
                    Console.WriteLine($"Ошибка: Неизвестный операнд '{symbol}'.");
                    return;
                }
            }
            if (st.Count == 1)
            {
                Console.WriteLine("Ответ: " + st.Pop());
            }
            else
            {
                Console.WriteLine("Ошибка: Неверная запись, лишние операнды.");
            }
        }
    }
}
