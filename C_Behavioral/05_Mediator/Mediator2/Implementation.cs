namespace Mediator2;
//In this demo, we assume that name properties are unique. Something like Id in a real life scenario.

//Mediator
public interface IChatRoom
{
    void Register(TeamMember teamMember);
    void Send(string from, string message);
    void Send(string from, string to, string message);
    void Send<T>(string from, string message) where T : TeamMember;
}

//Colleague
public abstract class TeamMember
{
    private IChatRoom? _chatroom;
    public string Name { get; set; }

    public TeamMember(string name)
    {
        Name = name;
    }

    internal void SetChatroom(IChatRoom chatroom)
    {
        _chatroom = chatroom;
    }

    public void Send(string message)
    {
        _chatroom?.Send(Name, message);
    }

    public void Send(string to, string message)
    {
        _chatroom?.Send(Name, to, message);
    }

    public void Send<T>(string message) where T : TeamMember
    {
        _chatroom?.Send<T>(Name, message);
    }

    public virtual void Receive(string from, string message)
    {
        Console.WriteLine($"Message from {from} to {Name}: {message}.");
    }
}

//ColleagueConcrete
public class Lawyer : TeamMember
{
    public Lawyer(string name) : base(name)
    {
    }

    public override void Receive(string from, string message)
    {
        Console.WriteLine($"{nameof(Lawyer)} {Name} received:");
        base.Receive(from, message);
    }
}

//ColleagueConcrete
public class AccountManager : TeamMember
{
    public AccountManager(string name) : base(name)
    {
    }

    public override void Receive(string from, string message)
    {
        Console.WriteLine($"{nameof(AccountManager)} {Name} received:");
        base.Receive(from, message);
    }
}

//ConcreteMediator
public class TeamChatRoom : IChatRoom
{
    private readonly Dictionary<string, TeamMember> _members = new Dictionary<string, TeamMember>();

    public void Register(TeamMember teamMember)
    {
        teamMember.SetChatroom(this);
        if (!_members.ContainsKey(teamMember.Name))
        {
            _members.Add(teamMember.Name, teamMember);
        }
    }

    public void Send(string from, string message)
    {
        foreach (TeamMember member in _members.Values)
        {
            member.Receive(from, message);
        }
    }

    public void Send(string from, string to, string message)
    {
        TeamMember member = _members[from];
        member?.Receive(from, message);
    }

    public void Send<T>(string from, string message) where T : TeamMember
    {
        foreach(TeamMember member in _members.Values.OfType<T>())
        {
            member?.Send(from, message);
        }
    }
}
