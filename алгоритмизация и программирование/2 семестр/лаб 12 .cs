/***************************
Лаб 12 - 25.04.25 - файл
***************************/
using System;
using System.IO;
namespace File
{
    class Program
    {
        static bool HasEvenNumber(string line)
        {
            string number = "";
            for (int i = 0; i < line.Length; i++)
            {
                if (char.IsDigit(line[i]))
                {
                    number += line[i];
                }
                else
                {
                    if (IsEvenNumber(number)) return true;
                    number = "";
                }
            }
            return IsEvenNumber(number);
        }
        static bool IsEvenNumber(string number)
        {
            if (string.IsNullOrEmpty(number)) return false;
            int lastDigit = number[number.Length - 1] - '0';
            return lastDigit % 2 == 0;
        }
        static void Main()
        {
            string inputPath = "input.txt";
            string outputPath = "output.txt";

            using StreamReader reader = new StreamReader(inputPath);
            using StreamWriter writer = new StreamWriter(outputPath);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (HasEvenNumber(line))
                    writer.WriteLine(line);
            }
        }
    }
}
