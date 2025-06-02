/****************************************
Лаб 14 - 02.05.25 - база данных магазин
****************************************/
using System;
using System.Collections.Generic;
using System.Linq;
class Product
{
    public int Article { get; set; }
    public string Name { get; set; }
    public Product(int article, string name)
    {
        Article = article;
        Name = name;
    }
}
class Supplier
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string City { get; set; }
    public Supplier(int id, string name, string phone, string city)
    {
        ID = id;
        Name = name;
        Phone = phone;
        City = city;
    }
}
class Movement
{
    public int ProductArticle { get; set; }
    public int SupplierID { get; set; }
    public string Date { get; set; }
    public bool IsIncoming { get; set; }
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }
    public Movement(string[] input)
    {
        ProductArticle = int.Parse(input[0]);
        SupplierID = int.Parse(input[1]);
        Date = input[2];
        IsIncoming = bool.Parse(input[3]);
        Quantity = int.Parse(input[4]);
        UnitPrice = double.Parse(input[5]);
    }
}
class Store
{
    static void ShowStock(List<Movement> movements, List<Product> products)
    {
        Console.WriteLine("Количество остатков товара в магазине:");
        foreach (var product in products)
        {
            int incoming = movements
                .Where(x => x.ProductArticle == product.Article && x.IsIncoming)
                .Sum(x => x.Quantity);
            int outgoing = movements
                .Where(x => x.ProductArticle == product.Article && !x.IsIncoming)
                .Sum(x => x.Quantity);
            int stockQuantity = incoming - outgoing;
            Console.WriteLine($"Товар: {product.Name} (Артикул: {product.Article}) - Остаток: {stockQuantity}");
        }
    }
    static void GroupByDate(List<Movement> movements, List<Product> products)
    {
        Console.WriteLine("Поставки товара, сгруппированные по дате:");
        var grouped = movements
            .Where(x => x.IsIncoming)
            .GroupBy(x => x.Date)
            .OrderBy(g => g.Key);

        foreach (var group in grouped)
        {
            Console.WriteLine($"Дата: {group.Key}");
            foreach (var movement in group)
            {
                var product = products.FirstOrDefault(p => p.Article == movement.ProductArticle);
                Console.WriteLine($"  Товар: {product?.Name} (Артикул: {movement.ProductArticle}), " +
                                 $"Количество: {movement.Quantity}, Цена за единицу: {movement.UnitPrice}");
            }
        }
    }
    static void GroupBySupplier(List<Movement> movements, List<Supplier> suppliers, List<Product> products)
    {
        Console.WriteLine("Поставки товара, сгруппированные по поставщику:");
        var grouped = movements
            .Where(x => x.IsIncoming)
            .GroupBy(x => x.SupplierID)
            .OrderBy(g => g.Key);
        foreach (var group in grouped)
        {
            var supplier = suppliers.FirstOrDefault(s => s.ID == group.Key);
            Console.WriteLine($"Поставщик: {supplier?.Name} (ID: {group.Key}, Город: {supplier?.City})");
            foreach (var movement in group)
            {
                var product = products.FirstOrDefault(p => p.Article == movement.ProductArticle);
                Console.WriteLine($"  Товар: {product?.Name} (Артикул: {movement.ProductArticle}), " +
                                 $"Дата: {movement.Date}, Количество: {movement.Quantity}");
            }
        }
    }
    static void GroupByProduct(List<Movement> movements, List<Product> products, List<Supplier> suppliers)
    {
        Console.WriteLine("Движение товара, сгруппированное по артикулу:");
        var grouped = movements
            .GroupBy(x => x.ProductArticle)
            .OrderBy(g => g.Key);
        foreach (var group in grouped)
        {
            var product = products.FirstOrDefault(p => p.Article == group.Key);
            Console.WriteLine($"Товар: {product?.Name} (Артикул: {group.Key})");

            foreach (var movement in group)
            {
                var type = movement.IsIncoming ? "Поступление" : "Продажа";
                var supplierInfo = movement.IsIncoming ?
                    $"от {suppliers.FirstOrDefault(s => s.ID == movement.SupplierID)?.Name}" : "";
                Console.WriteLine($"  {type} {supplierInfo}, " +
                                 $"Дата: {movement.Date}, " +
                                 $"Количество: {movement.Quantity}, " +
                                 $"Цена за единицу: {movement.UnitPrice}");
            }
        }
    }
    static void Continue()
    {
        Console.WriteLine("Нажмите любую клавишу для продолжения...");
        Console.ReadKey();
        Console.Clear();
    }
    static void Main()
    {
        List<Product> products = new List<Product>();
        List<Supplier> suppliers = new List<Supplier>();
        List<Movement> movements = new List<Movement>();
        Console.WriteLine("Введите товары (артикул и наименование через пробел, 0 для завершения):");
        string input;
        do
        {
            input = Console.ReadLine().Trim();
            if (input != "0")
            {
                string[] ar = input.Split();
                Product curProduct = new Product(int.Parse(ar[0]), ar[1]);
                products.Add(curProduct);
            }
        } while (input != "0");
        Console.WriteLine("Введите поставщиков (ID, наименование, телефон, город через пробел, 0 для завершения):");
        do
        {
            input = Console.ReadLine().Trim();
            if (input != "0")
            {
                string[] ar = input.Split(new[] { ' ' }, 4);
                Supplier curSupplier = new Supplier(int.Parse(ar[0]), ar[1], ar[2], ar[3]);
                suppliers.Add(curSupplier);
            }
        } while (input != "0");
        Console.WriteLine("Введите движение товаров (артикул, ID поставщика, дата, true/false (поступление/продажа), количество, цена через пробел, 0 для завершения):");
        do
        {
            input = Console.ReadLine().Trim();
            if (input != "0")
            {
                string[] ar = input.Split();
                Movement curMovement = new Movement(ar);
                movements.Add(curMovement);
            }
        } while (input != "0");
        do
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Количество остатков товара в магазине");
            Console.WriteLine("2. Поставки товара по дате");
            Console.WriteLine("3. Поставки товара по поставщику");
            Console.WriteLine("4. Движение товара по артикулу");
            Console.WriteLine("5. Выход");
            Console.Write("Выберите опцию: ");
            input = Console.ReadLine();
            Console.Clear();
            switch (input)
            {
                case "1":
                    ShowStock(movements, products);
                    break;
                case "2":
                    GroupByDate(movements, products);
                    break;
                case "3":
                    GroupBySupplier(movements, suppliers, products);
                    break;
                case "4":
                    GroupByProduct(movements, products, suppliers);
                    break;
                case "5":
                    Console.WriteLine("Выход из программы.");
                    return;
                default:
                    Console.WriteLine("Неверная опция, попробуйте снова.");
                    break;
            }
            Continue();
        } while (true);
    }
}