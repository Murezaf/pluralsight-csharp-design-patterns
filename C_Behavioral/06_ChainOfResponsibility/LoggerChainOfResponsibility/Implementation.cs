namespace LoggerChainOfResponsibility;

//Handler
abstract class Logger
{
    protected Logger? _nextLogger;

    public Logger SetNext(Logger next)
    {
        _nextLogger = next;
        return _nextLogger;
    }

    public abstract void Log(string level, string message);
}

//ConcreteLoggers
class ConsoleLogger : Logger
{
    public override void Log(string level, string message)
    {
        if (level == "ERROR" || level == "WARNING")
        {
            Console.WriteLine($"Console: {level} - {message}");
        }

        if (_nextLogger != null)
        {
            _nextLogger.Log(level, message);
        }
    }
}

class FileLogger : Logger
{
    public override void Log(string level, string message)
    {
        Console.WriteLine("Log saved to the log.txt file");

        if (_nextLogger != null)
        {
            _nextLogger.Log(level, message);
        }
    }
}

class RemoteLogger : Logger
{
    public override void Log(string level, string message)
    {
        if (level == "ERROR")
        {
            Console.WriteLine($"Remote: {level} - {message}");
        }
        
        if (_nextLogger != null)
        {
            _nextLogger.Log(level, message);
        }
    }
}