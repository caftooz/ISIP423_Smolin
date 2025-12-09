namespace ConsoleApp.Enums;

[Flags]
public enum PlayerEffects : byte
{
    None = 0,
    FreezeEffect = 1 << 0,
}