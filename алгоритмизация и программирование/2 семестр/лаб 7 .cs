/***************************
Лаб 7 - 21.03.25 - гараж
***************************/
using System;
using System.Collections.Generic;
namespace Garage
{
    delegate void CarCleaningHandler(Car vehicle);
    class Car
    {
        public int Year { get; set; }
        public string Brand { get; set; }
        public bool IsClean { get; set; }
        public Car()
        {
            Console.WriteLine("Введите год выпуска и марку автомобиля:");
            Year = int.Parse(Console.ReadLine());
            Brand = Console.ReadLine();

            Console.WriteLine("Если автомобиль чистый, введите 'да':");
            string input = Console.ReadLine();
            IsClean = (input == "да");
        }
    }
    class Garage
    {
        public List<Car> Vehicles { get; set; }
        public Garage()
        {
            Vehicles = new List<Car>();
        }
        public void Park(Car car)
        {
            Vehicles.Add(car);
        }
    }
    class CarWash
    {
        public static void PerformWash(Car car)
        {
            if (car.IsClean)
            {
                Console.WriteLine("Автомобиль уже чистый.");
            }
            else
            {
                car.IsClean = true;
                Console.WriteLine("Автомобиль был вымыт.");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Garage userGarage = new Garage();
            CarCleaningHandler washing = CarWash.PerformWash;

            Console.WriteLine("Сколько автомобилей вы хотите добавить?");
            int carCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carCount; i++)
            {
                Car newVehicle = new Car();
                userGarage.Park(newVehicle);
            }
            foreach (Car vehicle in userGarage.Vehicles)
            {
                if (!vehicle.IsClean)
                {
                    washing(vehicle);
                }
            }
        }
    }
}
