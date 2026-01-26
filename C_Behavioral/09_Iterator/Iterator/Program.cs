using Iterator;

Console.Title = "Iterator";

PeopleCollection people = new PeopleCollection();
people.Add(new Person("Kevin", "Belgium"));
people.Add(new Person("Ali", "Iran"));
people.Add(new Person("Thomas", "Germany"));
people.Add(new Person("Mohamad", "Iraq"));

IPeopleIterator peopleIterator = people.CreateIterator();
for(Person person = peopleIterator.First(); !peopleIterator.IsDone; person = peopleIterator.Next())
{
    Console.WriteLine(person.Name);
}