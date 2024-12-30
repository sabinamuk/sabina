/******************************************************************************
Лаб 12(23.12.24)Есть класс люди с полями:
-ФИО(можно разбивать, можно нет)
-год рождения
Два наследника этого класса:
1) Класс студенты с полями:
-массив оценок (одномерный массив)
2) Класс преподаватели
-массив наименований предметов, которые они ведут.
*******************************************************************************/
using System;
using System.Diagnostics;
using System.Linq;
class People
{
    public string name;
    public string year;

    public People(string name, string year)
    {
        this.name = name;
        this.year = year;
    }
}
class Student: People
{
    public char[] marks;
    public Student(string name, string year, char[] marks):base(name, year)
    {
        this.marks = marks;
    }
}
class Teacher: People
{
    public string[] subjects;
    public Teacher(string name, string year, string[] subjects): base(name, year)
    {
        this.subjects = subjects;
    }
}
class HelloWorld
{
    static void Main()
    {
        Console.Write("Введите число студентов: ");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите число преподавателей: ");
        int m = Convert.ToInt32(Console.ReadLine());

        Student[] students = new Student[n];
        Teacher[] teachers = new Teacher[m];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Введите данные о студенте {i + 1}");
            string[] data = Console.ReadLine().Split(' ');
            students[i] = new Student(data[0], data[1], data[2].ToCharArray());
        }
        for (int i = 0; i < m; i++)
        {
            Console.WriteLine($"Введите данные о преподавателе {i + 1}");
            string[] data = Console.ReadLine().Split(' ');
            teachers[i] = new Teacher(data[0], data[1], data[2].Split(','));
        }
        int action;
        do
        {
            Console.WriteLine("Выберите действие:\n1 – Заполнение | 2 – Вывод данных | 3 – Выборка студентов | 4 – Выборка преподавателей | 5 – Выход ");
            action = Convert.ToInt32(Console.ReadLine());
            switch (action)
            {
                case 1:
                    Console.WriteLine("Данные уже получены");
                    break;
                case 2:
                    Console.WriteLine("---Студенты---");
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write($"{students[i].name} {students[i].year} ");
                        for (int a = 0; a < students[i].marks.Length; a++)
                        {
                            Console.Write(students[i].marks[a]);
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("---Преподаватели---");
                    for (int j = 0; j < m; j++)
                    {
                        Console.Write($"{teachers[j].name} {teachers[j].year} ");
                        for (int a = 0; a < teachers[j].subjects.Length; a++)
                        {
                            Console.Write($"{teachers[j].subjects[a]} ");
                        }
                        Console.WriteLine();
                    }
                    break;
                case 3:
                    Console.Write("Введите год: ");
                    string year = Console.ReadLine();
                    for (int i = 0; i < n; i++)
                    {
                        if (students[i].year == year)
                        {
                            Console.Write($"{students[i].name} {students[i].year} ");
                            for (int a = 0; a < students[i].marks.Length; a++)
                            {
                                Console.Write(students[i].marks[a]);
                            }
                            Console.WriteLine();
                        }
                    }
                    break;
                case 4:
                    Console.Write("Введите дисциплину: ");
                    string subject = Console.ReadLine();
                    for (int j = 0; j < m; j++)
                    {
                        if (teachers[j].subjects.Contains(subject))
                        {
                            Console.Write($"{teachers[j].name} {teachers[j].year} ");
                            for (int a = 0; a < teachers[j].subjects.Length; a++)
                            {
                                Console.Write($"{teachers[j].subjects[a]} ");
                            }
                            Console.WriteLine();
                        }
                    }
                    break;
            }
        } while (action != 5);
    }
}