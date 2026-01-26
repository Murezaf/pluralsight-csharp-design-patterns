using System.Security;

namespace Iterator;

//HelperClass
public class Person
{
    public string Name { get; set; }
    public string Country { get; set; }

    public Person(string name, string country)
    {
        Name = name;
        Country = country;
    }
}

//Iterator
public interface IPeopleIterator
{
    Person First();
    Person Next();
    bool IsDone {  get; }
    Person CurrentItem {  get; }
}

//Aggregate
public interface IPeopleCollection
{
    IPeopleIterator CreateIterator();
}

//ConcreteAggregate
public class PeopleCollection : List<Person>, IPeopleCollection
{
    public IPeopleIterator CreateIterator()
    {
        return new PeopleIterator(this);
    }
}

//ConcreteIterator
public class PeopleIterator : IPeopleIterator
{
    private PeopleCollection _peopleCollection;
    private int _current = 0;

    public PeopleIterator(PeopleCollection collection)
    {
        _peopleCollection = collection;
    }

    public Person First()
    {
        _current = 0;
        IOrderedEnumerable<Person> orderedPeople = _peopleCollection.OrderBy(p => p.Name);
        return orderedPeople.ToList()[_current];
    }

    public Person Next()
    {
        _current++;
        if (!IsDone)
        {
            return _peopleCollection.OrderBy(p => p.Name).ToList()[_current];
        }
        else
        {
            return null;
        }
    }

    public bool IsDone
    {
        get
        {
            return _current >= _peopleCollection.Count;
        }
    }

    public Person CurrentItem
    {
        get
        {
            return _peopleCollection.OrderBy(p => p.Name).ToList()[_current];
        }
    }
}