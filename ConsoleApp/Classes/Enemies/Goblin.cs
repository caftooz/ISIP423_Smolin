using System;

namespace ConsoleApp;

public class Goblin : Enemy
{
    private readonly int _critDamageChance;
    private readonly float _critDamageMultiply;

    private Player _player;

    public Goblin(EnemyStats stats, int critDamageChance, float critDamageMultiply) : base(stats)
    {
        _critDamageChance = critDamageChance;
        _critDamageMultiply = critDamageMultiply;
    }


    public override void ActivateBonus(Player player)
    {
        _player = player;
        player.OnTakeDamage += TakeBonusDamage;
    }

    public override void DeactivateBonus(Player player)
    {
        player.OnTakeDamage -= TakeBonusDamage;
    }

    private void TakeBonusDamage()
    {
        if (RandomChance.GetRandomChance(_critDamageChance))
        {
            Console.WriteLine("Враг нанёс критический удар и игрок получает дополнительный урон");
            _player.TakeDamage(Convert.ToInt32(AttackDamage * _critDamageMultiply));
        }
    }
}