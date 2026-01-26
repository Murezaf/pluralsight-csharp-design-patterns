using System.Runtime.Intrinsics.X86;
using System.Text.Json;

namespace Prototype;

//Prototype
public abstract class Person
{
    public string Name { get; set; }
    //public abstract Person Clone();
    
    public abstract Person Clone(bool deepClone);
}

//ConcretePrototype
public class Manager : Person
{
    public Manager(string name)
    { 
        Name = name;
    }

    //We need to implement the Clone method. We could implement this by newing up a Person and manually copying over all the fields,
    //but there's an easier, built‑in way to do this by calling into MemberwiseClone.
    //public override Person Clone()
    //{
    //    return (Person)this.MemberwiseClone(); //This is a method that's defined on object, so every instance you use in C#, has access to this. It creates a shallow copy of the existing object.
    //}

    public override Person Clone(bool deepClone = false)
    {
        if(deepClone)
        {
            string objectAsJson = JsonSerializer.Serialize(this);
            return JsonSerializer.Deserialize<Manager>(objectAsJson);
        }

        return (Person)this.MemberwiseClone(); //This is a method that's defined on object, so every instance you use in C#, has access to this. It creates a shallow copy of the existing object.
    }
}

//ConcretePrototype
public class Employee : Person
{
    public Manager Manager { get; set; }
    
    public Employee(string name, Manager manager)
    {
        Name = name;
        Manager = manager;
    }

    //public override Person Clone()
    //{
    //    return (Person)this.MemberwiseClone(); 
    //}

    public override Person Clone(bool deepClone = false)
    {
        if(deepClone)
        {
            var objectAsJson = JsonSerializer.Serialize(this);
            return JsonSerializer.Deserialize<Employee>(objectAsJson);
        }

        return (Person)this.MemberwiseClone();
    }
}