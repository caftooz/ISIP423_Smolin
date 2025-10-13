using ConsoleApp.Structs;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Classes.Abstract
{
    abstract internal class Enemy : Entity
    {
        private static int _lastID = 1;
        public int ID { get; private set; }

        protected Enemy(EntityStats stats ) : base(stats)
        {
            ID = _lastID++;
        }
    }
}
