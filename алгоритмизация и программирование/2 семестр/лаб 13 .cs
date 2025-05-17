/*********************
Лаб 13 - 30.04.25
*********************/
using System;
using System.Linq;
namespace Phone_list
{
    class Phone
    {
        public uint phone_number { get; set; }
        public string owner { get; set; }
        public uint year { get; set; }
        public string provider { get; set; }
        public Phone(uint phone_number, string owner, uint year, string provider)
        {
            this.phone_number = phone_number;
            this.owner = owner;
            this.year = year;
            this.provider = provider;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Phone phone_1 = new Phone(8888, "Иван Иванов", 2000, "теле2");
            Phone phone_2 = new Phone(9999, "Сергей Сидоров", 2010, "теле2");
            Phone phone_3 = new Phone(7777, "Дмитрий Петров", 2010, "мтс");
            Phone[] database = new Phone[] { phone_1, phone_2, phone_3 };
            int option = 0;
            while (true)
            {
                Console.WriteLine("\nМЕНЮ:");
                Console.WriteLine("1. Все данные, сгруппированные по оператору связи");
                Console.WriteLine("2. Все данные, сгруппированные по году постановки");
                Console.WriteLine("3. Поиск по ФИО");
                Console.WriteLine("4. Поиск по номеру телефона");
                Console.WriteLine("5. Выход");
                Console.Write("Выберите опцию: ");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        var data_by_prov = from phone in database
                                           group phone by phone.provider;
                        foreach (var group in data_by_prov)
                        {
                            Console.WriteLine($"\nОператор: {group.Key}");
                            foreach (var phone in group)
                                Console.WriteLine($"{phone.phone_number}, {phone.owner}, {phone.year}");
                        }
                        break;
                    case 2:
                        var data_by_year = from phone in database
                                           group phone by phone.year;

                        foreach (var group in data_by_year)
                        {
                            Console.WriteLine($"\nГод: {group.Key}");
                            foreach (var phone in group)
                                Console.WriteLine($"{phone.phone_number}, {phone.owner}, {phone.provider}");
                        }
                        break;
                    case 3:
                        Console.Write("\nВведите ФИО владельца: ");
                        string name = Console.ReadLine();

                        var phones_by_owner = from phone in database
                                              where phone.owner.Equals(name, StringComparison.OrdinalIgnoreCase)
                                              select phone;

                        foreach (var phone in phones_by_owner)
                            Console.WriteLine($"{phone.phone_number}, {phone.owner}, {phone.year}, {phone.provider}");
                        break;
                    case 4:
                        Console.Write("\nВведите номер телефона: ");
                        uint number = Convert.ToUInt32(Console.ReadLine());

                        var phones_by_number = from phone in database
                                               where phone.phone_number == number
                                               select phone;
                        foreach (var phone in phones_by_number)
                            Console.WriteLine($"{phone.phone_number}, {phone.owner}, {phone.year}, {phone.provider}");
                        break;
                    case 5:
                        Console.WriteLine("Выход");
                        return;
                    default:
                        Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                        break;
                }
            }
        }
    }
}
