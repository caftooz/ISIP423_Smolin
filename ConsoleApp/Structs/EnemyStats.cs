namespace ConsoleApp;

public struct EnemyStats(int healthPoints, int attackDamage, int protection)
{
    public int HealthPoints = healthPoints;
    public int AttackDamage = attackDamage;
    public int Protection = protection;
}