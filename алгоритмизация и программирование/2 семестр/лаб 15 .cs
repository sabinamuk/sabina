/****************************************
Лаб 15 - 16.05.25
****************************************/
using System;
using System.Linq;
using System.Collections.Generic;
class User {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Date { get; set; }
    public bool HasComputer { get; set; }
    public Computer? Computer { get; set; }
    public User(int id, string name, string date, bool hasComputer, Computer? computer = null)
    {
        Id = id;
        Name = name;
        Date = date;
        HasComputer = hasComputer;
        Computer = computer;
    }
}
class Computer
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Year { get; set; }
    public string OS { get; set; }
    public Computer(int id, string brand, string model, string year, string os)
    {
        Id = id;
        Brand = brand;
        Model = model;
        Year = year;
        OS = os;
    }
}
class Program
{
    static void Continue()
    {
        Console.WriteLine("Нажмите любую кнопку для продолжения");
        Console.ReadKey();
        Console.Clear();
    }
    static List<User> ComputerFilter(List<User> users, bool hasComputer)
    {
        List<User> filtered = users.Where(x => x.HasComputer == hasComputer).ToList();
        return filtered;
    }
    static void Main()
    {
        List<User> users = new List<User>();
        users.Add(new User(1, "A", "1", true, new Computer(1, "Asus", "Model1", "2020", "Windows")));
        users.Add(new User(2, "B", "1", false));
        users.Add(new User(3, "C", "1", true, new Computer(2, "Asus", "Model2", "2014", "Linux")));
        users.Add(new User(4, "D", "1", true, new Computer(3, "Apple", "Model1", "2023", "Windows")));
        users.Add(new User(5, "E", "1", false));
        users.Add(new User(6, "F", "1", true, new Computer(4, "Irbis", "Model1", "2026", "MacOS")));
        string? choice = "";
        do
        {
            Console.WriteLine("1. Пользователи без ноутбука (сортировка по алфавиту)");
            Console.WriteLine("2. Пользователи сгруппированные по ОС");
            Console.WriteLine("3. Пользователи сгруппированные по бренду ноутбука (сортировка по алфавиту)");
            Console.WriteLine("4. Сравнение количества пользователей");
            Console.WriteLine("0. Выход");
            choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Пользователи без ноутбука:");
                    foreach (var i in ComputerFilter(users, false).OrderBy(u => u.Name))
                        Console.WriteLine($"ID: {i.Id}, Имя: {i.Name}, Год рождения: {i.Date}");
                    Continue();
                    break;
                case "2":
                    Console.WriteLine("Пользователи сгруппированные по ОС:");
                    var groupedByOS = ComputerFilter(users, true)
                        .GroupBy(u => u.Computer.OS)
                        .OrderBy(g => g.Key);
                    foreach (var group in groupedByOS)
                    {
                        Console.WriteLine($"\nОС: {group.Key}");
                        foreach (var user in group)
                            Console.WriteLine($"ID: {user.Id}, Имя: {user.Name}, Бренд: {user.Computer.Brand}, Модель: {user.Computer.Model}");
                    }
                    Continue();
                    break;
                case "3":
                    Console.WriteLine("Пользователи сгруппированные по бренду ноутбука:");
                    var groupedByBrand = ComputerFilter(users, true)
                        .GroupBy(u => u.Computer.Brand)
                        .OrderBy(g => g.Key);

                    foreach (var group in groupedByBrand)
                    {
                        Console.WriteLine($"\nБренд: {group.Key}");
                        foreach (var user in group.OrderBy(u => u.Name))
                            Console.WriteLine($"ID: {user.Id}, Имя: {user.Name}, Модель: {user.Computer.Model}, ОС: {user.Computer.OS}");
                    }
                    Continue();
                    break;
                case "4":
                    int countNoComputers = ComputerFilter(users, false).Count();
                    int countComputers = ComputerFilter(users, true).Count();
                    Console.WriteLine($"Количество пользователей с ноутбуком: {countComputers}, Без ноутбука: {countNoComputers}");
                    Continue();
                    break;
            }
        } while (choice != "0");
    }
}