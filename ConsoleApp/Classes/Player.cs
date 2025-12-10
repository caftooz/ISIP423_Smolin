using System;

namespace ConsoleApp;

public sealed class Player : IDamageable, IAttackable
{
    public int MaxHP { get; set; }
    public int HP { get; set; }
    public int AttackDamage { get; set; }
    public int Protection { get; set; }
    
    public PlayerEffects ActiveEffect { get; private set; }

    public event Action? OnDie;
    public event Action? OnTakeDamage;

    public Player(int  maxHP, int attackDamage, int protection)
    {
        MaxHP = maxHP;
        HP = maxHP;
        AttackDamage = attackDamage;
        Protection = protection;
        ActiveEffect = PlayerEffects.None;
    }
    
    public void TakeDamage(int damage)
    {
        int trueDamage = damage * (100 - Protection) / 100;
        if (HP > trueDamage)
        {
            Thread.Sleep(1000);
            Console.WriteLine($"Игрок получет {trueDamage} урона");
            HP -= trueDamage;
            OnTakeDamage?.Invoke();
        }
        else
        {
            OnDie?.Invoke();
        }
    }
    public void Attack(IDamageable target)
    {
        Thread.Sleep(1000);
        Console.WriteLine($"Игрок атакует на {AttackDamage} едениц урона");
        target.TakeDamage(AttackDamage);
    }
    
    public void ApplyEffect(PlayerEffects effect)
    {
        ActiveEffect |= effect;
    }
    
    public void RemoveEffect(PlayerEffects effect)
    {
        ActiveEffect &= ~effect;
    }
}