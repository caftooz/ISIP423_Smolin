using System.Globalization;

namespace ConsoleApp;

public static class Menu
{
    public static MenuChoose ShowMenu(params string[] items)
    {
        int length = items.Length;
        for (var i = 0; i < length; i++)
        {
            var item = items[i];
            Console.WriteLine(i+1 + ". " + item);
        }

        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.D1:
                    return MenuChoose.D1;
                case ConsoleKey.D2:
                    return MenuChoose.D2;
                case ConsoleKey.D3:
                    if (length > 3)
                        return MenuChoose.D3;
                    break;
                case ConsoleKey.D4:
                    if (length > 4)
                        return MenuChoose.D4;
                    break;
                case ConsoleKey.D5:
                    if (length > 5)
                        return MenuChoose.D5;
                    break;
                case ConsoleKey.D6:
                    if (length > 6)
                        return MenuChoose.D6;
                    break;
                case ConsoleKey.D7:
                    if (length > 7)
                        return MenuChoose.D7;   
                    break;
                case ConsoleKey.D8:
                    if (length > 8)
                        return MenuChoose.D8;
                    break;
                case ConsoleKey.D9:
                    if (length > 9)
                        return MenuChoose.D9;
                    break;
                default:
                    continue;
            }
            continue;
        }
    }

    public enum MenuChoose
    {
        D1,
        D2,
        D3,
        D4,
        D5,
        D6,
        D7,
        D8,
        D9,
    }
}