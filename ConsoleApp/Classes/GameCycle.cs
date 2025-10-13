using ConsoleApp.Classes.Enemies;
using ConsoleApp.Structs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Classes
{
    internal class GameCycle
    {
        private EntityStats WizardBaseStats, GoblinBaseStats, SkeletonBaseStats;

        public GameCycle()
        {
            InitializeSettings();
        }
        private void InitializeSettings()
        {
            WizardBaseStats = new EntityStats(70, 30 ,1);
            GoblinBaseStats = new EntityStats(130, 10, 3);
            SkeletonBaseStats = new EntityStats(100, 20, 10);
        }
        public void StartGame()
        {
            Skeleton s = new(SkeletonBaseStats);
            Wizard w = new(WizardBaseStats);

            Console.WriteLine(s);
            Console.WriteLine(w);
        }
    }
}
