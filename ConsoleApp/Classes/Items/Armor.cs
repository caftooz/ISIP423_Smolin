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
        throw new NotImplementedException();
    }

    public override void UseItem(Player player)
    {
        player.Protection = _armorProtection;
    }
}