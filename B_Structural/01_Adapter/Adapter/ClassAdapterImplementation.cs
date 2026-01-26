namespace ClassAdapter;

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
public class ExternalSystem
{
    public CityFromExternalSystem GetCity()
    {
        return new CityFromExternalSystem("Tehran", "jfoajf", 500000);
    }
}

//helper
public class City
{
    public string Fullname { get; private set; }
    public long Inhabitants { get; private set; }

    public City(string fullName, long inhabitants)
    {
        Fullname = fullName;
        Inhabitants = inhabitants;
    }
}

//target
public interface ICityAdapter
{
    City GetCity();
}

//They are incompatible now, but we compatible them by implementing the ICityAdapter

//Adapter
public class CityAdapter : ExternalSystem, ICityAdapter
{
    public City GetCity()
    {
        CityFromExternalSystem cityFromExternalSystem = base.GetCity();

        return new City($"{cityFromExternalSystem.Name} - {cityFromExternalSystem.NickName}", cityFromExternalSystem.Inhabitants);
    }
}