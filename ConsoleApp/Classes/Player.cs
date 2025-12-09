using ConsoleApp.Enums;

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
        Protection = protection;
        ActiveEffect = PlayerEffects.None;
    }
    
    public void TakeDamage(int damage)
    {
        if (HP > damage)
        {
            HP -= damage;
            OnTakeDamage?.Invoke();
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
    
    public void ApplyEffect(PlayerEffects effect)
    {
        ActiveEffect |= effect;
    }
    
    public void RemoveEffect(PlayerEffects effect)
    {
        ActiveEffect &= ~effect;
    }
}