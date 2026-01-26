using LoggerChainOfResponsibility;

Console.Title = "LoggerChainOfResponsibility";

ConsoleLogger ChainOfLoggers = new ConsoleLogger();
ChainOfLoggers.SetNext(new FileLogger())
    .SetNext(new RemoteLogger());

ChainOfLoggers.Log("ERROR", "Can not cast from boolean to integer");
Console.WriteLine();
ChainOfLoggers.Log("INFO", "Variable Name is defined bot not used.");
Console.WriteLine();
ChainOfLoggers.Log("WARNING", "variable Name can be null");