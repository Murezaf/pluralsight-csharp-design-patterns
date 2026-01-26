using EnemyGameFactoryMethod;

Console.Title = "EnemyGameFactoryMethod";

string season = "Future"; // Apocalypse or Future
int playerLevel = 18;

EnemyFactory factory;

if (season == "Apocalypse")
    factory = new ApocalypseEnemyFactory();
else
    factory = new FutureEnemyFactory();

var game = new Game(factory, playerLevel);
game.Start();