using OrganizationChartComposite;

Console.Title = "OrganizationChartComposite";

Department HR = new Department("HumanResource");
Employee HRmanager = new Employee("Bob");
Employee HRemployee1 = new Employee("Carl", HRmanager);
Employee HRemployee2 = new Employee("Mark", HRmanager);
HR.Add(HRmanager);
HR.Add(HRemployee1);
HR.Add(HRemployee2);

Department programming = new Department("Programming");
Employee programmingManager = new Employee("Mike");
Employee programmingDepartmentEmployee = new Employee("Roberto", programmingManager);
Department backend = new Department("Backend");
Employee backendManager = new Employee("Rose");
Employee Developer1 = new Employee("Ronald", backendManager);
Employee Developer2 = new Employee("Ravi", backendManager);
Employee JuniorDeveloper = new Employee("Sara", Developer1);
programming.Add(programmingManager);
programming.Add(programmingDepartmentEmployee);
programming.Add(backend);
backend.Add(backendManager);
backend.Add(Developer1);
backend.Add(Developer2);
backend.Add(JuniorDeveloper);

HR.Report();
Console.WriteLine();
programming.Report();
