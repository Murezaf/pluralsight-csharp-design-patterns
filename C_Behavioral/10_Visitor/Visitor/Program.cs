using Visitor;

Console.Title = "Visitor";

Container container = new Container();

container.customers.Add(new Customer("Sophie", 500));
container.customers.Add(new Customer("Kevin", 1000));
container.customers.Add(new Customer("Sven", 800));
container.Employees.Add(new Employee("Karen", 18));
container.Employees.Add(new Employee("Tom", 5));

DiscountVisitor visitor = new DiscountVisitor();
container.Accept(visitor);

Console.WriteLine($"Total discounts: {visitor.TotalDiscountGiven}.");