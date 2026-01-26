using GameAbstractFactory;

Console.Title = "GameAbstractFactory";

IGameWorldFactory factory;

string season = "Future"; // "Apocalypse" or "Future"
int playerLevel = 12;

if (season == "Apocalypse")
    factory = new ApocalypseWorldFactory();
else
    factory = new FutureWorldFactory();

Game game = new Game(factory, playerLevel);
game.Start();
