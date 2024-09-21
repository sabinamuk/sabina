/******************************************************************************
13.09.24- на вход будет подаваться две переменные a и b,
необходимо поменять местами содержимое этих переменных
*******************************************************************************/
using System;
class HelloWorld {
  static void Main() {
      int a = Convert.ToInt32(Console.ReadLine());
      int b = Convert.ToInt32(Console.ReadLine());
      
      b = a + b;
      a = b - a;
      b = b - a;
     
      Console.WriteLine(a);
      Console.WriteLine(b);
  }
}