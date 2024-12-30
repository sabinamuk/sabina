/******************************************************************************
Лаб 10 (06.12.24)
*******************************************************************************/
using System;
using System.Linq;
class Calculator
{
    int a;
    int b;
    public Calculator() {
        a = 0;
        b = 0;
    }
    public Calculator(int a) { 
        this.a = a;
        b = 0;
    }
    public Calculator(int a, int b)
    {
        this.a = a;
        this.b = b;
    }
    public void Sum()
    {
        Console.WriteLine(a + b);
    }
    public void Subtract(int a, int b)
    {
        Console.WriteLine(a - b);
    }
    public void Subtract()
    {
        Console.WriteLine(a - b);
    }
    public void Mult()
    {
        Console.WriteLine(a * b);
    }
    public void Divide()
    { 
        Console.WriteLine(b != 0 ? ((double)a / (double)b) : "Деление на ноль");
    }
}
class HelloWorld
{
    static void Main()
    {
        Calculator calc1 = new Calculator(9, 6);
        calc1.Sum();
        calc1.Subtract();
        calc1.Subtract(6, 9);
        calc1.Mult();
        calc1.Divide();

        Console.WriteLine();

        Calculator calc2 = new Calculator(9);
        calc2.Sum();
        calc2.Subtract();
        calc2.Subtract(0, 9);
        calc2.Mult();
        calc2.Divide();

        Console.WriteLine();

        Calculator calc3 = new Calculator();
        calc3.Sum();
        calc3.Subtract();
        //calc3.Subtract();
        calc3.Mult();
        calc3.Divide();
    }
}
