/****************************************
лаб 1 - (07.02.25) телефонный справочник 
****************************************/
using System;
class PhoneNumberBook
{
    public string Number { get; set; }
    public string NameOperator { get; set; }
    public string Year { get; set; }
    public PhoneNumberBook(string number, string nameoperator, string year)
    {
        Number = number;
        NameOperator = nameoperator;
        Year = year;
    }
}
class Contact
{
    public string Name { get; set; }
    public string City { get; set; }
    public PhoneNumberBook[] Numbers { get; set; }
    public Contact(string name, string city, PhoneNumberBook[] numbers)
    {
        Name = name;
        City = city;
        Numbers = numbers;
    }
}
class Program
{
    static void Main()
    {
        Console.Write("Введите количество контактов: ");
        int n = Convert.ToInt32(Console.ReadLine());
        Contact[] contacts = new Contact[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Введите данные контакта {i + 1} (ФИО город номер1 оператор1 год1 номер2 оператор2 год2...):");
            string[] data = Console.ReadLine().Split(' ');

            if (data.Length < 4)
            {
                Console.WriteLine("Недостаточно данных.");
                i--;
                continue;
            }

            string name = data[0];
            string city = data[1];

            PhoneNumberBook[] numbers = new PhoneNumberBook[(data.Length - 2) / 3];
            for (int j = 0, k = 2; j < numbers.Length; j++, k += 3)
            {
                numbers[j] = new PhoneNumberBook(data[k], data[k + 1], data[k + 2]);
            }

            contacts[i] = new Contact(name, city, numbers);
        }
        int action;
        do
        {
            Console.WriteLine("Выберите действие:\n1 – Заполнение | 2 – Вывод данных | 3 – Выборка по оператору | 4 – Выборка по имени | 5 – Выборка по номеру | 6 – Выход");
            action = Convert.ToInt32(Console.ReadLine());
            switch (action)
            {
                case 1:
                    Console.WriteLine("Данные получены");
                    break;
                case 2:
                    Console.WriteLine("---Контакты---");
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write($"{contacts[i].Name} {contacts[i].City} ");
                        for (int j = 0; j < contacts[i].Numbers.Length; j++)
                        {
                            Console.Write($"{contacts[i].Numbers[j].Number} ({contacts[i].Numbers[j].NameOperator}, {contacts[i].Numbers[j].Year}) ");
                        }
                        Console.WriteLine();
                    }
                    break;
                case 3:
                    Console.Write("Введите оператора: ");
                    string nameoperator = Console.ReadLine();
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < contacts[i].Numbers.Length; j++)
                        {
                            if (contacts[i].Numbers[j].NameOperator.Equals(nameoperator, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.Write($"{contacts[i].Name} {contacts[i].City} {contacts[i].Numbers[j].Number} ({contacts[i].Numbers[j].NameOperator}, {contacts[i].Numbers[j].Year})\n");
                            }
                        }
                    }
                    break;
                case 4:
                    Console.Write("Введите ФИО контакта: ");
                    string name = Console.ReadLine();
                    for (int i = 0; i < n; i++)
                    {
                        if (contacts[i].Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.Write($"{contacts[i].Name} {contacts[i].City} ");
                            for (int j = 0; j < contacts[i].Numbers.Length; j++)
                            {
                                Console.Write($"{contacts[i].Numbers[j].Number} ({contacts[i].Numbers[j].NameOperator}, {contacts[i].Numbers[j].Year}) ");
                            }
                            Console.WriteLine();
                        }
                    }
                    break;
                case 5:
                    Console.Write("Введите номер телефона: ");
                    string phoneNumber = Console.ReadLine();
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < contacts[i].Numbers.Length; j++)
                        {
                            if (contacts[i].Numbers[j].Number.Equals(phoneNumber))
                            {
                                Console.Write($"{contacts[i].Name} {contacts[i].City} {contacts[i].Numbers[j].Number} ({contacts[i].Numbers[j].NameOperator}, {contacts[i].Numbers[j].Year})\n");
                            }
                        }
                    }
                    break;
            }
        } while (action != 6);
    }
}
