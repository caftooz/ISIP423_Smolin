using System;

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
        int trueDamage = damage * (100 - Protection) / 100;
        if (HP > trueDamage)
        {
            Thread.Sleep(1000);
            Console.WriteLine($"Враг получил {trueDamage} урона");
            HP -= trueDamage;
        }
        else
        {
            OnDie?.Invoke();
        }
    }
    public void Attack(IDamageable target)
    {
        Thread.Sleep(1000);
        Console.WriteLine($"Враг атакует на {AttackDamage} едениц урона");
        target.TakeDamage(AttackDamage);
    }

    public abstract void ActivateBonus(Player player);
    public abstract void DeactivateBonus(Player player);
}