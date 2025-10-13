using ConsoleApp.Structs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Classes.Abstract
{
    abstract class Entity
    {
        public int CurrenHP { get; private set; }
        public EntityStats BaseStats { get; private set; }

        protected Entity(EntityStats stats)
        {
            BaseStats = stats;
        }

        protected void TakeDamage(int damage)
        {
            int takenDamage = damage - BaseStats.Protection;
            if (takenDamage > 0)
            {
                if (damage >= CurrenHP)
                {
                    Death();
                }
                else
                {
                    CurrenHP -= takenDamage;
                }
            }
        }

        private void Death()
        {
            CurrenHP = 0;
        }

        public override string ToString()
        {
            return string.Format("HP: {0}\n" +
                                  "Strength: {1}\n" +
                                  "Protection: {2}\n",
                                  CurrenHP, BaseStats.Strength,
                                  BaseStats.Protection);
        }
    }
}
