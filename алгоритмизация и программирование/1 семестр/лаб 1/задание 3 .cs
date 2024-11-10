/******************************************************************************
13.09.24- грядки (l=3 m=3 k=5)
*******************************************************************************/
using System;
class HelloWorld {
  static void Main() {
      int k,l,m,N,S; 
        l=Convert.ToInt32(Console.ReadLine()); 
        m=Convert.ToInt32(Console.ReadLine()); 
        k=Convert.ToInt32(Console.ReadLine()); 
        N=Convert.ToInt32(Console.ReadLine()); 
       
        S=((2*k + 2*l + 2*m + 2*k + 2*l*N + 2*m)*N) / 2; 
       
        Console.WriteLine(S); 
  }
}