using Prototype;
using System.Runtime.InteropServices;

Console.Title = "Prototype";

//ShallowCopy
Manager manager = new Manager("Alex");
Manager clonedManager = (Manager)manager.Clone();
Console.WriteLine("Manager is cloned: " + clonedManager.Name); //We do need to cast this to a manager if we want to use it as a manager. Because the Clone method returns a Person object, the abstract base class.

Employee employee = new Employee("Karl", clonedManager);
Employee clonedEmployee = (Employee)employee.Clone();
Console.WriteLine($"Employee is cloned: {clonedEmployee.Name} with manager {clonedEmployee.Manager.Name}.");

//Change the manager's name
clonedManager.Name = "Bob";

//Lets check ClonedEmployee infos again. manager's name is changed here too! and that's a bit odd.
Console.WriteLine($"Employee is cloned: {clonedEmployee.Name} with manager {clonedEmployee.Manager.Name}.");

Console.WriteLine("========================================================");

//DeepCopy
Manager manager2 = new Manager("Alex");
Manager clonedManager2 = (Manager)manager2.Clone(true);
Console.WriteLine("Manager is cloned: " + clonedManager2.Name);

Employee employee2 = new Employee("Karl", clonedManager2);
Employee clonedEmployee2 = (Employee)employee2.Clone(true);
Console.WriteLine($"Employee is cloned: {clonedEmployee2.Name} with manager {clonedEmployee2.Manager.Name}.");

//Change the manager's name
clonedManager2.Name = "Bob";

Console.WriteLine($"Employee is cloned: {clonedEmployee2.Name} with manager {clonedEmployee2.Manager.Name}.");
//This time we do get back the expected result.
//We changed the manager name after having cloned the employee, yet cloning the employee also cloned the Manager object(deep clone), which means that we see the manager name of the clone and not the changed name we passed through. This is effectively a deep clone or deep copy.

Console.WriteLine(clonedManager2.Name);