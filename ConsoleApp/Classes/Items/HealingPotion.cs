using System;

namespace ConsoleApp;

public class HealingPotion : Item
{
    public override void ShowInfo()
    {
        Console.WriteLine("Лечебное зелье (полностью востанавливает HP)");
    }

    public override void UseItem(Player player)
    {
        player.HP = player.MaxHP;
    }
}