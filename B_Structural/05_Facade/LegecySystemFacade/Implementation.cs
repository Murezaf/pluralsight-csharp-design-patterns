namespace LegecySystemFacade;

//SubsystemClasses
public interface ILegacySystem
{
    string GetCustomerData(string customerId);
    void UpdateOrder(string orderId, string status);
}

public class LegacySystem : ILegacySystem
{
    public string GetCustomerData(string customerId)
    {
        //Complex logic to fetch customer data from the legacy system(lots of database queries, etc.)
        return $"Customer data for {customerId} from Legacy";
    }

    public void UpdateOrder(string orderId, string status)
    {
        //Complex logic to update order status in the legacy system(more database operations, validation, etc.)
        Console.WriteLine($"Updating order {orderId} in Legacy to status: {status}");
    }
}

//Facade
public class Facade
{
    private readonly ILegacySystem _legacySystem;

    public Facade(ILegacySystem legacySystem)
    {
        _legacySystem = legacySystem;
    }

    public string GetCustomerDetails(string customerId)
    {
        return _legacySystem.GetCustomerData(customerId);
    }

    public void ProcessOrder(string orderId, string newStatus)
    {
        _legacySystem.UpdateOrder(orderId, newStatus);
    }
}

//Client
public class NewSystem
{
    public void PerformTask(string customerId, string orderId, string newStatus)
    {
        Facade facade = new Facade(new LegacySystem());
        string customerData = facade.GetCustomerDetails(customerId);
        facade.ProcessOrder(orderId, newStatus);
        Console.WriteLine($"Task completed using Legacy System via Facade.");
    }
}