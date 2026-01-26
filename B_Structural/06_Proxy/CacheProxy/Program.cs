using CacheProxy;

Console.Title = "CacheProxy";

WeatherDatabase weatherDatabase = new WeatherDatabase();
WeatherProxy weatherProxy = new WeatherProxy(weatherDatabase);

weatherProxy.GetWeather("Tehran", DateTime.Now.AddDays(-1));
weatherProxy.GetWeather("Tehran", DateTime.Now);
weatherProxy.GetWeather("Tehran", DateTime.Now.AddDays(-5));
weatherProxy.GetWeather("Tehran", DateTime.Now.AddDays(-2));
weatherProxy.GetWeather("Tehran", DateTime.Now.AddDays(-1));
weatherProxy.GetWeather("Tehran", DateTime.Now.AddDays(-1));
weatherProxy.GetWeather("Tehran", DateTime.Now.AddDays(-1));
weatherProxy.GetWeather("Tehran", DateTime.Now.AddDays(-2));
weatherProxy.GetWeather("Tehran", DateTime.Now.AddDays(-6));
weatherProxy.GetWeather("Tehran", DateTime.Now.AddDays(-4));
weatherProxy.GetWeather("Tehran", DateTime.Now.AddDays(-3));
weatherProxy.GetWeather("Tehran", DateTime.Now.AddDays(-3));