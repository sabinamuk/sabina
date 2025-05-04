/******************************************************************************
Лаб 5 - 07.03.25 - Необходимо определить частоту использования оператора связи. 
*******************************************************************************/
using System;
using System.Collections.Generic;
namespace PhoneOper
{
    class Phone
    {
        public string number { get; set; }
        public string owner { get; set; }
        public string mobile_oper { get; set; }
        public Phone(string number, string owner, string mobile_oper)
        {
            this.number = number;
            this.owner = owner;
            this.mobile_oper = mobile_oper;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Phone> phones = new List<Phone>();
            while (true)
            {
                Console.Write("Номер телефона: ");
                string number = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(number))
                    break;
                if (!IsDigitsOnly(number))
                {
                    Console.WriteLine("Номер должен содержать только цифры.");
                    continue;
                }
                Console.Write("ФИО владельца: ");
                string owner = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(owner))
                    break;
                Console.Write("Оператор связи: ");
                string mobile_oper = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(mobile_oper))
                    break;
                Phone phone = new Phone(number, owner, mobile_oper);
                phones.Add(phone);
                Console.WriteLine();
            }
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (Phone phone in phones)
            {
                if (dict.ContainsKey(phone.mobile_oper))
                    dict[phone.mobile_oper]++;
                else
                    dict[phone.mobile_oper] = 1;
            }
            Console.WriteLine("\nЧастота использования операторов связи:");
            foreach (var pair in dict)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }
        static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }
    }
}