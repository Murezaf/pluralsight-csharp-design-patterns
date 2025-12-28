using System.Text;

namespace Builder;

public class Car
{
    private readonly string _carType;
    private readonly List<string> _parts = new List<string>();

    public Car(string carType)
    {
        _carType = carType;
    }

    public void AddPart(string part)
    {
        _parts.Add(part);
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        foreach (string part in _parts)
        {
            stringBuilder.Append($"Car of type {_carType} has part {part}.");
        }

        return stringBuilder.ToString();
    }
}

public abstract class CarBuilder
{
    public Car Car {  get; private set; }

    public CarBuilder(string carType)
    {
        Car = new Car(carType);
    }

    public abstract void BuildEngine();
    public abstract void BuildFrame();
}

public class MiniBuilder : CarBuilder
{
    public MiniBuilder() : base("Mini")
    {
    }

    public override void BuildEngine()
    {
        Car.AddPart("Not a V8");
    }

    public override void BuildFrame()
    {
        Car.AddPart("3 door plastic");
    }
}

public class BMWBuilder : CarBuilder
{
    public BMWBuilder() : base("BMW")
    {
    }

    public override void BuildEngine()
    {
        Car.AddPart("Fancy V8 Engine");
    }

    public override void BuildFrame()
    {
        Car.AddPart("5 door metallic");
    }
}

public class Garage
{
    private CarBuilder _carBuilder;

    public void Construct(CarBuilder carBuilder)
    {
        _carBuilder = carBuilder;

        _carBuilder.BuildEngine();
        _carBuilder.BuildFrame();
    }

    public void Show()
    {
        Console.WriteLine(_carBuilder.Car.ToString());
    }
}
