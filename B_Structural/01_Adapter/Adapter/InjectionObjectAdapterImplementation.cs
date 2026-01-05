namespace InjectionObjectAdapter;

//-------------------------------------------------------------------------------------------
//injection instead of ad hoc newing

//helper
public class CityFromExternalSystem
{
    public string Name { get; private set; }
    public string NickName { get; private set; }
    public int Inhabitants { get; private set; }

    public CityFromExternalSystem(string name, string nickName, int inhabitants)
    {
        Name = name;
        NickName = nickName;
        Inhabitants = inhabitants;
    }
}

//Adaptee
public interface IExternalSystem
{
    CityFromExternalSystem GetCity();
}

public class ExternalSystem : IExternalSystem
{
    public CityFromExternalSystem GetCity()
    {
        return new CityFromExternalSystem("Antwerp", "Stad", 500_000);
    }
}

//helper
public class City
{
    public string FullName { get; private set; }
    public long Inhabitants { get; private set; }

    public City(string fullName, long inhabitants)
    {
        FullName = fullName;
        Inhabitants = inhabitants;
    }
}

//target
public interface ICityAdapter
{
    City GetCity();
}

//Adapter
public class CityAdapter : ICityAdapter
{
    private readonly IExternalSystem _externalSystem;

    public CityAdapter(IExternalSystem externalSystem)
    {
        _externalSystem = externalSystem;
    }

    public City GetCity()
    {
        var externalCity = _externalSystem.GetCity();

        return new City($"{externalCity.Name} - {externalCity.NickName}", externalCity.Inhabitants);  
    }
}