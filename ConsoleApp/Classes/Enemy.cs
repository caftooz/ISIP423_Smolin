namespace ConsoleApp;

public abstract class Enemy : IDamageable, IAttackable
{
    public int HP { get; private set; }
    public int AttackDamage { get; private set; }
    public int Protection { get; set; }
    
    public event Action? OnDie;
    
    private EnemyStats _stats;

    protected Enemy(EnemyStats stats)
    {
        _stats = stats;
    }

    public virtual void Initialize()
    {
        HP = _stats.HealthPoints;
        AttackDamage = _stats.AttackDamage;
        Protection = _stats.Protection;
    }
    
    public void TakeDamage(int damage)
    {
        if (HP > damage)
        {
            HP -= damage;
        }
        else
        {
            OnDie?.Invoke();
        }
    }
    public void Attack(IDamageable target)
    {
        target.TakeDamage(AttackDamage);
    }

    public abstract void ActivateBonus(Player player);
    public abstract void DeactivateBonus(Player player);
}