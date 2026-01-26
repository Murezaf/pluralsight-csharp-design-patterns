using System.ComponentModel;

namespace Strategy;

//Strategy
public interface IExportService //Can also be implemented with an abstract base class in case you want to provide some out‑of‑the‑box implementation of parts of its functionality.
{
    public void Export(Order order); //In our case, we're mimicking that we need access to all properties of the Order object for exporting.
}

//ConcreteStrategy
public class JsonExportService : IExportService
{
    public void Export(Order order)
    {
        Console.WriteLine($"Exporting {order.Name} to Json.");
    }
}

//ConcreteStrategy
public class XMLExportService : IExportService
{
    public void Export(Order order)
    {
        Console.WriteLine($"Exporting {order.Name} to XML.");
    }
}

//ConcreteStrategy
public class CSVExportService : IExportService
{
    public void Export(Order order)
    {
        Console.WriteLine($"Exporting {order.Name} to CSV.");
    }
}

//Context
public class Order
{
    public string Name { get; set; }
    public string Customer { get; set; }
    public int Amount { get; set; }
    public string? Description { get; set; }
    public IExportService? ExportService { get; set; }

    public Order(string name, string customer, int amount)
    {
        Name = name;
        Customer = customer;
        Amount = amount;

        //There can ba a set to default for ExportService that can be changed too(in Program.cs). Another way is to get the ExportService as a constructor input value. That being said, these days dependencies like this are often injected via an IoC container, which tend to have their own null checks in place.
        //ExportService = new CSVExportService(); 
    }

    public void Export()
    {
        ExportService?.Export(this);
    }

    //public void Export(IExportService exportService)
    //{
    //    if(exportService == null)
    //        throw new ArgumentNullException(nameof(exportService));

    //    exportService.Export(this);
    //}
    //By this implementation there is no need to keep the IExportService property in our class
}