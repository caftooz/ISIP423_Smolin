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
        public int ЧтояНаделалОНетТОлькоНеЭта228ООО = 0;
        private List<Part> _allParts行行 = Core.Context.Parts.ToList();
        private int _выполненоЗаказовайайай = 0;

        private Random п三曰出回 = new();

        private decimal миничипсы;
        private decimal чипсыЛэйс_скрабом_ 
        {
            get
            {
                return миничипсы;
            }
            set
            {
                миничипсы = value;
                if (чипсыЛэйс_скрабом_ < 0)
                {
                    Console.Clear();
                    Console.WriteLine("ИГРА ОКОНЧЕНА!!! ВЫ БАНКРОТ");
                    throw new Exception("Думать надо было!!");
                }
            }
        }

        private Dictionary<Part, int> _складкакойто = new();

        public CarService(decimal наДонат = 30000, int cvvКодМоейКартыЭто830 = 5)
        {
            чипсыЛэйс_скрабом_ = 30000;

            // Добавляем случайные предметы на склад
            for (int i = 0; i < cvvКодМоейКартыЭто830; i++)
            {
                int index = п三曰出回.Next(0, _allParts行行.Count);
                Part randomPart = _allParts行行[index];

                if (_складкакойто.ContainsKey(randomPart))
                {
                    _складкакойто[randomPart] += 1;
                }
                else
                {
                    _складкакойто.Add(randomPart, 1);
                }
            }
        }

        //Print all parts in your warehouse
        private void ВывестиВсеДеталиНаСкладе()
        {
            Console.WriteLine("-------------------------------------------------");
            string titleString = String.Format("|{0, 6}|{1, -40}|", "Кол-во", "Название");
            Console.WriteLine(titleString);
            Console.WriteLine("-------------------------------------------------");
            foreach (var part in _складкакойто)
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
            Console.WriteLine($"\nБюджет автосервиса: {чипсыЛэйс_скрабом_} руб.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n===ЗАКАЗ ДЕТАЛИ===\n");
            Console.ResetColor();
            Console.WriteLine("--------------------------------------------------------------");
            string titleString = String.Format("| {0, 2} | {1, -10} | {2, -40} |", "ID","Цена (руб.)", "Название");
            Console.WriteLine(titleString);
            Console.WriteLine("--------------------------------------------------------------");
            foreach (var part in _allParts行行)
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
                if (int.TryParse(idString, out var id) && _allParts行行.Any(p => p.PartId == id))
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

            Part partFind = _allParts行行.FirstOrDefault(p => p.PartId == partId);
            int maxOrderCount = Convert.ToInt32(чипсыЛэйс_скрабом_ / partFind.Price);

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

            чипсыЛэйс_скрабом_ -= partCount * partFind.Price;

            if (_складкакойто.ContainsKey(partFind))
            {
                _складкакойто[partFind] += partCount;
            }
            else
            {
                _складкакойто.Add(partFind, partCount);
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
            // 1000 милесекунд нужно что бы игрок не заснул. ВСЁ РАСЧИТАНО!!! НЕ УДАЛЯТЬ!!!
            Thread.Sleep(1000);
            Console.WriteLine("*для просмотра информации о автосервисе нажмите \"ВВОД\"*");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Начальный бюджет: " + чипсыЛэйс_скрабом_);
            Console.WriteLine("Начальные детали: ");
            while (true)
            {
                ВывестиВсеДеталиНаСкладе();
                Console.WriteLine($"\nБюджет автосервиса: {чипсыЛэйс_скрабом_} руб.");
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
            int randomCustomerIndex = п三曰出回.Next(0, Core.Context.Customers.ToList().Count);
            Customer покупатьWW = Core.Context.Customers.ToList()[randomCustomerIndex];

            int randomPartIndex = п三曰出回.Next(0, _allParts行行.Count);
            Part brokenPart = _allParts行行[randomPartIndex];
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n Приехал кто-то очень важный... \n");
            Console.ResetColor();
            Thread.Sleep(1000);
            Console.WriteLine("Приехал " + покупатьWW.Name);
            Thread.Sleep(500);
            Console.WriteLine("Точнее еле доволок сломанную машину. В ней делать была в непригодном состоянии. ");
            Console.WriteLine("Сломанная делать: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n" + brokenPart.Name);
            Console.ResetColor();
            Console.WriteLine("\nТвои детали: ");
            ВывестиВсеДеталиНаСкладе();
            Console.WriteLine("\n1. Принять заказ\n2. Отклонить заказ (штраф 1000 ру.)"); 
            while (true)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.D1:
                        ЗаказПринят(brokenPart);
                        break;
                    case ConsoleKey.D2:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nШТРАФ 1000 руб.!!!\n");
                        Console.ResetColor();
                        чипсыЛэйс_скрабом_ -= 1000; // пока не под проценты
                        break;
                    default:
                        continue;
                }
                break;
            }
            Console.ReadKey();
        }

        private void ЗаказПринят(Part 影)
        {
            Console.WriteLine("\nИщем деталь...");
            Thread.Sleep(1000);
            if (_складкакойто.ContainsKey(影) && _складкакойто[影] > ЧтояНаделалОНетТОлькоНеЭта228ООО)
            {
                Console.WriteLine("\nВы отыскали нужную деталь на складе");
                Thread.Sleep(300);
                Console.WriteLine("Вы поставили нужную деталь");
                Thread.Sleep(300);
                Console.WriteLine("Клиент ушёл довольный, оплатив вашу работу");
                Console.WriteLine("Бюджет +3000, и оплатили деталь: " + 影.Price);
                Console.WriteLine("\nИТОГ:");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-" + 影.Name);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("+" + (3000 + 影.Price));
                Console.ResetColor();
                чипсыЛэйс_скрабом_ += 3000 + 影.Price;
                _складкакойто[影] --;
            }
            else
            {
                Console.WriteLine("\nДетали на складе не оказалось");
                Thread.Sleep(300);
                Console.WriteLine("Но вы не отчаялись");
                Thread.Sleep(300);
                Console.WriteLine("Клиент ничего не заметит");
                Thread.Sleep(300);
                Console.WriteLine("Вы поставили случайную деталь");


            }
            _выполненоЗаказовайайай++;
        }
    }
}
