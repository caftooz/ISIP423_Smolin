namespace ConsoleApp;

public interface IDamageable
{
    public int HP { get; }
    public void TakeDamage(int damage);
}