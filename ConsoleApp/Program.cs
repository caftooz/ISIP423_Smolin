using Microsoft.EntityFrameworkCore;
using ConsoleApp.BD;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Новый день в автосервисе. Я так рад работая тут!!!");

            CarService ГордыеМашиныСервис = new CarService();
        }
    }

    internal class CarService
    {
        private List<Part> _allParts = Core.Context.Parts.ToList();

        private Random random = new();
        private static double _money;
        private Dictionary<Part, int> _parts = new();

        public CarService(double startMoney = 30000, int startPartsCount = 5)
        {
            _money = 30000;

            // Добавляем случайные предметы на склад
            for (int i = 0; i < startPartsCount; i++)
            {
                int index = random.Next(0, _allParts.Count);
                Part randomPart = _allParts[index];

                _parts[randomPart] += 1;
            }
        }
    }
}
