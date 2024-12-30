/******************************************************************************
Лаб 11 (09.12.24) Создать массив из заданного количества объектов класса студент.
Класс студент: ФИО (можно одно поле, можно разбить на три поля), год рождения, курс.
*******************************************************************************/
using System;
using System.Linq;
class Student
{
    string name;
    int year;
    int course;
    public string Name { get { return name; } set { name = value; } }
    public int Year { get { return year; } set { year = value; } }
    public int Course { get { return course; } set { course = value; } }
}
class HelloWorld
{
    static void Main()
    {
        Console.WriteLine("Введите число студентов: ");
        int n = Convert.ToInt32(Console.ReadLine());
        Student[] studs = new Student[n];
        for (int i = 0; i < n; i++)
        {
            studs[i] = new Student();
            Console.WriteLine("Введите ФИО");
            studs[i].Name = Console.ReadLine();

            Console.WriteLine("Введите год рождения");
            studs[i].Year = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите курс");
            studs[i].Course = Convert.ToInt32(Console.ReadLine());
        }
        if (studs.Length == 0)
        {
            Console.WriteLine("Данные не получены!");
        }
        else {
            Console.WriteLine("Данные получены!");
        }
        Console.WriteLine("Выберите дейcтвие:");
        Console.WriteLine("1: Модификация\t2: Запрос по году рождения\t3: Запрос по курсу\t4:Выход");
        Console.Write("Действие: ");
        int action = Convert.ToInt32(Console.ReadLine());
        while (action != 4) {
            if (action == 1)
            {
                if (studs.Length != 0)
                {
                    Console.Write("Введите ФИО: ");
                    string name = Console.ReadLine();
                    for (int i = 0; i < studs.Length; i++)
                    {
                        if (studs[i].Name == name)
                        {
                            Console.WriteLine("Выберите параметр, который хотите изменить: ");
                            Console.WriteLine("1: Год рождения\t2: Курс\t3: Год рождения и курс");
                            string param = Console.ReadLine();
                            Console.Write("Введите новое значение: ");
                            string value = Console.ReadLine();
                            if (param == "1")
                            {
                                studs[i].Year = Convert.ToInt32(value);
                            }
                            else if (param == "2")
                            {
                                studs[i].Course = Convert.ToInt32(value);
                            }
                            else if (param == "3")
                            {
                                studs[i].Year = Convert.ToInt32(value.Split(' ')[0]);
                                studs[i].Course = Convert.ToInt32(value.Split(' ')[1]);
                            }
                            Console.WriteLine("Данные обновлены");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Данные не получены!");
                }
            }
            else if (action == 2)
            {
                if (studs.Length != 0)
                {
                    Console.Write("Введите год рождения: ");
                    int year = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < studs.Length; i++)
                    {
                        if (studs[i].Year == year) 
                        {
                            Console.WriteLine($"{studs[i].Name} {studs[i].Year} {studs[i].Course}");
                        }
                    }
                } else
                {
                    Console.WriteLine("Данные не получены!");
                }
            }
            else if (action == 3)
            {
                if (studs.Length != 0)
                {
                    Console.Write("Введите курс: ");
                    int course = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < studs.Length; i++)
                    {
                        if (studs[i].Course == course)
                        {
                            Console.WriteLine($"{studs[i].Name} {studs[i].Year} {studs[i].Course}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Данные не получены!");
                }
            }
            Console.Write("Действие: ");
            action = Convert.ToInt32(Console.ReadLine());
        }
    }
}