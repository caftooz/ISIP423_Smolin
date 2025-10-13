using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Classes
{
    abstract class Entity
    {
        public int HP { get; private set; }
        public int Strength { get; private set; }
        public int Protection { get; private set; }

        protected void TakeDamage(int damage)
        {
            int takenDamage = damage - Protection;
            if (takenDamage > 0)
            {
                if (damage >= HP)
                {
                    Death();
                }
                else
                {
                    HP -= takenDamage;
                }
            }
        }

        private void Death()
        {
            HP = 0;
        }
    }
}
