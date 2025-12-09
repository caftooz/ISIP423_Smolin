namespace ConsoleApp;

public class HealingPotion : Item
{
    public override void ShowInfo()
    {
        throw new NotImplementedException();
    }

    public override void UseItem(Player player)
    {
        player.HP = player.MaxHP;
    }
}