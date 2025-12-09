namespace ConsoleApp;

public class Skeleton : Enemy
{
    private readonly int _ignoringProtectionPrecent;

    private int _defaultPlayerProtection;
    
    public Skeleton(EnemyStats stats, int ignoringProtectionPrecent) : base(stats)
    {
        _ignoringProtectionPrecent =  ignoringProtectionPrecent;
    }
    
    public override void ActivateBonus(Player player)
    {
        _defaultPlayerProtection = player.Protection;
        player.Protection -= (player.Protection * _ignoringProtectionPrecent) / 100;
    }

    public override void DeactivateBonus(Player player)
    {
        player.Protection = _defaultPlayerProtection;
    }
}