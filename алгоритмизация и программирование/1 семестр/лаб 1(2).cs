/******************************************************************************
13.09.24- на вход подается две переменные,
нужно выдать минимальное из двух переменных
*******************************************************************************/
using System;
class HelloWorld {
  static void Main() {
      int a,b,k,m;
      a = Convert.ToInt32(Console.ReadLine());
      b = Convert.ToInt32(Console.ReadLine());
      k = Math.Abs(a - b);
      m = (a + b - k) / 2;
     
     Console.WriteLine(m);
  }
}