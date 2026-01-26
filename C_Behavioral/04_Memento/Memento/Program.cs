using Memento;

Console.Title = "Memento";

CommandManager commandManager = new CommandManager();
IEmployeeManagerRepository employeeManagerRepository = new EmployeeManagerRepository();

commandManager.Invoke(new AddEmployeeToManagerList(employeeManagerRepository, 1, new Employee(111, "Kevin")));
employeeManagerRepository.WriteDataStore();

commandManager.Undo();
employeeManagerRepository.WriteDataStore();

commandManager.Invoke(new AddEmployeeToManagerList(employeeManagerRepository, 1, new Employee(222, "Clara")));
employeeManagerRepository.WriteDataStore();

commandManager.Invoke(new AddEmployeeToManagerList(employeeManagerRepository, 2, new Employee(333, "Tom")));
employeeManagerRepository.WriteDataStore();

//Try adding the same employee again => nothing should change compare to last one
commandManager.Invoke(new AddEmployeeToManagerList(employeeManagerRepository, 2, new Employee(333, "Tom")));
employeeManagerRepository.WriteDataStore();

commandManager.UndoAll();
employeeManagerRepository.WriteDataStore();