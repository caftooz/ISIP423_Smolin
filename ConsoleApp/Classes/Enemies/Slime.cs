namespace ConsoleApp;

public class Slime : Enemy
{
    public Slime(EnemyStats stats) : base(stats)
    {
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage - 2);
    }

    public override void ActivateBonus(Player player)
    {
        //
    }

    public override void DeactivateBonus(Player player)
    {
        //
    }
}