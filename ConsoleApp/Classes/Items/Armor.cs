using System;

namespace ConsoleApp;

public class Armor : Item
{
    private readonly int _armorProtection;

    public Armor(int armorProtection)
    {
        _armorProtection = armorProtection;
    }
    
    public override void ShowInfo()
    {
        Console.WriteLine("Броня с показателем защиты: " + _armorProtection);
    }

    public override void UseItem(Player player)
    {
        player.Protection = _armorProtection;
    }
}