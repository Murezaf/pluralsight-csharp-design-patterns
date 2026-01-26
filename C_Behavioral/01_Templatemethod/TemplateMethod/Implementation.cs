namespace TemplateMethod;

//AbstractClass
public abstract class MailParser
{
    public virtual void FindServer() //This method tends to be the same across concrete implementations, but we mark it as virtual just in case there's a MailParser that has a different implementation for it. 
    {
        Console.WriteLine("Finding Server...");
    }

    public abstract void AuthenticateToServer(); //We mark this method abstract cause it will be different in each subclasses and they should implement it on their own. 

    public string ParseHTMLMailBody(string identifier) //This method remains the same across different implementations, so we don't mark it as abstract nor as virtual.
    {
        Console.WriteLine("Parsing HTML mail body...");
        return $"This is the body of mail with id {identifier}";
    }

    //TemplateMethod
    public string ParseMailBody(string identifier) //In this method, we define the algorithm by calling the other methods in order.(Can't change in subclasses)
    {
        Console.WriteLine("Parsing mail body(in a template method)...");
        FindServer();
        AuthenticateToServer();
        return ParseHTMLMailBody(identifier);
    }
}

//ConcreteClass
public class ExchangeMailParser : MailParser
{
    public override void AuthenticateToServer()
    {
        Console.WriteLine("Connecting to Exchange...");
    }
}

//ConcreteClass
public class ApacheMailParser : MailParser
{
    public override void AuthenticateToServer()
    {
        Console.WriteLine("Connecting to Apache...");
    }
}

//ConcreteClass
public class EudoraMailParser : MailParser
{
    public override void FindServer()
    {
        Console.WriteLine("Finding Eudora Server through a custom algorithm...");
    }

    public override void AuthenticateToServer()
    {
        Console.WriteLine("Connecting to Eudora...");
    }
}