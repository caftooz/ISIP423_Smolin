using System;
using System.Collections.Generic;

namespace ConsoleApp;

public static class RandomChance
{
    private static Random _random = new Random();
    public static bool GetRandomChance(int chance)
    {
        return _random.Next(1, 100) <= chance;
    }

    public static int GetRandomNumber(int min, int max)
    {
        return _random.Next(min, max);
    }

    public static Enemy GetRandomEnemy(List<Enemy> enemies)
    {
        return enemies[_random.Next(0, enemies.Count)];
    }
    
    public static Boss GetRandomBosses(List<Boss> bosses)
    {
        return bosses[_random.Next(0, bosses.Count)];
    }
    
    public static Item GetRandomItem()
    {
        switch (_random.Next(1, 3))
        {
            case 1:
                return new HealingPotion();
            case 2:
                return new Armor(_random.Next(70, 100));
            case 3:
                return new Sword(_random.Next(10, 40));
            default:
                throw new Exception("Invalid random choice");
        }
    }
}