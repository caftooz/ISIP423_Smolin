using Microsoft.EntityFrameworkCore;
using ConsoleApp.BD;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("АВТОСЕРВИС (игра)");
            Thread.Sleep(1000);
            Console.Clear();

            CarService ГордыеМашиныСервис = new CarService();
            ГордыеМашиныСервис.НачатьСмену();
        }
    }

    internal class CarService
    {
        private List<Part> _allParts = Core.Context.Parts.ToList();

        private Random random = new();
        private static decimal _money;
        private Dictionary<Part, int> _parts = new();

        public CarService(decimal startMoney = 30000, int startPartsCount = 5)
        {
            _money = 30000;

            // Добавляем случайные предметы на склад
            for (int i = 0; i < startPartsCount; i++)
            {
                int index = random.Next(0, _allParts.Count);
                Part randomPart = _allParts[index];

                if (_parts.ContainsKey(randomPart))
                {
                    _parts[randomPart] += 1;
                }
                else
                {
                    _parts.Add(randomPart, 1);
                }
            }
        }

        private void ВывестиВсеДеталиНаСкладе()
        {
            Console.WriteLine("-------------------------------------------------");
            string titleString = String.Format("|{0, 6}|{1, -40}|", "Кол-во", "Название");
            Console.WriteLine(titleString);
            Console.WriteLine("-------------------------------------------------");
            foreach (var part in _parts)
            {
                if (part.Value > 0)
                {
                    string partString = String.Format("|{0, 6}|{1, -40}|", part.Value, part.Key.Name);
                    Console.WriteLine(partString);
                }
            }
            Console.WriteLine("-------------------------------------------------");
        }
        private void ЗаказатьДеталь()
        {
            Console.Clear();
            Console.WriteLine($"\nБюджет автосервиса: {_money} руб.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n===ЗАКАЗ ДЕТАЛИ===\n");
            Console.ResetColor();
            Console.WriteLine("--------------------------------------------------------------");
            string titleString = String.Format("| {0, 2} | {1, -10} | {2, -40} |", "ID","Цена (руб.)", "Название");
            Console.WriteLine(titleString);
            Console.WriteLine("--------------------------------------------------------------");
            foreach (var part in _allParts)
            {
                
                string partString = String.Format("| {0, 2} | {1, -10} | {2, -40} |", part.PartId, part.Price, part.Name);
                Console.WriteLine(partString);
                
            }
            Console.WriteLine("--------------------------------------------------------------");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nВведите ID детали для заказа: \n");
            Console.ResetColor();
            int partId;
            while (true)
            {
                string idString = Console.ReadLine();
                if (int.TryParse(idString, out var id) && _allParts.Any(p => p.PartId == id))
                {
                    partId = id;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("НЕВЕРНЫЙ ВВОД!! попробуйте ещё раз: ");
                    Console.ResetColor();
                    continue;
                }
            }

            Part partFind = _allParts.FirstOrDefault(p => p.PartId == partId);
            int maxOrderCount = Convert.ToInt32(_money / partFind.Price);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nID детали принят!");
            Console.WriteLine($"Деталь \"{partFind.Name}\" - {partFind.Price} руб.\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nВведите кол-во деталей для заказа (доступно {maxOrderCount}): \n");
            Console.ResetColor();

            int partCount;
            while (true)
            {
                string countString = Console.ReadLine();
                if (int.TryParse(countString, out var count) && count <= maxOrderCount)
                {
                    partCount = count;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("НЕВЕРНЫЙ ВВОД!! попробуйте ещё раз: ");
                    Console.ResetColor();
                    continue;
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nЗАКАЗ УСПЕШНО СДЕЛАН\n");
            Console.ResetColor();

            _money -= partCount * partFind.Price;

            if (_parts.ContainsKey(partFind))
            {
                _parts[partFind] += partCount;
            }
            else
            {
                _parts.Add(partFind, partCount);
            }

            PurchaseOrder purchaseOrder = new PurchaseOrder()
            {
                PartId = partId,
                Quantity = partCount,
                OrderDate = DateTime.Now,
                DeliveryDueCarCount = 2
            };
            Core.Context.PurchaseOrders.Add(purchaseOrder);
            Core.Context.SaveChanges();

            Console.ReadKey();
            Console.Clear();
        }
        public void НачатьСмену()
        {
            Console.WriteLine("Новый день в автосервисе. Я так рад работая тут!!!");
            Thread.Sleep(1000);
            Console.WriteLine("*для просмотра информации о автосервисе нажмите \"ВВОД\"*");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Начальный бюджет: " + _money);
            Console.WriteLine("Начальные детали: ");
            while (true)
            {
                ВывестиВсеДеталиНаСкладе();
                Console.WriteLine($"\nБюджет автосервиса: {_money} руб.");
                Console.WriteLine("\n1. Ждать клиента\n2. Заказать деталь");
                while (true)
                {
                    ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                    switch (consoleKeyInfo.Key)
                    {
                        case ConsoleKey.D1:
                            ЖдатьКлиента();
                            break;
                        case ConsoleKey.D2:
                            ЗаказатьДеталь();
                            break;
                        default:
                            continue;
                    }
                    break;
                }
            }
        }

        private void ЖдатьКлиента()
        {
            int randomCustomerIndex = random.Next(0, Core.Context.Customers.ToList().Count);
            Customer customer = Core.Context.Customers.ToList()[randomCustomerIndex];

            int randomPartIndex = random.Next(0, _allParts.Count);
            Part brokenPart = _allParts[randomPartIndex];
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n Приехал кто-то очень важный... \n");
            Console.ResetColor();
            Thread.Sleep(1000);
            Console.WriteLine("Приехал " + customer.Name);
            Thread.Sleep(500);
            Console.WriteLine("Точнее еле доволок сломанную машину. В ней делать была в непригодном состоянии. ");
            Console.WriteLine("Сломанная делать: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n" + brokenPart.Name);
            Console.ResetColor();
            Console.WriteLine("\nТвои детали: ");
            ВывестиВсеДеталиНаСкладе();
            Console.WriteLine("\n1. Принять заказ\n2. Отклонить заказ (штраф 1000 ру.)");
        }
    }
}
