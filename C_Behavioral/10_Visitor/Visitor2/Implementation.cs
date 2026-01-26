namespace Visitor;

//Element
public interface IElement
{
    void Accept(IVisitor visitor);
}

//ConcreteElement
public class Customer : IElement
{
    public string Name { get; private set; }
    public decimal AmountOrdered { get; private set; } //The calculated discount for customers depends on the amount of their orders(10% of final order cost).  
    public decimal Discount { get; set; } //Discount will be set by visitor class, so can't have private set here

    public Customer(string name, decimal amountOrdered)
    {
        Name = name;
        AmountOrdered = amountOrdered;
    }

    public void Accept(IVisitor visitor)
    {
        //visitor.VisitCustomer(this);
        visitor.Visit(this);
        Console.WriteLine($"Visited {nameof(Customer)} name {Name}, discount given {Discount}.");
    }
}

//ConcreteElement
public class Employee : IElement
{
    public string Name { get; private set; }
    public int YearsEmployed { get; private set; } //The calculated discount for Employees depends on the number of years they have been employed.
    public decimal Discount { get; set; }

    public Employee(string name, int yearsEmployed)
    {
        Name = name;
        YearsEmployed = yearsEmployed;
    }

    public void Accept(IVisitor visitor)
    {
        //visitor.VisitEmployee(this);
        visitor.Visit(this);
        Console.WriteLine($"Visited {nameof(Employee)} name {Name}, discount given {Discount}.");
    }
}

//Visitor
public interface IVisitor
{
    void Visit(IElement element);

    //void VisitCustomer(Customer customer);
    //void VisitEmployee(Employee employee);
    ////For now we have just two classes to visit.
}

//ConcreteVisitor
public class DiscountVisitor : IVisitor
{
    public decimal TotalDiscountGiven { get; set; }

    public void Visit(IElement element)
    {
        if (element is Employee)
            VisitEmployee((Employee)element);
        else if (element is Customer)
            VisitCustomer((Customer)element);
    }

    public void VisitCustomer(Customer customer)
    {
        decimal discount = customer.AmountOrdered / 10;
        customer.Discount = discount;

        TotalDiscountGiven += discount;
    }

    public void VisitEmployee(Employee employee)
    {
        decimal discount = employee.YearsEmployed < 10 ? 100 : 200;
        employee.Discount = discount;

        TotalDiscountGiven += discount;
    }
}

//ObjectStructure
public class Container
{
    public List<Employee> Employees { get; set; } = new List<Employee>();
    public List<Customer> customers { get; set; } = new List<Customer>();

    public void Accept(IVisitor visitor)
    {
        foreach (Employee employee in Employees)
        {
            employee.Accept(visitor);
        }
        foreach (Customer customer in customers)
        {
            customer.Accept(visitor);
        }
    }
}