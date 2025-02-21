/****************************************
лаб 1 - (07.02.25) телефонный справочник 
****************************************/
using System;
using System.Linq;
class PhoneNumberBook
{
    public string name;
    public string city;
    public PhoneNumber[] numbers;
    public PhoneNumberBook(string name, string city, PhoneNumber[] numbers)
    {
        this.name = name;
        this.city = city;
        this.numbers = numbers;
    }
}
class PhoneNumber
{
    public string number;
    public string operat;
    public string year;
    public PhoneNumber(string number, string operat, string year)
    {
        this.number = number;
        this.operat = operat;
        this.year = year;
    }
}
class Program
{
    static void Main()
    {
        Console.Write("Введите число контактов: ");
        int n = Convert.ToInt32(Console.ReadLine());
        PhoneNumberBook[] contacts = new PhoneNumberBook[n];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Введите данные о контакте {i + 1} (ФИО(Ф_И_О) город номер1 оператор1 год1 номер2 оператор2 год2 ...):");
            string[] inform = Console.ReadLine().Split(' ');
            if (inform.Length < 4)
            {
                Console.WriteLine("Недостаточно данных для контакта.");
                i--;
                continue;
            }
            string name = inform[0];
            string city = inform[1];
            PhoneNumber[] numbers = new PhoneNumber[(inform.Length - 2) / 3];
            for (int j = 0, z = 2; j < numbers.Length; j++, z += 3)
            {
                numbers[j] = new PhoneNumber(inform[z], inform[z + 1], inform[z + 2]);
            }
            contacts[i] = new PhoneNumberBook(name, city, numbers);
        }
        int action;
        do
        {
            Console.WriteLine("Выберите действие:\n1 – Заполнение | 2 – Вывод данных | 3 – Выборка по оператору | 4 – Выборка по ФИО | 5 – Выборка по номеру | 6 – Выход ");
            action = Convert.ToInt32(Console.ReadLine());
            switch (action)
            {
                case 1:
                    Console.WriteLine("Данные получены");
                    break;
                case 2:
                    Console.WriteLine("Контакты:");
                    foreach (var contact in contacts)
                    {
                        Console.Write($"{contact.name} {contact.city} ");
                        foreach (var num in contact.numbers)
                        {
                            Console.Write($"{num.number} ({num.operat}, {num.year})  ");
                        }
                        Console.WriteLine();
                    }
                    break;
                case 3:
                    Console.Write("Введите оператора: ");
                    string operat = Console.ReadLine();
                    foreach (var contact in contacts)
                    {
                        foreach (var num in contact.numbers)
                        {
                            if (num.operat.Equals(operat, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine($"{contact.name} {contact.city} {num.number} ({num.operat}, {num.year})");
                            }
                        }
                    }
                    break;
                case 4:
                    Console.Write("Введите ФИО: ");
                    string name = Console.ReadLine();
                    foreach (var contact in contacts)
                    {
                        if (contact.name.Equals(name, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.Write($"{contact.name} {contact.city} ");
                            foreach (var num in contact.numbers)
                            {
                                Console.Write($"{num.number} ({num.operat}, {num.year})  ");
                            }
                            Console.WriteLine();
                        }
                    }
                    break;
                case 5:
                    Console.Write("Введите номер: ");
                    string phoneNumber = Console.ReadLine();
                    foreach (var contact in contacts)
                    {
                        foreach (var num in contact.numbers)
                        {
                            if (num.number == phoneNumber)
                            {
                                Console.WriteLine($"{contact.name} {contact.city} {num.number} ({num.operat}, {num.year})");
                            }
                        }
                    }
                    break;
            }
        } while (action != 6);
    }
}
