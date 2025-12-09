namespace ConsoleApp;

public interface IAttackable
{
    protected int AttackDamage { get;}
    public void Attack(IDamageable target);
}