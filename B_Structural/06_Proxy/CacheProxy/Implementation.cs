namespace CacheProxy;

public class Weather
{
    public string City { get; set; }
    public DateTime Date { get; set; }
    public string Temperature { get; set; }

    public Weather(string city, DateTime date, string temperature)
    {
        City = city;
        Date = date;
        Temperature = temperature;
    }
}

//Subject
public interface IWeatherDatabase
{
    Weather GetWeather(string city, DateTime date);
}

//RealSubject
public class WeatherDatabase : IWeatherDatabase
{
    private readonly List<Weather> _weatherDatabase;

    public WeatherDatabase()
    {
        _weatherDatabase = new List<Weather>();
        _weatherDatabase.Add(new Weather("Tehran", DateTime.Now.AddDays(-1), "25C"));
        _weatherDatabase.Add(new Weather("Tehran", DateTime.Now.AddDays(-2), "22C"));
        _weatherDatabase.Add(new Weather("Tehran", DateTime.Now.AddDays(-3), "20C"));
        _weatherDatabase.Add(new Weather("Tehran", DateTime.Now.AddDays(-4), "18C"));
        _weatherDatabase.Add(new Weather("Tehran", DateTime.Now.AddDays(-5), "23C"));
        _weatherDatabase.Add(new Weather("Tehran", DateTime.Now.AddDays(-6), "27C"));
        _weatherDatabase.Add(new Weather("Tehran", DateTime.Now.AddDays(-7), "30C"));
        _weatherDatabase.Add(new Weather("Tehran", DateTime.Now.AddDays(-8), "28C"));
        _weatherDatabase.Add(new Weather("Tehran", DateTime.Now.AddDays(-9), "26C"));
        _weatherDatabase.Add(new Weather("Tehran", DateTime.Now.AddDays(-10), "24C"));
    }

    public Weather GetWeather(string city, DateTime date)
    {
        foreach (var item in _weatherDatabase)
        {
            if (item.City == city && item.Date.Date == date.Date)
            {
                return item;
            }
        }

        return null;
    }

    public void AddWeather(Weather weather)
    {
        _weatherDatabase.Add(weather);
    }
}

//Proxy(SmartCacheProxy)
public class WeatherProxy : IWeatherDatabase
{
    private readonly IWeatherDatabase _weatherDatabase;
    private readonly List<Weather> _cache = new List<Weather>();
    private readonly int _cacheCapacity = 3; 

    public WeatherProxy(IWeatherDatabase weatherDatabase)
    {
        _weatherDatabase = weatherDatabase;
    }

    public Weather GetWeather(string city, DateTime date)
    {
        foreach (var item in _cache)
        {
            if (item.City == city && item.Date.Date == date.Date)
            {
                Console.WriteLine("Proxy: Retrieving from cache.");
                Weather foundedReportFromCache = _cache.Find(item => item.City == city && item.Date == date);
                Console.WriteLine(item.Temperature);
                Console.WriteLine();

                return foundedReportFromCache;
            }
        }

        Console.WriteLine("Proxy: Retrieving from database.");
        Weather foundedReportFromDatabase = _weatherDatabase.GetWeather(city, date);

        if (foundedReportFromDatabase != null)
        {
            Console.WriteLine(foundedReportFromDatabase.Temperature);
            Console.WriteLine("Proxy: Adding to cache.");
            _cache.Add(foundedReportFromDatabase);

            if (_cache.Count > _cacheCapacity)
            {
                _cache.RemoveAt(0);
            }
        }
        else
            Console.WriteLine("Report not found in the database");

        Console.WriteLine();
        
        return foundedReportFromDatabase;
    }
}