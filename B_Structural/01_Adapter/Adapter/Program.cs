//using ObjectAdapter;
//using ClassAdapter;

//Console.Title = "Adapter";

//ICityAdapter adapter = new CityAdapter();

//City city = adapter.GetCity();

//Console.WriteLine($"{city.Fullname}, {city.Inhabitants}");

using InjectionObjectAdapter;
IExternalSystem externalSystem = new ExternalSystem();

ICityAdapter cityAdapter = new CityAdapter(externalSystem);

City city = cityAdapter.GetCity();

Console.WriteLine(city.FullName);
Console.WriteLine(city.Inhabitants);