using Singleton;

Console.Title = "Singleton Pattern";

//Logger logger = new Logger();

Logger instance1 = Logger.Instance;
Logger instance2 = Logger.Instance;

if (instance1 == instance2 && instance2 == Logger.Instance)
    Console.WriteLine("Instances are the same.");

instance1.Log(nameof(instance1));
instance2.Log(nameof(instance2));
Logger.Instance.Log(nameof(Logger.Instance));