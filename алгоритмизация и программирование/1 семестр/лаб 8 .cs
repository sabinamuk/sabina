/******************************************************************************
Лаб 8 ( 11.11.24 ) На вход подаётся строка, состоящая из слов между которыми 
от одного до нескольких пробелов. Для заданной строки выполнить задачи:
1. Удалить все лишние пробелы, оставив по одному.
2. Выдать все слова перевертыши-палиндромы.
3. Подсчитать количество слов у которых первые и последние символы совпадают
*******************************************************************************/
using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Введите строку:");
        string s = Console.ReadLine();

        string sclean = s.Trim();
        bool pr = false;
        string result = "";
        for (int i = 0; i < sclean.Length; i++)
        {
            char str = sclean[i];
            if (str != ' ')
            {
                result += str;
                pr = false;
            }
            else if (!pr)
            {
                result += ' ';
                pr = true;
            }
        }
        Console.WriteLine("Строка без лишних пробелов:");
        Console.WriteLine(result);
        string[] words = result.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        Console.WriteLine("Слова-палиндромы:");
        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];
            bool Palindr = true;
            int left = 0, right = word.Length - 1;
            while (left < right)
            {
                if (char.ToLower(word[left]) != char.ToLower(word[right]))
                {
                    Palindr = false;
                    break;
                }
                left++;
                right--;
            }
            if (Palindr)
            {
                Console.WriteLine(word);
            }
        }
        int count = 0;
        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];
            if (char.ToLower(word[0]) == char.ToLower(word[word.Length - 1]))
            {
                count++;
            }
        }
        Console.WriteLine($"Количество слов, у которых первый и последний символы совпадают: {count}");
    }
}