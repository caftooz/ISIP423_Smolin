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
        throw new NotImplementedException();
    }

    public override void UseItem(Player player)
    {
        player.AttackDamage = _attackDamage;
    }
}