namespace ConsoleApp;

public class Boss
{
    public Boss(Enemy enemy, string name)
    {
        Enemy = enemy;
        Name = name;
    }

    public Enemy Enemy { get;private set;}
    public string Name { get;private set;}
}