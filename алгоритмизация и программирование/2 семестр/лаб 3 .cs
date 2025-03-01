/****************************************
лаб 3 - (21.02.25) скобки 
****************************************/
using System;
using System.Collections;

namespace BracketChecker
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите математическое выражение:");
            string expression = Console.ReadLine();
            Stack bracketsStack = new Stack();
            bool test = true;
            foreach (char symbol in expression)
            {
                if (symbol == '(' || symbol == '[' || symbol == '{')
                    bracketsStack.Push(symbol);
                if (symbol == ')' || symbol == ']' || symbol == '}')
                {
                    try
                    {
                        bracketsStack.Peek();
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("Выражение введено неверно");
                        test = false;
                        break;
                    }
                    char openingBracket = (char)bracketsStack.Pop();
                    switch (openingBracket)
                    {
                        case '(':
                            if (symbol == ')')
                                continue;
                            else test = false;
                            break;
                        case '[':
                            if (symbol == ']')
                                continue;
                            else test = false;
                            break;
                        case '{':
                            if (symbol == '}')
                                continue;
                            else test = false;
                            break;
                    }
                    if (!test)
                    {
                        Console.WriteLine("Выражение введено неверно");
                        break;
                    }
                }
            }
            if (test)
            {
                try
                {
                    bracketsStack.Pop();
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Выражение введено верно, Скобки расставлены верно");
                }
                finally
                {
                    if (!test)
                        Console.WriteLine("Выражение введено неверно");
                }
            }
        }
    }
}
