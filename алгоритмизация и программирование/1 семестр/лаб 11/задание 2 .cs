/******************************************************************************
Лаб 11 (09.12.24) Описать класс с именем «Поезд»
*******************************************************************************/
using System;
using System.Linq;

class Train
{
    string target;
    string num;
    string time;
    public string Target
    {
        get => target;
        set { target = value; }
    }
    public string Num
    {
        get => num;
        set { num = value; }
    }
    public string Time
    {
        get => time;
        set { time = value; }
    }
    public Train()
    {
    }
    public Train(string target, string num, string time)
    {
        Target = target;
        Num = num;
        Time = time;
    }
}
class Station: Train
{
    string name;
    public string Name
    {
        get => name;
        set { name = value; }
    }
    public Train[] trains = new Train[3];

    public Station(string name)
    {
        Name = name;
    }
}
class HelloWorld
{
    static void Main()
    {
        Console.WriteLine("Выберите действие: 1: Добавить поезда\t2: Вывести поезда, отравляющиеся после...\t3: Выход");
        string action = Console.ReadLine();
        bool f = false;
        Station st = new Station("State");
        while (action != "3")
        {
            if (action == "1")
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine($"Введите данные о {i + 1}-м поезде:");
                    string target = Console.ReadLine();
                    string num = Console.ReadLine();
                    string time = Console.ReadLine();
                    Train t = new Train { Target = target, Num = num, Time = time };
                    st.trains[i] = t;
                }
                f = true;
            }
            else if (action == "2" && f)
            {
                Console.Write("Введите время: ");
                string time = Console.ReadLine();
                for (int i = 0; i < 3; i++)
                {
                    if (Convert.ToInt32(st.trains[i].Time.Split(':')[0]) > Convert.ToInt32(time.Split(':')[0]) || (Convert.ToInt32(st.trains[i].Time.Split(':')[0]) == Convert.ToInt32(time.Split(':')[0]) && Convert.ToInt32(st.trains[i].Time.Split(':')[1]) > Convert.ToInt32(time.Split(':')[1])))
                    {
                        Console.WriteLine(st.trains[i].Time);
                    }
                }

            } else if (!f)
            {
                Console.WriteLine("Данные не получены!");
            }
            Console.WriteLine("Выберите действие: 1: Добавить поезда\t2: Вывести поезда, отравляющиеся после...\t3: Выход");
            action = Console.ReadLine();
        }
    }
}