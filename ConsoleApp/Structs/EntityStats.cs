using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Structs
{
    internal struct EntityStats
    {
        public EntityStats(int hp, int strength, int protection)
        {
            HP = hp;
            Strength = strength;
            Protection = protection;
        }
        public int HP { get; private set; }
        public int Strength { get; private set; }
        public int Protection { get; private set; }
    }
}
 