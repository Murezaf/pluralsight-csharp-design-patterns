using Builder;

Console.Title = "Builder";

Garage garage = new Garage();

MiniBuilder miniBuilder  = new MiniBuilder();
BMWBuilder bmwBuilder = new BMWBuilder();

garage.Construct(bmwBuilder);
garage.Show();

garage.Construct(miniBuilder);
garage.Show();