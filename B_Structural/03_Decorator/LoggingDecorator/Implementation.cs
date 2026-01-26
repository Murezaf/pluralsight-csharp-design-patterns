namespace LoggingDecorator;

//Component
public interface ILoggable
{
    void Process();
}

//ConcreteComponent1
public class Migration : ILoggable
{
    public void Process()
    {
        Console.WriteLine("Migration is happening...");
    }
}

//ConcreteComponent2
public class UpdateDatabase : ILoggable
{
    public void Process()
    {
        Console.WriteLine("Updating database is happening...");
    }
}

//Decorator
public abstract class LoggingDecoratorBase : ILoggable
{
    private readonly ILoggable _loggable; 

    public LoggingDecoratorBase(ILoggable loggable)
    {
        _loggable = loggable;
    }

    public virtual void Process()
    {
        _loggable.Process();
    }
}

//ConcreteDecorator1
public class FileLoggerDecorator : LoggingDecoratorBase
{
    public FileLoggerDecorator(ILoggable loggable) : base(loggable)
    {
    }

    public override void Process()
    {
        Console.WriteLine("Logging is happening in a file");
        base.Process();
    }
}

//ConcreteDecorator1
public class ConsoleLoggerDecorator : LoggingDecoratorBase
{
    public ConsoleLoggerDecorator(ILoggable loggable) : base(loggable)
    {
    }

    public override void Process()
    {
        Console.WriteLine("Logging is happening inside you console");
        base.Process();
    }
}