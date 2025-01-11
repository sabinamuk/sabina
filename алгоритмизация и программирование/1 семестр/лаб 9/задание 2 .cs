/******************************************************************************
Лаб 9 (25.11.24) задание 2
*******************************************************************************/
using System;
class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        int currentLength = 0;
        int maxLength = 0;
        char[] view = { 'a', 'b', 'c' };
        int view_Index = 0;
        foreach (char c in input)
        {
            if (c == view[view_Index])
            {
                currentLength++;
                view_Index++;
                if (view_Index == view.Length)
                {
                    view_Index = 0;
                }
            }
            else if (c == 'a')
            {
                currentLength++;
                view_Index = 1;
            }
            else
            {
                currentLength = 0;
                view_Index = 0;
            }
            maxLength = Math.Max(maxLength, currentLength);
        }
        Console.WriteLine(maxLength);
    }
}