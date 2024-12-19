/******************************************************************************
практика - 5 (28.10.24) Крестьянин и черт
*******************************************************************************/
using System; 
class Program 
{ 
    static void Main() 
    { 
        long MaxN = long.Parse(Console.ReadLine()); 
        long count = 0; 
        for (int M = 1;; M++) 
        { 
            long tinM = (1L << M); 
            long tinM_1 = tinM - 1;
            if (tinM_1 > MaxN)  
                break; 
            for (long N = tinM_1; N <= MaxN; N += tinM_1) 
            { 
                long K = (tinM * N) / tinM_1; 
                if (K > 0) 
                    count++; 
            } 
        } 
        Console.WriteLine(count); 
    } 
}