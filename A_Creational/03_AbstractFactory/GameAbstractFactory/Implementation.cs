namespace GameAbstractFactory;

//Products
interface IEnemy
{
    string Name { get; }
    int Health { get; }
    int Damage { get; }
    void Attack();
}

interface IWeapon
{
    string Type { get; }
    int Damage { get; }
}

interface IArmor
{
    string Name { get; }
    int Defense { get; }
}

//ConcreteProducts
class WeakZombie : IEnemy
{
    public string Name => "Weak Zombie";
    public int Health => 50;
    public int Damage => 10;
    public void Attack() => Console.WriteLine($"{Name} attacks with {Damage} damage!");
}

class StrongZombie : IEnemy
{
    public string Name => "Strong Zombie";
    public int Health => 120;
    public int Damage => 25;
    public void Attack() => Console.WriteLine($"{Name} attacks with {Damage} damage!");
}

class WeakRobot : IEnemy
{
    public string Name => "Weak Robot";
    public int Health => 80;
    public int Damage => 15;
    public void Attack() => Console.WriteLine($"{Name} attacks with {Damage} damage!");
}

class StrongRobot : IEnemy
{
    public string Name => "Strong Robot";
    public int Health => 200;
    public int Damage => 40;
    public void Attack() => Console.WriteLine($"{Name} attacks with {Damage} damage!");
}

class Claws : IWeapon
{
    public string Type => "Claws";
    public int Damage => 15;
}

class LaserGun : IWeapon
{
    public string Type => "Laser Gun";
    public int Damage => 30;
}

class LeatherArmor : IArmor
{
    public string Name => "Leather Armor";
    public int Defense => 5;
}

class EnergyShield : IArmor
{
    public string Name => "Energy Shield";
    public int Defense => 20;
}

//FactoryMethods(Creators)
abstract class EnemyFactoryMethod
{
    public abstract IEnemy Create(int playerLevel);
}

abstract class WeaponFactoryMethod
{
    public abstract IWeapon Create();
}

abstract class ArmorFactoryMethod
{
    public abstract IArmor Create();
}

//ConcreteCreators
class WeakZombieFactory : EnemyFactoryMethod
{
    public override IEnemy Create(int playerLevel) => new WeakZombie();
}

class StrongZombieFactory : EnemyFactoryMethod
{
    public override IEnemy Create(int playerLevel) => new StrongZombie();
}

class WeakRobotFactory : EnemyFactoryMethod
{
    public override IEnemy Create(int playerLevel) => new WeakRobot();
}

class StrongRobotFactory : EnemyFactoryMethod
{
    public override IEnemy Create(int playerLevel) => new StrongRobot();
}

class ClawsFactory : WeaponFactoryMethod
{
    public override IWeapon Create() => new Claws();
}

class LaserGunFactory : WeaponFactoryMethod
{
    public override IWeapon Create() => new LaserGun();
}

class LeatherArmorFactory : ArmorFactoryMethod
{
    public override IArmor Create() => new LeatherArmor();
}

class EnergyShieldFactory : ArmorFactoryMethod
{
    public override IArmor Create() => new EnergyShield();
}

//AbstractFactory
interface IGameWorldFactory
{
    IEnemy CreateEnemy(int playerLevel);
    IWeapon CreateWeapon();
    IArmor CreateArmor();
}

//ConcreteAbstractFactory
class ApocalypseWorldFactory : IGameWorldFactory
{
    public IEnemy CreateEnemy(int playerLevel)
    {
        EnemyFactoryMethod factory = playerLevel < 10
            ? new WeakZombieFactory()
            : new StrongZombieFactory();

        return factory.Create(playerLevel);
    }

    public IWeapon CreateWeapon()
    {
        WeaponFactoryMethod factory = new ClawsFactory();
        return factory.Create();
    }

    public IArmor CreateArmor()
    {
        ArmorFactoryMethod factory = new LeatherArmorFactory();
        return factory.Create();
    }
}

class FutureWorldFactory : IGameWorldFactory
{
    public IEnemy CreateEnemy(int playerLevel)
    {
        EnemyFactoryMethod factory = playerLevel < 15
            ? new WeakRobotFactory()
            : new StrongRobotFactory();

        return factory.Create(playerLevel);
    }

    public IWeapon CreateWeapon()
    {
        WeaponFactoryMethod factory = new LaserGunFactory();
        return factory.Create();
    }

    public IArmor CreateArmor()
    {
        ArmorFactoryMethod factory = new EnergyShieldFactory();
        return factory.Create();
    }
}

//Client
class Game
{
    private readonly IGameWorldFactory _factory;
    private readonly int _playerLevel;

    public Game(IGameWorldFactory factory, int playerLevel)
    {
        _factory = factory;
        _playerLevel = playerLevel;
    }

    public void Start()
    {
        IEnemy enemy = _factory.CreateEnemy(_playerLevel);
        IWeapon weapon = _factory.CreateWeapon();
        IArmor armor = _factory.CreateArmor();

        Console.WriteLine($"Enemy appeared: {enemy.Name}");
        Console.WriteLine($"Enemy equipped with {weapon.Type} and {armor.Name}");
        enemy.Attack();
    }
}
