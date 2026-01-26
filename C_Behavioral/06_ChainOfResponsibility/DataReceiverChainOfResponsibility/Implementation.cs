namespace DataReceiverChainOfResponsibility;

//Handler
public abstract class DataHandler
{
    protected DataHandler _nextHandler;

    public DataHandler SetNext(DataHandler next)
    {
        _nextHandler = next;
        return _nextHandler;
    }

    public abstract void GetData(string name);
}

//ConcreteHandlers
public class CacheHandler : DataHandler
{
    private readonly List<string> _cache = new List<string> { "Ali", "Reza", "Sara" };

    public override void GetData(string name)
    {
        if (_cache.Contains(name))
        {
            Console.WriteLine($"Data {name} retrieved from Cache.");
        }
        else
        {
            Console.WriteLine($"Data not found in Cache, moving to next handler...");
            if(_nextHandler != null)
            {
                _nextHandler.GetData(name);
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
    }
}

public class FileHandler : DataHandler
{
    private readonly string filePath = "data.txt";

    public override void GetData(string name)
    {
        if (File.Exists(filePath))
        {
            var lines = File.ReadAllLines(filePath);
            var fileData = new List<string>(lines);

            if (fileData.Contains(name))
            {
                Console.WriteLine($"Data {name} retrieved from File.");
            }
            else
            {
                Console.WriteLine($"Data not found in File, moving to next handler...");
                if (_nextHandler != null)
                {
                    _nextHandler.GetData(name);
                }
                else
                {
                    Console.WriteLine("Not Found");
                }
            }
        }
        else
        {
            Console.WriteLine($"File not found, moving to next handler...");
            if (_nextHandler != null)
            {
                _nextHandler.GetData(name);
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
    }
}

public class DatabaseHndler : DataHandler
{
    private readonly List<string> _database = new List<string> { "Mohamad", "Sara", "Ali" };

    public override void GetData(string name)
    {
        if (_database.Contains(name))
        {
            Console.WriteLine($"Data {name} retrieved from Database.");
        }
        else
        {
            Console.WriteLine($"Data not found in Database, moving to next handler...");
            if (_nextHandler != null)
            {
                _nextHandler.GetData(name);
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
    }
}