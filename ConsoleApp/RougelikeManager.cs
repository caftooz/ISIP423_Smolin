using System.Collections.Generic;
using System;

namespace ConsoleApp;

public class RougelikeManager
{
    private List<Enemy> _enemies;
    private List<Boss> _bosses;

    private Player _player;
    private void InitializeEnemies()
    {
        //Initialize base enemies
        //Skeleton------------------------------------------------------------------------------------------------------
        var skeletonStats = new EnemyStats(100,10,40);
        int skeletonIgnoringProtectionPrecent = 10;
        
        Skeleton baseSkeleton = new Skeleton(skeletonStats, skeletonIgnoringProtectionPrecent);
        
        //Goblin--------------------------------------------------------------------------------------------------------
        var goblinStats = new EnemyStats(150,20,5);
        int critDamageChance = 30;
        float critDamageMultiply = 2;
        
        Goblin baseGoblin = new Goblin(goblinStats, critDamageChance, critDamageMultiply);
        
        //Wizard--------------------------------------------------------------------------------------------------------
        var wizardStats = new EnemyStats(50,35,10);
        int freezeChance = 25;
        
        Wizard baseWizard = new Wizard(wizardStats, freezeChance);
        
        //Add enemies to list
        _enemies = new();
        _enemies.Add(baseSkeleton);
        _enemies.Add(baseGoblin);
        _enemies.Add(baseWizard);
        
        //Initialize bosses
        //ВВГ (goblin)--------------------------------------------------------------------------------------------------
        var vvgStats = new EnemyStats(
            goblinStats.HealthPoints * 2,
            Convert.ToInt32(goblinStats.AttackDamage * 1.5f), 
            Convert.ToInt32(goblinStats.Protection * 1.2f));
        int vvgCritDamageChance = critDamageChance + 10;
        float vvgCritDamageMultiply = critDamageMultiply;
        
        Goblin vvgoblin = new Goblin(vvgStats, vvgCritDamageChance, vvgCritDamageMultiply);

        Boss vvg = new(vvgoblin, "ВВГ");
        
        //Ковальский (skeleton)-----------------------------------------------------------------------------------------
        var kovalskyStats = new EnemyStats(
            Convert.ToInt32(skeletonStats.HealthPoints * 2.5f),
            Convert.ToInt32(skeletonStats.AttackDamage * 1.3f),
            Convert.ToInt32(skeletonStats.Protection * 1.4f));
        int kovalskyIgnoringProtectionPrecent = 100;
        
        Skeleton kovalskySkeleton = new Skeleton(kovalskyStats, kovalskyIgnoringProtectionPrecent);

        Boss kovalsky = new(kovalskySkeleton, "Ковальский");
        
        //Архимаг C++ (Wizard)------------------------------------------------------------------------------------------
        var arhimagStats = new EnemyStats(
            Convert.ToInt32(wizardStats.HealthPoints * 1.8f),
            Convert.ToInt32(wizardStats.AttackDamage * 1.6f),
            Convert.ToInt32(wizardStats.Protection * 1.1f));
        int arhimagFreezeChance = freezeChance + 10;
        
        Wizard arhimagWizard = new Wizard(arhimagStats, arhimagFreezeChance);
        Boss arhimag = new(arhimagWizard, "Архимаг C++");
        
        //Петров C--(skeleton)-----------------------------------------------------------------------------------------
        var petrovStats = new EnemyStats(
            Convert.ToInt32(skeletonStats.HealthPoints * 1.3f),
            Convert.ToInt32(skeletonStats.AttackDamage * 1.8f),
            Convert.ToInt32(skeletonStats.Protection * 0.6f));
        int petrovIgnoringProtectionPrecent = skeletonIgnoringProtectionPrecent + 15;
        
        Skeleton petrovSkeleton = new Skeleton(petrovStats, petrovIgnoringProtectionPrecent);

        Boss petrov = new(petrovSkeleton, "Ковальский");

        //Add bosses to list
        _bosses = new();
        _bosses.Add(vvg);
        _bosses.Add(kovalsky);
        _bosses.Add(arhimag);
        _bosses.Add(petrov);
    }
    private void InitializePlayer()
    {
        _player = new(100, 20, 60);
        _player.OnDie += GameOver;
    }

    private void GameOver()
    {
        Console.Clear();
        Console.WriteLine("Вы проиграли!");
        throw new Exception("Тренеруйтесь");
    }

    public void StartGame()
    {
        InitializePlayer();
        InitializeEnemies();
        
        StartGameCycle();
    }


    private void StartGameCycle()
    {
        Console.Clear();
        Console.WriteLine("Добро пожаловать в игру рогалик");
        int steps = 1;
        while (true)
        {
            if (steps % 10 == 0)
            {
                StartBossFight();
            }
            else
            {
                Move();
            }
            steps++;
        }
    }

    private void Move()
    {
        if (RandomChance.GetRandomChance(50))
        {
            OpenChest();
        }
        else
        {
            StartFight();
        }
    }

    private void StartBossFight()
    {
        throw new NotImplementedException();
    }

    private void StartFight()
    {
        Enemy randomEnemy = RandomChance.GetRandomEnemy(_enemies);
        randomEnemy.Initialize();
        randomEnemy.ActivateBonus(_player);
        
        bool isFighting = true;
        randomEnemy.OnDie += StopFight;

        while (isFighting)
        {
            
        }
        
        void StopFight()
        {
            isFighting = false;
            randomEnemy.OnDie -= StopFight;
        }
    }

    private void OpenChest()
    {
        Console.WriteLine("Вам попался суднук с добычей: ");
        
        Item randomItem = RandomChance.GetRandomItem();
        randomItem.ShowInfo();
        switch (Menu.ShowMenu("Подобрать", "Выбросить"))
        {
            case Menu.MenuChoose.D1:
                randomItem.UseItem(_player);
                break;
            case Menu.MenuChoose.D2:
                break;
        }
    }
}