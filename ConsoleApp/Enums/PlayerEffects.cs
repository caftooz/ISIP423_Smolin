using System;

namespace ConsoleApp;

[Flags]
public enum PlayerEffects : byte
{
    None = 0,
    FreezeEffect = 1 << 0,
}