using LegecySystemFacade;

Console.Title = "LegacySystemFacade";

ILegacySystem legacySystem = new LegacySystem();

Facade facade = new Facade(legacySystem);

string customerId = "12345";
string orderId = "67890";
string newStatus = "Shipped";

string customerData = facade.GetCustomerDetails(customerId);
Console.WriteLine($"Customer Data: {customerData}");

facade.ProcessOrder(orderId, newStatus);
Console.WriteLine($"Order {orderId} updated to status: {newStatus} via Facade.");

Console.WriteLine("Press any key to exit...");
Console.ReadKey();