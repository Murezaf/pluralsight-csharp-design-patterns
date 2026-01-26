namespace EnemyGameFactoryMethod;

//Product
abstract class Enemy
{
    public abstract string Name { get; }
    public abstract int Health { get; }
    public abstract int Damage { get; }

    public void Attack()
    {
        Console.WriteLine($"{Name} attacks with {Damage} damage!");
    }
}

//ConcreteProducts
class WeakZombie : Enemy
{
    public override string Name => "Weak Zombie";
    public override int Health => 50;
    public override int Damage => 10;
}

class StrongZombie : Enemy
{
    public override string Name => "Strong Zombie";
    public override int Health => 120;
    public override int Damage => 25;
}

class WeakRobot : Enemy
{
    public override string Name => "Weak Robot";
    public override int Health => 80;
    public override int Damage => 15;
}

class StrongRobot : Enemy
{
    public override string Name => "Strong Robot";
    public override int Health => 200;
    public override int Damage => 40;
}

//Creator
abstract class EnemyFactory
{
    public abstract Enemy CreateEnemy(int playerLevel);
}

//ConcreteCreators
class ApocalypseEnemyFactory : EnemyFactory
{
    public override Enemy CreateEnemy(int playerLevel)
    {
        if (playerLevel < 10)
            return new WeakZombie();

        return new StrongZombie();
    }
}

class FutureEnemyFactory : EnemyFactory
{
    public override Enemy CreateEnemy(int playerLevel)
    {
        if (playerLevel < 15)
            return new WeakRobot();

        return new StrongRobot();
    }
}

//Client
class Game
{
    private readonly EnemyFactory _enemyFactory;
    private readonly int _playerLevel;

    public Game(EnemyFactory enemyFactory, int playerLevel)
    {
        _enemyFactory = enemyFactory;
        _playerLevel = playerLevel;
    }

    public void Start()
    {
        Enemy enemy = _enemyFactory.CreateEnemy(_playerLevel);

        Console.WriteLine($"Enemy appeared: {enemy.Name}");
        enemy.Attack();
    }
}
