namespace ConsoleApp;

public class Wizard : Enemy
{
    private readonly int _freezeChance;

    private Player _player;
    
    public Wizard(EnemyStats stats, int freezeChance) : base(stats)
    {
        _freezeChance =  freezeChance;
    }

    public override void ActivateBonus(Player player)
    {
        _player = player;
        player.OnTakeDamage += TryCastFreezeEffect;
    }

    public override void DeactivateBonus(Player player)
    {
        player.OnTakeDamage -= TryCastFreezeEffect;
    }
    
    private void TryCastFreezeEffect()
    {
        if (RandomChance.GetRandomChance(_freezeChance))
        {
            _player.ApplyEffect(PlayerEffects.FreezeEffect);
        }
    }
}