namespace Memento;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Employee(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

public class Manger : Employee
{
    public List<Employee> employees = new List<Employee>();
    public Manger(int id, string name) : base(id, name)
    {
    }
}

//Receiver(interface)
public interface IEmployeeManagerRepository
{
    void AddEmployee(int managerId, Employee employee);
    void RemoveEmployee(int managerId, Employee employee);
    bool HasTheEmployee(int managerId, Employee employee);
    void WriteDataStore();
}

//Receiver(Implementation)
public class EmployeeManagerRepository : IEmployeeManagerRepository
{
    //For demo purposes, we are using an in-memory datastore. In a real‑life scenario, it would probably be better to persist this to a database somewhere. But for the pattern implementation, that is not important.
    private readonly List<Manger> _managers = new List<Manger>() { new Manger(1, "Katie"), new Manger(2, "Geoff") };

    //Add additional check in a real life scenario in each method
    public void AddEmployee(int managerId, Employee employee)
    {
        _managers.First(m => m.Id == managerId).employees.Add(employee);
    }

    public bool HasTheEmployee(int managerId, Employee employee)
    {
        return _managers.First(m => m.Id == managerId).employees.Any(e => e.Id == employee.Id);
    }

    public void RemoveEmployee(int managerId, Employee employee)
    {
        _managers.First(m => m.Id == managerId).employees.Remove(employee);
    }

    public void WriteDataStore()
    {
        foreach (Manger manager in _managers)
        {
            Console.WriteLine($"Manager {manager.Id}, {manager.Name}");

            if (manager.employees.Any())
            {
                foreach (Employee employee in manager.employees)
                {
                    Console.WriteLine($"\t Employee {employee.Id}, {employee.Name}");
                }
            }
            else
            {
                Console.WriteLine("\t No employees.");
            }
        }
    }
}

//Memento
public class AddEmployeeToManagerListMemento
{
    public int ManagerId { get; private set; }
    public Employee? Employee { get; private set; }
    /* We give these properties private setters. Like that, the caretaker will not be able to modify the memento.
    That also means we can only set them via the constructor.*/

    public AddEmployeeToManagerListMemento(int managerId, Employee? employee)
    {
        ManagerId = managerId;
        Employee = employee;
    }
}

//Command
public interface ICommand
{
    bool CanExecute();
    void Execute();

    void Undo();
}

//ConcreteCommand(Originator)
public class AddEmployeeToManagerList : ICommand
{
    private readonly IEmployeeManagerRepository _employeeManagerRepository;
    private int _managerId;
    private Employee _employee;

    public AddEmployeeToManagerList(IEmployeeManagerRepository employeeManagerRepository, int managerId, Employee employee)
    {
        _employeeManagerRepository = employeeManagerRepository;
        _managerId = managerId;
        _employee = employee;
    }

    public AddEmployeeToManagerListMemento CreateMemento()
    {
        return new AddEmployeeToManagerListMemento(_managerId, _employee);
    }

    public void RestoreMemento(AddEmployeeToManagerListMemento memento)
    {
        _employee = memento.Employee;
        _managerId = memento.ManagerId;
        //_employee and _managerId can't be readonly anymore, we should be able to change them outside the constructor
    }

    public bool CanExecute()
    {
        if (_employee == null)
            return false;

        //Employee shouldn't be on the manager's list already
        if (_employeeManagerRepository.HasTheEmployee(_managerId, _employee))
            return false;

        //additional checks can be here too like: the manager with this Id exist or not, the fact that each employee can be in only one manager's list and so on

        return true;
    }

    public void Execute()
    {
        _employeeManagerRepository.AddEmployee(_managerId, _employee);
    }

    public void Undo()
    {
        _employeeManagerRepository.RemoveEmployee(_managerId, _employee);
    }
}

/*We need something to invoke requests. The command can be invoked by user clicking a button in a user interface. So, the Invoker could be that button. 
But we haven't got a user interface, we're building a console app.
So what we do is, adding a small Manager class: CommandManager, which is responsible for effectively invoking commands.*/
//Invoker(Carataker)
public class CommandManager
{
    private readonly Stack<AddEmployeeToManagerListMemento> _mementos = new Stack<AddEmployeeToManagerListMemento>();
    private AddEmployeeToManagerList? _command;

    public void Invoke(ICommand command)
    {
        if (_command == null)
        {
            _command = (AddEmployeeToManagerList)command;
        }

        if (command.CanExecute())
        {
            command.Execute();
            _mementos.Push(((AddEmployeeToManagerList)command).CreateMemento()); //ICommand doesn't have CreateMemento necessarily.
        }
    }

    public void Undo()
    {
        if(_mementos.Any())
        {
            _command?.RestoreMemento(_mementos.Pop());
            _command?.Undo();
        }
    }

    public void UndoAll()
    {
        while (_mementos.Any())
        {
            _command?.RestoreMemento(_mementos.Pop());
            _command?.Undo();
        }
    }
}