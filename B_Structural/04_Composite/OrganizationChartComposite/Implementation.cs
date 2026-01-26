namespace OrganizationChartComposite;

//Component 
public abstract class OrganizationNode
{
    public string Name { get; }
    public virtual void Report()
    { }

    protected OrganizationNode(string name)
    {
        Name = name;
    }
}

//Leaf
public class Employee : OrganizationNode
{
    private OrganizationNode _parent;

    public Employee(string name, OrganizationNode parent = null) : base(name)
    {
        _parent = parent;
    }

    public override void Report()
    {
        Console.WriteLine($"Employee: {Name}");

        if (_parent != null)
        {
            Console.WriteLine($"  Reports to: {_parent.Name}");
        }
    }
}

//Composite 
public class Department : OrganizationNode
{
    private List<OrganizationNode> _organizations = new List<OrganizationNode>();

    public Department(string name) : base(name)
    { }

    public void Add(OrganizationNode employee)
    {
        _organizations.Add(employee);
    }

    public void Remove(OrganizationNode employee)
    {
        _organizations.Remove(employee);
    }

    public override void Report()
    {
        Console.WriteLine($"Department: {Name}");
        foreach (OrganizationNode organization in _organizations)
        {
            organization.Report();
        }
    }
}