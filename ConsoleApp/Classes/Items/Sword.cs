using System;

namespace ConsoleApp;

public class Sword : Item
{
    private readonly int _attackDamage;

    public Sword(int attackDamage)
    {
        _attackDamage = attackDamage;
    }
    
    public override void ShowInfo()
    {
        Console.WriteLine("Меч с показателем урона: " + _attackDamage);
    }

    public override void UseItem(Player player)
    {
        player.AttackDamage = _attackDamage;
    }
}