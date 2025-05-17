/*********************
Лаб 6 - 14.03.25 
*********************/
using System;
namespace Math
{
    delegate int Eval(int input);
    class Equation
    {
        public int a { get; set; }
        public int b { get; set; }
        public Equation(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public int Sum(int x1, int x2)
        {
            return x1 + x2;
        }
        public int Dif(int x1, int x2)
        {
            return x1 - x2;
        }
        public int Mult(int x1, int x2)
        {
            return x1 * x2;
        }
        public int Div(int x1, int x2)
        {
            if (x2 == 0)
            {
                Console.WriteLine("Деление на ноль невозможно");
                throw new DivideByZeroException();
            }
            return x1 / x2;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Equation eq1 = new Equation(10, 5);
            Eval eval1 = delegate (int _)
            {
                int result = eq1.Sum(eq1.a, eq1.b); 
                result = eq1.Dif(result, eq1.b);  
                result = eq1.Mult(result, eq1.b);  
                return result;
            };
            int result1 = eval1(0);
            Console.WriteLine("Результат для первого объекта: " + result1);
            Equation eq2 = new Equation(20, 4);
            Eval eval2 = delegate (int _)
            {
                int result = eq2.Div(eq2.a, eq2.b);
                result = eq2.Sum(result, eq2.b);   
                result = eq2.Mult(result, eq2.b); 
                return result;
            };
            int result2 = eval2(0);
            Console.WriteLine("Результат для второго объекта: " + result2);
        }
    }
}
